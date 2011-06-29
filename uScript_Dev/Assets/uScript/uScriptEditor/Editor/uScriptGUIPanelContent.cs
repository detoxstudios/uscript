using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Detox.ScriptEditor;
using Detox.FlowChart;

//using Detox.Data.Tools;
//using System.Windows.Forms;
using System.Linq;
//using System.Drawing;




public sealed class uScriptGUIPanelContent : uScriptGUIPanel
{
   //
   // Singleton pattern
   //
   static readonly uScriptGUIPanelContent _instance = new uScriptGUIPanelContent();
   public static uScriptGUIPanelContent Instance { get { return _instance; } }
   private uScriptGUIPanelContent() { Init(); }


   //
   // Members specific to this panel class
   //
   String _graphListFilterText = string.Empty;


   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      _name = "Graph Contents";
      _size = 300;
      _region = uScriptGUI.Region.Content;
   }

   public void Update()
   {
      //
      // Called whenever member data should be updated
      //
   }

   public override void Draw()
   {
      //
      // Called during OnGUI()
      //

      // Local references to uScript
      uScript uScriptInstance = uScript.Instance;
      ScriptEditorCtrl m_ScriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;
      bool m_CanvasDragging = uScriptInstance.m_CanvasDragging;





      /*Rect r =*/ EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, _options);
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
         {
            GUILayout.Label(_name, uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();

            // This is where the Graph Contents toolbar buttons will go

            // Toggle hierarchy foldouts
//            bool newToggleState = GUILayout.Toggle(_paletteFoldoutToggle,
//                                                   (_paletteFoldoutToggle ? uScriptGUIContent.toolbarButtonCollapse : uScriptGUIContent.toolbarButtonExpand),
//                                                   uScriptGUIStyle.paletteToolbarButton,
//                                                   GUILayout.ExpandWidth(false));
//            if (_paletteFoldoutToggle != newToggleState)
//            {
//               _paletteFoldoutToggle = newToggleState;
//               if (_paletteFoldoutToggle)
//               {
//                  ExpandPaletteMenuItem(null);
//               }
//               else
//               {
//                  CollapsePaletteMenuItem(null);
//               }
//            }

            GUI.SetNextControlName ("FilterSearch" );
            string _filterText = uScriptGUI.ToolbarSearchField(_graphListFilterText, GUILayout.Width(100));
            GUI.SetNextControlName ("" );
            if (_filterText != _graphListFilterText)
            {
               // Drop focus if the user inserted a newline (hit enter)
               if (_filterText.Contains('\n'))
               {
                  GUIUtility.keyboardControl = 0;
               }

               // Trim leading whitespace
               _filterText = _filterText.TrimStart( new char[] { ' ' } );

               _graphListFilterText = _filterText;
            }
         }
         EditorGUILayout.EndHorizontal();

         if (m_CanvasDragging && uScript.Preferences.DrawPanelsOnUpdate == false)
         {
            DrawHiddenNotification();
         }
         else
         {
            //
            // Graph Contents list
            //
            // Every node in the graph should be listed here, categorized by type.
            //

            // Process all nodes and place them in the appropriate list
            Dictionary<string, Dictionary<string, List<DisplayNode>>> categories = new Dictionary<string, Dictionary<string, List<DisplayNode>>>();

            DisplayNode displayNode;
            string category;
            string name;
            string comment;

            categories.Add("Comments", new Dictionary<string, List<DisplayNode>>());
            categories.Add("Actions", new Dictionary<string, List<DisplayNode>>());
            categories.Add("Conditions", new Dictionary<string, List<DisplayNode>>());
            categories.Add("Events", new Dictionary<string, List<DisplayNode>>());
            categories.Add("Properties", new Dictionary<string, List<DisplayNode>>());
            categories.Add("Variables", new Dictionary<string, List<DisplayNode>>());
            categories.Add("Miscellaneous", new Dictionary<string, List<DisplayNode>>());

            // @TODO: clean up this code

            foreach (Node node in m_ScriptEditorCtrl.FlowChart.Nodes)
            {
               displayNode = node as DisplayNode;
               category = string.Empty;
               name = string.Empty;
               comment = string.Empty;

               if (displayNode is EntityEventDisplayNode)
               {
                  category = "Events";
                  name = ((EntityEventDisplayNode)displayNode).EntityEvent.FriendlyType;
                  comment = ((EntityEventDisplayNode)displayNode).EntityEvent.Comment.Default;
               }
               else if (displayNode is LogicNodeDisplayNode)
               {
                  category = "Actions";
                  name = ((LogicNodeDisplayNode)displayNode).LogicNode.FriendlyName;
                  comment = ((LogicNodeDisplayNode)displayNode).LogicNode.Comment.Default;
               }
               else if (displayNode is LocalNodeDisplayNode)
               {
                  category = "Variables";
                  name = ((LocalNodeDisplayNode)displayNode).LocalNode.Value.Type; // get FriendlyName
                  name = uScriptConfig.Variable.FriendlyName(name).Replace("UnityEngine.", string.Empty);
                  name = name + ": " + (name == "String" ? "\"" + ((LocalNodeDisplayNode)displayNode).LocalNode.Value.Default + "\"" : ((LocalNodeDisplayNode)displayNode).LocalNode.Value.Default);
                  comment = ((LocalNodeDisplayNode)displayNode).LocalNode.Name.Default;
               }
               else if (displayNode is CommentDisplayNode)
               {
                  category = "Comments";
                  name = ((CommentDisplayNode)displayNode).Comment.TitleText.FriendlyName;
                  comment = ((CommentDisplayNode)displayNode).Comment.TitleText.Default;
               }
               else if (displayNode is EntityPropertyDisplayNode)
               {
                  category = "Properties";
                  name = ((EntityPropertyDisplayNode)displayNode).DisplayName.Replace( "\n", "  " ) + ": " + ((EntityPropertyDisplayNode)displayNode).DisplayValue;
                  comment = ((EntityPropertyDisplayNode)displayNode).EntityProperty.Comment.Default;
               }
               else if (displayNode is OwnerConnectionDisplayNode)
               {
                  category = "Variables";
                  name = "Owner";
                  comment = ((OwnerConnectionDisplayNode)displayNode).OwnerConnection.Comment.Default;
               }
               else if (displayNode is ExternalConnectionDisplayNode)
               {
                  category = "Miscellaneous";
                  name = ((ExternalConnectionDisplayNode)displayNode).ExternalConnection.Name.Default;
                  comment = ((ExternalConnectionDisplayNode)displayNode).ExternalConnection.Comment.Default;
               }
               else
               {
                  category = "Miscellaneous";
               }

               // Validate strings
               name = (String.IsNullOrEmpty(name) ? "UNKNOWN" : name);
               comment = (String.IsNullOrEmpty(comment) ? string.Empty : " (" + comment + ")");

               string fullName = name + comment;

               if (String.IsNullOrEmpty(_graphListFilterText) || fullName.ToLower().Contains(_graphListFilterText.ToLower()))
               {
                  if (categories[category].ContainsKey(name) == false)
                  {
                     categories[category].Add(name, new List<DisplayNode>());
                  }

                  // Add the node to the list
                  categories[category][name].Add(displayNode);
               }
            }

            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
            {
               GUIContent nodeButtonContent = new GUIContent(string.Empty, "Click to select node. Shift-click to toggle the selection.");

               foreach (KeyValuePair<string, Dictionary<string, List<DisplayNode>>> kvpCategory in categories)
               {
                  if (kvpCategory.Value.Count > 0)
                  {
                     // The category contains at least one item to show

                     // This is should be a folding menu item that contains more buttons
                     GUIStyle tmpStyle = new GUIStyle(uScriptGUIStyle.paletteFoldout);
                     tmpStyle.margin = new RectOffset(tmpStyle.margin.left + (0 * 12), 0, 0, 0);

                     bool tmpBool = true;
                     tmpBool = GUILayout.Toggle(tmpBool, kvpCategory.Key, tmpStyle);
                     if (tmpBool)
                     {
                        List<string> nodeList = kvpCategory.Value.Keys.ToList();
                        nodeList.Sort();

                        foreach (string s in nodeList)
                        {
                           List<DisplayNode> dnList = kvpCategory.Value[s];

                           // Show each node
                           foreach (DisplayNode dn in dnList)
                           {
                              // Get the name and comment strings
                              name = string.Empty;
                              comment = string.Empty;

                              if (dn is EntityEventDisplayNode)
                              {
                                 name = ((EntityEventDisplayNode)dn).EntityEvent.FriendlyType;
                                 comment = ((EntityEventDisplayNode)dn).EntityEvent.Comment.Default;
                              }
                              else if (dn is LogicNodeDisplayNode)
                              {
                                 name = ((LogicNodeDisplayNode)dn).LogicNode.FriendlyName;
                                 comment = ((LogicNodeDisplayNode)dn).LogicNode.Comment.Default;
                              }
                              else if (dn is LocalNodeDisplayNode)
                              {
                                 name = ((LocalNodeDisplayNode)dn).LocalNode.Value.Type; // get FriendlyName
                                 name = uScriptConfig.Variable.FriendlyName(name).Replace("UnityEngine.", string.Empty);
                                 name = name + ": " + (name == "String" ? "\"" + ((LocalNodeDisplayNode)dn).LocalNode.Value.Default + "\"" : ((LocalNodeDisplayNode)dn).LocalNode.Value.Default);
                                 comment = ((LocalNodeDisplayNode)dn).LocalNode.Name.Default;
                              }
                              else if (dn is CommentDisplayNode)
                              {
                                 name = ((CommentDisplayNode)dn).Comment.TitleText.FriendlyName;
                                 comment = ((CommentDisplayNode)dn).Comment.TitleText.Default;
                              }
                              else if (dn is EntityPropertyDisplayNode)
                              {
                                 name = ((EntityPropertyDisplayNode)dn).DisplayName.Replace( "\n", "  " ) + ": " + ((EntityPropertyDisplayNode)dn).DisplayValue;
                                 comment = ((EntityPropertyDisplayNode)dn).EntityProperty.Comment.Default;
                              }
                              else if (dn is OwnerConnectionDisplayNode)
                              {
                                 category = "Variables";
                                 name = "Owner";
                                 comment = ((OwnerConnectionDisplayNode)dn).OwnerConnection.Comment.Default;
                              }
                              else if (dn is ExternalConnectionDisplayNode)
                              {
                                 category = "Miscellaneous";
                                 name = ((ExternalConnectionDisplayNode)dn).ExternalConnection.Name.Default;
                                 comment = ((ExternalConnectionDisplayNode)dn).ExternalConnection.Comment.Default;
                              }

                              // Validate strings
                              name = (String.IsNullOrEmpty(name) ? "UNKNOWN" : name);
                              comment = (String.IsNullOrEmpty(comment) ? string.Empty : " (" + comment + ")");

                              GUILayout.BeginHorizontal();
                              {
                                 nodeButtonContent.text = name + comment;
                                 bool selected = dn.Selected;
                                 selected = GUILayout.Toggle(selected, nodeButtonContent, uScriptGUIStyle.nodeButtonLeft);
                                 if (selected != dn.Selected)
                                 {
                                    // is the shift key modifier being used?
                                    if (Event.current.modifiers != EventModifiers.Shift)
                                    {
                                       // clear all selected nodes first
                                       m_ScriptEditorCtrl.DeselectAll();
                                    }
                                    // toggle the clicked node
                                    m_ScriptEditorCtrl.ToggleNode(dn.Guid);
                                 }

                                 if (GUILayout.Button(uScriptGUIContent.listMiniSearch, uScriptGUIStyle.nodeButtonRight, GUILayout.Width(20)))
                                 {
                                    uScript.Instance.ScriptEditorCtrl.CenterOnNode(uScript.Instance.ScriptEditorCtrl.GetNode(dn.Guid));
                                 }
                              }
                              GUILayout.EndHorizontal();
                           }
                        }
                     }
                  }
               }
            }
            EditorGUILayout.EndScrollView();
         }
      }
      EditorGUILayout.EndVertical();

      uScriptGUI.DefineRegion(uScriptGUI.Region.Content);
//      uScriptInstance.SetMouseRegion( uScript.MouseRegion.Palette );//, 1, 1, -4, -4 );

//      if (Event.current.type == EventType.Repaint)
//      {
//         Debug.Log("Region: " + uScriptGUI.Region.Content + ", RegionSize: " + uScriptGUI.GetRegion(uScriptGUI.Region.Content).ToString() + ", Rect: " + r.ToString() + "\n");
//      }
   }

}
