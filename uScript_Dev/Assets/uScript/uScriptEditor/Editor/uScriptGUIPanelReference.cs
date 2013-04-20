using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

using Detox.ScriptEditor;
using Detox.FlowChart;

public sealed class uScriptGUIPanelReference: uScriptGUIPanel
{
   //
   // Singleton pattern
   //
   static readonly uScriptGUIPanelReference _instance = new uScriptGUIPanelReference();

   public static uScriptGUIPanelReference Instance { get { return _instance; } }

   private uScriptGUIPanelReference()
   {
      Init();
   }


   //
   // Members specific to this panel class
   //
   private string currentNodeClassName = string.Empty;
   private EntityNode _hotSelection = null;

   public EntityNode hotSelection { set { _hotSelection = value; } }

   private Node _focusedNode = null;

   // Node variables
   private string _nodeSignature = string.Empty;
   private uScriptGUIPanelPalette.PaletteMenuItem _toolboxMenuItem = null;
   private string _toolboxPath = string.Empty;

   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      _name = "Reference";
//      _size = 250;
//      _region = uScriptGUI.Region.Reference;
   }

//   public void Update()
//   {
//      //
//      // Called whenever member data should be updated
//      //
//   }

   public override void Draw()
   {
      //
      // Called during OnGUI()
      //

      // Local references to uScript
      uScript uScriptInstance = uScript.Instance;
      ScriptEditorCtrl m_ScriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;

      // Setup the strings for the button
      string helpButtonTooltip = string.Empty;
      string helpButtonURL = string.Empty;

      EntityNode node = null;


      // Hot node selection has priority.  If the mouse isn't hovering over a node in the Node Palette,
      // use the current node selection to determine the contents of the panel.

      // Setup the toolbar buttons
      if (_hotSelection != null)
      {
         node = _hotSelection;

         currentNodeClassName = string.Empty;
         helpButtonURL = string.Empty;
         helpButtonTooltip = string.Empty;
      }
      else
      {
         if (m_ScriptEditorCtrl.SelectedNodes.Length != 1)
         {
            currentNodeClassName = string.Empty;
            helpButtonTooltip = "Open the online uScript reference in the default web browser.";
            helpButtonURL = "http://www.uscript.net/docs/";
         }
         else
         {
            node = m_ScriptEditorCtrl.SelectedNodes[0].EntityNode;

            if (node != null)
            {
               string newNodeClassName = ScriptEditor.FindNodeType(node);
               if (newNodeClassName != currentNodeClassName)
               {
                  currentNodeClassName = newNodeClassName;
//                  currentNodeClassPath = GetClassPath(newNodeClassName);
               }

               helpButtonTooltip = "Open the online reference for the selected node in the default web browser.";
               helpButtonURL = uScript.FindNodeHelp(uScript.GetNodeType(node), node);
            }
         }

         helpButtonTooltip += " (" + helpButtonURL + ")";
      }

//      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, _options);
      EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox);
      {
         // Toolbar
         //
//         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label(_name, uScriptGUIStyle.PanelTitle, GUILayout.ExpandWidth(true));

//            GUIStyle style = new GUIStyle(GUI.skin.label);
//            style.richText = true;
//            style.normal.textColor = UnityEngine.Color.white;
//
//            GUILayout.Label(("HELLO: " + "bold".Bold().Color(UnityEngine.Color.cyan) + ", " + "italic".Italic() + ", " + "bold and italic".BoldItalic() + ", <color=black>black</color>, <color=white>white</color>, <color=green>red</color>, " + "red".Red() + ", " + "green".Green() + ", <color=blue>blue</color>, " + "blue".Blue() + ", <color=#F70>uScript</color> XXX").Black(), style);

            uScriptGUI.enabled = (string.IsNullOrEmpty(currentNodeClassName) == false);

            if (GUILayout.Button(uScriptGUIContent.buttonNodeSource, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
            {
               uScriptGUI.PingObject(uScript.GetClassPath(currentNodeClassName), typeof(TextAsset));
            }

            uScriptGUI.enabled = (string.IsNullOrEmpty(helpButtonURL) == false);

            uScriptGUIContent.ChangeTooltip(helpButtonTooltip);
            if (GUILayout.Button(uScriptGUIContent.buttonWebDocumentation, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
            {
               Help.BrowseURL(helpButtonURL);
            }

            uScriptGUI.enabled = (_hotSelection == null);

            if (GUILayout.Button(uScriptGUIContent.buttonWebForum, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
            {
               Help.BrowseURL("http://uscript.net/forum");
            }

            if (GUILayout.Button(uScriptGUIContent.commandReference, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
            {
               ReferenceWindow.Init();
            }

            uScriptGUI.enabled = true;
         }
         EditorGUILayout.EndHorizontal();


         if (uScriptInstance.wasCanvasDragged && uScript.Preferences.DrawPanelsOnUpdate == false)
         {
            DrawHiddenNotification();
         }
         else
         {
            // Selection description
            //
            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, "scrollview");
            {
               if ((m_ScriptEditorCtrl.SelectedNodes.Length == 1) && (m_ScriptEditorCtrl.SelectedNodes[0] != null))
               {
                  if (uScript.IsNodeTypeDeprecated(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode) || m_ScriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode))
                  {
                     GUILayout.Box("SELECTED NODE IS DEPRECATED: UPDATE OR REPLACE", uScriptGUIStyle.PanelMessageError);
                  }
               }

               if (node == null)
               {
                  DrawGraphReferenceContent();
               }
               else
               {
                  DrawNodeReferenceContent(node);
               }
            }
            EditorGUILayout.EndScrollView();
         }
      }
      EditorGUILayout.EndVertical();

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Reference);
      uScriptInstance.SetMouseRegion(uScript.MouseRegion.Reference);
   }

   private void DrawFormattedParameter(Parameter p)
   {
      DrawFormattedParameter(p, string.Empty);
   }

   private void DrawFormattedParameter(Parameter p, string nodeType)
   {
      DrawFormattedParameter(p.FriendlyName,
         uScriptConfig.Variable.FriendlyName(p.Type).Replace("UnityEngine.", string.Empty) + (p.Input && p.Output ? " (In/Out)" : p.Output ? " (out)" : string.Empty),
         uScript.FindParameterDescription(nodeType, p));
   }

   private void DrawFormattedParameter(string name, string type, string description)
   {
      GUILayout.BeginHorizontal();
      {
         // Icon
         GUILayout.Space(24);

         //
         GUILayout.BeginVertical();
         {
            // Parameter name and type
            GUILayout.Label(name + ":", uScriptGUIStyle.ReferenceName);
            GUI.Label(GUILayoutUtility.GetLastRect(), type, uScriptGUIStyle.ReferenceInfo);

            // Parameter description
            GUILayout.Label(description, uScriptGUIStyle.ReferenceDesc);
         }
         GUILayout.EndVertical();
      }
      GUILayout.EndHorizontal();
   }

   private void DrawGraphDetails()
   {
      ScriptEditorCtrl m_ScriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;

      EditorGUILayout.BeginVertical(uScriptGUIStyle.ReferenceDetailBox);
      {
         int count;
         float titleWidth = uScriptGUIStyle.ReferenceDetailTitle.CalcSize(new GUIContent("Graph contains:")).x;
         float countWidth;
         float labelWidth;

         EditorGUILayout.BeginHorizontal();
         {
            GUILayout.Label("Graph contains:", uScriptGUIStyle.ReferenceDetailTitle, GUILayout.Width(titleWidth));

            EditorGUILayout.BeginVertical();
            {
               int countMax = Math.Max(m_ScriptEditorCtrl.FlowChart.Nodes.Length, m_ScriptEditorCtrl.FlowChart.Links.Length);
               countWidth = uScriptGUIStyle.ReferenceDetailValue.CalcSize(new GUIContent(countMax.ToString())).x;
               labelWidth = uScriptGUIStyle.ReferenceDetailLabel.CalcSize(new GUIContent("nodes")).x + 12;

               EditorGUILayout.BeginHorizontal();
               {
                  count = m_ScriptEditorCtrl.FlowChart.Nodes.Length;

                  GUILayout.Label(count.ToString(), uScriptGUIStyle.ReferenceDetailValue, GUILayout.Width(countWidth));

                  GUILayout.Label((count == 1 ? "node" : "nodes"), uScriptGUIStyle.ReferenceDetailLabel, GUILayout.Width(labelWidth));

                  if (m_ScriptEditorCtrl.FlowChart.SelectedNodes.Length > 0)
                  {
                     string label = "(" + m_ScriptEditorCtrl.FlowChart.SelectedNodes.Length.ToString() + " selected)";
                     GUILayout.Label(label, uScriptGUIStyle.ReferenceDetailLabel);
                  }
               }
               EditorGUILayout.EndHorizontal();

               EditorGUILayout.BeginHorizontal();
               {
                  string value = m_ScriptEditorCtrl.FlowChart.Links.Length.ToString();
                  GUILayout.Label(value, uScriptGUIStyle.ReferenceDetailValue);

                  GUILayout.Label((count == 1 ? "link" : "links"), uScriptGUIStyle.ReferenceDetailLabel, GUILayout.Width(labelWidth));

                  if (m_ScriptEditorCtrl.FlowChart.SelectedLinks.Length > 0)
                  {
                     value = "(" + m_ScriptEditorCtrl.FlowChart.SelectedLinks.Length.ToString() + " selected)";
                     GUILayout.Label(value, uScriptGUIStyle.ReferenceDetailLabel);
                  }
               }
               EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
         }
         EditorGUILayout.EndHorizontal();

         count = m_ScriptEditorCtrl.ScriptEditor.DeprecatedNodes.Length;
         if (count > 0)
         {
            EditorGUILayout.BeginHorizontal();
            {
               EditorGUILayout.BeginHorizontal(GUILayout.Width(titleWidth));
               {
                  GUILayout.FlexibleSpace();

                  if (GUILayout.Button(uScriptGUIContent.buttonNodeFindDeprecated, uScriptGUIStyle.ReferenceButtonIcon))
                  {
                     _focusedNode = m_ScriptEditorCtrl.GetNextDeprecatedNode(_focusedNode);
                     if (_focusedNode != null)
                     {
                        m_ScriptEditorCtrl.CenterOnNode(_focusedNode);
                     }
                  }

                  if (GUILayout.Button(uScriptGUIContent.buttonNodeFixAllDeprecated, uScriptGUIStyle.ReferenceButtonText))
                  {
                     List<DisplayNode> nodes = new List<DisplayNode>();
                     foreach (Node node in m_ScriptEditorCtrl.FlowChart.Nodes)
                     {
                        nodes.Add((DisplayNode)node);
                     }
                     m_ScriptEditorCtrl.UpgradeDeprecatedNodes(nodes.ToArray());
                  }
               }
               EditorGUILayout.EndHorizontal();

               GUILayout.Label(count.ToString(), uScriptGUIStyle.ReferenceDetailAlertValue, GUILayout.Width(countWidth));
               GUILayout.Label("deprecated " + (count == 1 ? "node" : "nodes") + " must be updated or replaced.", uScriptGUIStyle.ReferenceDetailAlertLabel);
            }
            EditorGUILayout.EndHorizontal();
         }
      }
      EditorGUILayout.EndVertical();
   }

   void DrawGraphReferenceContent()
   {
      ScriptEditorCtrl m_ScriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;

      // Graph name
      string graphName = m_ScriptEditorCtrl.ScriptName;

      int index = graphName.ToLower().LastIndexOf(".uscript");
      if (index >= 0)
      {
         graphName = graphName.Remove(index);
      }

      if (string.IsNullOrEmpty(m_ScriptEditorCtrl.ScriptEditor.FriendlyName.Default) == false)
      {
         graphName = m_ScriptEditorCtrl.ScriptEditor.FriendlyName.Default + "  (" + graphName + ")";
      }

      GUILayout.Label(graphName, uScriptGUIStyle.ReferenceName);

      // General reference description
      GUILayout.Label("Select a node on the canvas to view the help text for that node.", uScriptGUIStyle.ReferenceDesc);

      DrawGraphDetails();

      if (m_ScriptEditorCtrl.SelectedNodes.Length > 1)
      {
         GUILayout.Label("Help cannot be provided when multiple nodes are selected.", uScriptGUIStyle.PanelMessage);
         return;
      }

      // Display an "Friendly Name" and "Description" parameters
      DrawFormattedParameter(m_ScriptEditorCtrl.ScriptEditor.FriendlyName);
      DrawFormattedParameter(m_ScriptEditorCtrl.ScriptEditor.Description);
   }

   void DrawNodeReferenceContent(EntityNode node)
   {
      string nodeSignature = uScript.GetNodeSignature(node);

      if (_nodeSignature != nodeSignature)
      {
         _nodeSignature = nodeSignature;

         _toolboxMenuItem = uScriptGUIPanelPalette.Instance.GetToolboxMenuItem(nodeSignature);

         _toolboxPath = (_toolboxMenuItem != null ? _toolboxMenuItem.Path : string.Empty);
         int lastSeparatorIndex = _toolboxPath.LastIndexOf('/');
         if (lastSeparatorIndex < 0)
         {
            _toolboxPath = string.Empty;
         }
         else
         {
            _toolboxPath = _toolboxPath.Substring(0, lastSeparatorIndex).Replace("/", " > ");
         }
      }

      Rect rectNameRow = EditorGUILayout.BeginHorizontal();
      {
         // Node name
         string nodeName;
         if (_toolboxMenuItem == null)
         {
            nodeName = uScript.FindNodeName(uScript.GetNodeType(node), node);
         }
         else
         {
            nodeName = _toolboxMenuItem.Name;
         }
         GUILayout.Label(nodeName, uScriptGUIStyle.ReferenceName);

         // Node breadcrumbs
         if (Event.current.type != EventType.Layout && string.IsNullOrEmpty(_toolboxPath) == false)
         {
            Vector2 sizeNameLabel = uScriptGUIStyle.ReferenceName.CalcSize(new GUIContent(nodeName));

            GUIContent toolboxPath = uScriptGUIContent.toolboxBreadcrumbs;
            toolboxPath.text = _toolboxPath;

            while (toolboxPath.text != string.Empty
               && rectNameRow.width < sizeNameLabel.x + 32 + uScriptGUIStyle.ReferenceInfo.CalcSize(toolboxPath).x)
            {
               int lastSeparatorIndex = toolboxPath.text.LastIndexOf(" > ");
               if (lastSeparatorIndex < 0)
               {
                  toolboxPath.text = string.Empty;
               }
               else
               {
                  toolboxPath.text = toolboxPath.text.Substring(0, lastSeparatorIndex + 2);
               }
            }

            if (toolboxPath.text != _toolboxPath)
            {
               toolboxPath.text += (toolboxPath.text == string.Empty ? "..." : " ...");
            }

            rectNameRow.xMin = rectNameRow.xMax - uScriptGUIStyle.ReferenceInfo.CalcSize(toolboxPath).x;

            if (GUI.Button(rectNameRow, toolboxPath, uScriptGUIStyle.ReferenceInfo))
            {
               GUI.FocusControl("PaletteFilterSearch");
               uScriptGUIPanelPalette.Instance.FilterToolboxMenuItems(nodeName, true);
            }

            EditorGUIUtility.AddCursorRect(rectNameRow, MouseCursor.Link);
         }
      }
      EditorGUILayout.EndHorizontal();

      // Node description
      string nodeType = uScript.GetNodeType(node);
      GUILayout.Label(uScript.FindNodeDescription(nodeType, node), uScriptGUIStyle.ReferenceDesc);

      // Display the dynamic parameters
      foreach (Parameter p in node.Parameters)
      {
         DrawFormattedParameter(p, nodeType);
      }

      // Display an "ShowComment" parameter if necessary
      if (node.ShowComment.Input)
      {
         DrawFormattedParameter(node.ShowComment);
      }

      // Display an "Comment" parameter if necessary
      if (node.Comment.Input)
      {
         DrawFormattedParameter(node.Comment);
      }

      // Display an "Instance" parameter if necessary
      if (node.Instance.Input)
      {
         DrawFormattedParameter(node.Instance);
      }
   }

}
