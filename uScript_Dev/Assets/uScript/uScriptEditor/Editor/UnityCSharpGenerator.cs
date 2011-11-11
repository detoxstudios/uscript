using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace Detox.ScriptEditor
{
   //how it works with CSharp:
   //each node has inputs, the calling node (the one with the output linked to the input)
   //is responsible for setting that node's input before it calls it
   //the node's input is represented by a variable name which includes that node's id and the input's name
   //having nodes set the input of the next node before it calls it has the effect of trickling down
   //all the correct, and latest values, to that node directly before it is executed
   public class UnityCSharpGenerator
   {
      private const int MaxRelayCallCount = 1000;

      public Parameter []ExternalParameters { get { return m_ExternalParameters.ToArray( ); } }
      public Plug      []ExternalInputs     { get { return m_ExternalInputs.ToArray( ); } }
      public Plug      []ExternalOutputs    { get { return m_ExternalOutputs.ToArray( ); } }
      public Plug      []ExternalEvents     { get { return m_ExternalEvents.ToArray( ); } }
      public string    []Drivens            { get { return m_Drivens.ToArray( ); } }
      public string    []RequiredMethods    { get { return m_RequiredMethods.ToArray( ); } }

      private string       m_CSharpString;
      private bool         m_GenerateDebugInfo;
      private int          m_TabStack;
      private Hashtable    m_GuidToId = new Hashtable( );
      private ScriptEditor m_Script = null;

      List<Parameter> m_ExternalParameters = new List<Parameter>( );
      List<Plug>      m_ExternalInputs     = new List<Plug>( );
      List<Plug>      m_ExternalOutputs    = new List<Plug>( );
      List<Plug>      m_ExternalEvents     = new List<Plug>( );
      List<string>    m_Drivens            = new List<string>( );
      List<string>    m_RequiredMethods    = new List<string>( );

      private void Preprocess( )
      {  
         CreateGuidIndices( );
         CreateGlobalVariables( );
         CreateBidirectionalLinks( );
         PruneUnusedNodes( );
         RemoveOverriddenInstances( );
         ConslidateExternals( );
      }

      //setup all the guids now so 
      //indices are not node order dependent
      private void CreateGuidIndices( )
      {
         foreach ( EntityNode node in m_Script.EntityNodes )
         {
            GetGuidId( node.Guid );
         }
      }

      //short cut method to figure out just the external links/parameters
      //without needing to parse th entire script
      public void ParseExternals( ScriptEditor script )
      {
         m_GenerateDebugInfo = false;
         m_CSharpString = "";
         m_TabStack = 0;

         m_Script = null;

         m_ExternalParameters = new List<Parameter>( );
         m_ExternalInputs     = new List<Plug>( );
         m_ExternalOutputs    = new List<Plug>( );
         m_ExternalEvents     = new List<Plug>( );
         m_Drivens            = new List<string>( );
         m_RequiredMethods    = new List<string>( );

         if ( null != script )
         {
            m_Script = script.Copy( );

            Preprocess( );

            foreach ( ExternalConnection external in m_Script.Externals )
            {
               DefineExternalInput( external );
            }

            Plug []properties = FindExternalOutputProperties( );

            for ( int i = 0; i < properties.Length; i++ )
            {
               m_ExternalOutputs.Add( properties[i] );
            }
            
            Plug []events = FindExternalEvents( );

            if ( events.Length > 0 )
            {
               foreach ( Plug eventPlug in events )
               {
                  m_ExternalEvents.Add( eventPlug );
               }
            }

            DefineExternalDrivens( );

            m_RequiredMethods.Add("Start");
            m_RequiredMethods.Add("Update");

            if ( true == NeedsMethod("LateUpdate") )
            {
               m_RequiredMethods.Add("LateUpdate");
            }

            if ( true == NeedsMethod("FixedUpdate") )
            {
               m_RequiredMethods.Add("FixedUpdate");
            }
         }
      }

      private void CreateBidirectionalLinks( )
      {
         List<LinkNode> newLinks = new List<LinkNode>( );

         //go through all connections and make duplicate links going the other way
         //if they can be bi-directional
         foreach ( LinkNode link in m_Script.Links )
         {
            EntityNode source = m_Script.GetNode( link.Source.Guid );
            EntityNode dest   = m_Script.GetNode( link.Destination.Guid );

            Parameter sourceParam = Parameter.Empty, destParam = Parameter.Empty;

            foreach ( Parameter p in source.Parameters )
            {
               if ( p.Name == link.Source.Anchor )
               {
                  sourceParam = p;
                  break;
               }
            }

            foreach ( Parameter p in dest.Parameters )
            {
               if ( p.Name == link.Destination.Anchor )
               {
                  destParam = p;
                  break;
               }
            }

            bool cloneLink = false;

            if ( sourceParam != Parameter.Empty && destParam != Parameter.Empty )
            {
               if ( sourceParam.Input == true &&
                    destParam.Output  == true )
               {
                  cloneLink = true;
               }
            }
            else
            {
               if ( source is ExternalConnection && destParam != Parameter.Empty )
               {
                  if ( destParam.Output == true )
                  {
                     cloneLink = true;
                  }
               }
               else if ( dest is ExternalConnection && sourceParam != Parameter.Empty )
               {
                  if ( sourceParam.Input == true )
                  {
                     cloneLink = true;
                  }
               }
            }

            if ( true == cloneLink )
            {
               LinkNode clone    = link;
               clone.Guid        = Guid.NewGuid( );
               clone.Source      = link.Destination;
               clone.Destination = link.Source;

               LinkNode outNode;
               if ( false == FindLink(clone.Source.Guid, clone.Source.Anchor, clone.Destination.Guid, clone.Destination.Anchor, out outNode) )
               {
                  newLinks.Add( clone );
               }
            }
         }

         foreach ( LinkNode link in newLinks )
         {
            m_Script.AddNode( link );
         }
      }

      private void ConslidateExternals( )
      {
         ExternalConnection []externals = m_Script.Externals;
         Hashtable unique = new Hashtable( );

         //build lists, keyed by external name
         //so we can consolidate all the links to the same external
         foreach ( ExternalConnection external in externals )
         {
            if ( null == unique[external.Name.Default] )
            {
               unique[ external.Name.Default ] = new List<ExternalConnection>( );
            }

            List<ExternalConnection> list = unique[ external.Name.Default ] as List<ExternalConnection>;
            list.Add( external );
         }

         //for each external list...
         foreach ( object o in unique.Values )
         {
            List<ExternalConnection> list = o as List<ExternalConnection>;

            //the first one in the list is where we will consolidate
            ExternalConnection external = list[ 0 ];

            //every subsequent one, replace the links with the links to the consolidated one
            //and then remove the subsequent one (which will also remove its links)
            for ( int i = 1; i < list.Count; i++ )
            {
               ExternalConnection e = list[ i ];

               LinkNode [] sources = FindLinksBySource( e.Guid, e.Connection );         
               LinkNode [] dests   = FindLinksByDestination( e.Guid, e.Connection );   

               m_Script.RemoveNode( e );

               foreach ( LinkNode source in sources )
               {
                  LinkNode clone = source;
                  clone.Source.Guid = external.Guid;

                  m_Script.AddNode( clone );
               }
 
               foreach ( LinkNode dest in dests )
               {
                  LinkNode clone = dest;
                  clone.Destination.Guid = external.Guid;

                  m_Script.AddNode( clone );
               }
            }
         }
      }

      private void CreateGlobalVariables( )
      {
         //find any local variables which have no name
         //and give them their unique id as the name
         //this way they are individual instances
         LocalNode [] locals = m_Script.UniqueLocals;

         foreach ( LocalNode local in locals )
         {
            if ( "" == local.Name.Default )
            {
               LocalNode unique = new LocalNode( "" + GetGuidId(local.Guid), local.Value.Type, local.Value.Default );
               unique.Guid = local.Guid;

               //replace existing local
               m_Script.AddNode( unique );
            }
         }
      }

      private void PruneUnusedNodes( )
      {         
         //first prune out any nodes which don't have valid instances
         foreach ( EntityNode entityNode in m_Script.EntityNodes )
         {
            //if it doesn't need an instance, don't worry about finding one
            if ( false == entityNode is EntityProperty &&
                 false == entityNode is EntityEvent &&
                 false == entityNode is EntityMethod ) continue;


            //an instance set in the property grid?
            if ( entityNode.Instance.Default != "" ) continue;

            //include static nodes which don't need an instance
            if ( true == entityNode.IsStatic ) continue;

            bool includeNode = false;

            //how about an instance linked to it?
            LinkNode []instanceLinks = FindLinksByDestination( entityNode.Guid, entityNode.Instance.Name );
            
            foreach ( LinkNode link in instanceLinks )
            {
               EntityNode node = m_Script.GetNode( link.Source.Guid );
               
               if ( node is LocalNode )
               {
                  if ( ((LocalNode)node).Instance.Default != "" )
                  {
                     includeNode = true;
                     break;
                  }
               }
               else if ( node is OwnerConnection || node is ExternalConnection )
               {
                  includeNode = true;
               }
            }

            if ( false == includeNode )
            {
               instanceLinks = FindLinksBySource( entityNode.Guid, entityNode.Instance.Name );
            
               foreach ( LinkNode link in instanceLinks )
               {
                  LocalNode node = (LocalNode) m_Script.GetNode( link.Destination.Guid );

                  if ( node.Instance.Default != "" )
                  {
                     includeNode = true;
                     break;
                  }
               }
            }

            //no valid instance, so remove it
            if ( false == includeNode )
            {
               string name = uScriptConfig.Variable.FriendlyName( entityNode.Instance.Type );

               uScriptDebug.Log( "Node " + name + " is being pruned because there is no GameObject instance assigned to it", uScriptDebug.Type.Debug );
               m_Script.RemoveNode( entityNode );
            }
         }



         //now that we have removed all the nodes
         //which don't have valid instances assigned
         //track all the nodes which have links to them
         //and remove everything else

         //track all the link source / destination nodes
         Hashtable usedNodes = new Hashtable( );

         foreach ( LinkNode link in m_Script.Links )
         {
            usedNodes[ link.Source.Guid ] = true;
            usedNodes[ link.Destination.Guid ] = true;
            usedNodes[ link.Guid ] = true;
         }

         //prune any nodes which aren't linked
         foreach ( EntityNode entityNode in m_Script.EntityNodes )
         {
            if ( false == usedNodes.Contains(entityNode.Guid) )
            {
               m_Script.RemoveNode( entityNode );
            }
         }
      }

      private void RemoveOverriddenInstances( )
      {
         //first prune out any nodes which don't have valid instances
         EntityNode []nodes = m_Script.EntityNodes;

         foreach ( EntityNode entityNode in nodes )
         {
            //if it doesn't need an instance, don't worry about finding one
            if ( false == entityNode is EntityProperty &&
                 false == entityNode is EntityEvent &&
                 false == entityNode is EntityMethod ) continue;


            //no instance? then don't worry about it
            if ( entityNode.Instance.Default == "" ) continue;

            //how about an instance linked to it?
            LinkNode []instanceLinks = FindLinksByDestination( entityNode.Guid, entityNode.Instance.Name );
            
            if ( instanceLinks.Length > 0 )
            {
               Parameter p = entityNode.Instance;
               p.Default = "";
               entityNode.Instance = p;
               m_Script.AddNode( entityNode );
            }
         }
      }


      private bool FindLink(Guid sourceGuid, string sourceAnchor, Guid destGuid, string destAnchor, out LinkNode outNode)
      {
         foreach ( LinkNode link in m_Script.Links )
         {
            if ( link.Source.Guid        == sourceGuid   &&
                 link.Source.Anchor      == sourceAnchor &&
                 link.Destination.Guid   == destGuid     &&
                 link.Destination.Anchor == destAnchor )
            {
               outNode = link;
               return true;
            }
         }

         outNode = new LinkNode( );
         return false;
      }

      public string GenerateGameObjectScript(string logicClassName, ScriptEditor script)
      {
         m_GenerateDebugInfo = false;
         m_CSharpString = "";
         m_TabStack = 0;

         m_Script = null;

         if ( null != script )
         {
            m_Script = script.Copy( );

            DeclareNamespaces( );
            AddCSharpLine( "" );

            AddCSharpLine( "[AddComponentMenu(\"uScript/Graphs/" + logicClassName + "\")]" );
            AddCSharpLine( "public class " + System.IO.Path.GetFileNameWithoutExtension(script.Name) + uScriptConfig.Files.GeneratedComponentExtension + " : uScriptCode" );
            AddCSharpLine( "{" );
            ++m_TabStack;

               AddCSharpLine( "#pragma warning disable 414" );
               AddCSharpLine( logicClassName + " uScript; ");
               AddCSharpLine( "#pragma warning restore 414" );
            
               AddCSharpLine( "" );

               AddCSharpLine( "void Awake( )" );
               AddCSharpLine( "{" );
               ++m_TabStack;

                  AddCSharpLine( "useGUILayout = " + (NeedsGuiLayout( ) ? "true;" : "false;") );

                  AddCSharpLine( "uScript = ScriptableObject.CreateInstance(typeof(" + logicClassName + ")) as " + logicClassName + ";" );
                  AddCSharpLine( "uScript.SetParent( this.gameObject );" );

               --m_TabStack;
               AddCSharpLine( "}" );
            
               {
                  AddCSharpLine( "void Start( )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;
               
                     AddCSharpLine( "uScript.Start( );" );
               
                  --m_TabStack;
                  AddCSharpLine( "}" );
               }

               //always do update because the unity hooks
               //and drivens are valdiated there
               {
                  AddCSharpLine( "void Update( )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;
               
                     AddCSharpLine( "uScript.Update( );" );
               
                  --m_TabStack;
                  AddCSharpLine( "}" );
               }

               if ( true == NeedsMethod("LateUpdate") )
               {
                  AddCSharpLine( "void LateUpdate( )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;
               
                     AddCSharpLine( "uScript.LateUpdate( );" );
               
                  --m_TabStack;
                  AddCSharpLine( "}" );
               }

               if ( true == NeedsMethod("FixedUpdate") )
               {
                  AddCSharpLine( "void FixedUpdate( )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;
               
                     AddCSharpLine( "uScript.FixedUpdate( );" );
               
                  --m_TabStack;
                  AddCSharpLine( "}" );
               }

               if ( true == NeedsMethod("OnGUI") )
               {
                  AddCSharpLine( "void OnGUI( )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;
               
                     AddCSharpLine( "uScript.OnGUI( );" );
               
                  --m_TabStack;
                  AddCSharpLine( "}" );
               }

               AddCSharpLine( "#if UNITY_EDITOR" );
               ++m_TabStack;

                  AddCSharpLine( "void OnDrawGizmos( )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;
               
                     DefineDrawGizmos( );
               
                  --m_TabStack;
                  AddCSharpLine( "}" );

               --m_TabStack;
               AddCSharpLine( "#endif" );

            --m_TabStack;
            AddCSharpLine( "}" );
         }

         return m_CSharpString;
      }

      private bool NeedsMethod(EntityNode node, string methodName)
      {
         string s = ScriptEditor.FindNodeType(node);         
         if ( "" == s ) return false;

         Type t = uScript.MasterComponent.GetType(s);

         //nested script which isn't reflected yet 
         //(maybe the code hasn't been generated)
         if ( null == t && node is LogicNode )
         {
            LogicNode logic = (LogicNode) node;

            foreach ( string m in logic.RequiredMethods )
            {
               if ( m == methodName ) return true;
            }
         }
         else
         {
            if ( null != t.GetMethod(methodName) ) 
            {
               return true;
            }
         }

         return false;
      }

      private bool NeedsMethod(string methodName)
      {
         foreach ( EntityNode node in m_Script.EntityNodes )
         {
            if ( true == NeedsMethod(node, methodName) ) return true;
         }

         return false;
      }

      private bool NeedsGuiLayout( )
      {
         foreach ( EntityNode node in m_Script.EntityNodes )
         {
            if ( true == uScript.NodeNeedsGuiLayout(ScriptEditor.FindNodeType(node)) ) return true;
         }

         return false;
      }

      public string GenerateLogicScript(string logicClassName, ScriptEditor script, bool generateDebugInfo)
      {
         m_CSharpString = "";
         m_TabStack = 0;

         m_Script = null;
         m_GenerateDebugInfo = generateDebugInfo;

         m_ExternalParameters = new List<Parameter>( );
         m_ExternalInputs     = new List<Plug>( );
         m_ExternalOutputs    = new List<Plug>( );
         m_ExternalEvents     = new List<Plug>( );
         m_Drivens            = new List<string>( );
         m_RequiredMethods    = new List<string>( );

         if ( null != script )
         {
            m_Script = script.Copy( );

            Preprocess( );

            DeclareNamespaces( );
            AddCSharpLine( "" );

            AddCSharpLine( "[NodePath(\"Graphs\")]" );
            BeginLogicClass( logicClassName );
            AddCSharpLine( "" );

            ++m_TabStack;
               DeclareMemberVariables( );
               AddCSharpLine( "" );

               SetupProperties( );
               AddCSharpLine( "" );
               DefineSyncUnityHooks( );
               AddCSharpLine( "" );
               DefineSyncEventListeners( );
               AddCSharpLine( "" );
               
               AddCSharpLine( "public override void SetParent(GameObject g)" );
               AddCSharpLine( "{" );
               ++m_TabStack;
                  DefineSetParent( );
               --m_TabStack;
               AddCSharpLine( "}" );

               AddCSharpLine( "public void Awake()" );
               AddCSharpLine( "{" );

               ++m_TabStack;
                  DefineAwakeInitialization( );
               --m_TabStack;

               AddCSharpLine( "}" );
               AddCSharpLine( "" );
               
               {
                  if ( false == m_RequiredMethods.Contains("Start") ) m_RequiredMethods.Add("Start");

                  AddCSharpLine( "public void Start()" );
                  AddCSharpLine( "{" );

                  ++m_TabStack;
                     DefineStartInitialization( );
                  --m_TabStack;

                  AddCSharpLine( "}" );
                  AddCSharpLine( "" );
               }

               //always do fixed update because this is where we sync our unity hooks
               {
                  if ( false == m_RequiredMethods.Contains("Update") ) m_RequiredMethods.Add("Update");

                  AddCSharpLine( "public void Update()" );
                  AddCSharpLine( "{" );

                  ++m_TabStack;
                     DefineUpdate( );
                  --m_TabStack;

                  AddCSharpLine( "}" );
                  AddCSharpLine( "" );
               }

               if ( true == NeedsMethod("LateUpdate") )
               {
                  if ( false == m_RequiredMethods.Contains("LateUpdate") ) m_RequiredMethods.Add("LateUpdate");

                  AddCSharpLine( "public void LateUpdate()" );
                  AddCSharpLine( "{" );

                  ++m_TabStack;
                     DefineLateUpdate( );
                  --m_TabStack;

                  AddCSharpLine( "}" );
                  AddCSharpLine( "" );
               }

               if ( true == NeedsMethod("FixedUpdate") )
               {
                  if ( false == m_RequiredMethods.Contains("FixedUpdate") ) m_RequiredMethods.Add("FixedUpdate");

                  AddCSharpLine( "public void FixedUpdate()" );
                  AddCSharpLine( "{" );

                  ++m_TabStack;
                     DefineFixedUpdate( );
                  --m_TabStack;

                  AddCSharpLine( "}" );
                  AddCSharpLine( "" );
               }

               if ( true == NeedsMethod("OnGUI") )
               {
                  if ( false == m_RequiredMethods.Contains("OnGUI") ) m_RequiredMethods.Add("OnGUI");

                  AddCSharpLine( "public void OnGUI()" );
                  AddCSharpLine( "{" );

                  ++m_TabStack;
                     DefineOnGUI( );
                  --m_TabStack;

                  AddCSharpLine( "}" );
                  AddCSharpLine( "" );
               }

               DefineEvents( );
            --m_TabStack;
            
            EndClass( );
         }

         return m_CSharpString;
      }  
 
      private void DeclareNamespaces( )
      {
         AddCSharpLine( "//uScript Generated Code - Build " + uScript.Instance.BuildNumber );
         if ( true == m_GenerateDebugInfo )
         {
            AddCSharpLine( "//Generated with Debug Info" );
         }

         AddCSharpLine( "using UnityEngine;" );
         AddCSharpLine( "using System.Collections;" );
      }

      private void BeginLogicClass(string logicClassName)
      {
         AddCSharpLine( "public class " + logicClassName + " : uScriptLogic" );
         AddCSharpLine( "{" );
      }

      private void EndClass( )
      {
         AddCSharpLine( "}" );
      }

      //these are property get and set functions for the entity
      //
      //Set:
      //as per the 'how it works' comment, our input node variable will be set
      //and then a PropertySet function is called which sends that variable
      //to the entity's properties
      //
      //Get:
      //a PropertyGet function is called to refresh a CSharp variable with
      //the latest entity property value
      private void SetupProperties( )
      {
         AddCSharpLine( "//functions to refresh properties from entities" );

         foreach ( EntityProperty entityProperty in m_Script.Properties )
         {
            if ( false == entityProperty.IsStatic )
            {
               if ( entityProperty.Instance.Default != "" )
               {
                  if ( true == entityProperty.Parameter.Output )
                  {
                     //as stated above, cretae a function which 
                     //gets the property from the entity and sets the corresponding CSharp variable
                     AddCSharpLine( FormatType(entityProperty.Parameter.Type) + " " + CSharpRefreshGetPropertyDeclaration(entityProperty) + "( )");
                     AddCSharpLine( "{" );
                     ++m_TabStack;
                        AddCSharpLine( entityProperty.ComponentType + " component = " + CSharpName(entityProperty, entityProperty.Instance.Name) + ".GetComponent<" + entityProperty.ComponentType + ">();" );
                        AddCSharpLine( "if ( null != component )" );
                        AddCSharpLine( "{" );
                        ++m_TabStack;
                              AddCSharpLine( "return component." + entityProperty.Parameter.Name + ";" );
                        --m_TabStack;
                        AddCSharpLine( "}" );
                        AddCSharpLine( "else" );
                        AddCSharpLine( "{" );
                        ++m_TabStack;
                              AddCSharpLine( "return " + FormatValue(entityProperty.Parameter.Default, entityProperty.Parameter.Type) + ";" );
                        --m_TabStack;
                        AddCSharpLine( "}" );
                     --m_TabStack;
                     AddCSharpLine( "}" );
                     AddCSharpLine( "" );
                  }

                  if ( true == entityProperty.Parameter.Input )
                  {
                     //as stated above, create a function which sets the entity's property to the
                     //corresponding CSharp variable's value
                     AddCSharpLine( "void " + CSharpRefreshSetPropertyDeclaration( entityProperty ) + "( )" );
                     AddCSharpLine( "{" );
                     ++m_TabStack;
                        AddCSharpLine( entityProperty.ComponentType + " component = " + CSharpName(entityProperty, entityProperty.Instance.Name) + ".GetComponent<" + entityProperty.ComponentType + ">();" );
                        AddCSharpLine( "if ( null != component )" );
                        AddCSharpLine( "{" );
                        ++m_TabStack;
                           AddCSharpLine( "component." + entityProperty.Parameter.Name + " = " + CSharpName(entityProperty, entityProperty.Parameter.Name) + ";" );               
                        --m_TabStack;
                        AddCSharpLine( "}" );
                     --m_TabStack;
                     AddCSharpLine( "}" );
                     AddCSharpLine( "" );
                  }
               }
               else
               {
                  //only one instance allowed because we have no way to return multiple values (if > 1 instances were hooked up, who's would we return on get?)
                  LinkNode []instanceLinks = FindLinksByDestination( entityProperty.Guid, entityProperty.Instance.Name );

                  foreach ( LinkNode instanceLink in instanceLinks )
                  {
                     EntityNode entityNode = m_Script.GetNode( instanceLink.Source.Guid );

                     if ( true == entityProperty.Parameter.Output )
                     {
                        //as stated above, cretae a function which 
                        //gets the property from the entity and sets the corresponding CSharp variable
                        AddCSharpLine( FormatType(entityProperty.Parameter.Type) + " " + CSharpRefreshGetPropertyDeclaration(entityProperty) + "( )");
                        AddCSharpLine( "{" );
                        ++m_TabStack;
                           AddCSharpLine( entityProperty.ComponentType + " component = " + CSharpName(entityNode) + ".GetComponent<" + entityProperty.ComponentType + ">();" );
                           AddCSharpLine( "if ( null != component )" );
                           AddCSharpLine( "{" );
                           ++m_TabStack;
                                 AddCSharpLine( "return component." + entityProperty.Parameter.Name + ";" );
                           --m_TabStack;
                           AddCSharpLine( "}" );
                           AddCSharpLine( "else" );
                           AddCSharpLine( "{" );
                           ++m_TabStack;
                                 AddCSharpLine( "return " + FormatValue(entityProperty.Parameter.Default, entityProperty.Parameter.Type) + ";" );
                           --m_TabStack;
                           AddCSharpLine( "}" );
                        AddCSharpLine( "}" );
                        AddCSharpLine( "" );
                     }

                     if ( true == entityProperty.Parameter.Input )
                     {
                        //as stated above, create a function which sets the entity's property to the
                        //corresponding CSharp variable's value
                        AddCSharpLine( "void " + CSharpRefreshSetPropertyDeclaration(entityProperty) + "( )" );
                        AddCSharpLine( "{" );
                        ++m_TabStack;
                           AddCSharpLine( entityProperty.ComponentType + " component = " + CSharpName(entityNode) + ".GetComponent<" + entityProperty.ComponentType + ">();" );
                           AddCSharpLine( "if ( null != component )" );
                           AddCSharpLine( "{" );
                           ++m_TabStack;
                              AddCSharpLine( "component." + entityProperty.Parameter.Name + " = " + CSharpName(entityProperty, entityProperty.Parameter.Name) + ";" );               
                           --m_TabStack;
                           AddCSharpLine( "}" );
                        --m_TabStack;
                        AddCSharpLine( "}" );               
                        AddCSharpLine( "" );
                     }

                     break;
                  }
               }
            }
            else //it is static
            {
               if ( true == entityProperty.Parameter.Output )
               {
                  //as stated above, cretae a function which 
                  //gets the property from the entity and sets the corresponding CSharp variable
                  AddCSharpLine( FormatType(entityProperty.Parameter.Type) + " " + CSharpRefreshGetPropertyDeclaration(entityProperty) + "( )");
                  AddCSharpLine( "{" );
                  ++m_TabStack;
                     AddCSharpLine( "return " + entityProperty.ComponentType + "." + entityProperty.Parameter.Name + ";" );               
                  --m_TabStack;

                  AddCSharpLine( "}" );
                  AddCSharpLine( "" );
               }

               if ( true == entityProperty.Parameter.Input )
               {
                  //as stated above, create a function which sets the entity's property to the
                  //corresponding CSharp variable's value
                  AddCSharpLine( "void " + CSharpRefreshSetPropertyDeclaration(entityProperty) + "( )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;
                     AddCSharpLine( entityProperty.ComponentType + "." + entityProperty.Parameter.Name + " = " + CSharpName(entityProperty, entityProperty.Parameter.Name) + ";" );               
                  --m_TabStack;
                  AddCSharpLine( "}" );               
                  AddCSharpLine( "" );
               }
            }
         }
      }

      private string FormatValue(string stringValue, string type)
      {
         if ( "System.Object" == type )
         {
            return "\"" + stringValue.Replace( "\"", "\\\"") + "\"";
         }
         else if ( "System.Boolean" == type )
         {
            if ( "" == stringValue )
            {
               return "(bool) false";
            }

            return "(bool) " + stringValue;
         }
         else if ( "System.String" == type )
         {
            return "\"" + EscapeString(stringValue) + "\"";
         }
         else if ( "UnityEngine.Quaternion" == type )
         {
            try
            {
               string [] subString = stringValue.Split( ',' );
               return "new Quaternion( (float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + ", (float)" + subString[3] + " )";
            }
            catch ( Exception ) { return "new Quaternion( )"; }
         }
         else if ( "UnityEngine.Vector2" == type )
         {
            try
            {
               string [] subString = stringValue.Split( ',' );
               return "new Vector2( (float)" + subString[0] + ", (float)" + subString[1] + " )";
            }
            catch ( Exception ) { return "new Vector2( )"; }
         }
         else if ( "UnityEngine.Vector3" == type )
         {
            try
            {
               string [] subString = stringValue.Split( ',' );
               return "new Vector3( (float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + " )";
            }
            catch ( Exception ) { return "new Vector3( )"; }
         }
         else if ( "UnityEngine.Vector4" == type )
         {
            try
            {
               string [] subString = stringValue.Split( ',' );
               return "new Vector4( (float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + ", (float)" + subString[3] + " )";
            }
            catch ( Exception ) { return "new Vector4( )"; }
         }
         else if ( "UnityEngine.Rect" == type )
         {
            try
            {
               string [] subString = stringValue.Split( ',' );
               return "new Rect( (float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + ", (float)" + subString[3] + " )";
            }
            catch ( Exception ) { return "new Rect( )"; }
         }
         else if ( "System.Single" == type )
         {
            if ( "" == stringValue )
            {
               return "(float) 0";
            }

            return "(float) " + stringValue;
         }
         else if ( "System.Double" == type )
         {
            if ( "" == stringValue )
            {
               return "(double) 0";
            }

            return "(double) " + stringValue;
         }
         else if ( "System.Int32" == type )
         {
            if ( "" == stringValue )
            {
               return "(int) 0";
            }

            return "(int) " + stringValue;
         }
         else if ( "UnityEngine.Color" == type )
         {
            try
            {
               string [] subString = stringValue.Split( ',' );
               return "new UnityEngine.Color( (float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + ", (float)" + subString[3] + " )";
            }
            catch ( Exception ) { return "UnityEngine.Color.black"; }
         }
         else if ( "UnityEngine.Ray" == type )
         {
            return "new UnityEngine.Ray( )";
         }
         else if ( "UnityEngine.JointDrive" == type )
         {
            return "new UnityEngine.JointDrive( )";
         }
         else if ( "UnityEngine.RaycastHit" == type )
         {
            return "new UnityEngine.RaycastHit( )";
         }
         else if ( "UnityEngine.NetworkPlayer" == type )
         {
            return "new UnityEngine.NetworkPlayer( )";
         }
         else if ( "UnityEngine.LayerMask" == type )
         {
            if ( "" == stringValue )
            {
               return "0";
            }

            return stringValue;
         }
         else if ( "UnityEngine.NetworkMessageInfo" == type )
         {
            return "new UnityEngine.NetworkMessageInfo( )";
         }
         else if ( type.Contains("[]") )
         {
            return FormatArrayValue( stringValue, type );
         }
         else if ( null != uScript.MasterComponent.GetAssemblyQualifiedType(type) )
         {
            System.Type netType = uScript.MasterComponent.GetAssemblyQualifiedType(type);

            if ( typeof(System.Enum).IsAssignableFrom(netType) )
            {
               System.Enum newEnum;

               //try and turn the text field value back into an enum, if it doesn't work
               //then revert back to the original value
               try { newEnum = (System.Enum) System.Enum.Parse(netType, stringValue); }
               catch { newEnum = (System.Enum) System.Enum.Parse(netType, System.Enum.GetNames(netType)[0]); }


               return FormatType(netType + "." + newEnum.ToString( ));
            }
         }

         return "null";
      }
      
      private string FormatArrayValue(string stringValue, string type)
      {
         string declaration = "";

         string []elements = Parameter.StringToArray( stringValue );

         if ( "UnityEngine.Quaternion[]" == type )
         {
            try
            {
               elements = Parameter.FlattenStringArrays( elements, ',' );

               declaration = "new Quaternion[] {";

               for ( int i = 0; i < elements.Length; i += 4 )
               {
                  declaration += "new Quaternion((float)" + elements[i] + ",(float)" + elements[i+1] + ",(float)" + elements[i+2] + ",(float)" + elements[i+3] + "),";
               }

               if ( elements.Length > 0 ) declaration = declaration.Substring( 0, declaration.Length - 1 );
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new Quaternion[0]"; }
         }
         else if ( "UnityEngine.Vector2[]" == type )
         {
            try
            {
               elements = Parameter.FlattenStringArrays( elements, ',' );

               declaration = "new Vector2[] {";

               for ( int i = 0; i < elements.Length; i += 2 )
               {
                  declaration += "new Vector2((float)" + elements[i] + ",(float)" + elements[i+1] + "),";
               }

               if ( elements.Length > 0 ) declaration = declaration.Substring( 0, declaration.Length - 1 );
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new Vector2[0]"; }
         }
         else if ( "UnityEngine.Vector3[]" == type )
         {
            try
            {
               elements = Parameter.FlattenStringArrays( elements, ',' );

               declaration = "new Vector3[] {";

               for ( int i = 0; i < elements.Length; i += 3 )
               {
                  declaration += "new Vector3((float)" + elements[i] + ",(float)" + elements[i+1] + ",(float)" + elements[i+2] + "),";
               }

               if ( elements.Length > 0 ) declaration = declaration.Substring( 0, declaration.Length - 1 );
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new Vector3[0]"; }
         }
         else if ( "UnityEngine.Vector4[]" == type )
         {
            try
            {
               elements = Parameter.FlattenStringArrays( elements, ',' );

               declaration = "new Vector4[] {";

               for ( int i = 0; i < elements.Length; i += 4 )
               {
                  declaration += "new Vector4((float)" + elements[i] + ",(float)" + elements[i+1] + ",(float)" + elements[i+2] + ",(float)" + elements[i+3] + "),";
               }

               if ( elements.Length > 0 ) declaration = declaration.Substring( 0, declaration.Length - 1 );
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new Vector4[0]"; }
         }
         else if ( "UnityEngine.Rect[]" == type )
         {
            try
            {
               elements = Parameter.FlattenStringArrays( elements, ',' );

               declaration = "new Rect[] {";

               for ( int i = 0; i < elements.Length; i += 4 )
               {
                  declaration += "new Rect((float)" + elements[i] + ",(float)" + elements[i+1] + ",(float)" + elements[i+2] + ",(float)" + elements[i+3] + "),";
               }

               if ( elements.Length > 0 ) declaration = declaration.Substring( 0, declaration.Length - 1 );
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new Rect[0]"; }
         }
         else if ( "UnityEngine.Color[]" == type )
         {
            try
            {
               elements = Parameter.FlattenStringArrays( elements, ',' );

               declaration = "new UnityEngine.Color[] {";

               for ( int i = 0; i < elements.Length; i += 3 )
               {
                  declaration += "new UnityEngine.Color((float)" + elements[i] + ", (float)" + elements[i+1] + ", (float)" + elements[i+2] + ", (float)" + elements[i+3] + "),";
               }

               if ( elements.Length > 0 ) declaration = declaration.Substring( 0, declaration.Length - 1 );
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new UnityEngine.Color[0]"; }
         }
         else if ( "UnityEngine.GameObject[]" == type )
         {
            try
            {
               declaration = "new UnityEngine.GameObject[] {";

               string arguments = "";

               for ( int i = 0; i < elements.Length; i++ )
               {
                  if ( "" == elements[i] ) continue;

                  arguments += "null,";
               };

               if ( arguments.Length > 0 ) arguments = arguments.Substring( 0, arguments.Length - 1 );

               declaration += arguments;
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new UnityEngine.GameObject[0]"; }
         }
         else if ( "UnityEngine.Component[]" == type )
         {
            try
            {
               declaration = "new UnityEngine.Component[] {";

               for ( int i = 0; i < elements.Length; i++ )
               {
                  declaration += "null,";
               };

               if ( elements.Length > 0 ) declaration = declaration.Substring( 0, declaration.Length - 1 );
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new UnityEngine.Component[0]"; }
         }
         else if ( "UnityEngine.NetworkPlayer[]" == type )
         {
            try
            {
               declaration = "new UnityEngine.NetworkPlayer[] {";

               for ( int i = 0; i < elements.Length; i++ )
               {
                  declaration += "new UnityEngine.NetworkPlayer(),";
               };

               if ( elements.Length > 0 ) declaration = declaration.Substring( 0, declaration.Length - 1 );
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new UnityEngine.NetworkPlayer[0]"; }
         }
         else if ( "UnityEngine.Camera[]" == type )
         {
            try
            {
               declaration = "new UnityEngine.Camera[] {";

               for ( int i = 0; i < elements.Length; i++ )
               {
                  declaration += "null,";
               };

               if ( elements.Length > 0 ) declaration = declaration.Substring( 0, declaration.Length - 1 );
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new UnityEngine.Camera[0]"; }
         }
         else if ( "System.Boolean[]" == type )
         {
            try
            {
               declaration = "new System.Boolean[] {";

               for ( int i = 0; i < elements.Length; i++ )
               {
                  string value = elements[i].Trim();
                  if ( "" == value ) value = "false";

                  declaration += value + ",";
               };

               if ( elements.Length > 0 ) declaration = declaration.Substring( 0, declaration.Length - 1 );
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new UnityEngine.Boolean[0]"; }
         }
         else if ( "UnityEngine.ContactPoint[]" == type )
         {
            declaration = "new UnityEngine.ContactPoint[ " + elements.Length + " ]";;
         }
         else
         {
            try
            {
               string cast = "";

               if ( "System.Single[]" == type ) 
               {
                  cast = "(float)";
               }
               else if ( "System.Double[]" == type ) 
               {
                  cast = "(double)";
               }
               else
               {
                  if ( null != uScript.MasterComponent.GetAssemblyQualifiedType(type.Replace("[]", "")) )
                  {
                     System.Type netType = uScript.MasterComponent.GetAssemblyQualifiedType(type.Replace("[]", ""));

                     if ( typeof(System.Enum).IsAssignableFrom(netType) )
                     {
                        cast = netType.ToString() + ".";
                     }
                  }
               }

               bool formatString = ( type == "System.String[]" || type == "System.Object[]" );

               declaration = "new " + type + " {";

               foreach ( string element in elements )
               {
                  if ( true == formatString )
                  {
                     declaration += "\"" + EscapeString(element) + "\"" + ",";
                  }
                  else
                  {
                     string value = element.Trim();
                     if ( "" == value ) value = "0";

                     declaration += cast + value + ",";
                  }
               }

               if ( elements.Length > 0 ) declaration = declaration.Substring( 0, declaration.Length - 1 );
               declaration += "}";
            }
            catch ( Exception ) { declaration = "new " + type.Replace("[]", "") + "[0]";  }
         }

         return declaration;
      }

      private void DefineDrawGizmos( )
      {
         Hashtable uniqueObjects = new Hashtable( );

         foreach ( EntityNode node in m_Script.EntityNodes )
         {
            if ( node is LocalNode )
            {
               LocalNode localNode = (LocalNode) node;
               
               if ( "UnityEngine.GameObject" == localNode.Value.Type && "" != localNode.Value.Default )
               {
                  uniqueObjects[ localNode.Value.Default ] = "uscript_gizmo_variables.png";
               }
            }
            else
            {
               if ( null == node.Instance.Default || "" == node.Instance.Default ) continue;

               if ( node is EntityEvent )
               {
                  uniqueObjects[ node.Instance.Default ] = "uscript_gizmo_events.png";
               }
               else if ( node is EntityMethod )
               {
                  uniqueObjects[ node.Instance.Default ] = "uscript_gizmo.png";
               }
            }
         }

         if ( uniqueObjects.Keys.Count > 0 )
         {
            foreach ( string key in uniqueObjects.Keys )
            {
               //ignore master game object - this will render its own master gizmo
               if ( key == uScriptRuntimeConfig.MasterObjectName ) continue;

               AddCSharpLine( "{" );
               ++m_TabStack;
               AddCSharpLine( "GameObject gameObject;" );
               AddCSharpLine( "gameObject = GameObject.Find( \"" + EscapeString(key) + "\" ); " );
               AddCSharpLine( "if ( null != gameObject ) Gizmos.DrawIcon(gameObject.transform.position, \"" + uniqueObjects[key] + "\");" );
               --m_TabStack;
               AddCSharpLine( "}" );
            }
         }
      }
      
      //declare all the members this file will use throughout the CSharp functions
      //all node inputs are represented by global variables
      private void DeclareMemberVariables( )
      {
         AddCSharpLine( "#pragma warning disable 414" );

         AddCSharpLine( "GameObject parentGameObject = null;" );
         AddCSharpLine( "uScript_GUI " + OnGuiListenerName( ) + " = null; " );

         if ( true == m_GenerateDebugInfo )
         {
            AddCSharpLine( "const int MaxRelayCallCount = " + uScript.Preferences.MaximumNodeRecursionCount + ";" );
            AddCSharpLine( "int relayCallCount = 0;" );
         }

         AddCSharpLine( "//external output properties" );
         Plug []properties = FindExternalOutputProperties( );
         string []outputs  = FindExternalOutputs( );

         for ( int i = 0; i < properties.Length; i++ )
         {
            AddCSharpLine( "bool " + outputs[i] + " = false;" );

            AddCSharpLine( "[FriendlyName(\"" + properties[i].FriendlyName + "\")]" );
            AddCSharpLine( "public bool " + properties[i].Name + " { get { return " + outputs[i] + ";} }" );

            m_ExternalOutputs.Add( properties[i] );
         }
         

         AddCSharpLine( "" );
         AddCSharpLine( "//externally exposed events" );
         Plug []events = FindExternalEvents( );

         if ( events.Length > 0 )
         {
            AddCSharpLine( "public delegate void uScriptEventHandler(object sender, System.EventArgs args);" );
            foreach ( Plug eventPlug in events )
            {
               AddCSharpLine( "[FriendlyName(\"" + eventPlug.FriendlyName + "\")]" );
               AddCSharpLine( "public event uScriptEventHandler " + eventPlug.Name + ";" );

               m_ExternalEvents.Add( eventPlug );
            }
         }


         AddCSharpLine( "" );
         AddCSharpLine( "//external parameters" );         
         foreach ( ExternalConnection external in m_Script.Externals )
         {
            LinkNode [] links = FindLinksByDestination( external.Guid, external.Connection );

            foreach ( LinkNode link in links )
            {
               EntityNode node = m_Script.GetNode( link.Source.Guid );

               foreach ( Parameter p in node.Parameters )
               {
                  if ( p.Name == link.Source.Anchor &&
                       true == p.Output )
                  {
                     AddCSharpLine( FormatType(p.Type) + " " + CSharpName(external, p.Name) + " = " + FormatValue(p.Default, p.Type) + ";" );
                     break;
                  }
               }

               //only one link allowed for each external parameter output
               break;
            }

            links = FindLinksBySource( external.Guid, external.Connection );

            foreach ( LinkNode link in links )
            {
               EntityNode node = m_Script.GetNode( link.Destination.Guid );

               if ( node is EntityMethod )
               {
                  if ( node.Instance.Name == link.Destination.Anchor )
                  {
                     AddCSharpLine( FormatType(node.Instance.Type) + " " + CSharpName(external) + " = " + FormatValue(node.Instance.Default, node.Instance.Type) + ";" );
                     break;
                  }
               }
            }
         }

         AddCSharpLine( "" );
         AddCSharpLine( "//local nodes" );
         foreach ( LocalNode local in m_Script.UniqueLocals )
         {
            AddCSharpLine( FormatType(local.Value.Type) + " " + CSharpName(local) + " = " + FormatValue(local.Value.Default, local.Value.Type) + ";" );
            
            if ( local.Value.Type == "UnityEngine.GameObject" )
            {
               AddCSharpLine( FormatType(local.Value.Type) + " " + PreviousName(local) + " = null;" );
            }
         }

         AddCSharpLine( "" );
         AddCSharpLine( "//owner nodes" );
         foreach ( OwnerConnection owner in m_Script.Owners )
         {
            AddCSharpLine( FormatType(owner.Connection.Type) + " " + CSharpName(owner) + " = null;" );
         }

         AddCSharpLine( "" );
         AddCSharpLine( "//logic nodes" );

         foreach ( LogicNode logic in m_Script.Logics )
         {
            AddCSharpLine( "//pointer to script instanced logic node" );
            AddCSharpLine( FormatType(logic.Type) + " " + CSharpName(logic, logic.Type) + " = null;" );
            
            foreach ( Parameter parameter in logic.Parameters )
            {
               if ( true == parameter.Input )
               {
                  AddCSharpLine( FormatType(parameter.Type) + " " + CSharpName(logic, parameter.Name) + " = " + FormatValue(parameter.Default, parameter.Type) + ";" );
               }
               else
               {
                  AddCSharpLine( FormatType(parameter.Type) + " " + CSharpName(logic, parameter.Name) + ";" );
               }
            }

            foreach ( Plug output in logic.Outputs )
            {
               AddCSharpLine( "bool " + CSharpName(logic, output.Name) + " = true;" );
            }

            foreach ( string driven in logic.Drivens )
            {
               AddCSharpLine( "bool " + CSharpName(logic, driven) + " = true;" );
            }
         }

         AddCSharpLine( "" );
         AddCSharpLine( "//event nodes" );

         foreach ( EntityEvent entityEvent in m_Script.Events )
         {
            foreach ( Parameter parameter  in entityEvent.Parameters  )
            {
               AddCSharpLine( FormatType(parameter.Type) + " " + CSharpName(entityEvent, parameter.Name) + " = " + FormatValue(parameter.Default, parameter.Type) + ";" );
            }

            if ( entityEvent.Instance.Default != "" )
            {
               AddCSharpLine( FormatType(entityEvent.Instance.Type) + " " + CSharpName(entityEvent, entityEvent.Instance.Name) + " = " + FormatValue(entityEvent.Instance.Default, entityEvent.Instance.Type) + ";" );
            }
         }

         AddCSharpLine( "" );
         AddCSharpLine( "//property nodes" );

         foreach ( EntityProperty entityProperty in m_Script.Properties )
         {
            AddCSharpLine( FormatType(entityProperty.Parameter.Type) + " " + CSharpName(entityProperty, entityProperty.Parameter.Name) + " = " + FormatValue(entityProperty.Parameter.Default, entityProperty.Parameter.Type) + ";" );

            if ( entityProperty.Instance.Default != "" )
            {
               AddCSharpLine( FormatType(entityProperty.Instance.Type) + " " + CSharpName(entityProperty, entityProperty.Instance.Name) + " = " + FormatValue(entityProperty.Instance.Default, entityProperty.ComponentType) + ";" );
            }
         }

         AddCSharpLine( "" );
         AddCSharpLine( "//method nodes" );

         foreach ( EntityMethod entityMethod in m_Script.Methods )
         {
            foreach ( Parameter parameter in entityMethod.Parameters )
            {
               AddCSharpLine( FormatType(parameter.Type) + " " + CSharpName(entityMethod, parameter.Name) + " = " + FormatValue(parameter.Default, parameter.Type) + ";" );
            }

            if ( entityMethod.Instance.Default != "" )
            {
               AddCSharpLine( FormatType(entityMethod.Instance.Type) + " " + CSharpName(entityMethod, entityMethod.Instance.Name) + " = " + FormatValue(entityMethod.Instance.Default, entityMethod.Instance.Type) + ";" );
            }
         }

         AddCSharpLine( "#pragma warning restore 414" );
      }

      private void DefineSetParent( )
      {
         AddCSharpLine( "parentGameObject = g;" );        
         AddCSharpLine( "" );
         
         foreach ( LogicNode logic in m_Script.Logics )
         {
            AddCSharpLine( CSharpName(logic, logic.Type) + ".SetParent(g);" );
         }
      }

      private void DefineStartInitialization( )
      {
         //make sure all components we plan to reference
         //have been placed in their local variables
         AddCSharpLine( CSharpSyncUnityHooksDeclaration( ) + ";" );
         AddCSharpLine( "" );

         //for each logic node, create an script specific instance
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            if ( NeedsMethod(logicNode, "Start") )
            {
               AddCSharpLine( CSharpName(logicNode, logicNode.Type) + ".Start( );" );
            }
         }
      }
      
      private void DefineAwakeInitialization( )
      {         
         //for each logic node, create an script specific instance
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            AddCSharpLine( CSharpName(logicNode, logicNode.Type) + " = ScriptableObject.CreateInstance(typeof(" + logicNode.Type +")) as " + FormatType(logicNode.Type) + ";" );
         }
         
         AddCSharpLine( "" );

         //for each logic node event, register event listeners with it
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            foreach ( Plug eventName in logicNode.Events )
            {
               AddLogicEventListener( logicNode, eventName.Name );
            }
         }
      }

      private void DefineUpdate( )
      {
         if ( true == m_GenerateDebugInfo )
         {
            AddCSharpLine( "//reset each Update, and increments each method call" );
            AddCSharpLine( "//if it ever goes above MaxRelayCallCount before being reset" );
            AddCSharpLine( "//then we assume it is stuck in an infinite loop" );         
            AddCSharpLine( "if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;" );
         }

         AddCSharpLine( "//other scripts might have added GameObjects with event scripts" );
         AddCSharpLine( "//so we need to verify all our event listeners are registered" );
         AddCSharpLine( CSharpSyncEventListenersDeclaration( ) + ";" );
         AddCSharpLine( "" );

         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            if ( true == NeedsMethod(logicNode, "Update") )
            {
               AddCSharpLine( CSharpName(logicNode, logicNode.Type) + ".Update( );" );
            }
         }

         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            foreach ( string driven in logicNode.Drivens )
            {
               AddCSharpLine( CSharpRelay(logicNode, driven) + "();" );
            }
         }
      }

      private void DefineLateUpdate( )
      {
         //for each logic node, create an script specific instance
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            if ( true == NeedsMethod(logicNode, "LateUpdate") )
            {
               AddCSharpLine( CSharpName(logicNode, logicNode.Type) + ".LateUpdate( );" );
            }
         }
      }

      private void DefineFixedUpdate( )
      {
         //for each logic node, create an script specific instance
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            if ( true == NeedsMethod(logicNode, "FixedUpdate") )
            {
               AddCSharpLine( CSharpName(logicNode, logicNode.Type) + ".FixedUpdate( );" );
            }
         }
      }

      private void DefineOnGUI( )
      {
         //for each logic node, create an script specific instance
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            if ( true == NeedsMethod(logicNode, "OnGUI") )
            {
               AddCSharpLine( CSharpName(logicNode, logicNode.Type) + ".OnGUI( );" );
            }
         }
      }

      private void DefineSyncUnityHooks( )
      {
         AddCSharpLine( "void " + CSharpSyncUnityHooksDeclaration( ) );
         AddCSharpLine( "{" );
         ++m_TabStack;
   
            //get any references to components currently available
            //which we haven't filled out yet
            foreach ( EntityMethod entityMethod in m_Script.Methods )
            {
               if ( false == entityMethod.IsStatic )
               {
                  if ( entityMethod.Instance.Default != "" )
                  {
                     FillComponent( entityMethod, entityMethod.Instance );
                  }
               }

               foreach ( Parameter p in entityMethod.Parameters )
               {
                  if ( false == p.Input ) continue;
                  FillComponent( entityMethod, p );
               }
            }

            AddCSharpLine( CSharpSyncEventListenersDeclaration( ) + ";" );

            foreach ( EntityProperty entityProperty in m_Script.Properties )
            {
               if ( false == entityProperty.IsStatic )
               {
                  if ( entityProperty.Instance.Default != "" )
                  {
                     FillComponent( entityProperty, entityProperty.Instance );
                  }
               }
            }

            foreach ( LogicNode logicNode in m_Script.Logics )
            {
               foreach ( Parameter p in logicNode.Parameters )
               {
                  if ( false == p.Input ) continue;
                  FillComponent( logicNode, p );
               }
            }

            foreach ( LocalNode localNode in m_Script.UniqueLocals )
            {
               FillComponent( localNode, localNode.Value );
            }

            foreach ( OwnerConnection ownerNode in m_Script.Owners )
            {
               FillComponent( ownerNode, ownerNode.Connection );
            }

         --m_TabStack;
         AddCSharpLine( "}" );
      }

      public void DefineSyncEventListeners( )
      {
         AddCSharpLine( "void " + CSharpSyncEventListenersDeclaration( ) );
         AddCSharpLine( "{" );
         ++m_TabStack;

            foreach ( EntityEvent entityEvent in m_Script.Events )
            {
               if ( false == entityEvent.IsStatic )
               {
                  if ( entityEvent.Instance.Default != "" )
                  {
                     FillComponent( entityEvent, entityEvent.Instance );
                  }
               }
               else
               {
                  SetupEvent( null, entityEvent, true );
               }
            }

         --m_TabStack;
         AddCSharpLine( "}" );
      }

      private void FillComponent(EntityNode node, Parameter parameter)
      {
         Type componentType  = typeof(UnityEngine.Component);
         Type gameObjectType = typeof(UnityEngine.GameObject);
         Type componentArrayType  = typeof(UnityEngine.Component[]);
         Type gameObjectArrayType = typeof(UnityEngine.GameObject[]);

         Type nodeType = uScript.MasterComponent.GetType(parameter.Type);
         if ( null == nodeType ) return;

         if ( true == gameObjectArrayType.IsAssignableFrom(nodeType) )
         {
            //remove curly braces from type declaration
            //so we can use it to cast the object to the array element type
            string type = FormatType(parameter.Type);
            type = type.Substring( 0, type.Length - 2 );

            string []values = Parameter.StringToArray( parameter.Default );

            for ( int i = 0; i < values.Length; i++ )
            {
               if ( values[i].Trim( ) == "" ) continue;

               AddCSharpLine( "if ( null == " + CSharpName(node, parameter.Name) + "[" + i + "] )" );
               AddCSharpLine( "{" );
               ++m_TabStack;

                  if ( uScriptRuntimeConfig.MasterObjectName == EscapeString(values[i].Trim( )) )
                  {
                     AddCSharpLine( CSharpName(node, parameter.Name) + "[" + i + "] = uScript_MasterComponent.LatestMaster;" );
                  }
                  else
                  {
                     AddCSharpLine( CSharpName(node, parameter.Name) + "[" + i + "] = GameObject.Find( \"" + EscapeString(values[i].Trim( )) + "\" ) as " + type + ";" );                     
                  }
                  SetupEventListeners( CSharpName(node, parameter.Name) + "[" + i + "]", node, true );
         
               --m_TabStack;
               AddCSharpLine( "}" );
            }
         }
         else if ( true == componentArrayType.IsAssignableFrom(nodeType) )
         {
            string []values = Parameter.StringToArray( parameter.Default );
         
            //remove curly braces from type declaration
            //so we can use it to cast the object to the array element type
            string type = FormatType(parameter.Type);
            type = type.Substring( 0, type.Length - 2 );

            AddCSharpLine( "{" );
            ++m_TabStack;

            AddCSharpLine( "GameObject gameObject = null;" );
            
            for ( int i = 0; i < values.Length; i++ )
            {
               if ( values[i].Trim( ) == "" ) continue;

               AddCSharpLine( "if ( null == " + CSharpName(node, parameter.Name) + "[" + i + "] )" );
               AddCSharpLine( "{" );               
               ++m_TabStack;

                  if ( uScriptRuntimeConfig.MasterObjectName == EscapeString(values[i].Trim( )) )
                  {
                     AddCSharpLine( "gameObject = uScript_MasterComponent.LatestMaster;" );
                  }
                  else
                  {
                     AddCSharpLine( "gameObject = GameObject.Find( \"" + EscapeString(values[i].Trim( )) + "\" );" );
                  }
               
                  AddCSharpLine( "if ( null != " + "gameObject )" );
         
                  AddCSharpLine( "{" );               
                  ++m_TabStack;
                     AddCSharpLine( CSharpName(node, parameter.Name) + "[" + i + "] = gameObject.GetComponent<" + type + ">();" );
                     AddMissingComponent( CSharpName(node, parameter.Name) + "[" + i + "]", "gameObject", type ); 
                     SetupEventListeners( CSharpName(node, parameter.Name) + "[" + i + "]", node, true );
   
                  --m_TabStack;
                  AddCSharpLine( "}" );               

               --m_TabStack;
               AddCSharpLine( "};" );
            }

            --m_TabStack;
            AddCSharpLine( "};" );
         }
         else if ( true == componentType.IsAssignableFrom(nodeType) )
         {
            if ( parameter.Default != "" )
            {
               AddCSharpLine( "if ( null == " + CSharpName(node, parameter.Name) + " )" );
               AddCSharpLine( "{" );
               ++m_TabStack;

                  if ( uScriptRuntimeConfig.MasterObjectName == EscapeString(parameter.Default) )
                  {
                     AddCSharpLine( "GameObject gameObject = uScript_MasterComponent.LatestMaster;" );
                  }
                  else
                  {
                     AddCSharpLine( "GameObject gameObject = GameObject.Find( \"" + EscapeString(parameter.Default) + "\" );" );
                  }

                  AddCSharpLine( "if ( null != " + "gameObject )" );
            
                  AddCSharpLine( "{" );               
                  ++m_TabStack;
                     AddCSharpLine( CSharpName(node, parameter.Name) + " = gameObject.GetComponent<" + FormatType(parameter.Type) + ">();" );
                     AddMissingComponent( CSharpName(node, parameter.Name), "gameObject", FormatType(parameter.Type) ); 
                     SetupEventListeners( CSharpName(node, parameter.Name), node, true );
               
                  --m_TabStack;
                  AddCSharpLine( "}" );               

               --m_TabStack;
               AddCSharpLine( "}" );
            }
         }
         else if ( true == gameObjectType.IsAssignableFrom(nodeType) )
         {
            if ( true == node is OwnerConnection )
            {
               AddCSharpLine( "if ( null == " + CSharpName(node, parameter.Name) + " )" );
               AddCSharpLine( "{" );
               ++m_TabStack;
                  AddCSharpLine( CSharpName(node, parameter.Name) + " = parentGameObject;" );
                  SetupEventListeners( CSharpName(node, parameter.Name), node, true );
               --m_TabStack;
               AddCSharpLine( "}" );
            }
            else if ( parameter.Default != "" )
            {
               AddCSharpLine( "if ( null == " + CSharpName(node, parameter.Name) + " )" );
               AddCSharpLine( "{" );
               ++m_TabStack;

                  if ( uScriptRuntimeConfig.MasterObjectName == EscapeString(parameter.Default) )
                  {
                     AddCSharpLine( CSharpName(node, parameter.Name) + " = uScript_MasterComponent.LatestMaster;" );
                  }
                  else
                  {
                     AddCSharpLine( CSharpName(node, parameter.Name) + " = GameObject.Find( \"" + EscapeString(parameter.Default) + "\" ) as " + FormatType(parameter.Type) + ";" );
                  }

                  //only set up listeners if it's NOT a variable connecxtion
                  //otherwise they'll be set in the conditional below this
                  if ( false == node is LocalNode )
                  {
                     SetupEventListeners( CSharpName(node, parameter.Name), node, true );
                  }

               --m_TabStack;
               AddCSharpLine( "}" );
            }
            
            //if it's a variable node linked to us
            //then we need to go a few steps further to see if its contents
            //have been modified at runtime.  if they have then
            //we need to register new event listeners
            if ( true == node is LocalNode )
            {
               AddCSharpLine( "//if our game object reference was changed then we need to reset event listeners" );
               AddCSharpLine( "if ( " + PreviousName(node, parameter.Name) + " != " + CSharpName(node, parameter.Name) + " )" );
               AddCSharpLine( "{" );
               ++m_TabStack;

                  AddCSharpLine( "//tear down old listeners" );
                  SetupEventListeners( PreviousName(node, parameter.Name), node, false );
                  AddCSharpLine( "" );

                  AddCSharpLine( PreviousName(node, parameter.Name) + " = " + CSharpName(node, parameter.Name) + ";" );
                  AddCSharpLine( "" );

                  AddCSharpLine( "//setup new listeners" );
                  SetupEventListeners( CSharpName(node, parameter.Name), node, true );

               --m_TabStack;
               AddCSharpLine( "}" );
            }
         }
      }

      private string SetCode( string s )
      {
         string c = m_CSharpString;
         m_CSharpString = s;

         return c;
      }

      private void SetupEventListeners( string eventVariable, EntityNode node, bool setup )
      {
         string currentCode = SetCode( "" );

         ++m_TabStack;
            if ( node is EntityEvent )
            {
               SetupEvent( eventVariable, ((EntityEvent)node), setup );
            }
            else if ( node is LocalNode )
            {
               //if we are a local node, see if there are any event listeners
               //hooked up to us - if so then we need to get the matching component
               //and register the listeners
               LocalNode local = (LocalNode) node;

               foreach ( LinkNode link in m_Script.Links )
               {
                  if ( link.Source.Guid   == local.Guid &&
                       link.Source.Anchor == local.Value.Name )
                  {
                     EntityNode destNode = m_Script.GetNode( link.Destination.Guid );

                     if ( destNode is EntityEvent )
                     {
                        EntityEvent eventNode = (EntityEvent) destNode;
                        if ( link.Destination.Anchor == eventNode.Instance.Name )
                        {
                           SetupEvent( eventVariable, eventNode, setup ); 
                        }
                     }
                  }
               }
            }
            else if ( node is OwnerConnection )
            {
               //if we are an owner node, see if there are any event listeners
               //hooked up to us - if so then we need to get the matching component
               //and register the listeners
               OwnerConnection owner = (OwnerConnection) node;

               foreach ( LinkNode link in m_Script.Links )
               {
                  if ( link.Source.Guid   == owner.Guid &&
                       link.Source.Anchor == owner.Connection.Name )
                  {
                     EntityNode destNode = m_Script.GetNode( link.Destination.Guid );

                     if ( destNode is EntityEvent )
                     {
                        EntityEvent eventNode = (EntityEvent) destNode;
                        if ( link.Destination.Anchor == eventNode.Instance.Name )
                        {
                           SetupEvent( eventVariable, eventNode, setup ); 
                        }
                     }
                  }
               }
            }
         --m_TabStack;

         string newCode = SetCode( currentCode );

         if ( "" != newCode )
         {            
            AddCSharpLine( "if ( null != " + eventVariable + " )" );

            AddCSharpLine( "{" );               

               m_CSharpString += newCode;

            AddCSharpLine( "}" );               
         }
      }

      //default inputs for events which can only be set through the property grid
      //so they are only set once (in SyncUnityHooks)
      //and we add all our event listeners here
      private void SetupEvent( string eventVariable, EntityEvent eventNode, bool setup )
      {
         //if we're setting up then set the inputs
         //if we're tearing down, we can ignore this step
         if ( true == setup )
         {
            foreach ( Parameter p in eventNode.Parameters )
            {
               if ( p.Input == true )
               {
                  if ( true == eventNode.IsStatic )
                  {
                     AddCSharpLine( eventNode.ComponentType + "." + p.Name + " = " + CSharpName(eventNode, p.Name) + ";" );
                  }
                  else
                  {
                     AddCSharpLine( "{" );
                     ++m_TabStack;
                        AddCSharpLine( eventNode.ComponentType + " component = " + eventVariable + ".GetComponent<" + eventNode.ComponentType + ">();" );
                        AddMissingComponent( "component", eventVariable, eventNode.ComponentType ); 

                        AddCSharpLine( "if ( null != component )" );
                        AddCSharpLine( "{" );
                        ++m_TabStack;
                           AddCSharpLine( "component." + p.Name + " = " + CSharpName(eventNode, p.Name) + ";" );
                        --m_TabStack;
                        AddCSharpLine( "}" );
                     --m_TabStack;
                     AddCSharpLine( "}" );
                  }
               }
            }
         }

         AddCSharpLine( "{" );
         ++m_TabStack;
            AddEventListener( eventVariable, eventNode, setup );
         --m_TabStack;
         AddCSharpLine( "}" );
      }

      private void AddMissingComponent(string componentVariable, string gameObjectVariable, string componentType)
      {
         Type type = uScript.MasterComponent.GetType(componentType);
         if ( null != type && typeof(uScriptEvent).IsAssignableFrom(type) )
         {
            AddCSharpLine( "if ( null == " + componentVariable + " )" );
            AddCSharpLine( "{" );
            ++m_TabStack;                 
               AddCSharpLine( componentVariable + " = " + gameObjectVariable + ".AddComponent<" + componentType + ">();" );
            --m_TabStack;
            AddCSharpLine( "}" );
         }
      }

      private void DefineEvents( )
      {
         //for every registered event listener
         //define the function the event will call
         foreach ( EntityEvent entityEvent in m_Script.Events )
         {
            foreach ( Plug output in entityEvent.Outputs )
            {
               DefineEntityEvent( entityEvent, output.Name );
            }
         }

         //for every registered logic node event listener
         //define the function the event will call
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            foreach ( Plug eventName in logicNode.Events )
            {
               DefineLogicEvent( logicNode, eventName.Name );
            }
         }

         //for every external node
         //define the function the event will call
         foreach ( ExternalConnection external in m_Script.Externals )
         {
            DefineExternalInput( external );
         }

         //then for every node linked to the event listener or logic listener
         //define a relay function the event will call
         foreach ( EntityNode entityNode in m_Script.EntityNodes )
         {
            if ( false == entityNode is LinkNode )
            {
               DefineRelay( entityNode );
            }
         }

         DefineExternalDrivens( );
      }

      //create the function which the event listener will call
      private void DefineEntityEvent( EntityEvent entityEvent, string output )
      {
         AddCSharpLine( "void " + CSharpEventDeclaration(entityEvent, output) + "(object o, " + entityEvent.EventArgs + " e)" );
         AddCSharpLine( "{" );

         ++m_TabStack;

            int i = 0;

            //all we want to do for an entityevent is output the variables
            //then call the relays
            AddCSharpLine( "//fill globals" );
            foreach ( Parameter parameter in entityEvent.Parameters )
            {
               //only allow output parameters, those come through in the event args
               if ( parameter.Input == true ) continue;

               AddCSharpLine( CSharpName(entityEvent, parameter.Name) + " = e." + parameter.Name + ";" );
               ++i;
            }

            AddCSharpLine( "//relay event to nodes" );
            AddCSharpLine( CSharpRelay(entityEvent, output) + "( );" );

         --m_TabStack;

         AddCSharpLine( "}" );
         AddCSharpLine( "" );
      }

      private string[] FindExternalOutputs( )
      {
         List<string> externalLinks = new List<string>( );

         LinkNode [] links;

         foreach ( ExternalConnection external in m_Script.Externals )
         {
            links = FindLinksByDestination( external.Guid, external.Connection );

            foreach ( LinkNode link in links )
            {
               EntityNode node = m_Script.GetNode( link.Source.Guid );
            
               if ( node is EntityMethod ) 
               {
                  EntityMethod method = (EntityMethod) node;

                  if ( link.Source.Anchor == method.Output.Name )
                  {
                     externalLinks.Add( CSharpExternalOutputDeclaration(external.Name.Default) );
                  }
               }
               else if ( node is LogicNode ) 
               {
                  LogicNode logic = (LogicNode) node;

                  foreach ( Plug output in logic.Outputs )
                  {
                     if ( link.Source.Anchor == output.Name )
                     {
                        externalLinks.Add( CSharpExternalOutputDeclaration(external.Name.Default) );
                     }
                  }
               }
            
               //only needs to be defined once, even if multiple nodes are connected to it
               if ( externalLinks.Count > 0 )
               {
                  break;
               }
            }
         }

         return externalLinks.ToArray( );
      }

      private Plug[] FindExternalOutputProperties( )
      {
         List<Plug> externalLinks = new List<Plug>( );

         LinkNode [] links;

         foreach ( ExternalConnection external in m_Script.Externals )
         {
            links = FindLinksByDestination( external.Guid, external.Connection );

            foreach ( LinkNode link in links )
            {
               EntityNode node = m_Script.GetNode( link.Source.Guid );
            
               if ( node is EntityMethod ) 
               {
                  EntityMethod method = (EntityMethod) node;

                  if ( link.Source.Anchor == method.Output.Name )
                  {
                     externalLinks.Add( CSharpExternalOutputPropertyDeclaration(external.Name.Default) );
                  }
               }
               else if ( node is LogicNode ) 
               {
                  LogicNode logic = (LogicNode) node;

                  foreach ( Plug output in logic.Outputs )
                  {
                     if ( link.Source.Anchor == output.Name )
                     {
                        externalLinks.Add( CSharpExternalOutputPropertyDeclaration(external.Name.Default) );
                     }
                  }
               }

               //only needs to be defined once, even if multiple nodes are connected to it
               if ( externalLinks.Count > 0 )
               {
                  break;
               }
            }
         }

         return externalLinks.ToArray( );
      }
      
      private Plug[] FindExternalEvents( )
      {
         List<Plug> externalLinks = new List<Plug>( );

         LinkNode [] links;

         foreach ( ExternalConnection external in m_Script.Externals )
         {
            links = FindLinksByDestination( external.Guid, external.Connection );

            foreach ( LinkNode link in links )
            {
               EntityNode node = m_Script.GetNode( link.Source.Guid );
            
               if ( node is EntityEvent ) 
               {
                  EntityEvent entityEvent = (EntityEvent) node;

                  foreach ( Plug output in entityEvent.Outputs )
                  {
                     if ( link.Source.Anchor == output.Name )
                     {
                        externalLinks.Add( CSharpExternalEventDeclaration(external.Name.Default) );
                        break;
                     }
                  }
               }
               else if ( node is LogicNode ) 
               {
                  LogicNode logic = (LogicNode) node;

                  foreach ( Plug eventName in logic.Events )
                  {
                     if ( link.Source.Anchor == eventName.Name )
                     {
                        externalLinks.Add( CSharpExternalEventDeclaration(external.Name.Default) );
                        break;
                     }
                  }
               }

               //only needs to be defined once, even if multiple nodes are connected to it
               if ( externalLinks.Count > 0 )
               {
                  break;
               }
            }
         }

         return externalLinks.ToArray( );
      }
      
      //create the external function outsiders can call
      private void DefineExternalDrivens( )
      {
         //all output args
         string args = "";
         
         foreach ( ExternalConnection external in m_Script.Externals )
         {
            LinkNode []links = FindLinksByDestination( external.Guid, external.Connection );

            foreach ( LinkNode link in links )
            {
               EntityNode node = m_Script.GetNode( link.Source.Guid );

               foreach ( Parameter p in node.Parameters )
               {
                  //we don't allow refs or inputs on drivens
                  //because uScript standard doesn't allow changing of input variables
                  //without a pulse in
                  if ( p.Name == link.Source.Anchor )
                  {
                     args += "out " + FormatType(p.Type) + " " + CSharpExternalParameterDeclaration(external.Name.Default).Name + ", ";
                  }
               }

               //only needs to be defined once, even if multiple nodes are connected to it
               break;
            }
         }

         //remove trailing comma from last input arg
         if ( args != "" ) args = args.Substring( 0, args.Length - 2 );
 
         foreach ( LogicNode logic in m_Script.Logics )
         {
            foreach ( string driven in logic.Drivens )
            {
               DefineExternalDriven( logic, driven, args );
            }
         }
      }

      void DefineExternalDriven( LogicNode node, string driven, string args )
      {
         m_Drivens.Add( CSharpExternalDriven(node, driven) );

         AddCSharpLine( "[Driven]" );
         AddCSharpLine( "public bool " + CSharpExternalDriven(node, driven) + "( " + args + " )" );
         AddCSharpLine( "{" );
         ++m_TabStack;

            //transfer our member variables modified internally to the external call
            foreach ( ExternalConnection external in m_Script.Externals )
            {
               LinkNode []outputs = FindLinksByDestination( external.Guid, external.Connection );

               foreach ( LinkNode link in outputs )
               {
                  EntityNode parameterNode = m_Script.GetNode( link.Source.Guid );

                  foreach ( Parameter p in parameterNode.Parameters )
                  {
                     if ( p.Name == link.Source.Anchor )
                     {
                        //external connections don't have a parameter
                        //because they take on whatever parameter they link to
                        Parameter parameter = new Parameter( );
                        parameter.Name = external.Connection;
                        parameter.Type = p.Type;
                        SyncSlaveConnections(external, new Parameter[]{ parameter } );

                        AddCSharpLine( CSharpExternalParameterDeclaration(external.Name.Default).Name + " = " + CSharpName(external, p.Name) + ";" );
                     }
                  }

                  //only one link allowed for each external parameter output
                  break;
               }
            }

            AddCSharpLine( "return " + CSharpName(node, driven) + ";" );

         --m_TabStack;
         AddCSharpLine( "}" );
         AddCSharpLine( "" );
      }
      
      //create the external function outsiders can call
      private void DefineExternalInput( ExternalConnection externalInput )
      {
         Hashtable uniqueParameters = new Hashtable( );

         foreach ( ExternalConnection external in m_Script.Externals )
         {
            if ( null != uniqueParameters[ external.Name.Default ] ) continue;

            LinkNode []links = FindLinksBySource( external.Guid, external.Connection );

            foreach ( LinkNode link in links )
            {
               EntityNode node = m_Script.GetNode( link.Destination.Guid );

               foreach ( Parameter p in node.Parameters )
               {
                  if ( p.Name == link.Destination.Anchor )
                  {
                     uniqueParameters[ external.Name.Default ] = p;
                  }
               }
            
               if ( node.Instance.Name == link.Destination.Anchor )
               {
                  uniqueParameters[ external.Name.Default ] = node.Instance;
               }

               //only needs to be defined once, even if multiple nodes are connected to it
               break;
            }
         }

         foreach ( ExternalConnection external in m_Script.Externals )
         {
            LinkNode []links = FindLinksByDestination( external.Guid, external.Connection );

            foreach ( LinkNode link in links )
            {
               //the link ends at our external
               //so if it's already used as a source, change it to a ref
               if ( null != uniqueParameters[ external.Name.Default ] ) 
               {
                  Parameter p = (Parameter) uniqueParameters[ external.Name.Default ];
                  p.Output = true;
                  uniqueParameters[ external.Name.Default ] = p;
                  continue;
               }

               EntityNode node = m_Script.GetNode( link.Source.Guid );

               foreach ( Parameter p in node.Parameters )
               {
                  if ( p.Name == link.Source.Anchor )
                  {
                     uniqueParameters[ external.Name.Default ] = p;
                  }
               }

               //only one link allowed for each external parameter output
               break;
            }
         }

         string args = "";

         foreach ( string key in uniqueParameters.Keys )
         {
            Parameter p  = (Parameter) uniqueParameters[ key ];

            if ( true == p.Input && false == p.Output )
            {
               args += "[FriendlyName(\"" + CSharpExternalParameterDeclaration(key).FriendlyName + "\")] ";
               args += FormatType(p.Type) + " " + CSharpExternalParameterDeclaration(key).Name + ", ";
            }
            else if ( true == p.Input && true == p.Output )
            {
               args += "[FriendlyName(\"" + CSharpExternalParameterDeclaration(key).FriendlyName + "\")] ";
               args += "ref " + FormatType(p.Type) + " " + CSharpExternalParameterDeclaration(key).Name + ", ";
            }
            else if ( false == p.Input && true == p.Output )
            {
               args += "[FriendlyName(\"" + CSharpExternalParameterDeclaration(key).FriendlyName + "\")] ";
               args += "out " + FormatType(p.Type) + " " + CSharpExternalParameterDeclaration(key).Name + ", ";
            }
         }
 
         if ( args != "" ) args = args.Substring( 0, args.Length - 2 );
         
         LinkNode []relays = FindLinksBySource( externalInput.Guid, externalInput.Connection );
         
         List<LinkNode.Connection> allowedRelays = new List<LinkNode.Connection>( );
         
         foreach ( LinkNode relayLink in relays )
         {
            EntityNode node = m_Script.GetNode( relayLink.Destination.Guid );
            
            bool allowLink = false;

            if ( node is EntityMethod )
            {
               EntityMethod method = (EntityMethod) node;

               if ( method.Input.Name == relayLink.Destination.Anchor )
               {
                  allowLink = true;
               }
            }
            else if ( node is LogicNode )
            {
               LogicNode logic = (LogicNode) node;

               foreach ( Plug input in logic.Inputs )
               {
                  if ( input.Name == relayLink.Destination.Anchor )
                  {
                     allowLink = true;
                  }
               }
            }

            if ( true == allowLink )
            {
               allowedRelays.Add( relayLink.Destination );
            }

            //only one set of external parameters per script            
            //they match for every method signature
            if ( 0 == m_ExternalParameters.Count )
            {
               foreach ( string key in uniqueParameters.Keys )
               {
                  Parameter p  = (Parameter) uniqueParameters[ key ];
               
                  Plug plug = CSharpExternalParameterDeclaration(key);

                  Parameter clone = p;
                  clone.FriendlyName = plug.FriendlyName;
                  clone.Name  = plug.Name;
                  clone.State = Parameter.VisibleState.Visible;

                  m_ExternalParameters.Add( clone );
               }
            }

            if ( true == allowLink ) break;
         }
         
         if ( allowedRelays.Count > 0 )
         {
            DefineExternalInput( externalInput, allowedRelays.ToArray( ), args );
         }
      }

      void DefineExternalInput( ExternalConnection externalInput, LinkNode.Connection []connections, string args )
      {
         Plug inputPlug = CSharpExternalInputDeclaration(externalInput.Name.Default);
         m_ExternalInputs.Add( inputPlug );

         AddCSharpLine( "[FriendlyName(\"" + inputPlug.FriendlyName + "\")]" );
         AddCSharpLine( "public void " + inputPlug.Name + "( " + args + " )" );
         AddCSharpLine( "{" );

         ++m_TabStack;

         PrintDebug( externalInput );

         //set all output links to false
         string []outputLinks = FindExternalOutputs( );

         foreach ( string s in outputLinks )
         {
            AddCSharpLine( s + " = false;" );
         }

         AddCSharpLine( "" );


         //transfer input args to our member variables
         Hashtable filledExternals = new Hashtable( );
         foreach ( ExternalConnection external in m_Script.Externals )
         {
            LinkNode []inputs = FindLinksBySource( external.Guid, external.Connection );

            foreach ( LinkNode link in inputs )
            {
               EntityNode parameterNode = m_Script.GetNode( link.Destination.Guid );

               foreach ( Parameter p in parameterNode.Parameters )
               {
                  if ( p.Name == link.Destination.Anchor )
                  {
                     AddCSharpLine( CSharpName(parameterNode, p.Name) + " = " + CSharpExternalParameterDeclaration(external.Name.Default).Name + ";" );
                     SyncReferencedGameObject( parameterNode, p );
                  }
               }

               if ( parameterNode.Instance.Name == link.Destination.Anchor )
               {
                  if ( false == filledExternals.Contains(external.Guid) )
                  {
                     AddCSharpLine( CSharpName(external) + " = " + CSharpExternalParameterDeclaration(external.Name.Default).Name + ";" );
                     filledExternals[ external.Guid ] = external;
                  }
               }
            }

            //external connections don't have a parameter
            //because they take on whatever parameter they link to
            Parameter parameter = new Parameter( );
            parameter.Name = external.Connection;
            RefreshSetProperties( external, new Parameter[] {parameter} );
         }

         foreach ( LinkNode.Connection connection in connections )
         {
            EntityNode node = m_Script.GetNode( connection.Guid );
            AddCSharpLine( CSharpRelay(node, connection.Anchor) + "( );" );
         }

         //transfer our member variables to the output args
         foreach ( ExternalConnection external in m_Script.Externals )
         {
            LinkNode []outputs = FindLinksByDestination( external.Guid, external.Connection );

            foreach ( LinkNode link in outputs )
            {
               EntityNode parameterNode = m_Script.GetNode( link.Source.Guid );

               foreach ( Parameter p in parameterNode.Parameters )
               {
                  if ( p.Name == link.Source.Anchor )
                  {
                     //external connections don't have a parameter
                     //because they take on whatever parameter they link to
                     Parameter parameter = new Parameter( );
                     parameter.Name = external.Connection;
                     parameter.Type = p.Type;
                     SyncSlaveConnections(external, new Parameter[]{ parameter } );

                     AddCSharpLine( CSharpExternalParameterDeclaration(external.Name.Default).Name + " = " + CSharpName(external, p.Name) + ";" );
                  }
               }

               //only one link allowed for each external parameter out
               break;
            }
         }

         --m_TabStack;

         AddCSharpLine( "}" );
         AddCSharpLine( "" );
      }

      //create the function which the event listener will call
      private void DefineLogicEvent( LogicNode logicNode, string eventName )
      {
         AddCSharpLine( "void " + CSharpEventDeclaration(logicNode, eventName) + "(object o, System.EventArgs e)" );
         AddCSharpLine( "{" );

         ++m_TabStack;

            AddCSharpLine( "//relay event to nodes" );
            AddCSharpLine( CSharpRelay(logicNode, eventName) + "( );" );

         --m_TabStack;

         AddCSharpLine( "}" );
         AddCSharpLine( "" );
      }

      //if we're hit we allow any outputs which were linked to us
      private void RelayToExternal( ExternalConnection external )
      {
         LinkNode [] links = FindLinksByDestination( external.Guid, external.Connection );

         foreach ( LinkNode link in links )
         {
            EntityNode node = m_Script.GetNode( link.Source.Guid );
         
            if ( node is EntityEvent ) 
            {
               EntityEvent entityEvent = (EntityEvent) node;

               foreach ( Plug output in entityEvent.Outputs )
               {
                  if ( link.Source.Anchor == output.Name )
                  {
                     AddCSharpLine( "if ( " + CSharpExternalEventDeclaration(external.Name.Default).Name + " != null )" );
                     AddCSharpLine( "{" );
                     ++m_TabStack;
                        AddCSharpLine( CSharpExternalEventDeclaration(external.Name.Default).Name + "( this, new System.EventArgs());" );
                     --m_TabStack;
                     AddCSharpLine( "}" );
                     break;
                  }
               }
            }
            else if ( node is EntityMethod ) 
            {
               EntityMethod entityMethod = (EntityMethod) node;

               if ( link.Source.Anchor == entityMethod.Output.Name )
               {
                  AddCSharpLine( CSharpExternalOutputDeclaration(external.Name.Default) + " = true;" );
               }
            }
            else if ( node is LogicNode ) 
            {
               LogicNode logic = (LogicNode) node;

               foreach ( Plug eventName in logic.Events )
               {
                  if ( link.Source.Anchor == eventName.Name )
                  {
                     AddCSharpLine( "if ( " + CSharpExternalEventDeclaration(external.Name.Default).Name + " != null )" );
                     AddCSharpLine( "{" );
                     ++m_TabStack;
                        AddCSharpLine( CSharpExternalEventDeclaration(external.Name.Default).Name + "( this, new System.EventArgs());" );
                     --m_TabStack;
                     AddCSharpLine( "}" );
                     break;
                  }
               }

               foreach ( Plug output in logic.Outputs )
               {
                  if ( link.Source.Anchor == output.Name )
                  {
                     AddCSharpLine( CSharpExternalOutputDeclaration(external.Name.Default) + " = true;" );
                     break;
                  }
               }
            }

            //only needs to set once, even if multiple nodes are connected to it
            //break;
         }
      }

      //define the function which our event listeners will call
      //when an entity event is triggered
      private void RelayToEvent( EntityEvent receiver, string eventName )
      {
         List<Parameter> outputList = new List<Parameter>( );

         //figure out where our outgoing links go
         //and set those variables directly
         foreach ( Parameter parameter in receiver.Parameters )
         {
            LinkNode []argLinks = FindLinksBySource( receiver.Guid, parameter.Name );

            foreach ( LinkNode link in argLinks )
            {
               EntityNode argNode = m_Script.GetNode( link.Destination.Guid );

               //set variable directly based on the last set event argument
               AddCSharpLine( CSharpName(argNode, link.Destination.Anchor) + " = " + CSharpName(receiver, parameter.Name) + ";" );
               outputList.Add( parameter );

               foreach ( Parameter p in argNode.Parameters )
               {
                  if ( p.Name == link.Destination.Anchor )
                  {
                     SyncReferencedGameObject( argNode, parameter );
                     break;
                  }
               }

               if ( argNode.Instance.Name == link.Destination.Anchor )
               {
                  SyncReferencedGameObject( argNode, argNode.Instance );
               }
            }
         }

         //force any potential entites affected to update
         RefreshSetProperties( receiver, outputList.ToArray( ) );

         //call anyone else connected to us
         CallRelays(receiver.Guid, eventName);
      }

      //define the function which a node will call if they're
      //triggering an entity method
      private void RelayToMethod( EntityMethod receiver )
      {
         //make sure any properties or variables connected to us are up to date
         SyncSlaveConnections( receiver, receiver.Parameters );

         Parameter returnParam = Parameter.Empty;
         string args = "";

         foreach ( Parameter parameter in receiver.Parameters )
         {
            if ( true == parameter.Input && true == parameter.Output )
            {
               args += "ref " + CSharpName(receiver, parameter.Name) + ", ";
            }
            else if ( true == parameter.Output )
            {
               if ( parameter.Name == "Return" )
               {
                  returnParam = parameter;
               }
               else
               {
                  args += "out " + CSharpName(receiver, parameter.Name) + ", ";
               }
            }
            else if ( true == parameter.Input )
            {
               args += CSharpName(receiver, parameter.Name) + ", ";
            }
         }

         if ( args != "" ) args = args.Substring( 0, args.Length - 2 );


         if ( false == receiver.IsStatic )
         {
            AddCSharpLine( receiver.ComponentType + " component;" );
   
            LinkNode []instanceLinks = FindLinksByDestination( receiver.Guid, receiver.Instance.Name );

            foreach ( LinkNode link in instanceLinks )
            {
               EntityNode node = m_Script.GetNode( link.Source.Guid );

               if ( returnParam != Parameter.Empty )
               {
                  AddCSharpLine( "component = " + CSharpName(node) + ".GetComponent<" + receiver.ComponentType + ">();" );
                  AddCSharpLine( "if ( null != component )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;

                     AddCSharpLine( CSharpName(receiver, returnParam.Name) + " = component." + receiver.Input.Name + "(" + args + ");" );                     

                  --m_TabStack;
                  AddCSharpLine( "}" );

                  //only one instance link supported because of the return parameter - this should be enforced
                  //in the editor - this is just for a sanity check
                  break;
               }
               else
               {
                  AddCSharpLine( "component = " + CSharpName(node) + ".GetComponent<" + receiver.ComponentType + ">();" );
                  AddCSharpLine( "if ( null != component )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;

                     AddCSharpLine( "component." + receiver.Input.Name + "(" + args + ");" );            

                  --m_TabStack;
                  AddCSharpLine( "}" );
               }
            }

            //only one instance because of the return parameter
            if ( receiver.Instance.Default != "" )
            {
               if ( returnParam != Parameter.Empty )
               {
                  //only one instance supported because of the return parameter - this should be enforced
                  //in the editor - this is just for a sanity check
                  if ( instanceLinks.Length == 0 )
                  {
                     AddCSharpLine( "component = " + CSharpName(receiver, receiver.Instance.Name) + ".GetComponent<" + receiver.ComponentType + ">();" );
                     AddCSharpLine( "if ( null != component )" );
                     AddCSharpLine( "{" );
                     ++m_TabStack;

                        AddCSharpLine( CSharpName(receiver, returnParam.Name) + " = component." + receiver.Input.Name + "(" + args + ");" );            

                     --m_TabStack;
                     AddCSharpLine( "}" );
                  }
               }
               else
               {
                  AddCSharpLine( "component = " + CSharpName(receiver, receiver.Instance.Name) + ".GetComponent<" + receiver.ComponentType + ">();" );
                  AddCSharpLine( "if ( null != component )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;

                     AddCSharpLine( "component." + receiver.Input.Name + "(" + args + ");" );            

                  --m_TabStack;
                  AddCSharpLine( "}" );
               }
            }
         }
         else //static static receiver
         {
            if ( returnParam != Parameter.Empty )
            {
               AddCSharpLine( CSharpName(receiver, returnParam.Name) + " = " + receiver.ComponentType + "." + receiver.Input.Name + "(" + args + ");" );            
            }
            else
            {
               AddCSharpLine( receiver.ComponentType + "." + receiver.Input.Name + "(" + args + ");" );            
            }
         }

         //push the output values
         //to all the links we connect out to
         foreach ( Parameter parameter in receiver.Parameters )
         {
            if ( false == parameter.Output ) continue;

            LinkNode []argLinks = FindLinksBySource( receiver.Guid, parameter.Name );

            foreach ( LinkNode link in argLinks )
            {
               EntityNode argNode = m_Script.GetNode( link.Destination.Guid );
               AddCSharpLine( CSharpName(argNode, link.Destination.Anchor) + " = " + CSharpName(receiver, parameter.Name) + ";" );

               foreach ( Parameter p in argNode.Parameters )
               {
                  if ( p.Name == link.Destination.Anchor )
                  {
                     SyncReferencedGameObject( argNode, parameter );
                     break;
                  }
               }

               if ( argNode.Instance.Name == link.Destination.Anchor )
               {
                  SyncReferencedGameObject( argNode, argNode.Instance );
               }
            }
         }

         //force any potential entites affected to update
         RefreshSetProperties( receiver, receiver.Parameters );

         //call anyone else connected to us
         CallRelays(receiver.Guid, receiver.Output.Name);
      }

      //are any relay functions connected to the point
      //defined in the source parameters
      private bool HasRelays(Guid guid, string name)
      {
         foreach ( LinkNode link in m_Script.Links )
         {
            if ( link.Source.Anchor == name &&
                 link.Source.Guid   == guid )
            {
               return true;
            }
         }

         return false;
      }

      //call any relay functions connected to the point
      //defined in the source parameters
      private void CallRelays(Guid guid, string name)
      {
         foreach ( LinkNode link in m_Script.Links )
         {
            if ( link.Source.Anchor == name &&
                 link.Source.Guid   == guid )
            {
               AddCSharpLine( CSharpRelay(m_Script.GetNode(link.Destination.Guid), link.Destination.Anchor) + "();" );
            }
         }
      }

      //define a function which a node will call if
      //they are connected to a logic node
      private void RelayToLogic( LogicNode receiver, string methodName )
      {
         Parameter returnParam = Parameter.Empty;
         string args = "";

         foreach ( Parameter parameter in receiver.Parameters )
         {
            if ( true == parameter.Input && true == parameter.Output )
            {
               args += "ref " + CSharpName(receiver, parameter.Name) + ", ";
            }
            else if ( true == parameter.Output )
            {
               if ( parameter.Name == "Return" )
               {
                  returnParam = parameter;
               }
               else
               {
                  args += "out " + CSharpName(receiver, parameter.Name) + ", ";
               }
            }
            else if ( true == parameter.Input )
            {
               args += CSharpName(receiver, parameter.Name) + ", ";
            }
         }

         if ( args != "" ) args = args.Substring( 0, args.Length - 2 );
         
         //make sure any properties or variables connected to us are up to date
         SyncSlaveConnections( receiver, receiver.Parameters );

         if ( returnParam != Parameter.Empty )
         {
            AddCSharpLine( CSharpName(receiver, returnParam.Name) + " = " + CSharpName(receiver, receiver.Type) + "." + methodName + "(" + args + ");" );            
         }
         else
         {
            AddCSharpLine( CSharpName(receiver, receiver.Type) + "." + methodName + "(" + args + ");" );            
         }

         //use previously saved temp variables to push the values
         //to all the links we connect out to
         foreach ( Parameter parameter in receiver.Parameters )
         {
            if ( false == parameter.Output ) continue;

            LinkNode []argLinks = FindLinksBySource( receiver.Guid, parameter.Name );

            foreach ( LinkNode link in argLinks )
            {
               EntityNode argNode = m_Script.GetNode( link.Destination.Guid );
               AddCSharpLine( CSharpName(argNode, link.Destination.Anchor) + " = " + CSharpName(receiver, parameter.Name) + ";" );

               foreach ( Parameter p in argNode.Parameters )
               {
                  if ( p.Name == link.Destination.Anchor )
                  {
                     SyncReferencedGameObject( argNode, parameter );
                     break;
                  }
               }

               if ( argNode.Instance.Name == link.Destination.Anchor )
               {
                  SyncReferencedGameObject( argNode, argNode.Instance );
               }
            }
         }

         //force any potential entites affected to update
         RefreshSetProperties( receiver, receiver.Parameters );

         AddCSharpLine( "" );
         AddCSharpLine( "//save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested" );

         int i = 0;

         //call anyone else connected to our outputs
         //if the result of the logic node has set our output to true
         foreach ( Plug output in receiver.Outputs )
         {
            if ( true == HasRelays(receiver.Guid, output.Name) )
            {
               AddCSharpLine( "bool test_" + (i++) + " = " + CSharpName(receiver, receiver.Type) + "." + output.Name + ";" );
            }
         }

         AddCSharpLine( "" );
         i = 0;

         //call anyone else connected to our outputs
         //if the result of the logic node has set our output to true
         foreach ( Plug output in receiver.Outputs )
         {
            if ( true == HasRelays(receiver.Guid, output.Name) )
            {
               AddCSharpLine( "if ( test_" + (i++) + " == true )" );
               AddCSharpLine( "{" );
               ++m_TabStack;
                  CallRelays(receiver.Guid, output.Name);
               --m_TabStack;
               AddCSharpLine( "}" );
            }
         }
      }

      //define a function which a node will if a logic node implements a 'driven' function
      private void DefineDriven( LogicNode receiver, string methodName )
      {
         string args = "";

         foreach ( Parameter parameter in receiver.Parameters )
         {
            //we don't allow refs or inputs on drivens
            //because uScript standard doesn't allow changing of input variables
            //without a pulse in
            if ( true == parameter.Output )
            {
               if ( parameter.Name == "Return" )
               {
                  //do nothing, there shouldn't be one for a driven node
               }
               else
               {
                  args += "out " + CSharpName(receiver, parameter.Name) + ", ";
               }
            }
         }

         if ( args != "" ) args = args.Substring( 0, args.Length - 2 );
         
         //make sure any properties or variables connected to us are up to date
         SyncSlaveConnections( receiver, receiver.Parameters );

         AddCSharpLine( CSharpName(receiver, methodName) + " = " + CSharpName(receiver, receiver.Type) + "." + methodName + "(" + args + ");" );            

         AddCSharpLine( "if ( true == " + CSharpName(receiver, methodName) + " )" );
         AddCSharpLine( "{" );
         ++m_TabStack;

            //use previously saved temp variables to push the values
            //to all the links we connect out to
            foreach ( Parameter parameter in receiver.Parameters )
            {
               if ( false == parameter.Output ) continue;

               LinkNode []argLinks = FindLinksBySource( receiver.Guid, parameter.Name );

               foreach ( LinkNode link in argLinks )
               {
                  EntityNode argNode = m_Script.GetNode( link.Destination.Guid );
                  AddCSharpLine( CSharpName(argNode, link.Destination.Anchor) + " = " + CSharpName(receiver, parameter.Name) + ";" );

                  foreach ( Parameter p in argNode.Parameters )
                  {
                     if ( p.Name == link.Destination.Anchor )
                     {
                        SyncReferencedGameObject( argNode, parameter );
                        break;
                     }
                  }

                  if ( argNode.Instance.Name == link.Destination.Anchor )
                  {
                     SyncReferencedGameObject( argNode, argNode.Instance );
                  }
               }
            }

            //force any potential entites affected to update
            RefreshSetProperties( receiver, receiver.Parameters );

            //call anyone else connected to our outputs
            //if the result of the logic node has set our output to true
            foreach ( Plug output in receiver.Outputs )
            {
               if ( true == HasRelays(receiver.Guid, output.Name) )
               {
                  AddCSharpLine( "if ( " + CSharpName(receiver, receiver.Type) + "." + output.Name + " == true )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;
                     CallRelays(receiver.Guid, output.Name);
                  --m_TabStack;
                  AddCSharpLine( "}" );
               }
            }

         --m_TabStack;
         AddCSharpLine( "}" );
      }
      
      
      //define functions which get called by node connections
      private void DefineRelay( EntityNode receiver )
      {
         //no relays, these are only containers
         if ( receiver is LocalNode )        return;
         if ( receiver is EntityProperty )   return;

         if ( receiver is EntityMethod )
         {
            AddCSharpLine( "void " + CSharpRelay(receiver, ((EntityMethod)receiver).Input.Name) + "()" );
            AddCSharpLine( "{" );

            ++m_TabStack;

               if ( true == m_GenerateDebugInfo )
               {
                  AddCSharpLine( "if ( relayCallCount++ < MaxRelayCallCount )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;

                     PrintDebug( receiver );
                     RelayToMethod( (EntityMethod) receiver );

                  --m_TabStack;
                  AddCSharpLine( "}" );
                  AddCSharpLine( "else" );               
                  AddCSharpLine( "{" );
                  ++m_TabStack;

                     AddCSharpLine( "uScriptDebug.Log( \"Possible infinite loop detected in uScript " + m_Script.Name + " at " + ((EntityMethod)receiver).ComponentType + ".  " +
                                    "If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.\", uScriptDebug.Type.Error);" );

                  --m_TabStack;
                  AddCSharpLine( "}" );
               }
               else
               {
                  RelayToMethod( (EntityMethod) receiver );
               }

            --m_TabStack;

            AddCSharpLine( "}" );
            AddCSharpLine( "" );
         }
         if ( receiver is EntityEvent ) 
         {
            EntityEvent entityEvent = (EntityEvent) receiver;

            foreach ( Plug eventName in entityEvent.Outputs )
            {
               AddCSharpLine( "void " + CSharpRelay(receiver, eventName.Name) + "()" );
               AddCSharpLine( "{" );

               ++m_TabStack;

                  if ( true == m_GenerateDebugInfo )
                  {
                     //no need to wrap call count checking
                     //because this is an event coming in from Unity
                     PrintDebug( receiver );
                     RelayToEvent( entityEvent, eventName.Name );
                  }
                  else
                  {
                     RelayToEvent( entityEvent, eventName.Name );
                  }

               --m_TabStack;

               AddCSharpLine( "}" );
               AddCSharpLine( "" );
            }
         }
         if ( receiver is ExternalConnection )
         {
            ExternalConnection external = (ExternalConnection) receiver;

            AddCSharpLine( "void " + CSharpRelay(receiver, external.Connection) + "()" );
            AddCSharpLine( "{" );

            ++m_TabStack;

               if ( true == m_GenerateDebugInfo )
               {
                  AddCSharpLine( "if ( relayCallCount++ < MaxRelayCallCount )" );
                  AddCSharpLine( "{" );
                  ++m_TabStack;

                     PrintDebug( receiver );
                     RelayToExternal( external );

                  --m_TabStack;
                  AddCSharpLine( "}" );
                  AddCSharpLine( "else" );               
                  AddCSharpLine( "{" );
                  ++m_TabStack;

                     AddCSharpLine( "uScriptDebug.Log( \"Possible infinite loop detected in uScript " + m_Script.Name + " at " + external.Name.Default + ".  " + 
                                    "If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.\", uScriptDebug.Type.Error);" );
                  --m_TabStack;
                  AddCSharpLine( "}" );
               }
               else
               {
                  RelayToExternal( external );
               }
               
            --m_TabStack;

            AddCSharpLine( "}" );
            AddCSharpLine( "" );
         }
         if ( receiver is LogicNode ) 
         {
            LogicNode logicNode = (LogicNode) receiver;

            foreach ( Plug eventName in logicNode.Events )
            {
               AddCSharpLine( "void " + CSharpRelay(receiver, eventName.Name) + "()" );
               AddCSharpLine( "{" );

               ++m_TabStack;

                  if ( true == m_GenerateDebugInfo )
                  {
                     AddCSharpLine( "if ( relayCallCount++ < MaxRelayCallCount )" );
                     AddCSharpLine( "{" );
                     ++m_TabStack;

                        PrintDebug( receiver );                  
                        CallRelays(receiver.Guid, eventName.Name);

                     --m_TabStack;
                     AddCSharpLine( "}" );
                     AddCSharpLine( "else" );               
                     AddCSharpLine( "{" );
                     ++m_TabStack;

                        AddCSharpLine( "uScriptDebug.Log( \"Possible infinite loop detected in uScript " + m_Script.Name + " at " + logicNode.FriendlyName + ".  " + 
                                       "If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.\", uScriptDebug.Type.Error);" );
                     --m_TabStack;
                     AddCSharpLine( "}" );
                  }
                  else
                  {
                     CallRelays(receiver.Guid, eventName.Name);
                  }

               --m_TabStack;

               AddCSharpLine( "}" );
               AddCSharpLine( "" );
            }

            foreach ( Plug input in logicNode.Inputs )
            {
               AddCSharpLine( "void " + CSharpRelay(receiver, input.Name) + "()" );
               AddCSharpLine( "{" );

               ++m_TabStack;

                  if ( true == m_GenerateDebugInfo )
                  {
                     AddCSharpLine( "if ( relayCallCount++ < MaxRelayCallCount )" );
                     AddCSharpLine( "{" );
                     ++m_TabStack;

                        PrintDebug(receiver);                  
                        RelayToLogic((LogicNode)receiver, input.Name);

                     --m_TabStack;
                     AddCSharpLine( "}" );
                     AddCSharpLine( "else" );               
                     AddCSharpLine( "{" );
                     ++m_TabStack;

                        AddCSharpLine( "uScriptDebug.Log( \"Possible infinite loop detected in uScript " + m_Script.Name + " at " + logicNode.FriendlyName + ".  " + 
                                       "If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.\", uScriptDebug.Type.Error);" );
                     --m_TabStack;
                     AddCSharpLine( "}" );
                  }
                  else
                  {
                     RelayToLogic((LogicNode)receiver, input.Name);
                  }

               --m_TabStack;

               AddCSharpLine( "}" );
               AddCSharpLine( "" );
            }

            foreach ( string driven in logicNode.Drivens )
            {
               AddCSharpLine( "void " + CSharpRelay(logicNode, driven) + "( )" );
               AddCSharpLine( "{" );
               ++m_TabStack;

                  if ( true == m_GenerateDebugInfo )
                  {
                     AddCSharpLine( "if ( relayCallCount++ < MaxRelayCallCount )" );
                     AddCSharpLine( "{" );
                     ++m_TabStack;

                        DefineDriven( logicNode, driven );

                     --m_TabStack;
                     AddCSharpLine( "}" );
                     AddCSharpLine( "else" );               
                     AddCSharpLine( "{" );
                     ++m_TabStack;

                        AddCSharpLine( "uScriptDebug.Log( \"Possible infinite loop detected in uScript " + m_Script.Name + " at " + logicNode.FriendlyName + ".  " + 
                                       "If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.\", uScriptDebug.Type.Error);" );
                     --m_TabStack;
                     AddCSharpLine( "}" );
                  }
                  else
                  {
                     DefineDriven( logicNode, driven );
                  }

               --m_TabStack;
               AddCSharpLine( "}" );
            }
         }
      }

      private void AddCSharpLine( string CSharpScript )
      {
         for ( int i = 0; i < m_TabStack; i++ )
         {
            m_CSharpString += "   ";
         }

         m_CSharpString += CSharpScript + "\r\n";
      }

      private string PreviousName(EntityNode entityNode)
      {
         return PreviousName(entityNode, "Default");
      }

      private string PreviousName(EntityNode entityNode, string parameterName)
      {
         return CSharpName(entityNode, parameterName) + "_previous";
      }

      private string CSharpName(EntityNode entityNode)
      {
         return CSharpName( entityNode, "Default" );
      }

      //create unique CSharp name based on id, etc.
      private string CSharpName(EntityNode entityNode, string parameterName)
      {
         string name = "";

         int guidId = GetGuidId( entityNode.Guid );

         if ( entityNode is EntityEvent )
         {
            EntityEvent entityEvent = (EntityEvent) entityNode;
            name = "event_" + entityEvent.Instance.Type + "_" + parameterName + "_" + guidId;
         }
         else if ( entityNode is EntityMethod )
         {
            EntityMethod entityMethod = (EntityMethod) entityNode;
            name = "method_" + entityMethod.Input + "_" + entityMethod.Instance.Type + "_" + parameterName + "_" + guidId;
         }
         else if ( entityNode is EntityProperty )
         {
            EntityProperty entityProperty = (EntityProperty) entityNode;
            name = "property_" + entityProperty.Parameter.Name + "_" + entityProperty.Instance + "_" + parameterName + "_" + guidId;
         }
         else if ( entityNode is LocalNode )
         {
            LocalNode local = (LocalNode) entityNode;

            name = "local_" + local.Name.Default + "_" + local.Value.Type;
            name = name.Replace( "[]", "Array" );
         }
         else if ( entityNode is OwnerConnection )
         {
            OwnerConnection owner = (OwnerConnection) entityNode;

            name = "owner_" + owner.Connection.Name + "_" + guidId;
            name = name.Replace( "[]", "Array" );
         }
         else if ( entityNode is ExternalConnection )
         {
            name = "external_" + guidId;
            name = name.Replace( "[]", "Array" );
         }
         else if ( entityNode is LogicNode )
         {
            LogicNode logicNode = (LogicNode) entityNode;
            name = "logic_" + logicNode.Type + "_" + parameterName + "_" + guidId;
         }
         else
         {
            throw new Exception( "CSharp GENERATION ERROR - UNKNOWN TYPE " + entityNode.GetType( ).ToString( ) );
         }

         name = name.Replace( "+", "." );

         return MakeSyntaxSafe( name );
      }

      private string FormatType(string type)
      {
         return type.Replace( "+", "." );
      }

      public static string EscapeString(string s)
      {
         //escape backslashes
         s = s.Replace( "\\", "\\\\" );
         //escape quotes
         s = s.Replace( "\"", "\\\"");
         //newline
         s = s.Replace( "\n", "\\n");
         //carriage return
         s = s.Replace( "\r", "\\r");
      
         return s;
      }

      public static string MakeSyntaxSafe(string s)
      {
	      bool isSafe;
         return MakeSyntaxSafe(s, out isSafe);
      }

	   public static string MakeSyntaxSafe(string s, out bool isSafe)
      {
         string typeSafe = "";
         int count = 0;
         isSafe = true;

         foreach ( char c in s )
         {
            if ( c >= 'A' && c <= 'Z' ||
                 c >= 'a' && c <= 'z' ||
                 c == '_'             ||
               ( c >= '0' && c <= '9' && count > 0 ) )
            {
               typeSafe += c;
            }
            else
            {
               typeSafe += "_";
			      isSafe = false;
            }
				
            count++;
         }
      
         return typeSafe;
      }
      
      //int representation of the guid
      private int GetGuidId( Guid guid )
      {
         if ( false == m_GuidToId.Contains(guid) )
         {
            m_GuidToId[ guid ] = m_GuidToId.Values.Count;
         }

         return (int) m_GuidToId[ guid ];
      }

      //create unique CSharp function names based on entity node information
      private string CSharpRelay(EntityNode receiver, string methodName)
      {
         int guidId = GetGuidId( receiver.Guid );

         string name = "Relay_" + methodName + "_" + guidId;
         name = name.Replace( ' ', '_' );
         name = name.Replace( '-', '_' );

         return name;
      }

      //register event listener function with an entity
      private void AddEventListener( string eventVariable, EntityEvent entityEvent, bool add )
      {
         string operation = add ? " += " : " -= "; 

         if ( true == entityEvent.IsStatic )
         {
            foreach ( Plug output in entityEvent.Outputs )
            {
               AddCSharpLine( entityEvent.ComponentType + "." + output.Name + operation + CSharpEventDeclaration(entityEvent, output.Name) + ";" );            
            }
         }
         else
         {
            //if we're setting up a new event which is not a gui listener
            //or if we're removing the events, see if there is an existing one matching the name first
            if ( entityEvent.ComponentType != "uScript_GUI" )
            {
               AddCSharpLine( entityEvent.ComponentType + " component = " + eventVariable + ".GetComponent<" + entityEvent.ComponentType + ">();" );
               AddMissingComponent( "component", eventVariable, entityEvent.ComponentType ); 
            }
            else
            {
               AddCSharpLine( "if ( null == " + OnGuiListenerName( ) + " )" );
               AddCSharpLine( "{" );
               ++m_TabStack;

                  AddCSharpLine( "//OnGUI need unique listeners so calls like GUI.depth will work across uScripts" );
                  AddCSharpLine( OnGuiListenerName( ) + " = " + eventVariable + ".AddComponent<" + entityEvent.ComponentType + ">();" );
               
               --m_TabStack;
               AddCSharpLine( "}" );

               AddCSharpLine( entityEvent.ComponentType + " component = " + OnGuiListenerName( ) + ";" );
            }
            AddCSharpLine( "if ( null != component )" );
            AddCSharpLine( "{" );
            ++m_TabStack;
            
               foreach ( Plug output in entityEvent.Outputs )
               {
                  AddCSharpLine( "component." + output.Name + operation + CSharpEventDeclaration(entityEvent, output.Name) + ";" );            
               }

            --m_TabStack;
            AddCSharpLine( "}" );
         }
      }

      //register event listener function with an entity
      private void AddLogicEventListener( LogicNode logicNode, string eventName )
      {
         AddCSharpLine( CSharpName(logicNode, logicNode.Type) + "." + eventName + " += "+ CSharpEventDeclaration(logicNode, eventName) + ";" );            
      }

      //unique function name per entity property to get
      private string CSharpRefreshGetPropertyDeclaration(EntityProperty entityProperty)
      {
         return CSharpName(entityProperty, entityProperty.Parameter.Name) + "_Get_Refresh";
      }

      //unique function name per entity property to set
      private string CSharpRefreshSetPropertyDeclaration(EntityProperty entityProperty)
      {
         return CSharpName(entityProperty, entityProperty.Parameter.Name) + "_Set_Refresh";
      }

      private string CSharpSyncUnityHooksDeclaration( )
      {
         return "SyncUnityHooks( )";
      }

      private string CSharpSyncEventListenersDeclaration( )
      {
         return "SyncEventListeners( )";
      }

      private string CSharpExternalDriven(EntityNode node, string name)
      {
         return name + "_" + GetGuidId(node.Guid);
      }

      //we can't query unity base classes for possibly external connection
      //name ocnflicts because unity uses reflection to call and not true base calsses
      //so i have a manual list here of methods which are external inputs should not be called
      private string RemoveReflectionConflicts( string methodName )
      {
         if ( methodName == "OnDestroy" )   return "_" + methodName;
         if ( methodName == "OnDisable" )   return "_" + methodName;
         if ( methodName == "OnEnable" )    return "_" + methodName;
         if ( methodName == "Start" )       return "_" + methodName;
         if ( methodName == "Update" )      return "_" + methodName;
         if ( methodName == "LateUpdate" )  return "_" + methodName;
         if ( methodName == "FixedUpdate" ) return "_" + methodName;
         if ( methodName == "OnGUI" )       return "_" + methodName;
         if ( methodName == "Awake" )       return "_" + methodName;

         return methodName;
      }

      private Plug CSharpExternalInputDeclaration(string defaultName)
      {
         Plug plug;

         plug.FriendlyName = defaultName;
         
         //use friendlyname as external name
         //so the name stays the same even if they reorder the nodes
         //this prevents links from breaking in the parent scripts
         string methodName = MakeSyntaxSafe(plug.FriendlyName);

         //make sure it doesn't conflict with any known unity reflected calls
         methodName = RemoveReflectionConflicts( methodName );

         plug.Name = methodName;

         return plug;
      }

      private Plug CSharpExternalParameterDeclaration(string defaultName)
      {
         Plug plug;

         plug.FriendlyName = defaultName;
         
         //use friendlyname as external name
         //so the name stays the same even if they reorder the nodes
         //this prevents links from breaking in the parent scripts
         plug.Name = MakeSyntaxSafe(plug.FriendlyName);

         return plug;
      }

      private Plug CSharpExternalOutputPropertyDeclaration(string defaultName)
      {
         Plug plug;

         plug.FriendlyName = defaultName;

         //use friendlyname as external name
         //so the name stays the same even if they reorder the nodes
         //this prevents links from breaking in the parent scripts
         plug.Name = MakeSyntaxSafe(plug.FriendlyName);

         return plug;
      }
   
      private string CSharpExternalOutputDeclaration(string defaultName)
      {
         return "output_Link_" + MakeSyntaxSafe(defaultName);
      }

      private Plug CSharpExternalEventDeclaration(string defaultName)
      {
         Plug plug;

         plug.FriendlyName = defaultName;
         //use friendlyname as external name
         //so the name stays the same even if they reorder the nodes
         //this prevents links from breaking in the parent scripts
         plug.Name = MakeSyntaxSafe(plug.FriendlyName);

         return plug;
      }

      //unique function name per entity event to receive
      private string CSharpEventDeclaration(EntityEvent entityEvent, string output)
      {
         return entityEvent.Instance.Name + "_" + output + "_" + GetGuidId(entityEvent.Guid);
      }

      //unique function name per entity event to receive
      private string CSharpEventDeclaration(LogicNode logicNode, string eventName)
      {
         return FormatType(logicNode.Type) + "_" + eventName + "_" + GetGuidId(logicNode.Guid);
      }

      //have any non-triggable nodes (properties, local variables)
      //write themselves to the input parameters for the node passed into this method
      private void SyncSlaveConnections( EntityNode node, Parameter [] parameters )
      {
         AddCSharpLine( "{" );
         ++m_TabStack;

         string currentCode = SetCode( "" );

         bool needsProperties = false;
         bool needsIndex = false;

         foreach ( Parameter parameter in parameters )
         {
            bool needsPropertiesCleared = false;
            bool needsIndexCleared = false;

            string nestedCode = SetCode( "" );

            //get all the links hooked to the input on this node
            LinkNode []links = FindLinksByDestination( node.Guid, parameter.Name );
            if ( links.Length == 0 )
            {
               //no links? then they've specified
               //a default parmaeter so make sure that is hooked up
               SyncReferencedGameObject( node, parameter );
            }

            //if the input parameter is an array
            //we need to place all source node values into the array
            if ( parameter.Type.Contains("[]") )
            {
               foreach ( LinkNode link in links )
               {
                  EntityNode argNode = m_Script.GetNode( link.Source.Guid );
                  
                  //check to see if any source nodes are local variables
                  if ( argNode is LocalNode )
                  {
                     LocalNode localNode = (LocalNode) argNode;
                     SyncReferencedGameObject( argNode, localNode.Value );
                     
                     //if the local variable is an array then we need to copy the array
                     //to the next available index of the input parameter
                     if ( localNode.Value.Type.Contains("[]") )
                     {
                        AddCSharpLine( "properties = " + CSharpName(argNode) + ";" );

                        //make sure our input array is large enough to hold the array we're copying into it
                        AddCSharpLine( "if ( " + CSharpName(node, parameter.Name) + ".Length != index + properties.Length)" );
                        AddCSharpLine( "{" );
                        ++m_TabStack;
                           AddCSharpLine( "System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + properties.Length);" );
                        --m_TabStack;
                        AddCSharpLine( "}" );

                        //copy the source node array into the input parameter array
                        AddCSharpLine( "System.Array.Copy(properties, 0, " + CSharpName(node, parameter.Name) + ", index, properties.Length);" );
                        AddCSharpLine( "index += properties.Length;" );
                        AddCSharpLine( "" );

                        needsProperties = true;
                        needsIndex = true;

                        needsPropertiesCleared = true;
                        needsIndexCleared = true;

                     }
                     else
                     {
                        //make sure our input array is large enough to hold another value
                        AddCSharpLine( "if ( " + CSharpName(node, parameter.Name) + ".Length <= index)" );
                        AddCSharpLine( "{" );
                        ++m_TabStack;
                           AddCSharpLine( "System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + 1);" );
                        --m_TabStack;
                        AddCSharpLine( "}" );

                        //copy the source node value into the input parameter array
                        AddCSharpLine( CSharpName(node, parameter.Name) + "[ index++ ] = " + CSharpName(argNode) + ";" );
                        AddCSharpLine( "" );

                        needsIndex = true;
                        needsIndexCleared = true;
                     }
                  }

                  //check to see if any source nodes are local variables
                  if ( argNode is OwnerConnection )
                  {
                     //make sure our input array is large enough to hold another value
                     AddCSharpLine( "if ( " + CSharpName(node, parameter.Name) + ".Length <= index)" );
                     AddCSharpLine( "{" );
                     ++m_TabStack;
                        AddCSharpLine( "System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + 1);" );
                     --m_TabStack;
                     AddCSharpLine( "}" );

                     //copy the source node value into the input parameter array
                     AddCSharpLine( CSharpName(node, parameter.Name) + "[ index++ ] = " + CSharpName(argNode) + ";" );
                     AddCSharpLine( "" );

                     needsIndex = true;
                     needsIndexCleared = true;
                  }

                  //check to see if any source nodes are property nodes
                  else if ( argNode is EntityProperty )
                  {
                     EntityProperty entityProperty = (EntityProperty) argNode;
                     
                     if ( true == entityProperty.Parameter.Output )
                     {   
                        SyncReferencedGameObject( argNode, entityProperty.Parameter );

                        //if the property variable is an array then we need to copy the array
                        //to the next available index of the input parameter
                        if ( entityProperty.Parameter.Type.Contains("[]") )
                        {
                           AddCSharpLine( "properties = " + CSharpRefreshGetPropertyDeclaration( entityProperty ) + "( );" );

                           //make sure our input array is large enough to hold the array we're copying into it
                           AddCSharpLine( "if ( " + CSharpName(node, parameter.Name) + ".Length != index + properties.Length)" );
                           AddCSharpLine( "{" );
                           ++m_TabStack;
                              AddCSharpLine( "System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + properties.Length);" );
                           --m_TabStack;
                           AddCSharpLine( "}" );

                           AddCSharpLine( "System.Array.Copy(properties, 0, " + CSharpName(node, parameter.Name) + ", index, properties.Length);" );
                           AddCSharpLine( "index += properties.Length;" );
                           AddCSharpLine( "" );

                           needsProperties = true;
                           needsIndex = true;
                           needsPropertiesCleared = true;
                           needsIndexCleared = true;
                        }
                        else
                        {
                           //make sure our input array is large enough to hold another value
                           AddCSharpLine( "if ( " + CSharpName(node, parameter.Name) + ".Length <= index)" );
                           AddCSharpLine( "{" );
                           ++m_TabStack;
                              AddCSharpLine( "System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + 1);" );
                           --m_TabStack;
                           AddCSharpLine( "}" );

                           //copy the source node value into the input parameter array
                           AddCSharpLine( CSharpName(node, parameter.Name) + "[ index++ ] = " + CSharpRefreshGetPropertyDeclaration( entityProperty ) + "( );" );
                           AddCSharpLine( "" );

                           needsIndex = true;
                           needsIndexCleared = true;
                        }
                     }
                  }
               }
            }
            else
            {
               foreach ( LinkNode link in links )
               {
                  EntityNode argNode = m_Script.GetNode( link.Source.Guid );
                  
                  //if any of those links is a local node
                  //we need to write the line for the property to refresh
                  if ( argNode is LocalNode || argNode is OwnerConnection )
                  {
                     if ( argNode is LocalNode )
                     {
                        LocalNode localNode = (LocalNode) argNode;
                        SyncReferencedGameObject( localNode, localNode.Value );
                     }

                     AddCSharpLine( CSharpName(node, parameter.Name) + " = " + CSharpName(argNode) + ";" );
                     AddCSharpLine( "" );
                  }

                  //if any of those links is a property node
                  //we need to write the line for the property to refresh
                  else if ( argNode is EntityProperty )
                  {
                     EntityProperty entityProperty = (EntityProperty) argNode;

                     if ( true == entityProperty.Parameter.Output )
                     {
                        SyncReferencedGameObject( entityProperty, entityProperty.Parameter );

                        AddCSharpLine( CSharpName(node, parameter.Name) + " = " + CSharpRefreshGetPropertyDeclaration( entityProperty ) + "( );" );
                        AddCSharpLine( "" );
                     }
                  }
               }
            }

            string newNestedCode = SetCode( nestedCode );

            if ( newNestedCode != "" )
            {
               if ( true == needsIndexCleared ) AddCSharpLine( "index = 0;" );
               if ( true == needsPropertiesCleared ) AddCSharpLine( "properties = null;" );
            
               m_CSharpString += newNestedCode;
            }
         }

         string newCode = SetCode( currentCode );

         if ( newCode != "" )
         {
            if ( true == needsIndex ) AddCSharpLine( "int index;" );
            if ( true == needsProperties ) AddCSharpLine( "System.Array properties;" );

            m_CSharpString += newCode;
         }

         --m_TabStack;
         AddCSharpLine( "}" );
      }
   
      private void SyncReferencedGameObject( EntityNode node, Parameter parameter )
      {
         string currentCode = SetCode( "" );
         
         ++m_TabStack;
            FillComponent( node, parameter );
         --m_TabStack;

         string newCode = SetCode( currentCode );

         if ( newCode != "" )
         {
            AddCSharpLine( "{" );
            
               m_CSharpString += newCode;

            AddCSharpLine( "}" );
         }
      }

      private string OnGuiListenerName( ) { return "thisScriptsOnGuiListener"; }

      //go through and tell all the property linked to us to update their entity's values
      //because we could have modified the CSharp representation
      private void RefreshSetProperties( EntityNode node, Parameter [] parameters )
      {
         //make sure all components we plan to reference
         //have been placed in their local variables
         foreach ( Parameter parameter in parameters )
         {
            //get all the links which go out from the output on this node
            LinkNode [] links = FindLinksBySource( node.Guid, parameter.Name );
            
            foreach ( LinkNode link in links )
            {
               //if any of those links goes to a property node
               //we need to write the line for the property to refresh
               EntityNode argNode = m_Script.GetNode( link.Destination.Guid );
               
               if ( argNode is EntityProperty )
               {
                  EntityProperty property = (EntityProperty) argNode;

                  if ( true == property.Parameter.Input )
                  {
                     SyncReferencedGameObject( property, property.Parameter );
                     AddCSharpLine( CSharpRefreshSetPropertyDeclaration( property ) + "( );" );
                  }
               }
            }
         }
      }

      //helper function to find links which link to a specific destination point
      private LinkNode []FindLinksByDestination(Guid destination, string name)
      {
         List<LinkNode> links = new List<LinkNode>( );

         foreach ( LinkNode link in m_Script.Links )
         {
            if ( link.Destination.Guid   == destination &&
                 link.Destination.Anchor == name )
            {
               links.Add( link );
            }
         }

         return links.ToArray( );
      }

      //helper function to find links which link to a specific source point
      private LinkNode[] FindLinksBySource(Guid source, string name)
      {
         List<LinkNode> links = new List<LinkNode>( );

         foreach ( LinkNode link in m_Script.Links )
         {
            if ( link.Source.Guid   == source &&
                 link.Source.Anchor == name )
            {
               links.Add( link );
            }
         }

         return links.ToArray( );
      }

      private void PrintDebug(EntityNode node)
      {
         if ( true == m_GenerateDebugInfo )
         {
            if ( "true" == node.ShowComment.Default )
            {
               AddCSharpLine( "uScriptDebug.Log( \"[" + uScriptConfig.Variable.FriendlyName(node.GetType().ToString()) + "] " + EscapeString(node.Comment.Default) + "\", uScriptDebug.Type.Message);" );
            }
         }
      }
   }
}
