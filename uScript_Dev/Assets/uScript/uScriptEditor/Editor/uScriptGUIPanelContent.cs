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
   Dictionary<string, Dictionary<string, List<NodeInfo>>> _categories = null;

//   System.Drawing.Point _calculatedSize = System.Drawing.Point.Empty;

   private class NodeInfo
   {
      public readonly string GeneratedName;
      public readonly int GeneratedNameWidth;
      public readonly DisplayNode DisplayNode;

      public NodeInfo(string name, int width, DisplayNode node)
      {
         GeneratedName = name;
         GeneratedNameWidth = width;
         DisplayNode = node;
      }
   }

   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      _name = "Graph Contents";
      _size = 300;
      _region = uScriptGUI.Region.Content;

      // Setup the Dictionaries to store the local node information
      Update();
   }

   public void Update()
   {
      //
      // Called whenever member data should be updated
      //



      // Local references to uScript
      uScript uScriptInstance = uScript.Instance;
      ScriptEditorCtrl m_ScriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;


      if (_categories == null)
      {
         _categories = new Dictionary<string, Dictionary<string, List<NodeInfo>>>();

         // Create the Categories in the order they should appear in the list
         _categories.Add("Comments", new Dictionary<string, List<NodeInfo>>());
         _categories.Add("Actions", new Dictionary<string, List<NodeInfo>>());
         _categories.Add("Conditions", new Dictionary<string, List<NodeInfo>>());
         _categories.Add("Events", new Dictionary<string, List<NodeInfo>>());
         _categories.Add("Properties", new Dictionary<string, List<NodeInfo>>());
         _categories.Add("Variables", new Dictionary<string, List<NodeInfo>>());
         _categories.Add("Miscellaneous", new Dictionary<string, List<NodeInfo>>());
      }
      else
      {
//         foreach (KeyValuePair<string, List<NodeInfo>> _category in _categories)
         foreach (var _category in _categories)
         {
            _category.Value.Clear();
         }
      }

      // Process all nodes and place them in the appropriate list
      GUIContent content = new GUIContent();

      DisplayNode displayNode;
      string category;
      string name;
      string comment;

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
            name = "Comment";
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

         content.text = name + comment;

         if (_categories[category].ContainsKey(name) == false)
         {
            _categories[category].Add(name, new List<NodeInfo>());
         }

         // Add the node to the list
         _categories[category][name].Add(new NodeInfo(content.text, (int)uScriptGUIStyle.nodeButtonLeft.CalcSize(content).x, displayNode));
      }
   }

   public override void Draw()
   {
      //
      // Called during OnGUI()
      //
      Update();

      // Local references to uScript
      uScript uScriptInstance = uScript.Instance;
      ScriptEditorCtrl m_ScriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;
      bool m_CanvasDragging = uScriptInstance.m_CanvasDragging;

      Rect r = EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, _options);
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

            //
            // @TODO - Do not rely on hard coded control dimenions, but for now:
            //
            //    CenterOnNode buttons are 20x19
            //    There is 4px horizontal padding on the left and right of the compound control

            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
            {
               GUIContent nodeButtonContent = new GUIContent(string.Empty, "Click to select node. Shift-click to toggle the selection.");

               foreach (KeyValuePair<string, Dictionary<string, List<NodeInfo>>> kvpCategory in _categories)
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
                           List<NodeInfo> dnList = kvpCategory.Value[s];

                           // Show each node
                           foreach (NodeInfo dn in dnList)
                           {
                              // Filter items
                              if (String.IsNullOrEmpty(_graphListFilterText) || dn.GeneratedName.ToLower().Contains(_graphListFilterText.ToLower()))
                              {
                                 // Validate strings
//                                 if (Event.current.type == EventType.Repaint)
//                                 {
//                                    nodeButtonContent.text = Truncate(dn.GeneratedName, (int)r.width - 39, uScriptGUIStyle.nodeButtonLeft);
//                                 }

                                 if (Event.current.type == EventType.Repaint)
                                 {
                                    nodeButtonContent.text = dn.GeneratedName;
                                 }

                                 // Draw the buttons with GUILayout for now. Eventually, perhaps we can switch over to GUI
                                 // for some performance savings
                                 //
                                 GUILayout.BeginHorizontal();
                                 {
                                    bool selected = dn.DisplayNode.Selected;
                                    selected = GUILayout.Toggle(selected, nodeButtonContent, uScriptGUIStyle.nodeButtonLeft);
                                    if (selected != dn.DisplayNode.Selected)
                                    {
                                       // is the shift key modifier being used?
                                       if (Event.current.modifiers != EventModifiers.Shift)
                                       {
                                          // clear all selected nodes first
                                          m_ScriptEditorCtrl.DeselectAll();
                                       }
                                       // toggle the clicked node
                                       m_ScriptEditorCtrl.ToggleNode(dn.DisplayNode.Guid);
                                    }

                                    if (GUILayout.Button(uScriptGUIContent.listMiniSearch, uScriptGUIStyle.nodeButtonRight, GUILayout.Width(20)))
                                    {
                                       uScript.Instance.ScriptEditorCtrl.CenterOnNode(uScript.Instance.ScriptEditorCtrl.GetNode(dn.DisplayNode.Guid));
                                    }
                                 }
                                 GUILayout.EndHorizontal();
                              }
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

      if (Event.current.type == EventType.Repaint)
      {
         _rect = r;
      }
   }

//   GUIContent tempContent = new GUIContent();
   private string Truncate(string srcText, int maxWidth, GUIStyle style)
   {
      // Abort of the string is already short enough
      if (string.IsNullOrEmpty(srcText) || maxWidth > style.CalcSize(new GUIContent(srcText)).x)
      {
         return srcText;
      }


      string ellipsisText = "...";
      maxWidth = Math.Max(0, maxWidth - (int)style.CalcSize(new GUIContent(ellipsisText)).x);



      // Get the initial size of the content
      string tmpText = srcText;
      float tmpWidth = style.CalcSize(new GUIContent(tmpText)).x;

      // Get the percentage of original size with the target size to determine where to start.
      float percentage = maxWidth / tmpWidth;

      int index = (int)(tmpText.Length * percentage) + 1;

      Debug.Log("The string is length is " + tmpText.Length + ", and the initial index is " + index + " based on the percentage " + percentage + "\n");

      // make the initial cut
      // store as final
      tmpText = srcText.Substring(0, index);
      tmpWidth = style.CalcSize(new GUIContent(tmpText)).x;

      Debug.Log("INITIAL INDEX: " + tmpText.Length + ", (\"" + tmpText + "\") has a width of " + tmpWidth + "px (max: " + maxWidth + ")\n");

      // attempt to increase the length
      while (maxWidth > tmpWidth)
      {
         tmpText = srcText.Substring(0, ++index);
         tmpWidth = style.CalcSize(new GUIContent(tmpText)).x;
         Debug.Log("INDEX: " + index + ", (\"" + tmpText + "\") has a width of " + tmpWidth + "px (max: " + maxWidth + ")\n");
      }

      // if the length is too great, decrease it
      while (maxWidth < tmpWidth)
      {
         tmpText = srcText.Substring(0, --index);
         tmpWidth = style.CalcSize(new GUIContent(tmpText)).x;
         Debug.Log("INDEX: " + index + ", (\"" + tmpText + "\") has a width of " + tmpWidth + "px (max: " + maxWidth + ")\n");
      }

      return tmpText + ellipsisText;
   }

}
