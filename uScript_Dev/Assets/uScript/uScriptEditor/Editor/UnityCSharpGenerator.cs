using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace Detox.ScriptEditor
{
   public class Profile
   {
      static int m_Tab;

      private string m_Name;

      System.Diagnostics.Stopwatch m_Stopwatch = new System.Diagnostics.Stopwatch();

      public Profile(string name)
      {
         m_Name = name;
         m_Stopwatch.Start( );

         ++m_Tab;
      }

      public void End( )
      {
         float seconds = m_Stopwatch.ElapsedMilliseconds / 1000.0f;
         m_Stopwatch.Stop( );

         --m_Tab;

         if (uScript.Preferences.Profiling && seconds > uScript.Preferences.ProfileMin)
         {
            string tab = "PROFILE TIMING: ";
            for (int i = 0; i < m_Tab; i++)
            {
               tab += "   ";
            }

            uScriptDebug.Log(tab + m_Name + " " + seconds + "\n", uScriptDebug.Type.Message);
         }
      }
   }

   //how it works with CSharp:
   //each node has inputs, the calling node (the one with the output linked to the input)
   //is responsible for setting that node's input before it calls it
   //the node's input is represented by a variable name which includes that node's id and the input's name
   //having nodes set the input of the next node before it calls it has the effect of trickling down
   //all the correct, and latest values, to that node directly before it is executed
   public class UnityCSharpGenerator
   {
      private const int MaxRelayCallCount = 1000;

      public Parameter[] ExternalParameters { get { return m_ExternalParameters.ToArray(); } }
      public Plug[] ExternalInputs { get { return m_ExternalInputs.ToArray(); } }
      public Plug[] ExternalOutputs { get { return m_ExternalOutputs.ToArray(); } }
      public Plug[] ExternalEvents { get { return m_ExternalEvents.ToArray(); } }
      public string[] Drivens { get { return m_Drivens.ToArray(); } }
      public string[] RequiredMethods { get { return m_RequiredMethods.ToArray(); } }

      struct ExternalEventParameter
      {
         //pseudo parameter which hold the external name
         //but the type information of what it's linked to
         public Parameter ExternalParameter;

         //the actual external so we can reference its variable
         //when filling the event data
         public ExternalConnection ExternalVariableNode;
      }

      public Parameter[] LogicEventArgs
      {
         get
         {
            List<Parameter> p = new List<Parameter>();
            foreach (ExternalEventParameter eep in m_LogicEventArgs)
            {
               p.Add(eep.ExternalParameter);
            }

            return p.ToArray();
         }
      }

      private StringBuilder m_CSharpString;
      private bool m_GenerateDebugInfo;
      private int m_TabStack;
      private Hashtable m_GuidToId = new Hashtable();
      private ScriptEditor m_Script = null;

      List<Parameter> m_ExternalParameters = new List<Parameter>();
      List<Plug> m_ExternalInputs = new List<Plug>();
      List<Plug> m_ExternalOutputs = new List<Plug>();
      List<Plug> m_ExternalEvents = new List<Plug>();
      List<string> m_Drivens = new List<string>();
      List<string> m_RequiredMethods = new List<string>();

      List<ExternalEventParameter> m_LogicEventArgs = new List<ExternalEventParameter>();

      private void Preprocess(bool quick)
      {
         Profile preprocess = new Profile("Preprocess");

         CreateGuidIndices( );
         CreateGlobalVariables( );
         CreateBidirectionalLinks( );
         PruneUnusedNodes( );

         if (false == quick) RemoveOverriddenParameters( );

         ConsolidateExternals( );

         preprocess.End();
      }

      //setup all the guids now so
      //indices are not node order dependent
      private void CreateGuidIndices()
      {
         Profile p = new Profile("CreateGuidIndices");

         foreach (EntityNode node in m_Script.EntityNodes)
         {
            GetGuidId(node.Guid);
         }

         p.End( );
      }

      //short cut method to figure out just the external links/parameters
      //without needing to parse th entire script
      public void ParseExternals(ScriptEditor script)
      {
         Profile parseExternals = new Profile("ParseExternals");

         m_GenerateDebugInfo = false;
         m_CSharpString = new StringBuilder();
         m_TabStack = 0;

         m_Script = null;

         m_LogicEventArgs = new List<ExternalEventParameter>();
         m_ExternalParameters = new List<Parameter>();
         m_ExternalInputs = new List<Plug>();
         m_ExternalOutputs = new List<Plug>();
         m_ExternalEvents = new List<Plug>();
         //m_Drivens         = new List<string>( );
         m_RequiredMethods = new List<string>();

         if (null != script)
         {
            m_Script = script.Copy();

            Preprocess(true);

            foreach (ExternalConnection external in m_Script.Externals)
            {
               DefineExternalInput(external, false);
            }

            Plug[] events = FindExternalEvents();

            if (events.Length > 0)
            {
               foreach (Plug eventPlug in events)
               {
                  m_ExternalEvents.Add(eventPlug);
               }
            }

            DeclareEventArgs();

            m_RequiredMethods.Add("Start");
            m_RequiredMethods.Add("Update");

            if (true == NeedsMethod("LateUpdate"))
            {
               m_RequiredMethods.Add("LateUpdate");
            }

            if (true == NeedsMethod("FixedUpdate"))
            {
               m_RequiredMethods.Add("FixedUpdate");
            }
         }

         parseExternals.End( );
      }

      private void CreateBidirectionalLinks()
      {
         Profile profile = new Profile("CreateBidirectionalLinks");

         List<LinkNode> newLinks = new List<LinkNode>();

         //go through all connections and make duplicate links going the other way
         //if they can be bi-directional
         foreach (LinkNode link in m_Script.Links)
         {
            EntityNode source = m_Script.GetNode(link.Source.Guid);
            EntityNode dest = m_Script.GetNode(link.Destination.Guid);

            Parameter sourceParam = Parameter.Empty, destParam = Parameter.Empty;

            foreach (Parameter p in source.Parameters)
            {
               if (p.Name == link.Source.Anchor)
               {
                  sourceParam = p;
                  break;
               }
            }

            foreach (Parameter p in dest.Parameters)
            {
               if (p.Name == link.Destination.Anchor)
               {
                  destParam = p;
                  break;
               }
            }

            bool cloneLink = false;

            if (sourceParam != Parameter.Empty && destParam != Parameter.Empty)
            {
               if (sourceParam.Input == true &&
                  destParam.Output == true)
               {
                  cloneLink = true;
               }
            }
            else
            {
               if (source is ExternalConnection && destParam != Parameter.Empty)
               {
                  if (destParam.Output == true)
                  {
                     cloneLink = true;
                  }
               }
               else if (dest is ExternalConnection && sourceParam != Parameter.Empty)
               {
                  if (sourceParam.Input == true)
                  {
                     cloneLink = true;
                  }
               }
            }

            if (true == cloneLink)
            {
               LinkNode clone = link;
               clone.Guid = Guid.NewGuid();
               clone.Source = link.Destination;
               clone.Destination = link.Source;

               LinkNode outNode;
               if (false == FindLink(clone.Source.Guid, clone.Source.Anchor, clone.Destination.Guid, clone.Destination.Anchor, out outNode))
               {
                  newLinks.Add(clone);
               }
            }
         }

         foreach (LinkNode link in newLinks)
         {
            m_Script.AddNode(link);
         }

         profile.End( );
      }

      private void ConsolidateExternals()
      {
         Profile p = new Profile("ConsolidateExternals");

         ExternalConnection[] externals = m_Script.Externals;
         Hashtable unique = new Hashtable();

         //build lists, keyed by external name
         //so we can consolidate all the links to the same external
         foreach (ExternalConnection external in externals)
         {
            if (null == unique[external.Name.Default])
            {
               unique[external.Name.Default] = new List<ExternalConnection>();
            }

            List<ExternalConnection> list = unique[external.Name.Default] as List<ExternalConnection>;
            list.Add(external);
         }


         //for each external list...
         foreach (object o in unique.Values)
         {
            List<ExternalConnection> list = o as List<ExternalConnection>;

            //the first one in the list is where we will consolidate
            ExternalConnection external = list[0];

            //every subsequent one, replace the links with the links to the consolidated one
            //and then remove the subsequent one (which will also remove its links)
            for (int i = 1; i < list.Count; i++)
            {
               ExternalConnection e = list[i];

               LinkNode[] sources = FindLinksBySource(e.Guid, e.Connection);
               LinkNode[] dests = FindLinksByDestination(e.Guid, e.Connection);

               m_Script.RemoveNode(e);

               foreach (LinkNode source in sources)
               {
                  LinkNode clone = source;
                  clone.Source.Guid = external.Guid;

                  m_Script.TrustedUpdate(clone);
               }

               foreach (LinkNode dest in dests)
               {
                  LinkNode clone = dest;
                  clone.Destination.Guid = external.Guid;

                  m_Script.TrustedUpdate(clone);
               }
            }
         }
         //m_Script.VerifyAllLinks();

         p.End( );
      }

      private void CreateGlobalVariables()
      {
         Profile p = new Profile("CreateGlobalVariables");

         //find any local variables which have no name
         //and give them their unique id as the name
         //this way they are individual instances
         LocalNode[] locals = m_Script.UniqueLocals;

         foreach (LocalNode local in locals)
         {
            if ("" == local.Name.Default)
            {
               LocalNode unique = new LocalNode("" + GetGuidId(local.Guid), local.Value.Type, local.Value.Default);
               unique.Guid = local.Guid;

               //replace existing local
               m_Script.AddNode(unique);
            }
         }


         //now consolidate all links to the unique nodes

         Dictionary<string, LocalNode> dictionary = new Dictionary<string, LocalNode>();

         foreach (LocalNode local in m_Script.UniqueLocals)
         {
            dictionary[local.Name.Default + local.Value.Type] = local;
         }

         LocalNode[] allLocals = m_Script.Locals;

         foreach (LocalNode local in allLocals)
         {
            LocalNode existing = dictionary[local.Name.Default + local.Value.Type];

            if (existing.Guid != local.Guid)
            {
               m_Script.RedirectLinks(local.Guid, existing.Guid);
               m_Script.RemoveNode(local);
            }
         }

         p.End( );
      }

      private void PruneUnusedNodes()
      {
         Profile p = new Profile("PruneUnusedNodes");

         //first prune out any nodes which don't have valid instances
         foreach (EntityNode entityNode in m_Script.EntityNodes)
         {
            //if it doesn't need an instance, don't worry about finding one
            if (false == entityNode is EntityProperty &&
               false == entityNode is EntityEvent &&
               false == entityNode is EntityMethod) continue;


            //an instance set in the property grid?
            if (entityNode.Instance.Default != "") continue;

            //include static nodes which don't need an instance
            if (true == entityNode.IsStatic) continue;

            bool includeNode = false;

            //how about an instance linked to it?
            LinkNode[] instanceLinks = FindLinksByDestination(entityNode.Guid, entityNode.Instance.Name);

            foreach (LinkNode link in instanceLinks)
            {
               EntityNode node = m_Script.GetNode(link.Source.Guid);

               if (node is LocalNode)
               {
                  if (((LocalNode)node).Instance.Default != "")
                  {
                     includeNode = true;
                     break;
                  }
               }
               else if (node is OwnerConnection || node is ExternalConnection || node is EntityProperty)
               {
                  includeNode = true;
               }
            }

            if (false == includeNode)
            {
               instanceLinks = FindLinksBySource(entityNode.Guid, entityNode.Instance.Name);

               foreach (LinkNode link in instanceLinks)
               {
                  LocalNode node = (LocalNode)m_Script.GetNode(link.Destination.Guid);

                  if (node.Instance.Default != "")
                  {
                     includeNode = true;
                     break;
                  }
               }
            }

            if (false == includeNode && entityNode is LocalNode)
            {
               includeNode = ((LocalNode)entityNode).Externaled.Default == "true";
            }

            //no valid instance, so remove it
            if (false == includeNode)
            {
               string name = uScriptConfig.Variable.FriendlyName(entityNode.Instance.Type);

               uScriptDebug.Log("Node " + name + " is being pruned because there is no GameObject instance assigned to it", uScriptDebug.Type.Debug);
               m_Script.RemoveNode(entityNode);
            }
         }



         //now that we have removed all the nodes
         //which don't have valid instances assigned
         //track all the nodes which have links to them
         //and remove everything else

         //track all the link source / destination nodes
         Hashtable usedNodes = new Hashtable();

         foreach (LinkNode link in m_Script.Links)
         {
            usedNodes[link.Source.Guid] = true;
            usedNodes[link.Destination.Guid] = true;
            usedNodes[link.Guid] = true;
         }

         //prune any nodes which aren't linked
         foreach (EntityNode entityNode in m_Script.EntityNodes)
         {
            if (false == usedNodes.Contains(entityNode.Guid))
            {
               if (entityNode is LocalNode)
               {
                  bool externaled = ((LocalNode)entityNode).Externaled.Default == "true";
                  if (true == externaled) continue;
               }

               m_Script.RemoveNode(entityNode);
            }
         }

         p.End( );
      }

      private void RemoveOverriddenParameters()
      {
         Profile profile = new Profile("RemoveOverriddenParameters");

         //prune out parameter values which have been overridden because
         //a link is connected to it
         EntityNode[] nodes = m_Script.DirectEntityNodes;

         foreach (EntityNode entityNode in nodes)
         {
            if (entityNode is LocalNode) continue;
            if (entityNode is LinkNode) continue;

            if (entityNode.Instance != Parameter.Empty && entityNode.Instance.Default != "")
            {
               //how about an instance linked to it?
               LinkNode[] instanceLinks = FindLinksByDestination(entityNode.Guid, entityNode.Instance.Name);

               if (instanceLinks.Length > 0)
               {
                  Parameter p = entityNode.Instance;
                  p.Default = "";
                  entityNode.Instance = p;
                  m_Script.TrustedUpdate(entityNode);
               }
            }

            Parameter[] parameters = entityNode.Parameters;

            for (int i = 0; i < parameters.Length; i++)
            {
               Parameter p = parameters[i];

               LinkNode[] links = FindLinksByDestination(entityNode.Guid, p.Name);

               if (0 == links.Length)
               {
                  links = FindLinksBySource(entityNode.Guid, p.Name);
               }

               if (links.Length > 0)
               {
                  p.Default = "";
                  parameters[i] = p;
               }
            }

            entityNode.Parameters = parameters;
            m_Script.TrustedUpdate(entityNode);
         }

         profile.End( );
      }


      private bool FindLink(Guid sourceGuid, string sourceAnchor, Guid destGuid, string destAnchor, out LinkNode outNode)
      {
         Profile p = new Profile("FindLink");

         foreach (LinkNode link in m_Script.Links)
         {
            if (link.Source.Guid == sourceGuid &&
               link.Source.Anchor == sourceAnchor &&
               link.Destination.Guid == destGuid &&
               link.Destination.Anchor == destAnchor)
            {
               outNode = link;
               return true;
            }
         }

         outNode = new LinkNode();

         p.End( );

         return false;
      }

      public string GenerateGameObjectScript(string logicClassName, ScriptEditor script, bool stubCode)
      {
         Profile p = new Profile("GenerateGameObjectScript");

         m_GenerateDebugInfo = false;
         m_CSharpString = new StringBuilder();
         m_TabStack = 0;

         m_Script = null;

         if (null != script)
         {
            m_Script = script.Copy();

            Preprocess(false);

            DeclareNamespaces();
            AddCSharpLine("");
            AddCSharpLine("// This is the component script that you should assign to GameObjects to use this graph on them. Use the uScript/Graphs section of Unity's \"Component\" menu to assign this graph to a selected GameObject.");
            AddCSharpLine("");

            AddCSharpLine("[AddComponentMenu(\"uScript/Graphs/" + logicClassName + "\")]");
            AddCSharpLine("public class " + System.IO.Path.GetFileNameWithoutExtension(script.Name) + uScriptConfig.Files.GeneratedComponentExtension + " : uScriptCode");
            AddCSharpLine("{");
            ++m_TabStack;

            AddCSharpLine("#pragma warning disable 414");
            AddCSharpLine("public " + logicClassName + " ExposedVariables = new " + logicClassName + "( ); ");
            AddCSharpLine("#pragma warning restore 414");

            AddCSharpLine("");

            //any named variables using the "Make Public" property should be also marked as public properties
            //so they can be get/set by other uscripts
            foreach (LocalNode node in m_Script.UniqueLocals)
            {
               if ("true" == node.Externaled.Default)
               {
                  AddCSharpLine("public " + FormatType(node.Value.Type) + " " + CSharpName(node) + " { get { return ExposedVariables." + CSharpName(node) + "; } set { ExposedVariables." + CSharpName(node) + " = value; } } ");
               }
            }

            AddCSharpLine("");

            AddCSharpLine("void Awake( )");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               AddCSharpLine("#if !(UNITY_FLASH)");
               AddCSharpLine("useGUILayout = " + (NeedsGuiLayout() ? "true;" : "false;"));
               AddCSharpLine("#endif");
               AddCSharpLine("ExposedVariables.Awake( );");

               //AddCSharpLine( "ExposedVariables = ScriptableObject.CreateInstance(typeof(" + logicClassName + ")) as " + logicClassName + ";" );
               AddCSharpLine("ExposedVariables.SetParent( this.gameObject );");

               string version = uScript_MasterComponent.Version;

               AddCSharpLine("if ( \"" + version + "\" != uScript_MasterComponent.Version )");
               AddCSharpLine("{");
               ++m_TabStack;
               AddCSharpLine("uScriptDebug.Log( \"The generated code is not compatible with your current uScript Runtime \" + uScript_MasterComponent.Version, uScriptDebug.Type.Error );");
               AddCSharpLine("ExposedVariables = null;");
               AddCSharpLine("UnityEngine.Debug.Break();");
               --m_TabStack;
               AddCSharpLine("}");
            }

            --m_TabStack;
            AddCSharpLine("}");

            AddCSharpLine("void Start( )");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               AddCSharpLine("ExposedVariables.Start( );");
            }

            --m_TabStack;
            AddCSharpLine("}");

            AddCSharpLine("void OnEnable( )");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               AddCSharpLine("ExposedVariables.OnEnable( );");
            }

            --m_TabStack;
            AddCSharpLine("}");

            AddCSharpLine("void OnDisable( )");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               AddCSharpLine("ExposedVariables.OnDisable( );");
            }

            --m_TabStack;
            AddCSharpLine("}");


            //always do update because the unity hooks
            //and drivens are valdiated there
            AddCSharpLine("void Update( )");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               AddCSharpLine("ExposedVariables.Update( );");
            }

            --m_TabStack;
            AddCSharpLine("}");

            AddCSharpLine("void OnDestroy( )");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               AddCSharpLine("ExposedVariables.OnDestroy( );");
            }

            --m_TabStack;
            AddCSharpLine("}");

            if (true == NeedsMethod("LateUpdate"))
            {
               AddCSharpLine("void LateUpdate( )");
               AddCSharpLine("{");
               ++m_TabStack;

               if (false == stubCode)
               {
                  AddCSharpLine("ExposedVariables.LateUpdate( );");
               }

               --m_TabStack;
               AddCSharpLine("}");
            }

            if (true == NeedsMethod("FixedUpdate"))
            {
               AddCSharpLine("void FixedUpdate( )");
               AddCSharpLine("{");
               ++m_TabStack;

               if (false == stubCode)
               {
                  AddCSharpLine("ExposedVariables.FixedUpdate( );");
               }

               --m_TabStack;
               AddCSharpLine("}");
            }

            if (true == NeedsMethod("OnGUI"))
            {
               AddCSharpLine("void OnGUI( )");
               AddCSharpLine("{");
               ++m_TabStack;

               if (false == stubCode)
               {
                  AddCSharpLine("ExposedVariables.OnGUI( );");
               }

               --m_TabStack;
               AddCSharpLine("}");
            }

            AddCSharpLine("#if UNITY_EDITOR");
            ++m_TabStack;

            AddCSharpLine("void OnDrawGizmos( )");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               DefineDrawGizmos();
            }

            --m_TabStack;
            AddCSharpLine("}");

            --m_TabStack;
            AddCSharpLine("#endif");

            --m_TabStack;
            AddCSharpLine("}");
         }

         p.End( );

         return m_CSharpString.ToString();
      }

      private bool NeedsMethod(EntityNode node, string methodName)
      {
         Profile p = new Profile("NeedsMethod");

         string s = ScriptEditor.FindNodeType(node);
         if ("" == s)
         {
            p.End();
            return false;
         }

         Type t = uScript.Instance.GetType(s);

         //nested script which isn't reflected yet
         //(maybe the code hasn't been generated)
         if (null == t && node is LogicNode)
         {
            LogicNode logic = (LogicNode)node;

            foreach (string m in logic.RequiredMethods)
            {
               if (m == methodName)
               {
                  p.End();
                  return true;
               }
            }
         }
         else if (null != t)
         {
            if (null != t.GetMethod(methodName))
            {
               p.End();
               return true;
            }
         }

         p.End();
         return false;
      }

      private bool NeedsMethod(string methodName)
      {
         Profile p = new Profile("NeedsMethod");

         foreach (EntityNode node in m_Script.DirectEntityNodes)
         {
            if (true == NeedsMethod(node, methodName))
            {
               p.End();
               return true;
            }
         }

         p.End();
         return false;
      }

      private bool NeedsGuiLayout()
      {
         Profile p = new Profile("NeedsGuiLayout");

         foreach (EntityNode node in m_Script.EntityNodes)
         {
            if (true == uScript.NodeNeedsGuiLayout(ScriptEditor.FindNodeType(node)))
            {
               p.End();
               return true;
            }
         }

         p.End();
         return false;
      }

      public string GenerateLogicScript(string logicClassName, ScriptEditor script, bool generateDebugInfo, bool stubCode)
      {
         Profile p = new Profile("GenerateLogicScript");

         m_CSharpString = new StringBuilder();
         m_TabStack = 0;

         m_Script = null;
         m_GenerateDebugInfo = generateDebugInfo;

         m_LogicEventArgs = new List<ExternalEventParameter>();
         m_ExternalParameters = new List<Parameter>();
         m_ExternalInputs = new List<Plug>();
         m_ExternalOutputs = new List<Plug>();
         m_ExternalEvents = new List<Plug>();
         // m_Drivens         = new List<string>( );
         m_RequiredMethods = new List<string>();

         if (null != script)
         {
            m_Script = script.Copy();

            Preprocess(false);

            DeclareNamespaces();
            AddCSharpLine("");

            AddCSharpLine("[NodePath(\"Graphs\")]");
            AddCSharpLine("[System.Serializable]");
            AddCSharpLine("[FriendlyName(\"" + EscapeString(script.FriendlyName.Default) + "\", \"" + EscapeString(script.Description.Default) + "\")]");
            BeginLogicClass(logicClassName);
            AddCSharpLine("");

            ++m_TabStack;
            //required even when we stub code
            //so the inspector variables remain
            DeclareMemberVariables();
            DeclareEventArgs();
            AddCSharpLine("");

            if (false == stubCode)
            {
               SetupProperties();
               AddCSharpLine("");
               DefineSyncUnityHooks();
               AddCSharpLine("");
               DefineRegisterForUnityHooks();
               AddCSharpLine("");
               DefineSyncEventListeners();
               AddCSharpLine("");
               DefineUnregisterEventListeners();
               AddCSharpLine("");

               AddCSharpLine("public override void SetParent(GameObject g)");
               AddCSharpLine("{");
               ++m_TabStack;
               DefineSetParent();
               --m_TabStack;
               AddCSharpLine("}");
            }

            //we have to define each method regardless if we stub code or not
            //because classes which reflect us need to know if we have certain methods or not
            AddCSharpLine("public void Awake()");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               DefineAwakeInitialization();
            }

            --m_TabStack;
            AddCSharpLine("}");
            AddCSharpLine("");

            if (false == m_RequiredMethods.Contains("Start")) m_RequiredMethods.Add("Start");

            AddCSharpLine("public void Start()");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               DefineStartInitialization();
            }

            --m_TabStack;
            AddCSharpLine("}");
            AddCSharpLine("");

            if (false == m_RequiredMethods.Contains("OnEnable")) m_RequiredMethods.Add("OnEnable");

            AddCSharpLine("public void OnEnable()");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               DefineOnEnable();
            }

            --m_TabStack;
            AddCSharpLine("}");
            AddCSharpLine("");

            if (false == m_RequiredMethods.Contains("OnDisable")) m_RequiredMethods.Add("OnDisable");

            AddCSharpLine("public void OnDisable()");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               DefineOnDisable();
            }

            --m_TabStack;
            AddCSharpLine("}");
            AddCSharpLine("");

            //always do fixed update because this is where we sync our unity hooks
            if (false == m_RequiredMethods.Contains("Update")) m_RequiredMethods.Add("Update");

            AddCSharpLine("public void Update()");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               DefineUpdate();
            }

            --m_TabStack;
            AddCSharpLine("}");
            AddCSharpLine("");


            if (false == m_RequiredMethods.Contains("OnDestroy")) m_RequiredMethods.Add("OnDestroy");

            AddCSharpLine("public void OnDestroy()");
            AddCSharpLine("{");
            ++m_TabStack;

            if (false == stubCode)
            {
               DefineOnDestroy();
            }

            --m_TabStack;
            AddCSharpLine("}");
            AddCSharpLine("");


            if (true == NeedsMethod("LateUpdate"))
            {
               if (false == m_RequiredMethods.Contains("LateUpdate")) m_RequiredMethods.Add("LateUpdate");

               AddCSharpLine("public void LateUpdate()");
               AddCSharpLine("{");
               ++m_TabStack;

               if (false == stubCode)
               {
                  DefineLateUpdate();
               }

               --m_TabStack;
               AddCSharpLine("}");
               AddCSharpLine("");
            }

            if (true == NeedsMethod("FixedUpdate"))
            {
               if (false == m_RequiredMethods.Contains("FixedUpdate")) m_RequiredMethods.Add("FixedUpdate");

               AddCSharpLine("public void FixedUpdate()");
               AddCSharpLine("{");
               ++m_TabStack;

               if (false == stubCode)
               {
                  DefineFixedUpdate();
               }

               --m_TabStack;
               AddCSharpLine("}");
               AddCSharpLine("");
            }

            if (true == NeedsMethod("OnGUI"))
            {
               if (false == m_RequiredMethods.Contains("OnGUI")) m_RequiredMethods.Add("OnGUI");

               AddCSharpLine("public void OnGUI()");
               AddCSharpLine("{");
               ++m_TabStack;

               if (false == stubCode)
               {
                  DefineOnGUI();
               }

               --m_TabStack;
               AddCSharpLine("}");
               AddCSharpLine("");
            }

            DefineEvents(stubCode);
            
            if (false == stubCode)
            {
               DefineUpdateEditorValues();
               DefineCheckDebugBreak();
            }

            --m_TabStack;

            EndClass();
         }

         p.End();
         return m_CSharpString.ToString();
      }

      private void DeclareNamespaces()
      {
         Profile p = new Profile("DeclareNamespaces");

         AddCSharpLine("//uScript Generated Code - Build " + uScriptBuild.Number);
         if (true == m_GenerateDebugInfo)
         {
            AddCSharpLine("//Generated with Debug Info");
         }

         AddCSharpLine("using UnityEngine;");
         AddCSharpLine("using System.Collections;");
         AddCSharpLine("using System.Collections.Generic;");

         p.End();
      }

      private void BeginLogicClass(string logicClassName)
      {
         Profile p = new Profile("BeginLogicClass");

         AddCSharpLine("public class " + logicClassName + " : uScriptLogic");
         AddCSharpLine("{");

         p.End();
      }

      private void EndClass()
      {
         AddCSharpLine("}");
      }

      //these are property get and set functions for the entity
      //
      //Set:
      //as per the 'how it works' comment, our 'input node variable' will be set
      //and then a PropertySet function is called which sends that variable
      //to the entity's properties
      //
      //Get:
      //a PropertyGet function is called to refresh a CSharp variable with
      //the latest entity property value

      //NOTE: the 'input node variable' used in the Set is not updated with the Get call, 
      //the Get call should return directly into whichever variable wants to consume it
      //the 'input node variable' is only required by the Set function
      private void SetupProperties()
      {
         Profile p = new Profile("SetupProperties");

         AddCSharpLine("//functions to refresh properties from entities");

         foreach (EntityProperty entityProperty in m_Script.Properties)
         {
            bool isArray = entityProperty.Parameter.Type.Contains("[]");

            if (false == entityProperty.IsStatic)
            {
               if (entityProperty.Instance.Default != "")
               {
                  if (true == entityProperty.Parameter.Output)
                  {
                     //as stated above, cretae a function which
                     //gets the property from the entity and sets the corresponding CSharp variable
                     AddCSharpLine(FormatType(entityProperty.Parameter.Type) + " " + CSharpRefreshGetPropertyDeclaration(entityProperty) + "( )");
                     AddCSharpLine("{");
                     ++m_TabStack;
                     AddCSharpLine(entityProperty.ComponentType + " component = null;");
                     if (entityProperty.ComponentType != "UnityEngine.GameObject")
                     {
                        AddCSharpLine("if (" + CSharpName(entityProperty, entityProperty.Instance.Name) + " != null)");
                        AddCSharpLine("{");
                        ++m_TabStack;
                           AddCSharpLine("component = " + CSharpName(entityProperty, entityProperty.Instance.Name) + ".GetComponent<" + entityProperty.ComponentType + ">();");
                        --m_TabStack;
                        AddCSharpLine("}");
                     }
                     else
                        AddCSharpLine("component = " + CSharpName(entityProperty, entityProperty.Instance.Name) + ";");
                      
                     AddCSharpLine("if ( null != component )");
                     AddCSharpLine("{");
                     ++m_TabStack;
                     if (true == isArray)
                     {
                        string type = entityProperty.Parameter.Type.Replace("[]", "");
                        AddCSharpLine("return new List<" + FormatType(type) + ">(component." + entityProperty.Parameter.Name + ").ToArray();");
                     }
                     else
                     {
                        AddCSharpLine("return component." + entityProperty.Parameter.Name + ";");
                     }
                     --m_TabStack;
                     AddCSharpLine("}");
                     AddCSharpLine("else");
                     AddCSharpLine("{");
                     ++m_TabStack;
                     AddCSharpLine("return " + FormatValue(entityProperty.Parameter.Default, entityProperty.Parameter.Type) + ";");
                     --m_TabStack;
                     AddCSharpLine("}");
                     --m_TabStack;
                     AddCSharpLine("}");
                     AddCSharpLine("");
                  }

                  if (true == entityProperty.Parameter.Input)
                  {
                     //as stated above, create a function which sets the entity's property to the
                     //corresponding CSharp variable's value
                     AddCSharpLine("void " + CSharpRefreshSetPropertyDeclaration(entityProperty) + "( )");
                     AddCSharpLine("{");
                     ++m_TabStack;
                     AddCSharpLine(entityProperty.ComponentType + " component = null;");
                     if (entityProperty.ComponentType != "UnityEngine.GameObject")
                     {
                        AddCSharpLine("if (" + CSharpName(entityProperty, entityProperty.Instance.Name) + " != null)");
                        AddCSharpLine("{");
                        ++m_TabStack;
                           AddCSharpLine("component = " + CSharpName(entityProperty, entityProperty.Instance.Name) + ".GetComponent<" + entityProperty.ComponentType + ">();");
                        --m_TabStack;
                        AddCSharpLine("}");
                     }
                     else
                        AddCSharpLine("component = " + CSharpName(entityProperty, entityProperty.Instance.Name) + ";");

                     AddCSharpLine("if ( null != component )");
                     AddCSharpLine("{");
                     ++m_TabStack;
                     if (true == isArray)
                     {
                        string type = entityProperty.Parameter.Type.Replace("[]", "");
                        AddCSharpLine("component." + entityProperty.Parameter.Name + " = new List<" + FormatType(type) + ">(" + CSharpName(entityProperty, entityProperty.Parameter.Name) + ").ToArray();");
                     }
                     else
                     {
                        AddCSharpLine("component." + entityProperty.Parameter.Name + " = " + CSharpName(entityProperty, entityProperty.Parameter.Name) + ";");
                     }
                     --m_TabStack;
                     AddCSharpLine("}");
                     --m_TabStack;
                     AddCSharpLine("}");
                     AddCSharpLine("");
                  }
               }
               else
               {
                  //only one instance allowed because we have no way to return multiple values (if > 1 instances were hooked up, who's would we return on get?)
                  LinkNode[] instanceLinks = FindLinksByDestination(entityProperty.Guid, entityProperty.Instance.Name);

                  foreach (LinkNode instanceLink in instanceLinks)
                  {
                     EntityNode entityNode = m_Script.GetNode(instanceLink.Source.Guid);

                     if (true == entityProperty.Parameter.Output)
                     {

                        //as stated above, cretae a function which
                        //gets the property from the entity and sets the corresponding CSharp variable
                        AddCSharpLine(FormatType(entityProperty.Parameter.Type) + " " + CSharpRefreshGetPropertyDeclaration(entityProperty) + "( )");
                        AddCSharpLine("{");
                        ++m_TabStack;

                        AddCSharpLine(entityProperty.ComponentType + " component = null;"); 
                        
                        if (entityNode is EntityProperty)
                        {
                           SyncSlaveConnections(entityProperty, new Parameter[]{entityProperty.Instance});

                           if (entityProperty.ComponentType != "UnityEngine.GameObject")
                           {
                              AddCSharpLine("if (" + CSharpName(entityNode, entityNode.Parameters[0].Name) + " != null)");
                              AddCSharpLine("{");
                              ++m_TabStack;
                                 AddCSharpLine("component = " + CSharpName(entityNode, entityNode.Parameters[0].Name) + ".GetComponent<" + entityProperty.ComponentType + ">();");
                              --m_TabStack;
                              AddCSharpLine("}");
                           }
                           else
                              AddCSharpLine("component = " + CSharpName(entityNode, entityNode.Parameters[0].Name) + ";");
                        }
                        else
                        {
                           if (entityProperty.ComponentType != "UnityEngine.GameObject")
                           {
                              AddCSharpLine("if (" + CSharpName(entityNode)  + " != null)");
                              AddCSharpLine("{");
                              ++m_TabStack;
                                 AddCSharpLine("component = " + CSharpName(entityNode)  + ".GetComponent<" + entityProperty.ComponentType + ">();");
                              --m_TabStack;
                              AddCSharpLine("}");
                           }
                           else
                              AddCSharpLine("component = " + CSharpName(entityNode) + ";");
                        }

                        AddCSharpLine("if ( null != component )");
                        AddCSharpLine("{");
                        ++m_TabStack;
                        if (true == isArray)
                        {
                           string type = entityProperty.Parameter.Type.Replace("[]", "");
                           AddCSharpLine("return new List<" + FormatType(type) + ">(component." + entityProperty.Parameter.Name + ").ToArray();");
                        }
                        else
                        {
                           AddCSharpLine("return component." + entityProperty.Parameter.Name + ";");
                        }
                        --m_TabStack;
                        AddCSharpLine("}");
                        AddCSharpLine("else");
                        AddCSharpLine("{");
                        ++m_TabStack;
                        AddCSharpLine("return " + FormatValue(entityProperty.Parameter.Default, entityProperty.Parameter.Type) + ";");
                        --m_TabStack;
                        AddCSharpLine("}");
                        --m_TabStack;
                        AddCSharpLine("}");
                        AddCSharpLine("");
                     }

                     if (true == entityProperty.Parameter.Input)
                     {
                        //as stated above, create a function which sets the entity's property to the
                        //corresponding CSharp variable's value
                        AddCSharpLine("void " + CSharpRefreshSetPropertyDeclaration(entityProperty) + "( )");
                        AddCSharpLine("{");
                        ++m_TabStack;

                        AddCSharpLine(entityProperty.ComponentType + " component = null;");

                        if (entityNode is EntityProperty)
                        {
                           SyncSlaveConnections(entityProperty, new Parameter[]{entityProperty.Instance});

                           if (entityProperty.ComponentType != "UnityEngine.GameObject")
                           {
                              AddCSharpLine("if (" + CSharpName(entityNode, entityNode.Parameters[0].Name) + " != null)");
                              AddCSharpLine("{");
                              ++m_TabStack;
                                 AddCSharpLine("component = " + CSharpName(entityNode, entityNode.Parameters[0].Name) + ".GetComponent<" + entityProperty.ComponentType + ">();");
                              --m_TabStack;
                              AddCSharpLine("}");
                           }
                           else
                              AddCSharpLine("component = " + CSharpName(entityNode, entityNode.Parameters[0].Name) + ";");
                        }
                        else
                        {
                           if (entityProperty.ComponentType != "UnityEngine.GameObject")
                           {
                              AddCSharpLine("if (" + CSharpName(entityNode) + " != null)");
                              AddCSharpLine("{");
                              ++m_TabStack;
                                 AddCSharpLine("component = " + CSharpName(entityNode) + ".GetComponent<" + entityProperty.ComponentType + ">();");
                              --m_TabStack;
                              AddCSharpLine("}");
                           }
                           else
                              AddCSharpLine("component = " + CSharpName(entityNode) + ";");
                        }

                        AddCSharpLine("if ( null != component )");
                        AddCSharpLine("{");
                        ++m_TabStack;
                        if (true == isArray)
                        {
                           string type = entityProperty.Parameter.Type.Replace("[]", "");
                           AddCSharpLine("component." + entityProperty.Parameter.Name + " = new List<" + FormatType(type) + ">(" + CSharpName(entityProperty, entityProperty.Parameter.Name) + ").ToArray();");
                        }
                        else
                        {
                           AddCSharpLine("component." + entityProperty.Parameter.Name + " = " + CSharpName(entityProperty, entityProperty.Parameter.Name) + ";");
                        }
                        --m_TabStack;
                        AddCSharpLine("}");
                        --m_TabStack;
                        AddCSharpLine("}");
                        AddCSharpLine("");
                     }

                     break;
                  }
               }
            }
            else //it is static
            {
               if (true == entityProperty.Parameter.Output)
               {
                  //as stated above, cretae a function which
                  //gets the property from the entity and sets the corresponding CSharp variable
                  AddCSharpLine(FormatType(entityProperty.Parameter.Type) + " " + CSharpRefreshGetPropertyDeclaration(entityProperty) + "( )");
                  AddCSharpLine("{");
                  ++m_TabStack;
                  AddCSharpLine("return " + entityProperty.ComponentType + "." + entityProperty.Parameter.Name + ";");
                  --m_TabStack;

                  AddCSharpLine("}");
                  AddCSharpLine("");
               }

               if (true == entityProperty.Parameter.Input)
               {
                  //as stated above, create a function which sets the entity's property to the
                  //corresponding CSharp variable's value
                  AddCSharpLine("void " + CSharpRefreshSetPropertyDeclaration(entityProperty) + "( )");
                  AddCSharpLine("{");
                  // don't allow property setter for constants
                  if (entityProperty.ComponentType != "UnityEngine.Mathf")
                  {
                     ++m_TabStack;
                     AddCSharpLine(entityProperty.ComponentType + "." + entityProperty.Parameter.Name + " = " + CSharpName(entityProperty, entityProperty.Parameter.Name) + ";");
                     --m_TabStack;
                  }
                  AddCSharpLine("}");
                  AddCSharpLine("");
               }
            }
         }

         p.End();
      }

      private string FormatValue(string stringValue, string type)
      {
         if ("System.Object" == type)
         {
            return "\"" + EscapeString(stringValue) + "\"";
         }
         else if ("System.Boolean" == type)
         {
            if ("" == stringValue)
            {
               return "(bool) false";
            }

            return "(bool) " + stringValue;
         }
         else if ("System.String" == type)
         {
            return "\"" + EscapeString(stringValue) + "\"";
         }
         else if ("UnityEngine.Quaternion" == type)
         {
            try
            {
               string[] subString = stringValue.Split(',');
               return "new Quaternion( (float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + ", (float)" + subString[3] + " )";
            }
            catch (Exception) { return "new Quaternion( )"; }
         }
         else if ("UnityEngine.Matrix4x4" == type)
         {
            try
            {
               string[] subString = stringValue.Split(',');
               return "Matrix4x4.TRS( new Vector3((float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + "), " +
                              "new Quaternion((float)" + subString[3] + ", (float)" + subString[4] + ", (float)" + subString[5] + ", (float)" + subString[6] + "), " +
                              "new Vector3((float)" + subString[7] + ", (float)" + subString[8] + ", (float)" + subString[9] + "))";
            }
            catch (Exception) { return "new Matrix4x4( )"; }
         }
         else if ("UnityEngine.Vector2" == type)
         {
            try
            {
               string[] subString = stringValue.Split(',');
               return "new Vector2( (float)" + subString[0] + ", (float)" + subString[1] + " )";
            }
            catch (Exception) { return "new Vector2( )"; }
         }
         else if ("UnityEngine.Vector3" == type)
         {
            try
            {
               string[] subString = stringValue.Split(',');
               return "new Vector3( (float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + " )";
            }
            catch (Exception) { return "new Vector3( )"; }
         }
         else if ("UnityEngine.Vector4" == type)
         {
            try
            {
               string[] subString = stringValue.Split(',');
               return "new Vector4( (float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + ", (float)" + subString[3] + " )";
            }
            catch (Exception) { return "new Vector4( )"; }
         }
         else if ("UnityEngine.Rect" == type)
         {
            try
            {
               string[] subString = stringValue.Split(',');
               return "new Rect( (float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + ", (float)" + subString[3] + " )";
            }
            catch (Exception) { return "new Rect( )"; }
         }
         else if ("System.Single" == type)
         {
            if ("" == stringValue)
            {
               return "(float) 0";
            }

            return "(float) " + stringValue;
         }
         else if ("System.Double" == type)
         {
            if ("" == stringValue)
            {
               return "(double) 0";
            }

            return "(double) " + stringValue;
         }
         else if ("System.Int16" == type)
         {
            if ("" == stringValue)
            {
               return "(short) 0";
            }

            return "(int) " + stringValue;
         }
         else if ("System.Int32" == type)
         {
            if ("" == stringValue)
            {
               return "(int) 0";
            }

            return "(int) " + stringValue;
         }
         else if ("System.Int64" == type)
         {
            if ("" == stringValue)
            {
               return "(long) 0";
            }

            return "(long) " + stringValue;
         }
         else if ("System.UInt16" == type)
         {
            if ("" == stringValue)
            {
               return "(ushort) 0";
            }

            return "(ushort) " + stringValue;
         }
         else if ("System.UInt32" == type)
         {
            if ("" == stringValue)
            {
               return "(uint) 0";
            }

            return "(uint) " + stringValue;
         }
         else if ("System.UInt64" == type)
         {
            if ("" == stringValue)
            {
               return "(ulong) 0";
            }

            return "(ulong) " + stringValue;
         }
         else if ("System.Byte" == type)
         {
            if ("" == stringValue)
            {
               return "(byte) 0";
            }

            return "(byte) " + stringValue;
         }
         else if ("System.SByte" == type)
         {
            if ("" == stringValue)
            {
               return "(sbyte) 0";
            }

            return "(sbyte) " + stringValue;
         }
         else if ("System.Decimal" == type)
         {
            if ("" == stringValue)
            {
               return "(decimal) 0";
            }

            return "(decimal) " + stringValue;
         }
         else if ("UnityEngine.GUILayoutOption" == type)
         {
            try
            {
               string[] tokens = stringValue.Split(':');
               return "GUILayout." + tokens[0] + "(" + tokens[1] + ")";
            }
            catch (Exception) { return "GUILayout.Width(0)"; }
         }
         else if ("UnityEngine.Color" == type)
         {
            try
            {
               string[] subString = stringValue.Split(',');
               return "new UnityEngine.Color( (float)" + subString[0] + ", (float)" + subString[1] + ", (float)" + subString[2] + ", (float)" + subString[3] + " )";
            }
            catch (Exception) { return "UnityEngine.Color.black"; }
         }
         else if ("UnityEngine.Color32" == type)
         {
             try
             {
                 string[] subString = stringValue.Split(',');
                 return "new UnityEngine.Color32( (byte)" + subString[0] + ", (byte)" + subString[1] + ", (byte)" + subString[2] + ", (byte)" + subString[3] + " )";
             }
             catch (Exception) { return "UnityEngine.Color.black"; }
         }
         else if (type.Contains("Dictionary"))
         {
            return "new " + FormatType(type) + "( )";
         }
         else if ("UnityEngine.LayerMask" == type)
         {
            if ("" == stringValue)
            {
               return "0";
            }

            return stringValue;
         }
         else if (type.Contains("[]"))
         {
            return FormatArrayValue(stringValue, type);
         }
         else if (null != uScript.GetAssemblyQualifiedType(type))
         {
            System.Type netType = uScript.GetAssemblyQualifiedType(type);

            if (typeof(System.Enum).IsAssignableFrom(netType))
            {
               System.Enum newEnum;

               //try and turn the text field value back into an enum, if it doesn't work
               //then revert back to the original value
               try { newEnum = (System.Enum)System.Enum.Parse(netType, stringValue); }
               catch { newEnum = (System.Enum)System.Enum.Parse(netType, System.Enum.GetNames(netType)[0]); }


               return FormatType(netType + "." + newEnum.ToString());
            }
         }

         return "default(" + FormatType(type) + ")";
      }

      private string FormatArrayValue(string stringValue, string type)
      {
         string declaration = "";

         string[] elements = Parameter.StringToArray(stringValue);

         if ("UnityEngine.Quaternion[]" == type)
         {
            try
            {
               elements = Parameter.FlattenStringArrays(elements, ',');

               declaration = "new Quaternion[] {";

               for (int i = 0; i < elements.Length; i += 4)
               {
                  declaration += "new Quaternion((float)" + elements[i] + ",(float)" + elements[i + 1] + ",(float)" + elements[i + 2] + ",(float)" + elements[i + 3] + "),";
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
               declaration += "}";
            }
            catch (Exception) { declaration = "new Quaternion[0]"; }
         }
         else if ("UnityEngine.Vector2[]" == type)
         {
            try
            {
               elements = Parameter.FlattenStringArrays(elements, ',');

               declaration = "new Vector2[] {";

               for (int i = 0; i < elements.Length; i += 2)
               {
                  declaration += "new Vector2((float)" + elements[i] + ",(float)" + elements[i + 1] + "),";
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
               declaration += "}";
            }
            catch (Exception) { declaration = "new Vector2[0]"; }
         }
         else if ("UnityEngine.Vector3[]" == type)
         {
            try
            {
               elements = Parameter.FlattenStringArrays(elements, ',');

               declaration = "new Vector3[] {";

               for (int i = 0; i < elements.Length; i += 3)
               {
                  declaration += "new Vector3((float)" + elements[i] + ",(float)" + elements[i + 1] + ",(float)" + elements[i + 2] + "),";
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
               declaration += "}";
            }
            catch (Exception) { declaration = "new Vector3[0]"; }
         }
         else if ("UnityEngine.Vector4[]" == type)
         {
            try
            {
               elements = Parameter.FlattenStringArrays(elements, ',');

               declaration = "new Vector4[] {";

               for (int i = 0; i < elements.Length; i += 4)
               {
                  declaration += "new Vector4((float)" + elements[i] + ",(float)" + elements[i + 1] + ",(float)" + elements[i + 2] + ",(float)" + elements[i + 3] + "),";
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
               declaration += "}";
            }
            catch (Exception) { declaration = "new Vector4[0]"; }
         }
         else if ("UnityEngine.Rect[]" == type)
         {
            try
            {
               elements = Parameter.FlattenStringArrays(elements, ',');

               declaration = "new Rect[] {";

               for (int i = 0; i < elements.Length; i += 4)
               {
                  declaration += "new Rect((float)" + elements[i] + ",(float)" + elements[i + 1] + ",(float)" + elements[i + 2] + ",(float)" + elements[i + 3] + "),";
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
               declaration += "}";
            }
            catch (Exception) { declaration = "new Rect[0]"; }
         }
         else if ("UnityEngine.GUILayoutOption[]" == type)
         {
            try
            {
               declaration = "new UnityEngine.GUILayoutOption[] { ";

               for (int i = 0; i < elements.Length; i++)
               {
                  string[] tokens = elements[i].Split(':');
                  declaration += "GUILayout." + tokens[0] + "(" + tokens[1] + "), ";
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 2);

               declaration += " }";
            }
            catch (Exception) { declaration = "new GUILayoutOption[0]"; }
         }
         else if ("UnityEngine.Color[]" == type)
         {
            try
            {
               elements = Parameter.FlattenStringArrays(elements, ',');

               declaration = "new UnityEngine.Color[] {";

               for (int i = 0; i < elements.Length; i += 4)
               {
                  declaration += "new UnityEngine.Color((float)" + elements[i] + ", (float)" + elements[i + 1] + ", (float)" + elements[i + 2] + ", (float)" + elements[i + 3] + "),";
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
               declaration += "}";
            }
            catch (Exception) { declaration = "new UnityEngine.Color[0]"; }
         }
         else if ("UnityEngine.Color32[]" == type)
         {
             try
             {
                 elements = Parameter.FlattenStringArrays(elements, ',');
                 
                 declaration = "new UnityEngine.Color32[] {";
                 
                 for (int i = 0; i < elements.Length; i += 4)
                 {
                     declaration += "new UnityEngine.Color32((byte)" + elements[i] + ", (byte)" + elements[i + 1] + ", (byte)" + elements[i + 2] + ", (byte)" + elements[i + 3] + "),";
                 }
                 
                 if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
                 declaration += "}";
             }
             catch (Exception) { declaration = "new UnityEngine.Color32[0]"; }
         }
         else if ("UnityEngine.GameObject[]" == type)
         {
            try
            {
               declaration = "new UnityEngine.GameObject[] {";

               string arguments = "";

               for (int i = 0; i < elements.Length; i++)
               {
                  if ("" == elements[i]) continue;

                  arguments += "null,";
               }

               if (arguments.Length > 0) arguments = arguments.Substring(0, arguments.Length - 1);

               declaration += arguments;
               declaration += "}";
            }
            catch (Exception) { declaration = "new UnityEngine.GameObject[0]"; }
         }
         else if ("UnityEngine.Component[]" == type)
         {
            try
            {
               declaration = "new UnityEngine.Component[] {";

               for (int i = 0; i < elements.Length; i++)
               {
                  declaration += "null,";
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
               declaration += "}";
            }
            catch (Exception) { declaration = "new UnityEngine.Component[0]"; }
         }
         else if ("UnityEngine.NetworkPlayer[]" == type)
         {
            try
            {
               declaration = "new UnityEngine.NetworkPlayer[] {";

               for (int i = 0; i < elements.Length; i++)
               {
                  declaration += "new UnityEngine.NetworkPlayer(),";
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
               declaration += "}";
            }
            catch (Exception) { declaration = "new UnityEngine.NetworkPlayer[0]"; }
         }
         else if ("UnityEngine.Camera[]" == type)
         {
            try
            {
               declaration = "new UnityEngine.Camera[] {";

               for (int i = 0; i < elements.Length; i++)
               {
                  declaration += "null,";
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
               declaration += "}";
            }
            catch (Exception) { declaration = "new UnityEngine.Camera[0]"; }
         }
         else if ("System.Boolean[]" == type)
         {
            try
            {
               declaration = "new System.Boolean[] {";

               for (int i = 0; i < elements.Length; i++)
               {
                  string value = elements[i].Trim();
                  if ("" == value) value = "false";

                  declaration += value + ",";
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
               declaration += "}";
            }
            catch (Exception) { declaration = "new UnityEngine.Boolean[0]"; }
         }
         else if ("UnityEngine.ContactPoint[]" == type)
         {
            declaration = "new UnityEngine.ContactPoint[ " + elements.Length + " ]";
         }
         else if ("UnityEngine.WheelHit[]" == type)
         {
            declaration = "new UnityEngine.WheelHit[ " + elements.Length + " ]";
         }
         else if ("UnityEngine.Texture2D[]" == type)
         {
            declaration = "new UnityEngine.Texture2D[ " + elements.Length + " ]";
         }
         else if ("UnityEngine.Touch[]" == type)
         {
            declaration = "new UnityEngine.Touch[ " + elements.Length + " ]";
         }
         else if ("UnityEngine.Plane[]" == type)
         {
            declaration = "new UnityEngine.Plane[ " + elements.Length + " ]";
         }
         else if ("UnityEngine.AudioClip[]" == type)
         {
            declaration = "new UnityEngine.AudioClip[ " + elements.Length + " ]";
         }
         else if ("UnityEngine.AnimationClip[]" == type)
         {
            declaration = "new UnityEngine.AnimationClip[ " + elements.Length + " ]";
         }
         else if ("UnityEngine.Material[]" == type)
         {
            declaration = "new UnityEngine.Material[ " + elements.Length + " ]";
         }
         else
         {
            try
            {
               string cast = "";

               if ("System.Single[]" == type)
               {
                  cast = "(float)";
               }
               else if ("System.Double[]" == type)
               {
                  cast = "(double)";
               }
               else
               {
                  if (null != uScript.GetAssemblyQualifiedType(type.Replace("[]", "")))
                  {
                     System.Type netType = uScript.GetAssemblyQualifiedType(type.Replace("[]", ""));

                     if (typeof(System.Enum).IsAssignableFrom(netType))
                     {
                        cast = netType.ToString() + ".";
                        cast = FormatType(cast);
                     }
                  }
               }

               bool formatString = (type == "System.String[]" || type == "System.Object[]");

               declaration = "new " + FormatType(type) + " {";

               foreach (string element in elements)
               {
                  if (true == formatString)
                  {
                     declaration += "\"" + EscapeString(element) + "\"" + ",";
                  }
                  else
                  {
                     string value = element.Trim();
                     if ("" == value) value = "0";

                     declaration += cast + value + ",";
                  }
               }

               if (elements.Length > 0) declaration = declaration.Substring(0, declaration.Length - 1);
               declaration += "}";
            }
            catch (Exception) { declaration = "new " + type.Replace("[]", "") + "[0]"; }
         }

         return declaration;
      }

      private void DefineDrawGizmos()
      {
         Hashtable uniqueObjects = new Hashtable();

         foreach (EntityNode node in m_Script.EntityNodes)
         {
            if (node is LocalNode)
            {
               LocalNode localNode = (LocalNode)node;

               if ("UnityEngine.GameObject" == localNode.Value.Type && "" != localNode.Value.Default)
               {
                  uniqueObjects[localNode.Value.Default] = "uscript_gizmo_variables.png";
               }
            }
            else
            {
               if (null == node.Instance.Default || "" == node.Instance.Default) continue;

               if (node is EntityEvent)
               {
                  uniqueObjects[node.Instance.Default] = "uscript_gizmo_events.png";
               }
               else if (node is EntityMethod)
               {
                  uniqueObjects[node.Instance.Default] = "uscript_gizmo.png";
               }
            }
         }

         if (uniqueObjects.Keys.Count > 0)
         {
            foreach (string key in uniqueObjects.Keys)
            {
               //ignore master game object - this will render its own master gizmo
               if (key == uScriptRuntimeConfig.MasterObjectName) continue;

               AddCSharpLine("{");
               ++m_TabStack;
               AddCSharpLine("GameObject gameObject;");
               AddCSharpLine("gameObject = GameObject.Find( \"" + EscapeString(key) + "\" ); ");
               AddCSharpLine("if ( null != gameObject ) Gizmos.DrawIcon(gameObject.transform.position, \"" + uniqueObjects[key] + "\");");
               --m_TabStack;
               AddCSharpLine("}");
            }
         }
      }

      //if we're a nested script declare any event arguments we put out
      private void DeclareEventArgs()
      {
         Profile profile = new Profile("DeclareEventArgs");

         ExternalConnection[] externals = m_Script.Externals;
         if (0 == externals.Length) return;

         m_LogicEventArgs = new List<ExternalEventParameter>();

         foreach (ExternalConnection external in externals)
         {
            LinkNode[] links = FindLinksByDestination(external.Guid, external.Connection);

            foreach (LinkNode link in links)
            {
               EntityNode node = m_Script.GetNode(link.Source.Guid);

               foreach (Parameter p in node.Parameters)
               {
                  if (p.Name == link.Source.Anchor &&
                     true == p.Output)
                  {
                     //update the parameter with whatever our external name will be
                     //instead of the actual parameter name of the source node
                     Parameter clone = p;
                     clone.Name = CSharpExternalParameterDeclaration(external.Name.Default).Name;

                     ExternalEventParameter eep;
                     eep.ExternalParameter = clone;
                     eep.ExternalVariableNode = external;

                     m_LogicEventArgs.Add(eep);
                     break;
                  }
               }

               //only one link allowed for each external parameter output
               break;
            }
         }


         AddCSharpLine("public delegate void uScriptEventHandler(object sender, LogicEventArgs args);");
         AddCSharpLine("");

         AddCSharpLine("public class " + LogicEventArgsDeclaration() + " : System.EventArgs");
         AddCSharpLine("{");
         ++m_TabStack;
         foreach (ExternalEventParameter eep in m_LogicEventArgs)
         {
            Parameter p = eep.ExternalParameter;
            AddCSharpLine("public " + FormatType(p.Type) + " " + p.Name + " = " + FormatValue(p.Default, p.Type) + ";");
         }
         --m_TabStack;
         AddCSharpLine("}");

         profile.End();
      }

      public string LogicEventArgsDeclaration()
      {
         return "LogicEventArgs";
      }

      //declare all the members this file will use throughout the CSharp functions
      //all node inputs are represented by global variables
      private void DeclareMemberVariables()
      {
         Profile p = new Profile("DeclareMemberVariables");

         AddCSharpLine("#pragma warning disable 414");

         AddCSharpLine("GameObject parentGameObject = null;");
         AddCSharpLine("uScript_GUI " + OnGuiListenerName() + " = null; ");

         AddCSharpLine("bool m_RegisteredForEvents = false;");

         if (true == m_GenerateDebugInfo)
         {
            AddCSharpLine("delegate void ContinueExecution();");
            AddCSharpLine("ContinueExecution m_ContinueExecution;");
            AddCSharpLine("bool m_Breakpoint = false;");

            AddCSharpLine("const int MaxRelayCallCount = " + uScript.Preferences.MaximumNodeRecursionCount + ";");
            AddCSharpLine("int relayCallCount = 0;");
         }

         AddCSharpLine("");
         AddCSharpLine("//externally exposed events");
         Plug[] events = FindExternalEvents();

         if (events.Length > 0)
         {
            //AddCSharpLine( "public delegate void uScriptEventHandler(object sender, System.EventArgs args);" );
            foreach (Plug eventPlug in events)
            {
               AddCSharpLine("[FriendlyName(\"" + EscapeString(eventPlug.FriendlyName) + "\")]");
               AddCSharpLine("public event uScriptEventHandler " + eventPlug.Name + ";");

               m_ExternalEvents.Add(eventPlug);
            }
         }


         AddCSharpLine("");
         AddCSharpLine("//external parameters");
         foreach (ExternalConnection external in m_Script.Externals)
         {
            Parameter lowestParameter = GetLowestCommonExternalParameter(external);
            if (lowestParameter != Parameter.Empty)
            {
               AddCSharpLine(FormatType(lowestParameter.Type) + " " + CSharpName(external) + " = " + FormatValue(lowestParameter.Default, lowestParameter.Type) + ";");
            }
            else
            {
               LinkNode[] links = FindLinksBySource(external.Guid, external.Connection);

               foreach (LinkNode link in links)
               {
                  EntityNode node = m_Script.GetNode(link.Destination.Guid);

                  if (node is EntityMethod || node is EntityProperty)
                  {
                     if (node.Instance.Name == link.Destination.Anchor)
                     {
                        AddCSharpLine(FormatType(node.Instance.Type) + " " + CSharpName(external) + " = " + FormatValue(node.Instance.Default, node.Instance.Type) + ";");
                        break;
                     }
                  }

                  //only one link allowed for each external parameter output
                  break;
               }
            }
         }

         AddCSharpLine("");
         AddCSharpLine("//local nodes");

         LocalNode [] locals = m_Script.UniqueLocals;
         Array.Sort(locals, LocalComparer);

         foreach (LocalNode local in locals)
         {
            if ( "true" == local.HideInInspector.Default )
            {
               AddCSharpLine("[HideInInspector]");
            }

            string prefix = "true" == local.Externaled.Default ? "public " : "";

            AddCSharpLine(prefix + FormatType(local.Value.Type) + " " + CSharpName(local) + " = " + FormatValue(local.Value.Default, local.Value.Type) + ";");

            if (local.Value.Type == "UnityEngine.GameObject")
            {
               AddCSharpLine(FormatType(local.Value.Type) + " " + PreviousName(local) + " = null;");
            }
         }

         AddCSharpLine("");
         AddCSharpLine("//owner nodes");
         foreach (OwnerConnection owner in m_Script.Owners)
         {
            AddCSharpLine(FormatType(owner.Connection.Type) + " " + CSharpName(owner) + " = null;");
         }

         AddCSharpLine("");
         AddCSharpLine("//logic nodes");

         foreach (LogicNode logic in m_Script.Logics)
         {
            string prefix = (true == (logic.InspectorName.Default != "")) ? "public " : "";

            AddCSharpLine("//pointer to script instanced logic node");
            AddCSharpLine(prefix + FormatType(logic.Type) + " " + CSharpName(logic, logic.Type) + " = new " + FormatType(logic.Type) + "( );");

            foreach (Parameter parameter in logic.Parameters)
            {
               if (true == parameter.Input)
               {
                  AddCSharpLine(FormatType(parameter.Type) + " " + CSharpName(logic, parameter.Name) + " = " + FormatValue(parameter.Default, parameter.Type) + ";");
               }
               else
               {
                  AddCSharpLine(FormatType(parameter.Type) + " " + CSharpName(logic, parameter.Name) + ";");
               }
            }

            foreach (Plug output in logic.Outputs)
            {
               AddCSharpLine("bool " + CSharpName(logic, output.Name) + " = true;");
            }

            foreach (string driven in logic.Drivens)
            {
               AddCSharpLine("bool " + CSharpName(logic, driven) + " = false;");
            }
         }

         AddCSharpLine("");
         AddCSharpLine("//event nodes");

         foreach (EntityEvent entityEvent in m_Script.Events)
         {
            foreach (Parameter parameter in entityEvent.Parameters)
            {
               AddCSharpLine(FormatType(parameter.Type) + " " + CSharpName(entityEvent, parameter.Name) + " = " + FormatValue(parameter.Default, parameter.Type) + ";");
            }

            if (entityEvent.Instance.Default != "")
            {
               AddCSharpLine(FormatType(entityEvent.Instance.Type) + " " + CSharpName(entityEvent, entityEvent.Instance.Name) + " = " + FormatValue(entityEvent.Instance.Default, entityEvent.Instance.Type) + ";");
            }
         }

         AddCSharpLine("");
         AddCSharpLine("//property nodes");

         foreach (EntityProperty entityProperty in m_Script.Properties)
         {
            AddCSharpLine(FormatType(entityProperty.Parameter.Type) + " " + CSharpName(entityProperty, entityProperty.Parameter.Name) + " = " + FormatValue(entityProperty.Parameter.Default, entityProperty.Parameter.Type) + ";");

            // If it's a gameobject, it might be swapped out and we'd need to re-register event listeners
            if (entityProperty.Parameter.Type == "UnityEngine.GameObject")
               AddCSharpLine(FormatType(entityProperty.Parameter.Type) + " " + PreviousName(entityProperty, entityProperty.Parameter.Name) + " = null;");

            if (entityProperty.Instance.Default != "")
            {
               AddCSharpLine(FormatType(entityProperty.Instance.Type) + " " + CSharpName(entityProperty, entityProperty.Instance.Name) + " = " + FormatValue(entityProperty.Instance.Default, entityProperty.Instance.Type) + ";");
               AddCSharpLine(FormatType(entityProperty.Instance.Type) + " " + PreviousName(entityProperty, entityProperty.Instance.Name) + " = null;");
            }
         }

         AddCSharpLine("");
         AddCSharpLine("//method nodes");

         foreach (EntityMethod entityMethod in m_Script.Methods)
         {
            foreach (Parameter parameter in entityMethod.Parameters)
            {
               AddCSharpLine(FormatType(parameter.Type) + " " + CSharpName(entityMethod, parameter.Name) + " = " + FormatValue(parameter.Default, parameter.Type) + ";");
            }

            if (entityMethod.Instance.Default != "")
            {
               AddCSharpLine(FormatType(entityMethod.Instance.Type) + " " + CSharpName(entityMethod, entityMethod.Instance.Name) + " = " + FormatValue(entityMethod.Instance.Default, entityMethod.Instance.Type) + ";");
            }
         }

         AddCSharpLine("#pragma warning restore 414");

         p.End();
      }

      private void DefineSetParent()
      {
         AddCSharpLine("parentGameObject = g;");
         AddCSharpLine("");

         foreach (LogicNode logic in m_Script.Logics)
         {
            AddCSharpLine(CSharpName(logic, logic.Type) + ".SetParent(g);");
         }

         // Required because an owner game object might be accessed
         // through an OnEnable event before the initial Start has had a chance
         // to populate it:
         // http://www.uscript.net/forum/viewtopic.php?f=11&t=3012&p=21396#p21396
         foreach (OwnerConnection owner in m_Script.Owners)
         {
            AddCSharpLine(CSharpName(owner) + " = parentGameObject;");
         }
      }

      private void DefineOnEnable()
      {
         AddCSharpLine(CSharpRegisterForUnityHooksDeclaration() + ";");
         AddCSharpLine("m_RegisteredForEvents = true;");

         //for each logic node, create an script specific instance
         foreach (LogicNode logicNode in m_Script.Logics)
         {
            if (NeedsMethod(logicNode, "OnEnable"))
            {
               AddCSharpLine(CSharpName(logicNode, logicNode.Type) + ".OnEnable( );");
            }
         }
      }

      private void DefineOnDisable()
      {
         //for each logic node, create an script specific instance
         foreach (LogicNode logicNode in m_Script.Logics)
         {
            if (NeedsMethod(logicNode, "OnDisable"))
            {
               AddCSharpLine(CSharpName(logicNode, logicNode.Type) + ".OnDisable( );");
            }
         }

         AddCSharpLine(CSharpUnregisterEventListenersDeclaration() + ";");
         AddCSharpLine("m_RegisteredForEvents = false;");
      }

      private void DefineStartInitialization()
      {
         AddCSharpLine(CSharpSyncUnityHooksDeclaration() + ";");
         AddCSharpLine("m_RegisteredForEvents = true;");

         AddCSharpLine("");

         //for each logic node, create an script specific instance
         foreach (LogicNode logicNode in m_Script.Logics)
         {
            if (NeedsMethod(logicNode, "Start"))
            {
               AddCSharpLine(CSharpName(logicNode, logicNode.Type) + ".Start( );");
            }
         }
      }

      private void DefineAwakeInitialization()
      {
         //for each logic node, create an script specific instance
         foreach (LogicNode logicNode in m_Script.Logics)
         {
            if (NeedsMethod(logicNode, "Awake"))
            {
               AddCSharpLine(CSharpName(logicNode, logicNode.Type) + ".Awake( );");
            }
         }

         AddCSharpLine("");

         //for each logic node event, register event listeners with it
         foreach (LogicNode logicNode in m_Script.Logics)
         {
            foreach (Plug eventName in logicNode.Events)
            {
               AddLogicEventListener(logicNode, eventName.Name, true);
            }
         }
      }

      private void DefineUpdate()
      {
         Profile p = new Profile("DefineUpdate");

         if (true == m_GenerateDebugInfo)
         {
            AddCSharpLine("//reset each Update, and increments each method call");
            AddCSharpLine("//if it ever goes above MaxRelayCallCount before being reset");
            AddCSharpLine("//then we assume it is stuck in an infinite loop");
            AddCSharpLine("if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;");

            AddCSharpLine("if ( null != m_ContinueExecution )");
            AddCSharpLine("{");
            ++m_TabStack;
            AddCSharpLine("ContinueExecution continueEx = m_ContinueExecution;");
            AddCSharpLine("m_ContinueExecution = null;");
            AddCSharpLine("m_Breakpoint = false;");
            AddCSharpLine("continueEx( );");
            AddCSharpLine("return;");
            --m_TabStack;
            AddCSharpLine("}");

            AddCSharpLine(UpdateEditorValuesDeclaration() + ";");
         }

         AddCSharpLine("");
         AddCSharpLine("//other scripts might have added GameObjects with event scripts");
         AddCSharpLine("//so we need to verify all our event listeners are registered");
         AddCSharpLine(CSharpSyncEventListenersDeclaration() + ";");
         AddCSharpLine("");

         foreach (LogicNode logicNode in m_Script.Logics)
         {
            if (true == NeedsMethod(logicNode, "Update"))
            {
               AddCSharpLine(CSharpName(logicNode, logicNode.Type) + ".Update( );");
            }
         }

         foreach (LogicNode logicNode in m_Script.Logics)
         {
            foreach (string driven in logicNode.Drivens)
            {
               AddCSharpLine("if (true == " + CSharpName(logicNode, driven) + ")");
               AddCSharpLine("{");
               ++m_TabStack;
               AddCSharpLine(CSharpRelay(logicNode, driven) + "();");
               --m_TabStack;
               AddCSharpLine("}");
            }
         }

         p.End();
      }

      private void DefineOnDestroy()
      {
         Profile p = new Profile("DefineOnDestroy");

         foreach (LogicNode logicNode in m_Script.Logics)
         {
            if (true == NeedsMethod(logicNode, "OnDestroy"))
            {
               AddCSharpLine(CSharpName(logicNode, logicNode.Type) + ".OnDestroy( );");
            }
         }

         //for each logic node event, register event listeners with it
         foreach (LogicNode logicNode in m_Script.Logics)
         {
            foreach (Plug eventName in logicNode.Events)
            {
               AddLogicEventListener(logicNode, eventName.Name, false);
            }
         }

         p.End();
      }

      private void DefineLateUpdate()
      {
         //for each logic node, create an script specific instance
         foreach (LogicNode logicNode in m_Script.Logics)
         {
            if (true == NeedsMethod(logicNode, "LateUpdate"))
            {
               AddCSharpLine(CSharpName(logicNode, logicNode.Type) + ".LateUpdate( );");
            }
         }
      }

      private void DefineFixedUpdate()
      {
         //for each logic node, create an script specific instance
         foreach (LogicNode logicNode in m_Script.Logics)
         {
            if (true == NeedsMethod(logicNode, "FixedUpdate"))
            {
               AddCSharpLine(CSharpName(logicNode, logicNode.Type) + ".FixedUpdate( );");
            }
         }
      }

      private void DefineOnGUI()
      {
         //for each logic node, create an script specific instance
         foreach (LogicNode logicNode in m_Script.Logics)
         {
            if (true == NeedsMethod(logicNode, "OnGUI"))
            {
               AddCSharpLine(CSharpName(logicNode, logicNode.Type) + ".OnGUI( );");
            }
         }
      }

      private void DefineSyncUnityHooks()
      {
         Profile profile = new Profile("DefineSyncUnityHooks");

         AddCSharpLine("void " + CSharpSyncUnityHooksDeclaration());
         AddCSharpLine("{");
         ++m_TabStack;

         //get any references to components currently available
         //which we haven't filled out yet
         foreach (EntityMethod entityMethod in m_Script.Methods)
         {
            if (false == entityMethod.IsStatic)
            {
               if (entityMethod.Instance.Default != "")
               {
                  FillComponent(true, entityMethod, entityMethod.Instance);
               }
            }

            foreach (Parameter p in entityMethod.Parameters)
            {
               if (false == p.Input) continue;
               FillComponent(true, entityMethod, p);
            }
         }

         foreach (EntityProperty entityProperty in m_Script.Properties)
         {
            if (false == entityProperty.IsStatic)
            {
               if (entityProperty.Instance.Default != "")
               {
                  FillComponent(true, entityProperty, entityProperty.Instance);
               }
            }
         }

         AddCSharpLine(CSharpSyncEventListenersDeclaration() + ";");

         foreach (LogicNode logicNode in m_Script.Logics)
         {
            foreach (Parameter p in logicNode.Parameters)
            {
               if (false == p.Input) continue;
               FillComponent(true, logicNode, p);
            }
         }

         foreach (LocalNode localNode in m_Script.UniqueLocals)
         {
            FillComponent(true, localNode, localNode.Value);
         }

         foreach (OwnerConnection ownerNode in m_Script.Owners)
         {
            FillComponent(true, ownerNode, ownerNode.Connection);
         }

         --m_TabStack;
         AddCSharpLine("}");

         profile.End();
      }

      private void DefineRegisterForUnityHooks()
      {
         Profile profile = new Profile("DefineRegisterForUnityHooks");

         AddCSharpLine("void " + CSharpRegisterForUnityHooksDeclaration());
         AddCSharpLine("{");
         ++m_TabStack;

         //get any references to components currently available
         //which we haven't filled out yet
         foreach (EntityMethod entityMethod in m_Script.Methods)
         {
            if (false == entityMethod.IsStatic)
            {
               if (entityMethod.Instance.Default != "")
               {
                  FillComponent(false, entityMethod, entityMethod.Instance);
               }
            }

            foreach (Parameter p in entityMethod.Parameters)
            {
               if (false == p.Input) continue;
               FillComponent(false, entityMethod, p);
            }
         }

         foreach (EntityProperty entityProperty in m_Script.Properties)
         {
            if (false == entityProperty.IsStatic)
            {
               if (entityProperty.Instance.Default != "")
               {
                  FillComponent(false, entityProperty, entityProperty.Instance);
               }
            }
         } 

         AddCSharpLine(CSharpSyncEventListenersDeclaration() + ";");

         foreach (LogicNode logicNode in m_Script.Logics)
         {
            foreach (Parameter p in logicNode.Parameters)
            {
               if (false == p.Input) continue;
               FillComponent(false, logicNode, p);
            }
         }

         foreach (LocalNode localNode in m_Script.UniqueLocals)
         {
            FillComponent(false, localNode, localNode.Value);
         }

         foreach (OwnerConnection ownerNode in m_Script.Owners)
         {
            FillComponent(false, ownerNode, ownerNode.Connection);
         }

         --m_TabStack;
         AddCSharpLine("}");

         profile.End();
      }


      public void DefineSyncEventListeners()
      {
         Profile p = new Profile("DefineSyncEventListeners");

         AddCSharpLine("void " + CSharpSyncEventListenersDeclaration());
         AddCSharpLine("{");
         ++m_TabStack;

         foreach (EntityProperty entityProperty in m_Script.Properties)
         {
            if (false == entityProperty.IsStatic)
            {
               if (entityProperty.Instance.Default != "")
               {
                  SyncSlaveConnections(entityProperty, new Parameter[]{entityProperty.Instance});
                  FillComponent(false, entityProperty, entityProperty.Parameter);
               }
            }
         }

         foreach (EntityEvent entityEvent in m_Script.Events)
         {
            if (false == entityEvent.IsStatic)
            {
               if (entityEvent.Instance.Default != "")
               {
                  FillComponent(true, entityEvent, entityEvent.Instance);
               }
            }
            else
            {
               SetupEvent(null, entityEvent, true);
            }
         }

         --m_TabStack;
         AddCSharpLine("}");

         p.End();
      }

      private void DefineUnregisterEventListeners()
      {
         Profile profile = new Profile("DefineUnregisterEventListeners");

         AddCSharpLine("void " + CSharpUnregisterEventListenersDeclaration());
         AddCSharpLine("{");
         ++m_TabStack;

         foreach (EntityMethod entityMethod in m_Script.Methods)
         {
            if (false == entityMethod.IsStatic)
            {
               if (entityMethod.Instance.Default != "")
               {
                  UnregisterEventListeners(entityMethod, entityMethod.Instance);
               }
            }

            foreach (Parameter p in entityMethod.Parameters)
            {
               if (false == p.Input) continue;
               UnregisterEventListeners(entityMethod, p);
            }
         }

         foreach (EntityProperty entityProperty in m_Script.Properties)
         {
            if (false == entityProperty.IsStatic)
            {
               if (entityProperty.Instance.Default != "")
               {
                  UnregisterEventListeners(entityProperty, entityProperty.Parameter);
               }
            }
         }

         foreach (LogicNode logicNode in m_Script.Logics)
         {
            foreach (Parameter p in logicNode.Parameters)
            {
               if (false == p.Input) continue;
               UnregisterEventListeners(logicNode, p);
            }
         }

         foreach (LocalNode localNode in m_Script.UniqueLocals)
         {
            UnregisterEventListeners(localNode, localNode.Value);
         }

         foreach (OwnerConnection ownerNode in m_Script.Owners)
         {
            UnregisterEventListeners(ownerNode, ownerNode.Connection);
         }

         foreach (EntityEvent entityEvent in m_Script.Events)
         {
            if (false == entityEvent.IsStatic)
            {
               if (entityEvent.Instance.Default != "")
               {
                  UnregisterEventListeners(entityEvent, entityEvent.Instance);
               }
            }
            else
            {
               SetupEvent(null, entityEvent, false);
            }
         }

         --m_TabStack;
         AddCSharpLine("}");

         profile.End();
      }

      private void FillComponent(bool fillNulls, EntityNode node, Parameter parameter)
      {
         Profile p = new Profile("FillComponent");

         //fillNulls, only fill null values we don't want to keep filling them
         //behind the scenes because a user might intentionally set something to null
         //or resize an array which contains nulls (then we would crash because it's not the
         //oroginal size of our code generation)

         //if a user starts with something null and it doesn't spawn in the scene until later
         //then he/she should use the SetGameObject node

         Type componentType = typeof(UnityEngine.Component);
         Type gameObjectType = typeof(UnityEngine.GameObject);
         Type componentArrayType = typeof(UnityEngine.Component[]);
         Type gameObjectArrayType = typeof(UnityEngine.GameObject[]);

         Type nodeType = uScript.Instance.GetType(parameter.Type);
         if (null == nodeType) return;

         if (true == gameObjectArrayType.IsAssignableFrom(nodeType))
         {
            //remove curly braces from type declaration
            //so we can use it to cast the object to the array element type
            string type = FormatType(parameter.Type);
            type = type.Substring(0, type.Length - 2);

            string[] values = Parameter.StringToArray(parameter.Default);

            if (true == fillNulls)
            {
               for (int i = 0; i < values.Length; i++)
               {
                  if (values[i].Trim() == "") continue;

                  AddCSharpLine("if ( null == " + CSharpName(node, parameter.Name) + "[" + i + "] || false == m_RegisteredForEvents )");
                  AddCSharpLine("{");
                  ++m_TabStack;

                  if (uScriptRuntimeConfig.MasterObjectName == EscapeString(values[i].Trim()))
                  {
                     AddCSharpLine(CSharpName(node, parameter.Name) + "[" + i + "] = uScript_MasterComponent.LatestMaster;");
                  }
                  else
                  {
                     AddCSharpLine(CSharpName(node, parameter.Name) + "[" + i + "] = GameObject.Find( \"" + EscapeString(values[i].Trim()) + "\" ) as " + type + ";");
                  }
                  SetupEventListeners(CSharpName(node, parameter.Name) + "[" + i + "]", node, true);

                  --m_TabStack;
                  AddCSharpLine("}");
               }
            }
         }
         else if (true == componentArrayType.IsAssignableFrom(nodeType))
         {
            if (true == fillNulls)
            {
               string[] values = Parameter.StringToArray(parameter.Default);

               //remove curly braces from type declaration
               //so we can use it to cast the object to the array element type
               string type = FormatType(parameter.Type);
               type = type.Substring(0, type.Length - 2);

               AddCSharpLine("{");
               ++m_TabStack;

               //make sure there is at least one valid value
               //before we declare our gameObject
               for (int i = 0; i < values.Length; i++)
               {
                  if (values[i].Trim() == "") continue;

                  AddCSharpLine("GameObject gameObject = null;");
                  break;
               }

               for (int i = 0; i < values.Length; i++)
               {
                  if (values[i].Trim() == "") continue;

                  AddCSharpLine("if ( null == " + CSharpName(node, parameter.Name) + "[" + i + "] || false == m_RegisteredForEvents )");
                  AddCSharpLine("{");
                  ++m_TabStack;

                  if (uScriptRuntimeConfig.MasterObjectName == EscapeString(values[i].Trim()))
                  {
                     AddCSharpLine("gameObject = uScript_MasterComponent.LatestMaster;");
                  }
                  else
                  {
                     AddCSharpLine("gameObject = GameObject.Find( \"" + EscapeString(values[i].Trim()) + "\" );");
                  }

                  AddCSharpLine("if ( null != " + "gameObject )");

                  AddCSharpLine("{");
                  ++m_TabStack;
                  AddCSharpLine(CSharpName(node, parameter.Name) + "[" + i + "] = gameObject.GetComponent<" + type + ">();");
                  AddMissingComponent(CSharpName(node, parameter.Name) + "[" + i + "]", "gameObject", type);
                  SetupEventListeners(CSharpName(node, parameter.Name) + "[" + i + "]", node, true);

                  --m_TabStack;
                  AddCSharpLine("}");

                  --m_TabStack;
                  AddCSharpLine("};");

               }

               --m_TabStack;
               AddCSharpLine("};");
            }
         }
         else if (true == componentType.IsAssignableFrom(nodeType))
         {
            if (true == fillNulls && parameter.Default != "")
            {
               AddCSharpLine("if ( null == " + CSharpName(node, parameter.Name) + " || false == m_RegisteredForEvents )");
               AddCSharpLine("{");
               ++m_TabStack;

               if (uScriptRuntimeConfig.MasterObjectName == EscapeString(parameter.Default))
               {
                  AddCSharpLine("GameObject gameObject = uScript_MasterComponent.LatestMaster;");
               }
               else
               {
                  AddCSharpLine("GameObject gameObject = GameObject.Find( \"" + EscapeString(parameter.Default) + "\" );");
               }

               AddCSharpLine("if ( null != " + "gameObject )");

               AddCSharpLine("{");
               ++m_TabStack;
               AddCSharpLine(CSharpName(node, parameter.Name) + " = gameObject.GetComponent<" + FormatType(parameter.Type) + ">();");
               AddMissingComponent(CSharpName(node, parameter.Name), "gameObject", FormatType(parameter.Type));
               SetupEventListeners(CSharpName(node, parameter.Name), node, true);

               --m_TabStack;
               AddCSharpLine("}");

               --m_TabStack;
               AddCSharpLine("}");
            }
         }
         else if (true == gameObjectType.IsAssignableFrom(nodeType))
         {
            if (true == fillNulls && true == node is OwnerConnection)
            {
               AddCSharpLine("if ( null == " + CSharpName(node, parameter.Name) + " || false == m_RegisteredForEvents )");
               AddCSharpLine("{");
               ++m_TabStack;
               AddCSharpLine(CSharpName(node, parameter.Name) + " = parentGameObject;");
               SetupEventListeners(CSharpName(node, parameter.Name), node, true);
               --m_TabStack;
               AddCSharpLine("}");
            }
            else if (true == fillNulls && parameter.Default != "")
            {
               AddCSharpLine("if ( null == " + CSharpName(node, parameter.Name) + " || false == m_RegisteredForEvents )");
               AddCSharpLine("{");
               ++m_TabStack;

               if (uScriptRuntimeConfig.MasterObjectName == EscapeString(parameter.Default))
               {
                  AddCSharpLine(CSharpName(node, parameter.Name) + " = uScript_MasterComponent.LatestMaster;");
               }
               else
               {
                  AddCSharpLine(CSharpName(node, parameter.Name) + " = GameObject.Find( \"" + EscapeString(parameter.Default) + "\" ) as " + FormatType(parameter.Type) + ";");
               }

               //only set up listeners if it's NOT a variable connection
               //otherwise they'll be set in the conditional below this
               if (false == node is LocalNode && false == node is EntityProperty)
               {
                  SetupEventListeners(CSharpName(node, parameter.Name), node, true);
               }

               --m_TabStack;
               AddCSharpLine("}");
            }

            //if we're not supposed to fill nulls we need to make sure
            //the event listeners get re-registered
            if (false == fillNulls && false == node is LocalNode && false == node is EntityProperty)
            {
               string currentCode = SetCode("");

               ++m_TabStack;
               SetupEventListeners(CSharpName(node, parameter.Name), node, true);
               --m_TabStack;

               string newCode = SetCode(currentCode);
               if (newCode != "")
               {
                  AddCSharpLine("//reset event listeners if needed");
                  AddCSharpLine("//this isn't a variable node so it should only be called once per enabling of the script");
                  AddCSharpLine("//if it's called twice there would be a double event registration (which is an error)");
                  AddCSharpLine("if ( false == m_RegisteredForEvents )");
                  AddCSharpLine("{");
                     m_CSharpString.Append(newCode);
                  AddCSharpLine("}");
               }
            }

            //if it's a variable node or an entity property node linked to us 
            //then we need to go a few steps further to see if its contents
            //have been modified at runtime.  if they have then
            //we need to register new event listeners
            if (true == node is LocalNode || true == node is EntityProperty)
            {
               if (true == node is EntityProperty && node.Instance != parameter)
                  AddCSharpLine(CSharpName(node, parameter.Name) + " = " + CSharpRefreshGetPropertyDeclaration((EntityProperty)node) + "();");

               AddCSharpLine("//if our game object reference was changed then we need to reset event listeners");
               AddCSharpLine("if ( " + PreviousName(node, parameter.Name) + " != " + CSharpName(node, parameter.Name) + " || false == m_RegisteredForEvents )");
               AddCSharpLine("{");
               ++m_TabStack;

               AddCSharpLine("//tear down old listeners");
               if ((node is LocalNode) ||
                   (node is EntityProperty && node.Instance != parameter))
                  SetupEventListeners(PreviousName(node, parameter.Name), node, false);
               AddCSharpLine("");

               AddCSharpLine(PreviousName(node, parameter.Name) + " = " + CSharpName(node, parameter.Name) + ";");
               AddCSharpLine("");

               AddCSharpLine("//setup new listeners");
               if ((node is LocalNode) ||
                   (node is EntityProperty && node.Instance != parameter))
                  SetupEventListeners(CSharpName(node, parameter.Name), node, true);

               --m_TabStack;
               AddCSharpLine("}");
            }
         }

         p.End();
      }

      private void UnregisterEventListeners(EntityNode node, Parameter parameter)
      {
         Profile p = new Profile("UnregisterEventListeners");

         //fillNulls, only fill null values we don't want to keep filling them
         //behind the scenes because a user might intentionally set something to null
         //or resize an array which contains nulls (then we would crash because it's not the
         //oroginal size of our code generation)

         //if a user starts with something null and it doesn't spawn in the scene until later
         //then he/she should use the SetGameObject node

         Type componentType = typeof(UnityEngine.Component);
         Type gameObjectType = typeof(UnityEngine.GameObject);
         Type componentArrayType = typeof(UnityEngine.Component[]);
         Type gameObjectArrayType = typeof(UnityEngine.GameObject[]);

         Type nodeType = uScript.Instance.GetType(parameter.Type);
         if (null == nodeType) return;

         if (true == gameObjectArrayType.IsAssignableFrom(nodeType))
         {
            //remove curly braces from type declaration
            //so we can use it to cast the object to the array element type
            string type = FormatType(parameter.Type);
            type = type.Substring(0, type.Length - 2);

            string[] values = Parameter.StringToArray(parameter.Default);

            for (int i = 0; i < values.Length; i++)
            {
               if (values[i].Trim() == "") continue;

               SetupEventListeners(CSharpName(node, parameter.Name) + "[" + i + "]", node, false);
            }
         }
         else if (true == componentArrayType.IsAssignableFrom(nodeType))
         {
            string[] values = Parameter.StringToArray(parameter.Default);

            //remove curly braces from type declaration
            //so we can use it to cast the object to the array element type
            string type = FormatType(parameter.Type);
            type = type.Substring(0, type.Length - 2);

            AddCSharpLine("{");
            ++m_TabStack;

            //make sure there is at least one valid value
            //before we declare our gameObject
            for (int i = 0; i < values.Length; i++)
            {
               if (values[i].Trim() == "") continue;

               AddCSharpLine("GameObject gameObject = null;");
               break;
            }

            for (int i = 0; i < values.Length; i++)
            {
               if (values[i].Trim() == "") continue;

               SetupEventListeners(CSharpName(node, parameter.Name) + "[" + i + "]", node, false);
            }

            --m_TabStack;
            AddCSharpLine("};");
         }
         else if (true == componentType.IsAssignableFrom(nodeType))
         {
            SetupEventListeners(CSharpName(node, parameter.Name), node, false);
         }
         else if (true == gameObjectType.IsAssignableFrom(nodeType))
         {
            if (true == node is OwnerConnection)
            {
               SetupEventListeners(CSharpName(node, parameter.Name), node, false);
            }
            else if (parameter.Default != "")
            {
               if (false == node is LocalNode)
               {
                  SetupEventListeners(CSharpName(node, parameter.Name), node, false);
               }
            }

            if (true == node is LocalNode)
            {
               SetupEventListeners(CSharpName(node, parameter.Name), node, false);
            }
         }

         p.End();
      }

      private string SetCode(string s)
      {
         string c = m_CSharpString.ToString();
         m_CSharpString = new StringBuilder(s);

         return c;
      }

      private void SetupEventListeners(string eventVariable, EntityNode node, bool setup)
      {
         Profile p = new Profile("SetupEventListeners");

         string currentCode = SetCode("");

         ++m_TabStack;
         if (node is EntityEvent)
         {
            SetupEvent(eventVariable, ((EntityEvent)node), setup);
         }
         else if (node is EntityProperty)
         {
            //if we are a property node, see if there are any event listeners
            //hooked up to us - if so then we need to get the matching component
            //and register the listeners
            EntityProperty ep = (EntityProperty)node;

            foreach (LinkNode link in m_Script.Links)
            {
               if (link.Source.Guid == ep.Guid &&
                  link.Source.Anchor == ep.Parameter.Name)
               {
                  EntityNode destNode = m_Script.GetNode(link.Destination.Guid);

                  if (destNode is EntityEvent)
                  {
                     EntityEvent eventNode = (EntityEvent)destNode;
                     if (link.Destination.Anchor == eventNode.Instance.Name)
                     {
                        SetupEvent(eventVariable, eventNode, setup);
                     }
                  }
               }
            }
         }
         else if (node is LocalNode)
         {
            //if we are a local node, see if there are any event listeners
            //hooked up to us - if so then we need to get the matching component
            //and register the listeners
            LocalNode local = (LocalNode)node;

            foreach (LinkNode link in m_Script.Links)
            {
               if (link.Source.Guid == local.Guid &&
                  link.Source.Anchor == local.Value.Name)
               {
                  EntityNode destNode = m_Script.GetNode(link.Destination.Guid);

                  if (destNode is EntityEvent)
                  {
                     EntityEvent eventNode = (EntityEvent)destNode;
                     if (link.Destination.Anchor == eventNode.Instance.Name)
                     {
                        SetupEvent(eventVariable, eventNode, setup);
                     }
                  }
               }
            }
         }
         else if (node is OwnerConnection)
         {
            //if we are an owner node, see if there are any event listeners
            //hooked up to us - if so then we need to get the matching component
            //and register the listeners
            OwnerConnection owner = (OwnerConnection)node;

            foreach (LinkNode link in m_Script.Links)
            {
               if (link.Source.Guid == owner.Guid &&
                  link.Source.Anchor == owner.Connection.Name)
               {
                  EntityNode destNode = m_Script.GetNode(link.Destination.Guid);

                  if (destNode is EntityEvent)
                  {
                     EntityEvent eventNode = (EntityEvent)destNode;
                     if (link.Destination.Anchor == eventNode.Instance.Name)
                     {
                        SetupEvent(eventVariable, eventNode, setup);
                     }
                  }
               }
            }
         }
         --m_TabStack;

         string newCode = SetCode(currentCode);

         if ("" != newCode)
         {
            AddCSharpLine("if ( null != " + eventVariable + " )");

            AddCSharpLine("{");

            m_CSharpString.Append(newCode);

            AddCSharpLine("}");

         }

         p.End();
      }

      //default inputs for events which can only be set through the property grid
      //so they are only set once (in SyncUnityHooks)
      //and we add all our event listeners here
      private void SetupEvent(string eventVariable, EntityEvent eventNode, bool setup)
      {
         Profile profile = new Profile("SetupEvent");

         //if we're setting up then set the inputs
         //if we're tearing down, we can ignore this step
         if (true == setup)
         {
            foreach (Parameter p in eventNode.Parameters)
            {
               if (p.Input == true)
               {
                  if (true == eventNode.IsStatic)
                  {
                     AddCSharpLine(eventNode.ComponentType + "." + p.Name + " = " + CSharpName(eventNode, p.Name) + ";");
                  }
                  else
                  {
                     AddCSharpLine("{");
                     ++m_TabStack;
                     AddCSharpLine(eventNode.ComponentType + " component = " + eventVariable + ".GetComponent<" + eventNode.ComponentType + ">();");
                     AddMissingComponent("component", eventVariable, eventNode.ComponentType);

                     AddCSharpLine("if ( null != component )");
                     AddCSharpLine("{");
                     ++m_TabStack;
                     AddCSharpLine("component." + p.Name + " = " + CSharpName(eventNode, p.Name) + ";");
                     --m_TabStack;
                     AddCSharpLine("}");
                     --m_TabStack;
                     AddCSharpLine("}");
                  }
               }
            }
         }

         AddCSharpLine("{");
         ++m_TabStack;
         AddEventListener(eventVariable, eventNode, setup);
         --m_TabStack;
         AddCSharpLine("}");

         profile.End();
      }

      private void AddMissingComponent(string componentVariable, string gameObjectVariable, string componentType)
      {
         Type type = uScript.Instance.GetType(componentType);
         if (null != type && typeof(uScriptEvent).IsAssignableFrom(type))
         {
            AddCSharpLine("if ( null == " + componentVariable + " )");
            AddCSharpLine("{");
            ++m_TabStack;
            AddCSharpLine(componentVariable + " = " + gameObjectVariable + ".AddComponent<" + componentType + ">();");
            --m_TabStack;
            AddCSharpLine("}");
         }
      }

      private void DefineEvents(bool stubCode)
      {
         Profile p = new Profile("DefineEvents");

         if (false == stubCode)
         {
            //for every registered event listener
            //define the function the event will call
            foreach (EntityEvent entityEvent in m_Script.Events)
            {
               foreach (Plug output in entityEvent.Outputs)
               {
                  DefineEntityEvent(entityEvent, output.Name);
               }
            }

            //for every registered logic node event listener
            //define the function the event will call
            foreach (LogicNode logicNode in m_Script.Logics)
            {
               foreach (Plug eventName in logicNode.Events)
               {
                  DefineLogicEvent(logicNode, eventName.Name);
               }
            }

            //for every external node
            //define the function the event will call
            foreach (ExternalConnection external in m_Script.Externals)
            {
               DefineExternalInput(external, stubCode);
            }

            //then for every node linked to the event listener or logic listener
            //define a relay function the event will call
            foreach (EntityNode entityNode in m_Script.EntityNodes)
            {
               if (false == entityNode is LinkNode)
               {
                  DefineRelay(entityNode);
               }
            }
         }
         else
         {
            //Even if the code is stubbed we need to declare the inputs
            //so other graphs which hook up to these will not error
            foreach (ExternalConnection external in m_Script.Externals)
            {
               DefineExternalInput(external, stubCode);
            }
         }

         p.End();
      }

      //create the function which the event listener will call
      private void DefineEntityEvent(EntityEvent entityEvent, string output)
      {
         Profile p = new Profile("DefineEntityEvent");

         AddCSharpLine("void " + CSharpEventDeclaration(entityEvent, output) + "(object o, " + entityEvent.EventArgs + " e)");
         AddCSharpLine("{");

         ++m_TabStack;

         if (true == m_GenerateDebugInfo)
         {
            AddCSharpLine("//reset event call");
            AddCSharpLine("//if it ever goes above MaxRelayCallCount before being reset");
            AddCSharpLine("//then we assume it is stuck in an infinite loop");
            AddCSharpLine("if ( relayCallCount < MaxRelayCallCount ) relayCallCount = 0;");
            AddCSharpLine("");
         }

         int i = 0;

         //all we want to do for an entityevent is output the variables
         //then call the relays
         AddCSharpLine("//fill globals");
         foreach (Parameter parameter in entityEvent.Parameters)
         {
            //only allow output parameters, those come through in the event args
            if (parameter.Input == true) continue;

            AddCSharpLine(CSharpName(entityEvent, parameter.Name) + " = e." + parameter.Name + ";");
            ++i;
         }

         AddCSharpLine("//relay event to nodes");
         AddCSharpLine(CSharpRelay(entityEvent, output) + "( );");

         --m_TabStack;

         AddCSharpLine("}");
         AddCSharpLine("");

         p.End();
      }

      private Plug[] FindExternalEvents()
      {
         Profile p = new Profile("FindExternalEvents");

         List<Plug> externalLinks = new List<Plug>();

         foreach (ExternalConnection external in m_Script.Externals)
         {
            LinkNode[] links = FindLinksByDestination(external.Guid, external.Connection);
            if (0 == links.Length) continue;

            bool validEnd = false;

            EntityNode sourceNode = null;

            foreach (LinkNode link in links)
            {
               sourceNode = m_Script.GetNode(link.Source.Guid);

               if (sourceNode is EntityEvent)
               {
                  EntityEvent entityEvent = (EntityEvent)sourceNode;

                  foreach (Plug output in entityEvent.Outputs)
                  {
                     if (link.Source.Anchor == output.Name)
                     {
                        validEnd = true;
                        break;
                     }
                  }
               }
               else if (sourceNode is EntityMethod)
               {
                  EntityMethod entityMethod = (EntityMethod)sourceNode;

                  if (link.Source.Anchor == entityMethod.Output.Name)
                  {
                     validEnd = true;
                     break;
                  }
               }
               else if (sourceNode is LogicNode)
               {
                  LogicNode logic = (LogicNode)sourceNode;

                  foreach (Plug eventName in logic.Events)
                  {
                     if (link.Source.Anchor == eventName.Name)
                     {
                        validEnd = true;
                        break;
                     }
                  }

                  foreach (Plug output in logic.Outputs)
                  {
                     if (link.Source.Anchor == output.Name)
                     {
                        validEnd = true;
                        break;
                     }
                  }
               }
            }

            if (true == validEnd)
            {
               externalLinks.Add(CSharpExternalEventDeclaration(external.Name.Default));
            }
         }

         p.End();

         return externalLinks.ToArray();
      }

      //create the external function outsiders can call
      private void DefineExternalInput(ExternalConnection externalInput, bool stubCode)
      {
         Profile profile = new Profile("DefineExternalInput");

         Hashtable uniqueParameters = new Hashtable();

         foreach (ExternalConnection external in m_Script.Externals)
         {
            if (null != uniqueParameters[external.Name.Default]) continue;

            LinkNode[] links = FindLinksBySource(external.Guid, external.Connection);

            foreach (LinkNode link in links)
            {
               EntityNode node = m_Script.GetNode(link.Destination.Guid);

               foreach (Parameter p in node.Parameters)
               {
                  if (p.Name == link.Destination.Anchor)
                  {
                     bool useExisting = false;

                     if (uniqueParameters.Contains(external.Name.Default))
                     {
                        Parameter existingP = (Parameter)uniqueParameters[external.Name.Default];

                        if (false == existingP.Type.Contains("[]") && true == p.Type.Contains("[]"))
                        {
                           useExisting = true;
                        }
                     }

                     //go for the lowest common denominator
                     //if one existed which didn't use an array
                     //and a new array one comes, ignore it
                     if (false == useExisting)
                     {
                        uniqueParameters[external.Name.Default] = p;
                     }
                  }
               }

               if (node.Instance.Name == link.Destination.Anchor)
               {
                  uniqueParameters[external.Name.Default] = node.Instance;
               }

               //we need to check them all to make sure
               //we use the lowest common denominator of types
               //so do not break here
            }
         }

         foreach (ExternalConnection external in m_Script.Externals)
         {
            LinkNode[] links = FindLinksByDestination(external.Guid, external.Connection);

            foreach (LinkNode link in links)
            {
               //the link ends at our external
               //so if it's already used as a source, change it to a ref
               if (null != uniqueParameters[external.Name.Default])
               {
                  Parameter p = (Parameter)uniqueParameters[external.Name.Default];
                  p.Output = true;
                  uniqueParameters[external.Name.Default] = p;
                  continue;
               }

               EntityNode node = m_Script.GetNode(link.Source.Guid);

               foreach (Parameter p in node.Parameters)
               {
                  if (p.Name == link.Source.Anchor)
                  {
                     uniqueParameters[external.Name.Default] = p;
                  }
               }

               //only one link allowed for each external parameter output
               break;
            }
         }

         string args = "";

         foreach (ExternalConnection external in m_Script.Externals)
         {
            string key = external.Name.Default;
            if (false == uniqueParameters.Contains(key)) continue;

            Parameter p = (Parameter)uniqueParameters[key];

            string description = external.Description.Default;

            if (true == p.Input && false == p.Output)
            {
               args += "[FriendlyName(\"" + CSharpExternalParameterDeclaration(key).FriendlyName + "\", \"" + description + "\")] ";
               args += FormatType(p.Type) + " " + CSharpExternalParameterDeclaration(key).Name + ", ";
            }
            else if (true == p.Input && true == p.Output)
            {
               args += "[FriendlyName(\"" + CSharpExternalParameterDeclaration(key).FriendlyName + "\", \"" + description + "\")] ";
               args += "ref " + FormatType(p.Type) + " " + CSharpExternalParameterDeclaration(key).Name + ", ";
            }
            else if (false == p.Input && true == p.Output)
            {
               //Output parameters are sent via events now
               //args += "[FriendlyName(\"" + CSharpExternalParameterDeclaration(key).FriendlyName + "\", \"" + description + "\")] ";
               //args += "out " + FormatType(p.Type) + " " + CSharpExternalParameterDeclaration(key).Name + ", ";
            }
         }

         if (args != "") args = args.Substring(0, args.Length - 2);

         LinkNode[] relays = FindLinksBySource(externalInput.Guid, externalInput.Connection);

         List<LinkNode.Connection> allowedRelays = new List<LinkNode.Connection>();

         foreach (LinkNode relayLink in relays)
         {
            EntityNode node = m_Script.GetNode(relayLink.Destination.Guid);

            bool allowLink = false;

            if (node is EntityMethod)
            {
               EntityMethod method = (EntityMethod)node;

               if (method.Input.Name == relayLink.Destination.Anchor)
               {
                  allowLink = true;
               }
            }
            else if (node is LogicNode)
            {
               LogicNode logic = (LogicNode)node;

               foreach (Plug input in logic.Inputs)
               {
                  if (input.Name == relayLink.Destination.Anchor)
                  {
                     allowLink = true;
                  }
               }
            }

            if (true == allowLink)
            {
               allowedRelays.Add(relayLink.Destination);
            }

            //only one set of external parameters per script
            //they match for every method signature
            if (0 == m_ExternalParameters.Count)
            {
               foreach (ExternalConnection external in m_Script.Externals)
               {
                  string key = external.Name.Default;
                  if (false == uniqueParameters.Contains(key)) continue;

                  Parameter p = (Parameter)uniqueParameters[key];

                  Plug plug = CSharpExternalParameterDeclaration(key);

                  Parameter clone = p;
                  clone.FriendlyName = plug.FriendlyName;
                  clone.Name = plug.Name;
                  clone.State = Parameter.VisibleState.Visible;

                  m_ExternalParameters.Add(clone);
               }
            }
         }

         if (allowedRelays.Count > 0)
         {
            DefineExternalInput(externalInput, allowedRelays.ToArray(), args, stubCode);
         }

         profile.End();
      }

      Parameter GetLowestCommonExternalParameter(ExternalConnection external)
      {
         Profile profile = new Profile("GetLowestCommonExternalParameter");

         LinkNode[] inputs = FindLinksBySource(external.Guid, external.Connection);

         Parameter lowestParameter = Parameter.Empty;

         foreach (LinkNode link in inputs)
         {
            EntityNode parameterNode = m_Script.GetNode(link.Destination.Guid);

            foreach (Parameter p in parameterNode.Parameters)
            {
               if (p.Name == link.Destination.Anchor)
               {
                  lowestParameter = p;

                  //if any type lacks an array, it is the lowest type
                  //so return it, otherwise keep checking
                  if (false == lowestParameter.Type.Contains("[]")) return lowestParameter;
               }
            }

            if (parameterNode.Instance.Name == link.Destination.Anchor)
            {
               lowestParameter = parameterNode.Instance;

                //if any type lacks an array, it is the lowest type
                //so return it, otherwise keep checking
                if (false == lowestParameter.Type.Contains("[]")) return lowestParameter;
            }
         }

         inputs = FindLinksByDestination(external.Guid, external.Connection);

         foreach (LinkNode link in inputs)
         {
            EntityNode parameterNode = m_Script.GetNode(link.Source.Guid);

            foreach (Parameter p in parameterNode.Parameters)
            {
               if (p.Name == link.Source.Anchor)
               {
                  lowestParameter = p;

                  //if any type lacks an array, it is the lowest type
                  //so return it, otherwise keep checking
                  if (false == lowestParameter.Type.Contains("[]")) return lowestParameter;
               }
            }
         }

         profile.End();

         return lowestParameter;
      }

      void DefineExternalInput(ExternalConnection externalInput, LinkNode.Connection[] connections, string args, bool stubCode)
      {
         Profile profile = new Profile("DefineExternalInput");

         Plug inputPlug = CSharpExternalInputDeclaration(externalInput.Name.Default);
         m_ExternalInputs.Add(inputPlug);

         AddCSharpLine("[FriendlyName(\"" + inputPlug.FriendlyName + "\", \"" + externalInput.Description.Default + "\")]");
         AddCSharpLine("public void " + inputPlug.Name + "( " + args + " )");
         AddCSharpLine("{");

         if (false == stubCode)
         {
            ++m_TabStack;
   
            PrintDebug(externalInput);

            AddCSharpLine("");


            //transfer input args to our member variables
            Hashtable filledExternals = new Hashtable();
            foreach (ExternalConnection external in m_Script.Externals)
            {
               LinkNode[] inputs = FindLinksBySource(external.Guid, external.Connection);

               foreach (LinkNode link in inputs)
               {
                  EntityNode parameterNode = m_Script.GetNode(link.Destination.Guid);

                  foreach (Parameter p in parameterNode.Parameters)
                  {
                     if (p.Name == link.Destination.Anchor)
                     {
                        AddCSharpLine(CSharpName(external, external.Connection) + " = " + CSharpExternalParameterDeclaration(external.Name.Default).Name + ";");
                        SyncReferencedGameObject(parameterNode, p);
                     }
                  }

                  if (parameterNode.Instance.Name == link.Destination.Anchor)
                  {
                     if (false == filledExternals.Contains(external.Guid))
                     {
                        AddCSharpLine(CSharpName(external) + " = " + CSharpExternalParameterDeclaration(external.Name.Default).Name + ";");
                        filledExternals[external.Guid] = external;
                     }
                  }

                  break;
               }
            }

            foreach (LinkNode.Connection connection in connections)
            {
               EntityNode node = m_Script.GetNode(connection.Guid);
               AddCSharpLine(CSharpRelay(node, connection.Anchor) + "( );");
            }

            --m_TabStack;
         }

         AddCSharpLine("}");
         AddCSharpLine("");

         profile.End();
      }

      //create the function which the event listener will call
      private void DefineLogicEvent(LogicNode logicNode, string eventName)
      {
         Profile profile = new Profile("DefineLogicEvent");

         AddCSharpLine("void " + CSharpEventDeclaration(logicNode, eventName) + "(object o, " + logicNode.EventArgs + " e)");
         AddCSharpLine("{");

         ++m_TabStack;

         int i = 0;

         //all we want to do for an entityevent is output the variables
         //then call the relays
         AddCSharpLine("//fill globals");
         foreach (Parameter parameter in logicNode.EventParameters)
         {
            //only allow output parameters, those come through in the event args
            if (parameter.Output == false) continue;

            AddCSharpLine(CSharpName(logicNode, parameter.Name) + " = e." + parameter.Name + ";");
            ++i;
         }



         List<Parameter> outputList = new List<Parameter>();

         //figure out where our outgoing links go
         //and set those variables directly
         foreach (Parameter parameter in logicNode.Parameters)
         {
            //only allow output parameters, those come through in the event args
            if (parameter.Output == false) continue;

            LinkNode[] argLinks = FindLinksBySource(logicNode.Guid, parameter.Name);

            AddCSharpLine("//links to " + parameter.Name + " = " + argLinks.Length);

            foreach (LinkNode link in argLinks)
            {
               EntityNode argNode = m_Script.GetNode(link.Destination.Guid);

               //set variable directly based on the last set event argument
               AddCSharpLine(CSharpName(argNode, link.Destination.Anchor) + " = " + CSharpName(logicNode, parameter.Name) + ";");
               outputList.Add(parameter);

               // don't sync up entity properties, they will sync themselves up
               // at the RefreshSetProperties call
               if (false == (argNode is EntityProperty))
               {
                  foreach (Parameter p in argNode.Parameters)
                  {
                     if (p.Name == link.Destination.Anchor)
                     {
                        SyncReferencedGameObject(argNode, parameter);
                        break;
                     }
                  }

                  if (argNode.Instance.Name == link.Destination.Anchor)
                  {
                     SyncReferencedGameObject(argNode, argNode.Instance);
                  }
               }
            }
         }

         //force any potential entites affected to update
         RefreshSetProperties(logicNode, outputList.ToArray());

         AddCSharpLine("//relay event to nodes");
         AddCSharpLine(CSharpRelay(logicNode, eventName) + "( );");

         --m_TabStack;

         AddCSharpLine("}");
         AddCSharpLine("");

         profile.End();
      }

      bool IsEventDriven(ExternalConnection external)
      {
         LinkNode[] links = FindLinksByDestination(external.Guid, external.Connection);

         //if any of them aren't direct outputs, then they are driven by an event
         foreach (LinkNode link in links)
         {
            bool isEventDriven = m_Script.IsEventDriven(link);
            if (true == isEventDriven) return true;
         }

         return false;
      }

      //if we're hit we allow any outputs which were linked to us
      private void RelayToExternal(ExternalConnection external)
      {
         Profile p = new Profile("RelayToExternal");

         LinkNode[] links = FindLinksByDestination(external.Guid, external.Connection);

         if (0 == links.Length) return;

         //bool isEventDriven = IsEventDriven(external);

         bool validEnd = false;

         EntityNode sourceNode = null;

         foreach (LinkNode link in links)
         {
            sourceNode = m_Script.GetNode(link.Source.Guid);

            if (sourceNode is EntityEvent)
            {
               EntityEvent entityEvent = (EntityEvent)sourceNode;

               foreach (Plug output in entityEvent.Outputs)
               {
                  if (link.Source.Anchor == output.Name)
                  {
                     validEnd = true;
                     break;
                  }
               }
            }
            else if (sourceNode is EntityMethod)
            {
               EntityMethod entityMethod = (EntityMethod)sourceNode;

               if (link.Source.Anchor == entityMethod.Output.Name)
               {
                  validEnd = true;
                  break;
               }
            }
            else if (sourceNode is LogicNode)
            {
               LogicNode logic = (LogicNode)sourceNode;

               foreach (Plug eventName in logic.Events)
               {
                  if (link.Source.Anchor == eventName.Name)
                  {
                     validEnd = true;
                     break;
                  }
               }

               foreach (Plug output in logic.Outputs)
               {
                  if (link.Source.Anchor == output.Name)
                  {
                     validEnd = true;
                     break;
                  }
               }
            }
         }

         if (true == validEnd)
         {
            //if ( false == isEventDriven )
            //{
            //   AddCSharpLine( CSharpExternalOutputDeclaration(external.Name.Default) + " = true;" );
            //}
            //else
            {
               AddCSharpLine("if ( " + CSharpExternalEventDeclaration(external.Name.Default).Name + " != null )");
               AddCSharpLine("{");
               ++m_TabStack;

               AddCSharpLine(LogicEventArgsDeclaration() + " eventArgs = new " + LogicEventArgsDeclaration() + "( );");
               foreach (ExternalEventParameter eep in m_LogicEventArgs)
               {
                  AddCSharpLine("eventArgs." + eep.ExternalParameter.Name + " = " + CSharpName(eep.ExternalVariableNode) + ";");
               }

               AddCSharpLine(CSharpExternalEventDeclaration(external.Name.Default).Name + "( this, eventArgs );");
               --m_TabStack;
               AddCSharpLine("}");
            }
         }

         p.End();
      }

      //define the function which our event listeners will call
      //when an entity event is triggered
      private void RelayToEvent(EntityEvent receiver, string eventName)
      {
         Profile profile = new Profile("RelayToEvent");

         List<Parameter> outputList = new List<Parameter>();

         //figure out where our outgoing links go
         //and set those variables directly
         foreach (Parameter parameter in receiver.Parameters)
         {
            LinkNode[] argLinks = FindLinksBySource(receiver.Guid, parameter.Name);

            foreach (LinkNode link in argLinks)
            {
               EntityNode argNode = m_Script.GetNode(link.Destination.Guid);

               //set variable directly based on the last set event argument
               AddCSharpLine(CSharpName(argNode, link.Destination.Anchor) + " = " + CSharpName(receiver, parameter.Name) + ";");
               outputList.Add(parameter);

               // don't sync up entity properties, they will sync themselves up
               // at the RefreshSetProperties call
               if (false == (argNode is EntityProperty))
               {
                  foreach (Parameter p in argNode.Parameters)
                  {
                     if (p.Name == link.Destination.Anchor)
                     {
                        SyncReferencedGameObject(argNode, parameter);
                        break;
                     }
                  }

                  if (argNode.Instance.Name == link.Destination.Anchor)
                  {
                     SyncReferencedGameObject(argNode, argNode.Instance);
                  }
               }
            }
         }

         //force any potential entites affected to update
         RefreshSetProperties(receiver, outputList.ToArray());

         //call anyone else connected to us
         CallRelays(receiver.Guid, eventName);

         profile.End();
      }

      //define the function which a node will call if they're
      //triggering an entity method
      private void RelayToMethod(EntityMethod receiver)
      {
         Profile profile = new Profile("RelayToMethod");

         //make sure any properties or variables connected to us are up to date
         SyncSlaveConnections(receiver, receiver.Parameters);

         Parameter returnParam = Parameter.Empty;
         string args = "";

         foreach (Parameter parameter in receiver.Parameters)
         {
            if (true == parameter.Input && true == parameter.Output)
            {
               args += "ref " + CSharpName(receiver, parameter.Name) + ", ";
            }
            else if (true == parameter.Output)
            {
               if (parameter.Name == "Return")
               {
                  returnParam = parameter;
               }
               else
               {
                  args += "out " + CSharpName(receiver, parameter.Name) + ", ";
               }
            }
            else if (true == parameter.Input)
            {
               args += CSharpName(receiver, parameter.Name) + ", ";
            }
         }

         if (args != "") args = args.Substring(0, args.Length - 2);


         if (false == receiver.IsStatic)
         {
            AddCSharpLine("{");
            ++m_TabStack;

                AddCSharpLine(receiver.ComponentType + " component;");

                LinkNode[] instanceLinks = FindLinksByDestination(receiver.Guid, receiver.Instance.Name);

                foreach (LinkNode link in instanceLinks)
                {
                   EntityNode node = m_Script.GetNode(link.Source.Guid);

                   if (returnParam != Parameter.Empty)
                   {
                      // Entity properties are defined by their .parameter and their .instance
                      // whereas other nodes are simply defined by the default EntityNode
                      if (node is EntityProperty)
                         AddCSharpLine("component = " + CSharpName(node, node.Parameters[0].Name) + ".GetComponent<" + receiver.ComponentType + ">();");
                      else
                         AddCSharpLine("component = " + CSharpName(node) + ".GetComponent<" + receiver.ComponentType + ">();");
                      
                      AddCSharpLine("if ( null != component )");
                      AddCSharpLine("{");
                      ++m_TabStack;
                       
                      AddCSharpLine(CSharpName(receiver, returnParam.Name) + " = component." + receiver.Input.Name + "(" + args + ");");

                      --m_TabStack;
                      AddCSharpLine("}");

                      //only one instance link supported because of the return parameter - this should be enforced
                      //in the editor - this is just for a sanity check
                      break;
                   }
                   else
                   {
                      // Entity properties are defined by their .parameter and their .instance
                      // whereas other nodes are simply defined by the default EntityNode
                      if (node is EntityProperty)
                         AddCSharpLine("component = " + CSharpName(node, node.Parameters[0].Name) + ".GetComponent<" + receiver.ComponentType + ">();");
                      else
                        AddCSharpLine("component = " + CSharpName(node) + ".GetComponent<" + receiver.ComponentType + ">();");
  
                      AddCSharpLine("if ( null != component )");
                      AddCSharpLine("{");
                      ++m_TabStack;

                      AddCSharpLine("component." + receiver.Input.Name + "(" + args + ");");

                      --m_TabStack;
                      AddCSharpLine("}");
                   }
                }

                //only one instance because of the return parameter
                if (receiver.Instance.Default != "")
                {
                   if (returnParam != Parameter.Empty)
                   {
                      //only one instance supported because of the return parameter - this should be enforced
                      //in the editor - this is just for a sanity check
                      if (instanceLinks.Length == 0)
                      {
                         AddCSharpLine("component = " + CSharpName(receiver, receiver.Instance.Name) + ".GetComponent<" + receiver.ComponentType + ">();");
                         AddCSharpLine("if ( null != component )");
                         AddCSharpLine("{");
                         ++m_TabStack;

                         AddCSharpLine(CSharpName(receiver, returnParam.Name) + " = component." + receiver.Input.Name + "(" + args + ");");

                         --m_TabStack;
                         AddCSharpLine("}");
                      }
                   }
                   else
                   {
                      AddCSharpLine("component = " + CSharpName(receiver, receiver.Instance.Name) + ".GetComponent<" + receiver.ComponentType + ">();");
                      AddCSharpLine("if ( null != component )");
                      AddCSharpLine("{");
                      ++m_TabStack;

                      AddCSharpLine("component." + receiver.Input.Name + "(" + args + ");");

                      --m_TabStack;
                      AddCSharpLine("}");
                   }
                }

             --m_TabStack;
             AddCSharpLine("}");
         }
         else //static static receiver
         {
            if (returnParam != Parameter.Empty)
            {
               AddCSharpLine(CSharpName(receiver, returnParam.Name) + " = " + receiver.ComponentType + "." + receiver.Input.Name + "(" + args + ");");
            }
            else
            {
               AddCSharpLine(receiver.ComponentType + "." + receiver.Input.Name + "(" + args + ");");
            }
         }

         //push the output values
         //to all the links we connect out to
         foreach (Parameter parameter in receiver.Parameters)
         {
            if (false == parameter.Output) continue;

            LinkNode[] argLinks = FindLinksBySource(receiver.Guid, parameter.Name);

            foreach (LinkNode link in argLinks)
            {
               EntityNode argNode = m_Script.GetNode(link.Destination.Guid);
               AddCSharpLine(CSharpName(argNode, link.Destination.Anchor) + " = " + CSharpName(receiver, parameter.Name) + ";");

               // don't sync up entity properties, they will sync themselves up
               // at the RefreshSetProperties call
               if (false == (argNode is EntityProperty))
               {
                  foreach (Parameter p in argNode.Parameters)
                  {
                     if (p.Name == link.Destination.Anchor)
                     {
                        SyncReferencedGameObject(argNode, parameter);
                        break;
                     }
                  }

                  if (argNode.Instance.Name == link.Destination.Anchor)
                  {
                     SyncReferencedGameObject(argNode, argNode.Instance);
                  }
               }
            }
         }

         //force any potential entites affected to update
         RefreshSetProperties(receiver, receiver.Parameters);

         //call anyone else connected to us
         CallRelays(receiver.Guid, receiver.Output.Name);

         profile.End();
      }

      //are any relay functions connected to the point
      //defined in the source parameters
      private bool HasRelays(Guid guid, string name)
      {
         foreach (LinkNode link in m_Script.Links)
         {
            if (link.Source.Anchor == name &&
               link.Source.Guid == guid)
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
         foreach (LinkNode link in m_Script.Links)
         {
            if (link.Source.Anchor == name &&
               link.Source.Guid == guid)
            {
               AddCSharpLine(CSharpRelay(m_Script.GetNode(link.Destination.Guid), link.Destination.Anchor) + "();");
            }
         }
      }

      //define a function which a node will call if
      //they are connected to a logic node
      private void RelayToLogic(LogicNode receiver, string methodName)
      {
         Profile profile = new Profile("RelayToLogic");

         Parameter returnParam = Parameter.Empty;
         string args = "";

         foreach (Parameter parameter in receiver.Parameters)
         {
            if (true == parameter.Input && true == parameter.Output)
            {
               args += "ref " + CSharpName(receiver, parameter.Name) + ", ";
            }
            else if (true == parameter.Output)
            {
               if (parameter.Name == "Return")
               {
                  returnParam = parameter;
               }
               else
               {
                  // if it is a nested node then all the values are sent back via an event
                  // and there are no output parameters
                  if (receiver.IsNestedNode == false)
                     args += "out " + CSharpName(receiver, parameter.Name) + ", ";
               }
            }
            else if (true == parameter.Input)
            {
               args += CSharpName(receiver, parameter.Name) + ", ";
            }
         }

         if (args != "") args = args.Substring(0, args.Length - 2);

         //make sure any properties or variables connected to us are up to date
         SyncSlaveConnections(receiver, receiver.Parameters);

         if (returnParam != Parameter.Empty)
         {
            AddCSharpLine(CSharpName(receiver, returnParam.Name) + " = " + CSharpName(receiver, receiver.Type) + "." + methodName + "(" + args + ");");
         }
         else
         {
            AddCSharpLine(CSharpName(receiver, receiver.Type) + "." + methodName + "(" + args + ");");
         }


         //restart any drivens contained in this node
         foreach (string driven in receiver.Drivens)
         {
            AddCSharpLine(CSharpName(receiver, driven) + " = true;");
         }

         // Only copy variables back over if it's not a nested node
         // if it is a nested node then all the values were sent back via an event
         // before the method we called ever exited
         // and this code would simply be overwriting those values
         if (receiver.IsNestedNode == false)
         {
            //use previously saved temp variables to push the values
            //to all the links we connect out to
            foreach (Parameter parameter in receiver.Parameters)
            {
               if (false == parameter.Output) continue;

               LinkNode[] argLinks = FindLinksBySource(receiver.Guid, parameter.Name);

               foreach (LinkNode link in argLinks)
               {
                  EntityNode argNode = m_Script.GetNode(link.Destination.Guid);
                  AddCSharpLine(CSharpName(argNode, link.Destination.Anchor) + " = " + CSharpName(receiver, parameter.Name) + ";");

                  // don't sync up entity properties, they will sync themselves up
                  // at the RefreshSetProperties call
                  if (false == (argNode is EntityProperty))
                  {
                     foreach (Parameter p in argNode.Parameters)
                     {
                        if (p.Name == link.Destination.Anchor)   
                        {
                           SyncReferencedGameObject(argNode, parameter);
                           break;
                        } 
                     }

                     if (argNode.Instance.Name == link.Destination.Anchor)
                     {
                        SyncReferencedGameObject(argNode, argNode.Instance);
                     }
                  }
               }
            }

            //force any potential entites affected to update
            RefreshSetProperties(receiver, receiver.Parameters);
         }
         else
         {

            AddCSharpLine("");
            AddCSharpLine("//Don't copy 'out' values back to the global variables because this was an auto generated nested node");
            AddCSharpLine("//and those values get set through an event which is called before the above method exited");
         }

         if (receiver.Outputs.Length > 0)
         {
            AddCSharpLine("");
            AddCSharpLine("//save off values because, if there are multiple, our relay logic could cause them to change before the next value is tested");
         }

         int i = 0;

         //call anyone else connected to our outputs
         //if the result of the logic node has set our output to true
         foreach (Plug output in receiver.Outputs)
         {
            if (true == HasRelays(receiver.Guid, output.Name))
            {
               AddCSharpLine("bool test_" + (i++) + " = " + CSharpName(receiver, receiver.Type) + "." + output.Name + ";");
            }
         }

         AddCSharpLine("");
         i = 0;

         //call anyone else connected to our outputs
         //if the result of the logic node has set our output to true
         foreach (Plug output in receiver.Outputs)
         {
            if (true == HasRelays(receiver.Guid, output.Name))
            {
               AddCSharpLine("if ( test_" + (i++) + " == true )");
               AddCSharpLine("{");
               ++m_TabStack;
               CallRelays(receiver.Guid, output.Name);
               --m_TabStack;
               AddCSharpLine("}");
            }
         }

         profile.End();
      }

      //define a function which a node will if a logic node implements a 'driven' function
      private void DefineDriven(LogicNode receiver, string methodName)
      {
         Profile profile = new Profile("DefineDriven");

         string args = "";

         foreach (Parameter parameter in receiver.Parameters)
         {
            //we don't allow refs or inputs on drivens
            //because uScript standard doesn't allow changing of input variables
            //without a pulse in
            if (true == parameter.Output)
            {
               if (parameter.Name == "Return")
               {
                  //do nothing, there shouldn't be one for a driven node
               }
               else
               {
                  args += "out " + CSharpName(receiver, parameter.Name) + ", ";
               }
            }
         }

         if (args != "") args = args.Substring(0, args.Length - 2);

         //make sure any properties or variables connected to us are up to date
         SyncSlaveConnections(receiver, receiver.Parameters);

         AddCSharpLine(CSharpName(receiver, methodName) + " = " + CSharpName(receiver, receiver.Type) + "." + methodName + "(" + args + ");");

         AddCSharpLine("if ( true == " + CSharpName(receiver, methodName) + " )");
         AddCSharpLine("{");
         ++m_TabStack;

         //use previously saved temp variables to push the values
         //to all the links we connect out to
         foreach (Parameter parameter in receiver.Parameters)
         {
            if (false == parameter.Output) continue;

            LinkNode[] argLinks = FindLinksBySource(receiver.Guid, parameter.Name);

            foreach (LinkNode link in argLinks)
            {
               EntityNode argNode = m_Script.GetNode(link.Destination.Guid);
               AddCSharpLine(CSharpName(argNode, link.Destination.Anchor) + " = " + CSharpName(receiver, parameter.Name) + ";");

               foreach (Parameter p in argNode.Parameters)
               {
                  if (p.Name == link.Destination.Anchor)
                  {
                     SyncReferencedGameObject(argNode, parameter);
                     break;
                  }
               }

               if (argNode.Instance.Name == link.Destination.Anchor)
               {
                  SyncReferencedGameObject(argNode, argNode.Instance);
               }
            }
         }

         //force any potential entites affected to update
         RefreshSetProperties(receiver, receiver.Parameters);

         //call anyone else connected to our outputs
         //if the result of the logic node has set our output to true
         foreach (Plug output in receiver.Outputs)
         {
            if (true == HasRelays(receiver.Guid, output.Name))
            {
               AddCSharpLine("if ( " + CSharpName(receiver, receiver.Type) + "." + output.Name + " == true )");
               AddCSharpLine("{");
               ++m_TabStack;
               CallRelays(receiver.Guid, output.Name);
               --m_TabStack;
               AddCSharpLine("}");
            }
         }

         --m_TabStack;
         AddCSharpLine("}");

         profile.End();
      }


      //define functions which get called by node connections
      private void DefineRelay(EntityNode receiver)
      {
         Profile p = new Profile("DefineRelay");

         //no relays, these are only containers
         if (receiver is LocalNode) return;
         if (receiver is EntityProperty) return;

         if (receiver is EntityMethod)
         {
            AddCSharpLine("void " + CSharpRelay(receiver, ((EntityMethod)receiver).Input.Name) + "()");
            AddCSharpLine("{");

            ++m_TabStack;

            if (true == m_GenerateDebugInfo)
            {
               AddCSharpLine("if ( relayCallCount++ < MaxRelayCallCount )");
               AddCSharpLine("{");
               ++m_TabStack;

               PrintDebug(receiver);
               CheckDebugBreak(receiver, CSharpRelay(receiver, ((EntityMethod)receiver).Input.Name));
               RelayToMethod((EntityMethod)receiver);

               --m_TabStack;
               AddCSharpLine("}");
               AddCSharpLine("else");
               AddCSharpLine("{");
               ++m_TabStack;

               AddCSharpLine("uScriptDebug.Log( \"Possible infinite loop detected in uScript " + m_Script.Name + " at " + ((EntityMethod)receiver).ComponentType + ".  " +
                        "If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.\", uScriptDebug.Type.Error);");

               --m_TabStack;
               AddCSharpLine("}");
            }
            else
            {
               RelayToMethod((EntityMethod)receiver);
            }

            --m_TabStack;

            AddCSharpLine("}");
            AddCSharpLine("");
         }
         if (receiver is EntityEvent)
         {
            EntityEvent entityEvent = (EntityEvent)receiver;

            foreach (Plug eventName in entityEvent.Outputs)
            {
               AddCSharpLine("void " + CSharpRelay(receiver, eventName.Name) + "()");
               AddCSharpLine("{");

               ++m_TabStack;

               if (true == m_GenerateDebugInfo)
               {
                  //no need to wrap call count checking
                  //because this is an event coming in from Unity
                  PrintDebug(receiver);
                  CheckDebugBreak(receiver, CSharpRelay(receiver, eventName.Name));
                  RelayToEvent(entityEvent, eventName.Name);
               }
               else
               {
                  RelayToEvent(entityEvent, eventName.Name);
               }

               --m_TabStack;

               AddCSharpLine("}");
               AddCSharpLine("");
            }
         }
         if (receiver is ExternalConnection)
         {
            ExternalConnection external = (ExternalConnection)receiver;

            AddCSharpLine("void " + CSharpRelay(receiver, external.Connection) + "()");
            AddCSharpLine("{");

            ++m_TabStack;

            if (true == m_GenerateDebugInfo)
            {
               AddCSharpLine("if ( relayCallCount++ < MaxRelayCallCount )");
               AddCSharpLine("{");
               ++m_TabStack;

               PrintDebug(receiver);
               CheckDebugBreak(receiver, CSharpRelay(receiver, external.Connection));
               RelayToExternal(external);

               --m_TabStack;
               AddCSharpLine("}");
               AddCSharpLine("else");
               AddCSharpLine("{");
               ++m_TabStack;

               AddCSharpLine("uScriptDebug.Log( \"Possible infinite loop detected in uScript " + m_Script.Name + " at " + external.Name.Default + ".  " +
                        "If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.\", uScriptDebug.Type.Error);");
               --m_TabStack;
               AddCSharpLine("}");
            }
            else
            {
               RelayToExternal(external);
            }

            --m_TabStack;

            AddCSharpLine("}");
            AddCSharpLine("");
         }
         if (receiver is LogicNode)
         {
            LogicNode logicNode = (LogicNode)receiver;

            foreach (Plug eventName in logicNode.Events)
            {
               AddCSharpLine("void " + CSharpRelay(receiver, eventName.Name) + "()");
               AddCSharpLine("{");

               ++m_TabStack;

               if (true == m_GenerateDebugInfo)
               {
                  AddCSharpLine("if ( relayCallCount++ < MaxRelayCallCount )");
                  AddCSharpLine("{");
                  ++m_TabStack;

                  PrintDebug(receiver);
                  CheckDebugBreak(receiver, CSharpRelay(receiver, eventName.Name));
                  CallRelays(receiver.Guid, eventName.Name);

                  --m_TabStack;
                  AddCSharpLine("}");
                  AddCSharpLine("else");
                  AddCSharpLine("{");
                  ++m_TabStack;

                  AddCSharpLine("uScriptDebug.Log( \"Possible infinite loop detected in uScript " + m_Script.Name + " at " + logicNode.FriendlyName + ".  " +
                           "If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.\", uScriptDebug.Type.Error);");
                  --m_TabStack;
                  AddCSharpLine("}");
               }
               else
               {
                  CallRelays(receiver.Guid, eventName.Name);
               }

               --m_TabStack;

               AddCSharpLine("}");
               AddCSharpLine("");
            }

            foreach (Plug input in logicNode.Inputs)
            {
               AddCSharpLine("void " + CSharpRelay(receiver, input.Name) + "()");
               AddCSharpLine("{");

               ++m_TabStack;

               if (true == m_GenerateDebugInfo)
               {
                  AddCSharpLine("if ( relayCallCount++ < MaxRelayCallCount )");
                  AddCSharpLine("{");
                  ++m_TabStack;

                  PrintDebug(receiver);
                  CheckDebugBreak(receiver, CSharpRelay(receiver, input.Name));
                  RelayToLogic((LogicNode)receiver, input.Name);

                  --m_TabStack;
                  AddCSharpLine("}");
                  AddCSharpLine("else");
                  AddCSharpLine("{");
                  ++m_TabStack;

                  AddCSharpLine("uScriptDebug.Log( \"Possible infinite loop detected in uScript " + m_Script.Name + " at " + logicNode.FriendlyName + ".  " +
                           "If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.\", uScriptDebug.Type.Error);");
                  --m_TabStack;
                  AddCSharpLine("}");
               }
               else
               {
                  RelayToLogic((LogicNode)receiver, input.Name);
               }

               --m_TabStack;

               AddCSharpLine("}");
               AddCSharpLine("");
            }

            foreach (string driven in logicNode.Drivens)
            {
               AddCSharpLine("void " + CSharpRelay(logicNode, driven) + "( )");
               AddCSharpLine("{");
               ++m_TabStack;

               if (true == m_GenerateDebugInfo)
               {
                  AddCSharpLine("if ( relayCallCount++ < MaxRelayCallCount )");
                  AddCSharpLine("{");
                  ++m_TabStack;

                  DefineDriven(logicNode, driven);

                  --m_TabStack;
                  AddCSharpLine("}");
                  AddCSharpLine("else");
                  AddCSharpLine("{");
                  ++m_TabStack;

                  AddCSharpLine("uScriptDebug.Log( \"Possible infinite loop detected in uScript " + m_Script.Name + " at " + logicNode.FriendlyName + ".  " +
                           "If this is in error you can change the Maximum Node Recursion in the Preferences Panel and regenerate the script.\", uScriptDebug.Type.Error);");
                  --m_TabStack;
                  AddCSharpLine("}");
               }
               else
               {
                  DefineDriven(logicNode, driven);
               }

               --m_TabStack;
               AddCSharpLine("}");
            }
         }

         p.End();
      }

      private void AddCSharpLine(string CSharpScript)
      {
         for (int i = 0; i < m_TabStack; i++)
         {
            m_CSharpString.Append("   ");
         }

         m_CSharpString.Append(CSharpScript + "\r\n");
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
         return CSharpName(entityNode, "Default");
      }

      //create unique CSharp name based on id, etc.
      private string CSharpName(EntityNode entityNode, string parameterName)
      {
         string name = "";

         if (null == entityNode)
         {
            name = parameterName;
         }
         else
         {
            int guidId = GetGuidId(entityNode.Guid);

            if (entityNode is EntityEvent)
            {
               EntityEvent entityEvent = (EntityEvent)entityNode;
               name = "event_" + entityEvent.Instance.Type + "_" + parameterName + "_" + guidId;
            }
            else if (entityNode is EntityMethod)
            {
               EntityMethod entityMethod = (EntityMethod)entityNode;
               name = "method_" + entityMethod.Input + "_" + entityMethod.Instance.Type + "_" + parameterName + "_" + guidId;
            }
            else if (entityNode is EntityProperty)
            {
               EntityProperty entityProperty = (EntityProperty)entityNode;
               name = "property_" + entityProperty.Parameter.Name + "_" + entityProperty.Instance + "_" + parameterName + "_" + guidId;
            }
            else if (entityNode is LocalNode)
            {
               LocalNode local = (LocalNode)entityNode;

               if ("true" == local.Externaled.Default)
               {
                  name = local.Name.Default;
               }
               else
               {
                  name = "local_" + local.Name.Default + "_" + local.Value.Type;
                  name = name.Replace("[]", "Array");
               }
            }
            else if (entityNode is OwnerConnection)
            {
               OwnerConnection owner = (OwnerConnection)entityNode;

               name = "owner_" + owner.Connection.Name + "_" + guidId;
               name = name.Replace("[]", "Array");
            }
            else if (entityNode is ExternalConnection)
            {
               name = "external_" + guidId;
               name = name.Replace("[]", "Array");
            }
            else if (entityNode is LogicNode)
            {
               LogicNode logicNode = (LogicNode)entityNode;

               //InspectorName if we're creating a name for the Type of the logic node
               if ("" != logicNode.InspectorName.Default && logicNode.Type == parameterName)
               {
                  name = logicNode.InspectorName.Default;
               }
               else
               {
                  name = "logic_" + logicNode.Type + "_" + parameterName + "_" + guidId;
               }
            }
            else
            {
               throw new Exception("CSharp GENERATION ERROR - UNKNOWN TYPE " + entityNode.GetType().ToString());
            }
         }

         name = name.Replace("+", ".");

         return MakeSyntaxSafe(name);
      }

      private string FormatType(string type)
      {
         string formatted = type.Replace("+", ".");

         //Template type
         string replace = null;

         if (formatted.Contains("`2["))
            replace = "`2[";
         else if (formatted.Contains("`1["))
             replace = "`1[";

         if (null != replace)
         {
            string newString = "";
            string[] values = formatted.Split(new string[] { replace }, StringSplitOptions.None);

            foreach (string v in values)
            {
               string value = v + "<";
               string newValue = value;

               int i, open = 1;

               for (i = 1; i < value.Length; i++)
               {
                  if (value[i] == ']') open--;
                  else if (value[i] == '[') open++;

                  if (0 == open)
                  {
                     newValue = value.Substring(0, i);
                     newValue += '>';

                     if (value.Length > i + 1) newValue += value.Substring(i + 1);
                     break;
                  }
               }

               newString += newValue;
            }

            //remove last alligator we appended during the foreach
            formatted = newString.TrimEnd(new char[] { '<' });
         }


         return formatted;
      }

      public static string EscapeString(string s)
      {
         //escape backslashes
         s = s.Replace("\\", "\\\\");
         //escape quotes
         s = s.Replace("\"", "\\\"");
         //newline
         s = s.Replace("\n", "\\n");
         //carriage return
         s = s.Replace("\r", "\\r");

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

         foreach (char c in s)
         {
            if (c >= 'A' && c <= 'Z' ||
               c >= 'a' && c <= 'z' ||
               c == '_' ||
               (c >= '0' && c <= '9' && count > 0))
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

         if (count == 0)
            isSafe = false;

         return typeSafe;
      }

      //int representation of the guid
      private int GetGuidId(Guid guid)
      {
         if (false == m_GuidToId.Contains(guid))
         {
            m_GuidToId[guid] = m_GuidToId.Values.Count;
         }

         return (int)m_GuidToId[guid];
      }

      //create unique CSharp function names based on entity node information
      private string CSharpRelay(EntityNode receiver, string methodName)
      {
         int guidId = GetGuidId(receiver.Guid);

         string name = "Relay_" + methodName + "_" + guidId;
         name = name.Replace(' ', '_');
         name = name.Replace('-', '_');

         return name;
      }

      //register event listener function with an entity
      private void AddEventListener(string eventVariable, EntityEvent entityEvent, bool add)
      {
         string operation = add ? " += " : " -= ";

         if (true == entityEvent.IsStatic)
         {
            foreach (Plug output in entityEvent.Outputs)
            {
               AddCSharpLine(entityEvent.ComponentType + "." + output.Name + operation + CSharpEventDeclaration(entityEvent, output.Name) + ";");
            }
         }
         else
         {
            //if we're setting up a new event which is not a gui listener
            //or if we're removing the events, see if there is an existing one matching the name first
            if (entityEvent.ComponentType != "uScript_GUI")
            {
               AddCSharpLine(entityEvent.ComponentType + " component = " + eventVariable + ".GetComponent<" + entityEvent.ComponentType + ">();");
               if (true == add) AddMissingComponent("component", eventVariable, entityEvent.ComponentType);
            }
            else
            {
               AddCSharpLine("if ( null == " + OnGuiListenerName() + " )");
               AddCSharpLine("{");
               ++m_TabStack;

               AddCSharpLine("//OnGUI need unique listeners so calls like GUI.depth will work across uScripts");
               AddCSharpLine(OnGuiListenerName() + " = " + eventVariable + ".AddComponent<" + entityEvent.ComponentType + ">();");

               --m_TabStack;
               AddCSharpLine("}");

               AddCSharpLine(entityEvent.ComponentType + " component = " + OnGuiListenerName() + ";");
            }
            AddCSharpLine("if ( null != component )");
            AddCSharpLine("{");
            ++m_TabStack;

            foreach (Plug output in entityEvent.Outputs)
            {
               AddCSharpLine("component." + output.Name + operation + CSharpEventDeclaration(entityEvent, output.Name) + ";");
            }

            --m_TabStack;
            AddCSharpLine("}");
         }
      }

      //register event listener function with an entity
      private void AddLogicEventListener(LogicNode logicNode, string eventName, bool addEvent)
      {
         string operation = addEvent ? "+=" : "-=";

         AddCSharpLine(CSharpName(logicNode, logicNode.Type) + "." + eventName + " " + operation + " " + CSharpEventDeclaration(logicNode, eventName) + ";");
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

      private string CSharpSyncUnityHooksDeclaration()
      {
         return "SyncUnityHooks( )";
      }

      private string CSharpRegisterForUnityHooksDeclaration()
      {
         return "RegisterForUnityHooks( )";
      }

      private string CSharpUnregisterEventListenersDeclaration()
      {
         return "UnregisterEventListeners( )";
      }

      private string CSharpSyncEventListenersDeclaration()
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
      private string RemoveReflectionConflicts(string methodName)
      {
         if (methodName == "Start")       return "_" + methodName;
         if (methodName == "Update")      return "_" + methodName;
         if (methodName == "OnGUI")       return "_" + methodName;
         if (methodName == "Awake")       return "_" + methodName;
         if (methodName == "OnDisable")   return "_" + methodName;
         if (methodName == "OnEnable")    return "_" + methodName;

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
         if (methodName == "") methodName = "UNNAMED_EXTERNAL_INPUT";

         //make sure it doesn't conflict with any known unity reflected calls
         methodName = RemoveReflectionConflicts(methodName);

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
         if (plug.Name == "") plug.Name = "UNNAMED_EXTERNAL_PARAMETER";

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
         if (plug.Name == "") plug.Name = "UNNAMED_EXTERNAL_PARAMETER";

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
         if (plug.Name == "") plug.Name = "UNNAMED_EXTERNAL_EVENT";

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
      private void SyncSlaveConnections(EntityNode node, Parameter[] parameters)
      {
         AddCSharpLine("{");
         ++m_TabStack;
         
         foreach (Parameter parameter in parameters)
         {
            AddCSharpLine("{");
            ++m_TabStack;

            string currentCode = SetCode("");

            bool needsProperties = false;

            //get all the links hooked to the input on this node
            LinkNode[] links = FindLinksByDestination(node.Guid, parameter.Name);
            if (links.Length == 0)
            {
               //no links? then they've specified
               //a default parmaeter so make sure that is hooked up
               SyncReferencedGameObject(node, parameter);
            }

            if (parameter.Type.Contains("[]"))
            {
               AddCSharpLine("int index = 0;");

               foreach (LinkNode link in links)
               {
                  EntityNode argNode = m_Script.GetNode(link.Source.Guid);

                  //check to see if any source nodes are local variables
                  if (argNode is LocalNode || argNode is ExternalConnection)
                  {
                     Parameter value;

                     if (argNode is LocalNode)
                     {
                        LocalNode localNode = (LocalNode)argNode;
                        value = localNode.Value;
                     }
                     else
                     {
                        //external connections take on the type
                        //they are connected to
                        value = GetLowestCommonExternalParameter((ExternalConnection)argNode);
                     }

                     SyncReferencedGameObject(argNode, value);
                     
                     //if the local variable is an array then we need to copy the array
                     //to the next available index of the input parameter

                     if (value.Type.Contains("[]"))
                     {
                        needsProperties = true;

                        AddCSharpLine("properties = " + CSharpName(argNode) + ";");

                        //make sure our input array is large enough to hold the array we're copying into it
                        AddCSharpLine("if ( " + CSharpName(node, parameter.Name) + ".Length != index + properties.Length)");
                        AddCSharpLine("{");
                        ++m_TabStack;
                        AddCSharpLine("System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + properties.Length);");
                        --m_TabStack;
                        AddCSharpLine("}");

                        //copy the source node array into the input parameter array
                        AddCSharpLine("System.Array.Copy(properties, 0, " + CSharpName(node, parameter.Name) + ", index, properties.Length);");
                        AddCSharpLine("index += properties.Length;");
                        AddCSharpLine("");
                     }
                     else
                     {
                        needsProperties = true;

                        //make sure our input array is large enough to hold another value
                        AddCSharpLine("if ( " + CSharpName(node, parameter.Name) + ".Length <= index)");
                        AddCSharpLine("{");
                        ++m_TabStack;
                        AddCSharpLine("System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + 1);");
                        --m_TabStack;
                        AddCSharpLine("}");

                        //copy the source node value into the input parameter array
                        AddCSharpLine(CSharpName(node, parameter.Name) + "[ index++ ] = " + CSharpName(argNode) + ";");
                        AddCSharpLine("");
                     }
                  }

                  //check to see if any source nodes are local variables
                  else if (argNode is OwnerConnection)
                  {
                     needsProperties = true;

                     //make sure our input array is large enough to hold another value
                     AddCSharpLine("if ( " + CSharpName(node, parameter.Name) + ".Length <= index)");
                     AddCSharpLine("{");
                     ++m_TabStack;
                     AddCSharpLine("System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + 1);");
                     --m_TabStack;
                     AddCSharpLine("}");

                     //copy the source node value into the input parameter array
                     AddCSharpLine(CSharpName(node, parameter.Name) + "[ index++ ] = " + CSharpName(argNode) + ";");
                     AddCSharpLine("");
                  }

                  //check to see if any source nodes are property nodes
                  else if (argNode is EntityProperty)
                  {
                     EntityProperty entityProperty = (EntityProperty)argNode;

                     if (true == entityProperty.Parameter.Output)
                     {
                        SyncReferencedGameObject(argNode, entityProperty.Parameter);

                        //if the property variable is an array then we need to copy the array
                        //to the next available index of the input parameter
                        if (entityProperty.Parameter.Type.Contains("[]"))
                        {
                           needsProperties = true;

                           AddCSharpLine("properties = " + CSharpRefreshGetPropertyDeclaration(entityProperty) + "( );");

                           //make sure our input array is large enough to hold the array we're copying into it
                           AddCSharpLine("if ( " + CSharpName(node, parameter.Name) + ".Length != index + properties.Length)");
                           AddCSharpLine("{");
                           ++m_TabStack;
                           AddCSharpLine("System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + properties.Length);");
                           --m_TabStack;
                           AddCSharpLine("}");

                           AddCSharpLine("System.Array.Copy(properties, 0, " + CSharpName(node, parameter.Name) + ", index, properties.Length);");
                           AddCSharpLine("index += properties.Length;");
                           AddCSharpLine("");
                        }
                        else
                        {
                           //make sure our input array is large enough to hold another value
                           AddCSharpLine("if ( " + CSharpName(node, parameter.Name) + ".Length <= index)");
                           AddCSharpLine("{");
                           ++m_TabStack;
                           AddCSharpLine("System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index + 1);");
                           --m_TabStack;
                           AddCSharpLine("}");

                           //copy the source node value into the input parameter array
                           AddCSharpLine(CSharpName(node, parameter.Name) + "[ index++ ] = " + CSharpRefreshGetPropertyDeclaration(entityProperty) + "( );");
                           AddCSharpLine("");
                        }
                     }
                  }
               }

               needsProperties = true;

               AddCSharpLine("System.Array.Resize(ref " + CSharpName(node, parameter.Name) + ", index);");
            }
            else
            {
               foreach (LinkNode link in links)
               {
                  EntityNode argNode = m_Script.GetNode(link.Source.Guid);

                  //if any of those links is a local node
                  //we need to write the line for the property to refresh
                  if (argNode is LocalNode || argNode is OwnerConnection || argNode is ExternalConnection)
                  {
                     if (argNode is LocalNode)
                     {
                        LocalNode localNode = (LocalNode)argNode;
                        SyncReferencedGameObject(localNode, localNode.Value);
                     }

                     AddCSharpLine(CSharpName(node, parameter.Name) + " = " + CSharpName(argNode) + ";");
                     AddCSharpLine("");
                  }

                  //if any of those links is a property node
                  //we need to write the line for the property to refresh
                  else if (argNode is EntityProperty)
                  {
                     EntityProperty entityProperty = (EntityProperty)argNode; 

                     if (true == entityProperty.Parameter.Output)
                     {
                        SyncReferencedGameObject(entityProperty, entityProperty.Parameter);

                        //If our node is an entity property
                        //we do nothing because it will refreshed automatically when its used
                        if (node is EntityProperty) 
                        {} // do nothing
                        else
                           //otherwise we fill the node with a new value
                           AddCSharpLine(CSharpName(node, parameter.Name) + " = " + CSharpRefreshGetPropertyDeclaration(entityProperty) + "( );");
                     }
                  }
               }
            }

            string newCode = SetCode(currentCode);

            if (true == needsProperties)
               AddCSharpLine("System.Array properties;");

            m_CSharpString.Append(newCode);

            --m_TabStack;
            AddCSharpLine("}");
         }

         --m_TabStack;
         AddCSharpLine("}");
      }

      private void SyncReferencedGameObject(EntityNode node, Parameter parameter)
      {
         string currentCode = SetCode("");

         ++m_TabStack;
         FillComponent(false, node, parameter);
         --m_TabStack;

         string newCode = SetCode(currentCode);

         if (newCode != "")
         {
            AddCSharpLine("{");

            m_CSharpString.Append(newCode);

            AddCSharpLine("}");
         }
      }

      private string OnGuiListenerName() { return "thisScriptsOnGuiListener"; }

      //go through and tell all the property linked to us to update their entity's values
      //because we could have modified the CSharp representation
      private void RefreshSetProperties(EntityNode node, Parameter[] parameters)
      {
         //make sure all components we plan to reference
         //have been placed in their local variables
         foreach (Parameter parameter in parameters)
         {
            //get all the links which go out from the output on this node
            LinkNode[] links = FindLinksBySource(node.Guid, parameter.Name);

            foreach (LinkNode link in links)
            {
               //if any of those links goes to a property node
               //we need to write the line for the property to refresh
               EntityNode argNode = m_Script.GetNode(link.Destination.Guid);

               if (argNode is EntityProperty)
               {
                  EntityProperty property = (EntityProperty)argNode;

                  if (true == property.Parameter.Input) 
                  {
                     AddCSharpLine(CSharpRefreshSetPropertyDeclaration(property) + "( );");
                     SyncReferencedGameObject(property, property.Parameter);
                  }
               }
            }
         }
      }

      //helper function to find links which link to a specific destination point
      private LinkNode[] FindLinksByDestination(Guid destination, string name)
      {
         List<LinkNode> links = new List<LinkNode>();

         foreach (LinkNode link in m_Script.Links)
         {
            if (link.Destination.Guid == destination &&
               link.Destination.Anchor == name)
            {
               links.Add(link);
            }
         }

         return links.ToArray();
      }

      //helper function to find links which link to a specific source point
      private LinkNode[] FindLinksBySource(Guid source, string name)
      {
         List<LinkNode> links = new List<LinkNode>();

         foreach (LinkNode link in m_Script.Links)
         {
            if (link.Source.Guid == source &&
               link.Source.Anchor == name)
            {
               links.Add(link);
            }
         }

         return links.ToArray();
      }

      private void CheckDebugBreak(EntityNode node, string method)
      {
         if (true == m_GenerateDebugInfo)
         {
            AddCSharpLine("if (true == " + CheckDebugBreakDeclaration(node, method) + ") return; ");
         }
      }

      private string CheckDebugBreakDeclaration(EntityNode node, string method)
      {
         return "CheckDebugBreak(\"" + node.Guid.ToString() + "\", \"" + MakeSyntaxSafe(uScript.FindFriendlyName(node)) + "\", " + method + ")";
      }

      private void DefineCheckDebugBreak()
      {
         if (true == m_GenerateDebugInfo)
         {
            AddCSharpLine("bool CheckDebugBreak(string guid, string name, ContinueExecution method)");
            AddCSharpLine("{");
            ++m_TabStack;
            AddCSharpLine("if (true == m_Breakpoint) return true;");
            AddCSharpLine("");

            AddCSharpLine("if (true == uScript_MasterComponent.FindBreakpoint(guid))");
            AddCSharpLine("{");
            ++m_TabStack;
            AddCSharpLine("if (uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint == guid)");
            AddCSharpLine("{");
            ++m_TabStack;
            AddCSharpLine("uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = \"\";");
            --m_TabStack;
            AddCSharpLine("}");
            AddCSharpLine("else");
            AddCSharpLine("{");
            ++m_TabStack;
            AddCSharpLine("uScript_MasterComponent.LatestMasterComponent.CurrentBreakpoint = guid;");
            AddCSharpLine(UpdateEditorValuesDeclaration() + ";");
            AddCSharpLine("UnityEngine.Debug.Log(\"uScript BREAK Node:\" + name + \" ((Time: \" + Time.time + \"\");");
            AddCSharpLine("UnityEngine.Debug.Break();");
            AddCSharpLine("#if (!UNITY_FLASH)");
            AddCSharpLine("m_ContinueExecution = new ContinueExecution(method);");
            AddCSharpLine("#endif");
            AddCSharpLine("m_Breakpoint = true;");
            AddCSharpLine("return true;");
            --m_TabStack;
            AddCSharpLine("}");
            --m_TabStack;
            AddCSharpLine("}");
            AddCSharpLine("return false;");
            --m_TabStack;
            AddCSharpLine("}");
         }
      }

      private void PrintDebug(EntityNode node)
      {
         if (true == m_GenerateDebugInfo)
         {
            if ("true" == node.ShowComment.Default)
            {
               AddCSharpLine("uScriptDebug.Log( \"[" + uScriptConfig.Variable.FriendlyName(node.GetType().ToString()) + "] " + EscapeString(node.Comment.Default) + "\", uScriptDebug.Type.Message);");
            }
         }
      }

      private void DefineUpdateEditorValues()
      {
         if (true == m_GenerateDebugInfo)
         {
            AddCSharpLine("private void " + UpdateEditorValuesDeclaration());
            AddCSharpLine("{");
            ++m_TabStack;

            foreach (LocalNode local in m_Script.Locals)
            {
               //send by name and id because non-globals don't have a synch'd name so they would have to use Id, whereas named variables have been consolidated
               //to a single id so we have to use their name
               AddCSharpLine("uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( \"" + m_Script.Name + ":" + local.Name.Default + "\", " + CSharpName(local) + ");");
               AddCSharpLine("uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( \"" + local.Guid + "\", " + CSharpName(local) + ");");
            }
            foreach (EntityProperty property in m_Script.Properties)
            {
               AddCSharpLine("uScript_MasterComponent.LatestMasterComponent.UpdateNodeValue( \"" + property.Guid + "\", " + CSharpRefreshGetPropertyDeclaration(property) + "());");
            }

            --m_TabStack;
            AddCSharpLine("}");
         }
      }

      private string UpdateEditorValuesDeclaration()
      {
         return "UpdateEditorValues( )";
      }

      private int LocalComparer(LocalNode a, LocalNode b)
      {
         string sa = CSharpName(a);
         string sb = CSharpName(b);

         return String.Compare(sa, sb);
      }
   }
}
