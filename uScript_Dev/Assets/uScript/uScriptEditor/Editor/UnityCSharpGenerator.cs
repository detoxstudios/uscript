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
      private string       m_CSharpString;
      private int          m_TabStack;
      private Hashtable    m_GuidToId = new Hashtable( );
      private ScriptEditor m_Script = null;

      private void Preprocess( )
      {
         //prune out unused nodes (nodes which have no links)
         
         //first prune out any nodes which dont' have valid instances
         foreach ( EntityNode entityNode in m_Script.EntityNodes )
         {
            //if it doesn't need an instance, don't worry about finding one
            if ( false == entityNode is EntityProperty &&
                 false == entityNode is EntityEvent &&
                 false == entityNode is EntityMethod ) continue;


            //an instance set in the property grid?
            if ( entityNode.Instance.Default != "" ) continue;
      
            bool includeNode = false;

            //how about an instance linked to it?
            LinkNode []instanceLinks = FindLinksByDestination( entityNode.Guid, entityNode.Instance.Name );
            
            foreach ( LinkNode link in instanceLinks )
            {
               LocalNode node = (LocalNode) m_Script.GetNode( link.Source.Guid );

               if ( node.Instance.Default != "" )
               {
                  includeNode = true;
                  break;
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

               uScriptDebug.Log( "Node " + name + " is being pruned because there is no GameObject instance assigned to it", uScriptDebug.Type.Warning );

               m_Script.RemoveNode( entityNode );
            }
         }

         //now that we have removed all the nodes
         //which don't have valid instances assigned
         //lets remove any nodes which don't have links to them
         
         //track all the link source / destination nodes
         Hashtable usedNodes = new Hashtable( );

         foreach ( LinkNode link in m_Script.Links )
         {
            usedNodes[ link.Source.Guid ] = true;
            usedNodes[ link.Destination.Guid ] = true;
            usedNodes[ link.Guid ] = true;
         }

         //pruen any nodes which aren't linked
         foreach ( EntityNode entityNode in m_Script.EntityNodes )
         {
            if ( false == usedNodes.Contains(entityNode.Guid) )
            {
               m_Script.RemoveNode( entityNode );
            }
         }

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
         m_CSharpString = "";
         m_TabStack = 0;

         m_Script = null;

         if ( null != script )
         {
            m_Script = script.Copy( );

            DeclareNamespaces( );
            AddCSharpLine( "" );

            AddCSharpLine( "public class " + System.IO.Path.GetFileNameWithoutExtension(script.Name) + " : uScriptCode" );
            AddCSharpLine( "{" );
            ++m_TabStack;

               AddCSharpLine( "#pragma warning disable 414" );
               AddCSharpLine( logicClassName + " uScript; ");
               AddCSharpLine( "#pragma warning restore 414" );
            
               AddCSharpLine( "" );

               AddCSharpLine( "void Awake( )" );
               AddCSharpLine( "{" );
               ++m_TabStack;

                  AddCSharpLine( "uScript = ScriptableObject.CreateInstance(typeof(" + logicClassName + ")) as " + logicClassName + ";" );

               --m_TabStack;
               AddCSharpLine( "}" );
            
               AddCSharpLine( "void Update( )" );
               AddCSharpLine( "{" );
               ++m_TabStack;
            
                  AddCSharpLine( "uScript.Update( );" );
            
               --m_TabStack;
               AddCSharpLine( "}" );

               AddCSharpLine( "void LateUpdate( )" );
               AddCSharpLine( "{" );
               ++m_TabStack;
            
                  AddCSharpLine( "uScript.LateUpdate( );" );
            
               --m_TabStack;
               AddCSharpLine( "}" );

               AddCSharpLine( "void FixedUpdate( )" );
               AddCSharpLine( "{" );
               ++m_TabStack;
            
                  AddCSharpLine( "uScript.FixedUpdate( );" );
            
               --m_TabStack;
               AddCSharpLine( "}" );

               AddCSharpLine( "void OnGUI( )" );
               AddCSharpLine( "{" );
               ++m_TabStack;
            
                  AddCSharpLine( "uScript.OnGUI( );" );
            
               --m_TabStack;
               AddCSharpLine( "}" );

            --m_TabStack;
            AddCSharpLine( "}" );
         }

         return m_CSharpString;
      }

      public string GenerateLogicScript(string logicClassName, ScriptEditor script)
      {
         m_CSharpString = "";
         m_TabStack = 0;

         m_Script = null;

         if ( null != script )
         {
            m_Script = script.Copy( );

            Preprocess( );

            DeclareNamespaces( );
            AddCSharpLine( "" );

            BeginLogicClass( logicClassName );
            AddCSharpLine( "" );

            ++m_TabStack;
               DeclareMemberVariables( );
               AddCSharpLine( "" );

               SetupProperties( );
               AddCSharpLine( "" );
               DefineFillComponents( );
               AddCSharpLine( "" );
               
               AddCSharpLine( "public void Awake()" );
               AddCSharpLine( "{" );

               ++m_TabStack;
                  DefineInitialization( );
               --m_TabStack;

               AddCSharpLine( "}" );
               AddCSharpLine( "" );
               
               AddCSharpLine( "public override void Update()" );
               AddCSharpLine( "{" );

               ++m_TabStack;
                  DefineUpdate( );
               --m_TabStack;

               AddCSharpLine( "}" );
               AddCSharpLine( "" );

               AddCSharpLine( "public override void LateUpdate()" );
               AddCSharpLine( "{" );

               ++m_TabStack;
                  DefineLateUpdate( );
               --m_TabStack;

               AddCSharpLine( "}" );
               AddCSharpLine( "" );

               AddCSharpLine( "public override void FixedUpdate()" );
               AddCSharpLine( "{" );

               ++m_TabStack;
                  DefineFixedUpdate( );
               --m_TabStack;

               AddCSharpLine( "}" );
               AddCSharpLine( "" );

               AddCSharpLine( "public override void OnGUI()" );
               AddCSharpLine( "{" );

               ++m_TabStack;
                  DefineOnGUI( );
               --m_TabStack;

               AddCSharpLine( "}" );
               AddCSharpLine( "" );

               AddCSharpLine( "public void OnDestroy()" );
               AddCSharpLine( "{" );
               ++m_TabStack;
                  DefineOnDestroy( );
               --m_TabStack;
               AddCSharpLine( "}" );

               DefineEvents( );
            --m_TabStack;
            
            EndClass( );
         }

         return m_CSharpString;
      }  
 
      private void DeclareNamespaces( )
      {
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
            if ( entityProperty.Instance.Default != "" )
            {
               if ( true == entityProperty.Parameter.Output )
               {
                  //as stated above, cretae a function which 
                  //gets the property from the entity and sets the corresponding CSharp variable
                  AddCSharpLine( entityProperty.Parameter.Type + " " + CSharpRefreshGetPropertyDeclaration(entityProperty) + "( )");
                  AddCSharpLine( "{" );
                  ++m_TabStack;
                     AddCSharpLine( "return " + CSharpName(entityProperty, entityProperty.Instance.Name) + "." + entityProperty.Parameter.Name + ";" );               
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
                     AddCSharpLine( CSharpName(entityProperty, entityProperty.Instance.Name) + "." + entityProperty.Parameter.Name + " = " + CSharpName(entityProperty, entityProperty.Parameter.Name) + ";" );               
                  --m_TabStack;
                  AddCSharpLine( "}" );               
                  AddCSharpLine( "" );
               }
            }
            else
            {
               //only one instance allowed because we have no way to return multiple values (if > 1 instances were hooked up, who's would we return on get?)
               
               //get links attached to this property
               LinkNode []instanceLinks = FindLinksByDestination( entityProperty.Guid, entityProperty.Instance.Name );

               if ( instanceLinks.Length == 0 )
               {
                  instanceLinks = FindLinksBySource( entityProperty.Guid, entityProperty.Instance.Name );
               }

               foreach ( LinkNode instanceLink in instanceLinks )
               {
                  EntityNode entityNode = m_Script.GetNode( instanceLink.Source.Guid );

                  if ( true == entityProperty.Parameter.Output )
                  {
                     //as stated above, cretae a function which 
                     //gets the property from the entity and sets the corresponding CSharp variable
                     AddCSharpLine( entityProperty.Parameter.Type + " " + CSharpRefreshGetPropertyDeclaration(entityProperty) + "( )");
                     AddCSharpLine( "{" );
                     ++m_TabStack;
                        AddCSharpLine( "return " + CSharpName(entityNode) + "." + entityProperty.Parameter.Name + ";" );               
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
                        AddCSharpLine( CSharpName(entityNode) + "." + entityProperty.Parameter.Name + " = " + CSharpName(entityProperty, entityProperty.Parameter.Name) + ";" );               
                     --m_TabStack;
                     AddCSharpLine( "}" );               
                     AddCSharpLine( "" );
                  }

                  //only one instance allowed
                  break;
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
            return "\"" + stringValue.Replace( "\"", "\\\"") + "\"";
         }
         else if ( "UnityEngine.Quaternion" == type )
         {
            if ( false == stringValue.Contains(',') )
            {
               return "new Quaternion( )";
            }

            string [] subString = stringValue.Split( ',' );
            return "new Quaternion( " + subString[0] + ", " + subString[1] + ", " + subString[2] + ", " + subString[3] + " )";
         }
         else if ( "UnityEngine.Vector2" == type )
         {
            if ( false == stringValue.Contains(',') )
            {
               return "new Vector2( )";
            }

            string [] subString = stringValue.Split( ',' );
            return "new Vector2( " + subString[0] + ", " + subString[1] + " )";
         }
         else if ( "UnityEngine.Vector3" == type )
         {
            if ( false == stringValue.Contains(',') )
            {
               return "new Vector3( )";
            }

            string [] subString = stringValue.Split( ',' );
            return "new Vector3( " + subString[0] + ", " + subString[1] + ", " + subString[2] + " )";
         }
         else if ( "UnityEngine.Vector4" == type )
         {
            if ( false == stringValue.Contains(',') )
            {
               return "new Vector4( )";
            }

            string [] subString = stringValue.Split( ',' );
            return "new Vector4( " + subString[0] + ", " + subString[1] + ", " + subString[2] + ", " + subString[3] + " )";
         }
         else if ( "System.Single" == type )
         {
            if ( "" == stringValue )
            {
               return "(float) 0";
            }

            return "(float) " + stringValue;
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
            if ( "" == stringValue )
            {
               return "UnityEngine.Color.black";
            }

            string [] subString = stringValue.Split( ',' );
            return "new UnityEngine.Color( (float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + " )";
         }
         else if ( "UnityEngine.Ray" == type )
         {
            return "new UnityEngine.Ray( )";
         }
         else if ( "UnityEngine.RaycastHit" == type )
         {
            return "new UnityEngine.RaycastHit( )";
         }
         else if ( type.Contains("[]") )
         {
            return FormatArrayValue( stringValue, type );
         }

         return "null";
      }
      
      private string FormatArrayValue(string stringValue, string type)
      {
         string declaration = "";

         string []elements = stringValue.Split( ',' );

         if ( "UnityEngine.Quaternion[]" == type )
         {
            declaration = "new Quaternion[] {";

            for ( int i = 0; i < elements.Length; i += 2 )
            {
               declaration += "new Quaternion(" + elements[i] + "," + elements[i+1] + "," + elements[i+2] + "," + elements[i+3] + "),";
            }

            declaration = declaration.Substring( 0, declaration.Length - 1 );
            declaration += "}";
         }
         else if ( "UnityEngine.Vector2[]" == type )
         {
            declaration = "new Vector2[] {";

            for ( int i = 0; i < elements.Length; i += 2 )
            {
               declaration += "new Vector2(" + elements[i] + "," + elements[i+1] + "),";
            }

            declaration = declaration.Substring( 0, declaration.Length - 1 );
            declaration += "}";
         }
         else if ( "UnityEngine.Vector3[]" == type )
         {
            declaration = "new Vector3[] {";

            for ( int i = 0; i < elements.Length; i += 3 )
            {
               declaration += "new Vector3(" + elements[i] + "," + elements[i+1] + "," + elements[i+2] + "),";
            }

            declaration = declaration.Substring( 0, declaration.Length - 1 );
            declaration += "}";
         }
         else if ( "UnityEngine.Vector4[]" == type )
         {
            declaration = "new Vector4[] {";

            for ( int i = 0; i < elements.Length; i += 4 )
            {
               declaration += "new Vector4(" + elements[i] + "," + elements[i+1] + "," + elements[i+2] + "," + elements[i+3] + "),";
            }

            declaration = declaration.Substring( 0, declaration.Length - 1 );
            declaration += "}";
         }
         else if ( "UnityEngine.Color[]" == type )
         {
            declaration = "new UnityEngine.Color[] {";

            for ( int i = 0; i < elements.Length; i += 3 )
            {
               declaration += "new UnityEngine.Color((float)" + elements[i] + ",(float)" + elements[i+1] + ",(float)" + elements[i+2] + "),";
            }

            declaration = declaration.Substring( 0, declaration.Length - 1 );
            declaration += "}";
         }
         else if ( "UnityEngine.GameObject[]" == type )
         {
            declaration = "new UnityEngine.GameObject[" + elements.Length +"] {";

            for ( int i = 0; i < elements.Length; i++ )
            {
               declaration += "null,";
            };

            declaration = declaration.Substring( 0, declaration.Length - 1 );
            declaration += "}";
         }
         else if ( "UnityEngine.Component[]" == type )
         {
            declaration = "new UnityEngine.Component[" + elements.Length +"] {";

            for ( int i = 0; i < elements.Length; i++ )
            {
               declaration += "null,";
            };

            declaration = declaration.Substring( 0, declaration.Length - 1 );
            declaration += "}";
         }
         else
         {
            bool formatString = ( type == "System.String[]" || type == "System.Object[]" );
            
            declaration = "new " + type + " {";

            foreach ( string element in elements )
            {
               if ( true == formatString )
               {
                  declaration += "\"" + element.Trim().Replace( "\"", "\\\"" ) + "\"" + ",";
               }
               else
               {
                  declaration += element.Trim() + ",";
               }
            }

            declaration = declaration.Substring( 0, declaration.Length - 1 );
            declaration += "}";
         }

         return declaration;
      }

      //declare all the members this file will use throughout the CSharp functions
      //all node inputs are represented by global variables
      private void DeclareMemberVariables( )
      {
         AddCSharpLine( "#pragma warning disable 414" );

         AddCSharpLine( "//external output properties" );
         Plug []properties = FindExternalOutputProperties( );
         string []outputs  = FindExternalOutputs( );

         for ( int i = 0; i < properties.Length; i++ )
         {
            AddCSharpLine( "bool " + outputs[i] + " = false;" );

            AddCSharpLine( "[FriendlyName(\"" + properties[i].FriendlyName + "\")]" );
            AddCSharpLine( "public bool " + properties[i].Name + " { get { return " + outputs[i] + ";} }" );
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
                     AddCSharpLine( p.Type + " " + CSharpName(external, p.Name) + " = " + FormatValue(p.Default, p.Type) + ";" );
                     break;
                  }
               }

               //only one link per external allowed
               break;
            }
         }

         AddCSharpLine( "" );
         AddCSharpLine( "//local nodes" );
         foreach ( LocalNode local in m_Script.UniqueLocals )
         {
            AddCSharpLine( local.Value.Type + " " + CSharpName(local) + " = " + FormatValue(local.Value.Default, local.Value.Type) + ";" );
         }

         AddCSharpLine( "" );
         AddCSharpLine( "//logic nodes" );

         foreach ( LogicNode logic in m_Script.Logics )
         {
            AddCSharpLine( "//pointer to script instanced logic node" );
            AddCSharpLine( logic.Type + " " + CSharpName(logic, logic.Type) + " = null;" );
            
            foreach ( Parameter parameter in logic.Parameters )
            {
               if ( true == parameter.Input )
               {
                  AddCSharpLine( parameter.Type + " " + CSharpName(logic, parameter.Name) + " = " + FormatValue(parameter.Default, parameter.Type) + ";" );
               }
               else
               {
                  AddCSharpLine( parameter.Type + " " + CSharpName(logic, parameter.Name) + ";" );
               }
            }

            foreach ( Plug output in logic.Outputs )
            {
               AddCSharpLine( "bool " + CSharpName(logic, output.Name) + " = true;" );
            }
         }

         AddCSharpLine( "" );
         AddCSharpLine( "//event nodes" );

         foreach ( EntityEvent entityEvent in m_Script.Events )
         {
            foreach ( Parameter parameter  in entityEvent.Parameters  )
            {
               AddCSharpLine( parameter.Type + " " + CSharpName(entityEvent, parameter.Name) + " = " + FormatValue(parameter.Default, parameter.Type) + ";" );
            }

            if ( entityEvent.Instance.Default != "" )
            {
               AddCSharpLine( entityEvent.Instance.Type + " " + CSharpName(entityEvent, entityEvent.Instance.Name) + " = " + FormatValue(entityEvent.Instance.Default, entityEvent.Instance.Type) + ";" );
            }
         }

         AddCSharpLine( "" );
         AddCSharpLine( "//property nodes" );

         foreach ( EntityProperty entityProperty in m_Script.Properties )
         {
            AddCSharpLine( entityProperty.Parameter.Type + " " + CSharpName(entityProperty, entityProperty.Parameter.Name) + " = " + FormatValue(entityProperty.Parameter.Default, entityProperty.Parameter.Type) + ";" );

            if ( entityProperty.Instance.Default != "" )
            {
               AddCSharpLine( entityProperty.Instance.Type + " " + CSharpName(entityProperty, entityProperty.Instance.Name) + " = " + FormatValue(entityProperty.Instance.Default, entityProperty.Instance.Type) + ";" );
            }
         }

         AddCSharpLine( "" );
         AddCSharpLine( "//method nodes" );

         foreach ( EntityMethod entityMethod in m_Script.Methods )
         {
            foreach ( Parameter parameter in entityMethod.Parameters )
            {
               AddCSharpLine( parameter.Type + " " + CSharpName(entityMethod, parameter.Name) + " = " + FormatValue(parameter.Default, parameter.Type) + ";" );
            }

            if ( entityMethod.Instance.Default != "" )
            {
               AddCSharpLine( entityMethod.Instance.Type + " " + CSharpName(entityMethod, entityMethod.Instance.Name) + " = " + FormatValue(entityMethod.Instance.Default, entityMethod.Instance.Type) + ";" );
            }
         }

         AddCSharpLine( "#pragma warning restore 414" );
      }

      private void DefineInitialization( )
      {
         //make sure all components we plan to reference
         //have been placed in their local variables
         AddCSharpLine( CSharpFillComponentsDeclaration( ) + ";" );
         AddCSharpLine( "" );

         //for every entity event node 
         //register event listeners with the entity
         foreach ( EntityEvent entityEvent in m_Script.Events )
         {
            AddEventListener( entityEvent );
         }

         AddCSharpLine( "" );

         //for each logic node, create an script specific instance
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            AddCSharpLine( CSharpName(logicNode, logicNode.Type) + " = ScriptableObject.CreateInstance(typeof(" + logicNode.Type +")) as " + logicNode.Type + ";" );
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
         //for each logic node, create an script specific instance
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            AddCSharpLine( CSharpName(logicNode, logicNode.Type) + ".Update( );" );
         }
      }

      private void DefineLateUpdate( )
      {
         //for each logic node, create an script specific instance
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            AddCSharpLine( CSharpName(logicNode, logicNode.Type) + ".LateUpdate( );" );
         }
      }

      private void DefineFixedUpdate( )
      {
         //for each logic node, create an script specific instance
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            AddCSharpLine( CSharpName(logicNode, logicNode.Type) + ".FixedUpdate( );" );
         }
      }

      private void DefineOnGUI( )
      {
         //for each logic node, create an script specific instance
         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            AddCSharpLine( CSharpName(logicNode, logicNode.Type) + ".OnGUI( );" );
         }
      }

      private void DefineOnDestroy( )
      {
         AddCSharpLine( "if (false == Application.isEditor )" );
         AddCSharpLine( "{" );
         ++m_TabStack;
            //destroy script specific instances of the logic nodes
            foreach ( LogicNode logicNode in m_Script.Logics )
            {
               AddCSharpLine( "ScriptableObject.Destroy( " + CSharpName(logicNode, logicNode.Type) + " );" );
            }
         --m_TabStack;
         AddCSharpLine( "}" );
         AddCSharpLine( "else" );
         AddCSharpLine( "{" );
         ++m_TabStack;
            //destroy script specific instances of the logic nodes
            foreach ( LogicNode logicNode in m_Script.Logics )
            {
               AddCSharpLine( "ScriptableObject.DestroyImmediate( " + CSharpName(logicNode, logicNode.Type) + " );" );
            }
         --m_TabStack;
          AddCSharpLine( "}" );
         AddCSharpLine( "" );

         foreach ( LogicNode logicNode in m_Script.Logics )
         {
            AddCSharpLine( CSharpName(logicNode, logicNode.Type) + " = null;" );
         }
         AddCSharpLine( "" );
      }

      private void DefineFillComponents( )
      {
         AddCSharpLine( "void " + CSharpFillComponentsDeclaration( ) );
         AddCSharpLine( "{" );
         ++m_TabStack;
   
            //get any references to components currently available
            //which we haven't filled out yet
            foreach ( EntityMethod entityMethod in m_Script.Methods )
            {
               if ( entityMethod.Instance.Default != "" )
               {
                  FillComponent( entityMethod, entityMethod.Instance );
               }

               foreach ( Parameter p in entityMethod.Parameters )
               {
                  if ( false == p.Input ) continue;
                  FillComponent( entityMethod, p );
               }
            }

            foreach ( EntityEvent entityEvent in m_Script.Events )
            {
               if ( entityEvent.Instance.Default != "" )
               {
                  FillComponent( entityEvent, entityEvent.Instance );
               }
            }

            foreach ( EntityProperty entityProperty in m_Script.Properties )
            {
               if ( entityProperty.Instance.Default != "" )
               {
                  FillComponent( entityProperty, entityProperty.Instance );
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

         --m_TabStack;
         AddCSharpLine( "}" );
      }

      private void FillComponent(EntityNode node, Parameter parameter)
      {
         Type componentType  = typeof(UnityEngine.Component);
         Type gameObjectType = typeof(UnityEngine.GameObject);
         Type componentArrayType  = typeof(UnityEngine.Component[]);
         Type gameObjectArrayType = typeof(UnityEngine.GameObject[]);

         Type nodeType = uScript.Instance.GetType(parameter.Type);
         if ( null == nodeType ) return;

         if ( true == gameObjectArrayType.IsAssignableFrom(nodeType) )
         {
            //remove curly braces from type declaration
            //so we can use it to cast the object to the array element type
            string type = parameter.Type;
            type = type.Substring( 0, type.Length - 2 );

            string []values = parameter.Default.Split( ',' );

            for ( int i = 0; i < values.Length; i++ )
            {
               if ( values[i].Trim( ) == "" ) continue;

               AddCSharpLine( "if ( null == " + CSharpName(node, parameter.Name) + "[" + i + "] )" );
               AddCSharpLine( "{" );
               ++m_TabStack;
                  AddCSharpLine( CSharpName(node, parameter.Name) + "[" + i + "] = GameObject.Find( \"" + values[i].Trim( ) + "\" ) as " + type + ";" );
               --m_TabStack;
               AddCSharpLine( "}" );
            }
         }
         else if ( true == componentArrayType.IsAssignableFrom(nodeType) )
         {
            string []values = parameter.Default.Split( ',' );
         
            //remove curly braces from type declaration
            //so we can use it to cast the object to the array element type
            string type = parameter.Type;
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

                  AddCSharpLine( "gameObject = GameObject.Find( \"" + values[i].Trim( ) + "\" );" );
                  AddCSharpLine( "if ( null != " + "gameObject )" );
         
                  AddCSharpLine( "{" );               
                  ++m_TabStack;
                     AddCSharpLine( CSharpName(node, parameter.Name) + "[" + i + "] = gameObject.GetComponent<" + type + ">();" );

                     if ( node is EntityEvent )
                     {
                        SetEventInputs( CSharpName(node, parameter.Name) + "[" + i + "]", ((EntityEvent)node) );
                     }

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

                  AddCSharpLine( "GameObject gameObject = GameObject.Find( \"" + parameter.Default + "\" );" );
                  AddCSharpLine( "if ( null != " + "gameObject )" );
            
                  AddCSharpLine( "{" );               
                  ++m_TabStack;
                     AddCSharpLine( CSharpName(node, parameter.Name) + " = gameObject.GetComponent<" + parameter.Type + ">();" );
                     
                     if ( node is EntityEvent )
                     {
                        SetEventInputs( CSharpName(node, parameter.Name), ((EntityEvent)node) );
                     }
               
                  --m_TabStack;
                  AddCSharpLine( "}" );               

               --m_TabStack;
               AddCSharpLine( "}" );
            }
         }
         else if ( true == gameObjectType.IsAssignableFrom(nodeType) )
         {
            if ( parameter.Default != "" )
            {
               AddCSharpLine( "if ( null == " + CSharpName(node, parameter.Name) + " )" );
               AddCSharpLine( "{" );
               ++m_TabStack;

                  AddCSharpLine( CSharpName(node, parameter.Name) + " = GameObject.Find( \"" + parameter.Default + "\" ) as " + parameter.Type + ";" );

               --m_TabStack;
               AddCSharpLine( "}" );
            }
         }
      }

      //default inputs for events which can only be set through the property grid
      //so they are only set once (in fillcomponents)
      private void SetEventInputs( string eventVariable, EntityEvent eventNode )
      {
         AddCSharpLine( "if ( null != " + eventVariable + " )" );
         AddCSharpLine( "{" );
         ++m_TabStack;
            foreach ( Parameter p in eventNode.Parameters )
            {
               if ( p.Input == true )
               {
                  AddCSharpLine( eventVariable + "." + p.Name + " = " + CSharpName(eventNode, p.Name) + ";" );
               }
            }
         --m_TabStack;
         AddCSharpLine( "}" );               
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

               AddCSharpLine( CSharpName(entityEvent, parameter.Name) + " = e. " + parameter.Name + ";" );
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
                     externalLinks.Add( CSharpExternalOutputDeclaration(method, method.Output.Name) );
                  }
               }
               else if ( node is LogicNode ) 
               {
                  LogicNode logic = (LogicNode) node;

                  foreach ( Plug output in logic.Outputs )
                  {
                     if ( link.Source.Anchor == output.Name )
                     {
                        externalLinks.Add( CSharpExternalOutputDeclaration(logic, output.Name) );
                     }
                  }
               }
            
               //only one link permitted per external connection
               break;
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
                     externalLinks.Add( CSharpExternalOutputPropertyDeclaration(external.Name.Default, method, method.Output.Name) );
                  }
               }
               else if ( node is LogicNode ) 
               {
                  LogicNode logic = (LogicNode) node;

                  foreach ( Plug output in logic.Outputs )
                  {
                     if ( link.Source.Anchor == output.Name )
                     {
                        externalLinks.Add( CSharpExternalOutputPropertyDeclaration(external.Name.Default, logic, output.Name) );
                     }
                  }
               }

               //only one link permitted per external connection
               break;
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
                        externalLinks.Add( CSharpExternalEventDeclaration(external.Name.Default, entityEvent, output.Name) );
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
                        externalLinks.Add( CSharpExternalEventDeclaration(external.Name.Default, logic, eventName.Name) );
                        break;
                     }
                  }
               }

               //only one link permitted per external connection
               break;
            }
         }

         return externalLinks.ToArray( );
      }

      //create the external function outsiders can call
      private void DefineExternalInput( ExternalConnection externalInput )
      {
         //all input args
         string inputArgs = "";

         foreach ( ExternalConnection external in m_Script.Externals )
         {
            LinkNode []links = FindLinksBySource( external.Guid, external.Connection );

            foreach ( LinkNode link in links )
            {
               EntityNode node = m_Script.GetNode( link.Destination.Guid );

               foreach ( Parameter p in node.Parameters )
               {
                  if ( p.Name == link.Destination.Anchor )
                  {
                     inputArgs += "[FriendlyName(\"" + CSharpExternalParameterDeclaration(external.Name.Default, node, p.Name).FriendlyName + "\")] ";
                     inputArgs += p.Type + " " + CSharpExternalParameterDeclaration(external.Name.Default, node, p.Name).Name + ", ";
                  }
               }
            
               //only one link allowed for each external
               break;
            }
         }

         //remove trailing comma from last input arg
         if ( inputArgs != "" ) inputArgs = inputArgs.Substring( 0, inputArgs.Length - 2 );

         //all output args
         string outputArgs = "";
         
         foreach ( ExternalConnection external in m_Script.Externals )
         {
            LinkNode []links = FindLinksByDestination( external.Guid, external.Connection );

            foreach ( LinkNode link in links )
            {
               EntityNode node = m_Script.GetNode( link.Source.Guid );

               foreach ( Parameter p in node.Parameters )
               {
                  if ( p.Name == link.Source.Anchor )
                  {
                     outputArgs += "[FriendlyName(\"" + CSharpExternalParameterDeclaration(external.Name.Default, node, p.Name).FriendlyName + "\")] ";
                     outputArgs += "out " + p.Type + " " + CSharpExternalParameterDeclaration(external.Name.Default, node, p.Name).Name + ", ";
                  }
               }

               //only one link allowed for each external
               break;
            }
         }

         //remove trailing comma from last input arg
         if ( outputArgs != "" ) outputArgs = outputArgs.Substring( 0, outputArgs.Length - 2 );

         //consolidate our args
         string args = inputArgs;
         if ( args != "" && outputArgs != "" ) args += ", " + outputArgs;
         else if ( outputArgs != "" ) args = outputArgs;
 
         LinkNode []relays = FindLinksBySource( externalInput.Guid, externalInput.Connection );
         
         foreach ( LinkNode relayLink in relays )
         {
            EntityNode node = m_Script.GetNode( relayLink.Destination.Guid );
            
            bool allowLink = false;

            if ( node is EntityMethod )
            {
               EntityMethod method = (EntityMethod) node;

               if ( method.Output.Name == relayLink.Destination.Anchor )
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

            if ( false == allowLink ) continue;
            
            AddCSharpLine( "[FriendlyName(\"" + CSharpExternalInputDeclaration(externalInput.Name.Default, node, relayLink.Destination.Anchor).FriendlyName + "\")]" );
            AddCSharpLine( "public void " + CSharpExternalInputDeclaration(externalInput.Name.Default, node, relayLink.Destination.Anchor).Name + "( " + args + " )" );
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
                        AddCSharpLine( CSharpName(parameterNode, p.Name) + " = " + CSharpExternalParameterDeclaration(external.Name.Default, parameterNode, p.Name).Name + ";" );
                     }
                  }

                  //only one link allowed for each external
                  break;
               }

               //external connections don't have a parameter
               //because they take on whatever parameter they link to
               Parameter parameter = new Parameter( );
               parameter.Name = external.Connection;
               RefreshSetProperties( external, new Parameter[] {parameter} );
            }

            AddCSharpLine( CSharpRelay(node, relayLink.Destination.Anchor) + "( );" );


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

                        AddCSharpLine( CSharpExternalParameterDeclaration(external.Name.Default, parameterNode, p.Name).Name + " = " + CSharpName(external, p.Name) + ";" );
                     }
                  }

                  //only one link allowed for each external
                  break;
               }
            }

            --m_TabStack;

            AddCSharpLine( "}" );
            AddCSharpLine( "" );
         }
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
                     AddCSharpLine( "if ( " + CSharpExternalEventDeclaration(external.Name.Default, entityEvent, output.Name).Name + " != null )" );
                     AddCSharpLine( "{" );
                     ++m_TabStack;
                        AddCSharpLine( CSharpExternalEventDeclaration(external.Name.Default, entityEvent, output.Name).Name + "( this, new System.EventArgs());" );
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
                  AddCSharpLine( CSharpExternalOutputDeclaration(entityMethod, entityMethod.Output.Name) + " = true;" );
               }
            }
            else if ( node is LogicNode ) 
            {
               LogicNode logic = (LogicNode) node;

               foreach ( Plug eventName in logic.Events )
               {
                  if ( link.Source.Anchor == eventName.Name )
                  {
                     AddCSharpLine( "if ( " + CSharpExternalEventDeclaration(external.Name.Default, logic, eventName.Name).Name + " != null )" );
                     AddCSharpLine( "{" );
                     ++m_TabStack;
                        AddCSharpLine( CSharpExternalEventDeclaration(external.Name.Default, logic, eventName.Name).Name + "( this, new System.EventArgs());" );
                     --m_TabStack;
                     AddCSharpLine( "}" );
                     break;
                  }
               }

               foreach ( Plug output in logic.Outputs )
               {
                  if ( link.Source.Anchor == output.Name )
                  {
                     AddCSharpLine( CSharpExternalOutputDeclaration(logic, output.Name) + " = true;" );
                     break;
                  }
               }
            }

            //only one link permitted per external connection
            break;
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


         LinkNode []instanceLinks = FindLinksByDestination( receiver.Guid, receiver.Instance.Name );

         foreach ( LinkNode link in instanceLinks )
         {
            AddCSharpLine( "INTERNAL ERROR - Instance Links not supported when methods have return types or variables" );

            EntityNode node = m_Script.GetNode( link.Source.Guid );
            AddCSharpLine( CSharpName(node) + "." + receiver.Input.Name + "(" + args + ");" );            
         }

         if ( receiver.Instance.Default != "" )
         {
            if ( returnParam != Parameter.Empty )
            {
               AddCSharpLine( CSharpName(receiver, returnParam.Name) + " = " + CSharpName(receiver, receiver.Instance.Name) + "." + receiver.Input.Name + "(" + args + ");" );            
            }
            else
            {
               AddCSharpLine( CSharpName(receiver, receiver.Instance.Name) + "." + receiver.Input.Name + "(" + args + ");" );            
            }
         }

         //force any potential entites affected to update
         RefreshSetProperties( receiver, receiver.Parameters );

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
            }
         }

         //call anyone else connected to us
         CallRelays(receiver.Guid, receiver.Output.Name);
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
            }
         }

         //force any potential entites affected to update
         RefreshSetProperties( receiver, receiver.Parameters );

         //call anyone else connected to our outputs
         //if the result of the logic node has set our output to true
         foreach ( Plug output in receiver.Outputs )
         {
            AddCSharpLine( "if ( " + CSharpName(receiver, receiver.Type) + "." + output.Name + " == true )" );
            AddCSharpLine( "{" );
            ++m_TabStack;
               CallRelays(receiver.Guid, output.Name);
            --m_TabStack;
            AddCSharpLine( "}" );
         }
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

               PrintDebug( receiver );
               RelayToMethod( (EntityMethod) receiver );

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

                  PrintDebug( receiver );
                  RelayToEvent( entityEvent, eventName.Name );            

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

               PrintDebug( receiver );
               RelayToExternal( external );
               
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

                  PrintDebug( receiver );                  
                  CallRelays(receiver.Guid, eventName.Name);

               --m_TabStack;

               AddCSharpLine( "}" );
               AddCSharpLine( "" );
            }

            foreach ( Plug input in logicNode.Inputs )
            {
               AddCSharpLine( "void " + CSharpRelay(receiver, input.Name) + "()" );
               AddCSharpLine( "{" );

               ++m_TabStack;

                  PrintDebug(receiver);                  
                  RelayToLogic((LogicNode)receiver, input.Name);

               --m_TabStack;

               AddCSharpLine( "}" );
               AddCSharpLine( "" );
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

         return MakeSyntaxSafe( name );
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
      private void AddEventListener( EntityEvent entityEvent )
      {
         LinkNode [] links = FindLinksByDestination( entityEvent.Guid, entityEvent.Instance.Name );

         foreach ( LinkNode link in links )
         {
            EntityNode entityNode = m_Script.GetNode( link.Source.Guid );
            
            foreach ( Plug output in entityEvent.Outputs )
            {
               AddCSharpLine( CSharpName(entityNode) +"." + output.Name + " += "+ CSharpEventDeclaration(entityEvent, output.Name) + ";" );            
            }
         }

         if ( entityEvent.Instance.Default != "" )
         {
            foreach ( Plug output in entityEvent.Outputs )
            {
               AddCSharpLine( CSharpName(entityEvent, entityEvent.Instance.Name) +"." + output.Name + " += "+ CSharpEventDeclaration(entityEvent, output.Name) + ";" );            
            }
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

      private string CSharpFillComponentsDeclaration( )
      {
         return "FillComponents( )";
      }

      private Plug CSharpExternalInputDeclaration(string defaultName, EntityNode node, string name)
      {
         Plug plug;

         plug.Name = name + "_" + GetGuidId(node.Guid);
         plug.FriendlyName = plug.Name;

         if ( "" != defaultName ) plug.FriendlyName = defaultName;

         return plug;
      }

      private Plug CSharpExternalParameterDeclaration(string defaultName, EntityNode node, string name)
      {
         Plug plug;

         plug.Name = name + "_" + GetGuidId(node.Guid);
         plug.FriendlyName = plug.Name;

         if ( "" != defaultName ) plug.FriendlyName = defaultName;

         return plug;
      }

      private Plug CSharpExternalOutputPropertyDeclaration(string defaultName, EntityNode node, string name)
      {
         Plug plug;

         plug.Name = "Link_" + name + "_" + GetGuidId(node.Guid);
         plug.FriendlyName = plug.Name;

         if ( "" != defaultName ) plug.FriendlyName = defaultName;

         return plug;
      }
   
      private string CSharpExternalOutputDeclaration(EntityNode node, string name)
      {
         return "output_Link_" + name + "_" + GetGuidId(node.Guid);
      }

      private Plug CSharpExternalEventDeclaration(string defaultName, EntityNode node, string name)
      {
         Plug plug;

         plug.Name = "Event_" + name + "_" + GetGuidId(node.Guid);
         plug.FriendlyName = plug.Name;

         if ( "" != defaultName ) plug.FriendlyName = defaultName;

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
         return logicNode.Type + "_" + eventName + "_" + GetGuidId(logicNode.Guid);
      }

      //have any non-triggable nodes (properties, local variables)
      //write themselves to the input parameters for the node passed into this method
      private void SyncSlaveConnections( EntityNode node, Parameter [] parameters )
      {
         AddCSharpLine( CSharpFillComponentsDeclaration( ) + ";" );

         AddCSharpLine( "#pragma warning disable 219" );
         AddCSharpLine( "#pragma warning disable 168" );

         AddCSharpLine( "int index = 0;" );
         AddCSharpLine( "System.Array properties;" );

         AddCSharpLine( "#pragma warning restore 219" );
         AddCSharpLine( "#pragma warning restore 168" );

         foreach ( Parameter parameter in parameters )
         {
            AddCSharpLine( "index = 0;" );
            AddCSharpLine( "properties = null;" );
   
            //if the input parameter is an array
            //we need to place all source node values into the array
            if ( parameter.Type.Contains("[]") )
            {
               //get all the links hooked to the input on this node
               LinkNode []links = FindLinksByDestination( node.Guid, parameter.Name );

               foreach ( LinkNode link in links )
               {
                  EntityNode argNode = m_Script.GetNode( link.Source.Guid );
                  
                  //check to see if any source nodes are local variables
                  if ( argNode is LocalNode )
                  {
                     LocalNode localNode = (LocalNode) argNode;
                     
                     //if the local variable is an array then we need to copy the array
                     //to the next available index of the input parameter
                     if ( localNode.Value.Type.Contains("[]") )
                     {
                        AddCSharpLine( "properties = " + CSharpName(argNode) + ";" );

                        //make sure our input array is large enough to hold the array we're copying into it
                        AddCSharpLine( "if ( " + CSharpName(node, parameter.Name) + ".Length < index + properties.Length)" );
                        AddCSharpLine( "{" );
                        ++m_TabStack;
                           AddCSharpLine( "System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + properties.Length);" );
                        --m_TabStack;
                        AddCSharpLine( "}" );

                        //copy the source node array into the input parameter array
                        AddCSharpLine( "System.Array.Copy(properties, 0, " + CSharpName(node, parameter.Name) + ", index, properties.Length);" );
                        AddCSharpLine( "index += properties.Length;" );
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
                     }
                  }

                  //check to see if any source nodes are property nodes
                  else if ( argNode is EntityProperty )
                  {
                     EntityProperty entityProperty = (EntityProperty) argNode;
                     
                     if ( true == entityProperty.Parameter.Output )
                     {
                        //if the property variable is an array then we need to copy the array
                        //to the next available index of the input parameter
                        if ( entityProperty.Parameter.Type.Contains("[]") )
                        {
                           AddCSharpLine( "properties = " + CSharpRefreshGetPropertyDeclaration( entityProperty ) + "( );" );

                           //make sure our input array is large enough to hold the array we're copying into it
                           AddCSharpLine( "if ( " + CSharpName(node, parameter.Name) + ".Length < index + properties.Length)" );
                           AddCSharpLine( "{" );
                           ++m_TabStack;
                              AddCSharpLine( "System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + properties.Length);" );
                           --m_TabStack;
                           AddCSharpLine( "}" );

                           AddCSharpLine( "System.Array.Copy(properties, 0, " + CSharpName(node, parameter.Name) + ", index, properties.Length);" );
                           AddCSharpLine( "index += properties.Length;" );
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

                           AddCSharpLine( "//here" );
                           //copy the source node value into the input parameter array
                           AddCSharpLine( CSharpName(node, parameter.Name) + "[ index++ ] = " + CSharpRefreshGetPropertyDeclaration( entityProperty ) + "( );" );
                        }
                     }
                  }

                  AddCSharpLine( "" );
               }
            }
            else
            {
               //get all the links hooked to the input on this node
               LinkNode []links = FindLinksByDestination( node.Guid, parameter.Name );

               foreach ( LinkNode link in links )
               {
                  EntityNode argNode = m_Script.GetNode( link.Source.Guid );
                  
                  //if any of those links is a local node
                  //we need to write the line for the property to refresh
                  if ( argNode is LocalNode )
                  {
                     AddCSharpLine( CSharpName(node, parameter.Name) + " = " + CSharpName(argNode) + ";" );
                  }

                  //if any of those links is a property node
                  //we need to write the line for the property to refresh
                  else if ( argNode is EntityProperty )
                  {
                     EntityProperty entityProperty = (EntityProperty) argNode;

                     if ( true == entityProperty.Parameter.Output )
                     {
                        AddCSharpLine( CSharpName(node, parameter.Name) + " = " + CSharpRefreshGetPropertyDeclaration( entityProperty ) + "( );" );
                     }
                  }
               }
            }
         }
      }
   
      //go through and tell all the property linked to us to update their entity's values
      //because we could have modified the CSharp representation
      private void RefreshSetProperties( EntityNode node, Parameter [] parameters )
      {
         //make sure all components we plan to reference
         //have been placed in their local variables
         AddCSharpLine( CSharpFillComponentsDeclaration( ) + ";" );

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
         if ( "true" == node.ShowComment.Default )
         {
            AddCSharpLine( "uScriptDebug.Log( \"[" + uScriptConfig.Variable.FriendlyName(node.GetType().ToString()) + "] " + node.Comment.Default + "\", uScriptDebug.Type.Message);" );
         }
      }
   }
}
