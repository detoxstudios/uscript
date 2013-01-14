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

      string nodeType = string.Empty;

      EntityNode node = null;


      // Hot node selection has priority.  If the mouse isn't hovering over a node in the Node Palette,
      // use the current node selection to determine the contents of the panel.

      // Setup the toolbar buttons
      if (_hotSelection != null)
      {
         node = _hotSelection;
         nodeType = GetNodeType(node);

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
               nodeType = GetNodeType(node);

               string newNodeClassName = ScriptEditor.FindNodeType(node);
               if (newNodeClassName != currentNodeClassName)
               {
                  currentNodeClassName = newNodeClassName;
//                  currentNodeClassPath = GetClassPath(newNodeClassName);
               }

               helpButtonTooltip = "Open the online reference for the selected node in the default web browser.";
               helpButtonURL = uScript.FindNodeHelp(GetNodeType(node), node);
            }
         }

         helpButtonTooltip += " (" + helpButtonURL + ")";
      }

//      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, _options);
      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox);
      {
         // Toolbar
         //
//         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label(_name, uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));

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

            if (GUILayout.Button("?", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
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
//            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview", GUILayout.ExpandWidth(true));
            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
            {
               if ((m_ScriptEditorCtrl.SelectedNodes.Length == 1) && (m_ScriptEditorCtrl.SelectedNodes[0] != null))
               {
                  if (uScript.IsNodeTypeDeprecated(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode) || m_ScriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode))
                  {
                     GUILayout.Box("SELECTED NODE IS DEPRECATED: UPDATE OR REPLACE", uScriptGUIStyle.panelMessageError);
                  }
               }

               if (node == null)
               {
                  DrawGraphReferenceContent();
               }
               else
               {
                  DrawNodeReferenceContent(node, nodeType, _hotSelection != null);
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
            GUILayout.Label(name + ":", uScriptGUIStyle.referenceName);
            GUI.Label(GUILayoutUtility.GetLastRect(), type, uScriptGUIStyle.referenceInfo);

            // Parameter description
            GUILayout.Label(description, uScriptGUIStyle.referenceDesc);
         }
         GUILayout.EndVertical();
      }
      GUILayout.EndHorizontal();
   }

   private void DrawGraphDetails()
   {
      ScriptEditorCtrl m_ScriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;

      EditorGUILayout.BeginVertical(uScriptGUIStyle.referenceDetailBox);
      {
         EditorGUILayout.BeginHorizontal();
         {
            GUILayout.Label("Graph contains:", uScriptGUIStyle.referenceDetailTitle);

            EditorGUILayout.BeginVertical();
            {
               int count;
               int countMax = Math.Max(m_ScriptEditorCtrl.FlowChart.Nodes.Length, m_ScriptEditorCtrl.FlowChart.Links.Length);
               float countWidth = uScriptGUIStyle.referenceDetailValue.CalcSize(new GUIContent(countMax.ToString())).x;
               float labelWidth = uScriptGUIStyle.referenceDetailLabel.CalcSize(new GUIContent("nodes")).x + 12;

               EditorGUILayout.BeginHorizontal();
               {
                  if (m_ScriptEditorCtrl.ScriptEditor.DeprecatedNodes.Length > 0)
                  {
                     count = m_ScriptEditorCtrl.ScriptEditor.DeprecatedNodes.Length;

                     GUILayout.Label(count.ToString(), uScriptGUIStyle.referenceDetailAlertValue, GUILayout.Width(countWidth));
                     GUILayout.Label("deprecated " + (count == 1 ? "node" : "nodes") + ", which should be updated or replaced.", uScriptGUIStyle.referenceDetailAlertLabel);

                     if (GUILayout.Button(uScriptGUIContent.buttonNodeFindDeprecated, uScriptGUIStyle.referenceButtonIcon))
                     {
                        _focusedNode = m_ScriptEditorCtrl.GetNextDeprecatedNode(_focusedNode);
                        if (_focusedNode != null)
                        {
                           m_ScriptEditorCtrl.CenterOnNode(_focusedNode);
                        }
                     }

                     if (GUILayout.Button(" Fix All ", uScriptGUIStyle.referenceButtonText))
                     {
                        List<DisplayNode> nodes = new List<DisplayNode>();
                        foreach (Node node in m_ScriptEditorCtrl.FlowChart.Nodes)
                        {
                           nodes.Add((DisplayNode)node);
                        }
                        m_ScriptEditorCtrl.UpgradeDeprecatedNodes(nodes.ToArray());
                     }

                     GUILayout.FlexibleSpace();
                  }
               }
               EditorGUILayout.EndHorizontal();

               EditorGUILayout.BeginHorizontal();
               {
                  count = m_ScriptEditorCtrl.FlowChart.Nodes.Length;

                  GUILayout.Label(count.ToString(), uScriptGUIStyle.referenceDetailValue);

                  GUILayout.Label((count == 1 ? "node" : "nodes"), uScriptGUIStyle.referenceDetailLabel, GUILayout.Width(labelWidth));

                  if (m_ScriptEditorCtrl.FlowChart.SelectedNodes.Length > 0)
                  {
                     string label = "(" + m_ScriptEditorCtrl.FlowChart.SelectedNodes.Length.ToString() + " selected)";
                     GUILayout.Label(label, uScriptGUIStyle.referenceDetailLabel);
                  }
               }
               EditorGUILayout.EndHorizontal();

               EditorGUILayout.BeginHorizontal();
               {
                  string value = m_ScriptEditorCtrl.FlowChart.Links.Length.ToString();
                  GUILayout.Label(value, uScriptGUIStyle.referenceDetailValue);

                  GUILayout.Label((count == 1 ? "link" : "links"), uScriptGUIStyle.referenceDetailLabel, GUILayout.Width(labelWidth));

                  if (m_ScriptEditorCtrl.FlowChart.SelectedLinks.Length > 0)
                  {
                     value = "(" + m_ScriptEditorCtrl.FlowChart.SelectedLinks.Length.ToString() + " selected)";
                     GUILayout.Label(value, uScriptGUIStyle.referenceDetailLabel);
                  }
               }
               EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();
         }
         EditorGUILayout.EndHorizontal();
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

      GUILayout.Label(graphName, uScriptGUIStyle.referenceName);

      // General reference description
      GUILayout.Label("Select a node on the canvas to view the help text for that node.", uScriptGUIStyle.referenceDesc);

      DrawGraphDetails();

      if (m_ScriptEditorCtrl.SelectedNodes.Length > 1)
      {
         GUILayout.Label("Help cannot be provided when multiple nodes are selected.", uScriptGUIStyle.panelMessage);
         return;
      }

      // Display an "Friendly Name" and "Description" parameters
      DrawFormattedParameter(m_ScriptEditorCtrl.ScriptEditor.FriendlyName);
      DrawFormattedParameter(m_ScriptEditorCtrl.ScriptEditor.Description);
   }

   void DrawNodeReferenceContent(EntityNode node, string nodeType, bool isHotSelection)
   {
      // For now, display the following text if this is a hot selection
      if (isHotSelection)
      {
         GUILayout.Label("HOT TIP:", EditorStyles.boldLabel);
      }

      // Node name
      string nodeName = uScript.FindNodeName(nodeType, node);
      GUILayout.Label(nodeName, uScriptGUIStyle.referenceName);
      
      // Identify reflected nodes
      if (nodeName.StartsWith("Reflected "))
      {
         nodeType = "_reflected" + (nodeName.EndsWith(" action") ? "Action" : "Property");
      }

//      // Node palette location
//      r = GUILayoutUtility.GetLastRect();
//      GUI.Label(r, "PATH", uScriptGUIStyle.referenceInfo);

      // GUI.skin.customStyles:
      //    "GUIEditor.BreadcrumbLeft"
      //    "GUIEditor.BreadcrumbMid"

//   328: "RL DragHandle"


      // Node description
      GUILayout.Label(uScript.FindNodeDescription(nodeType, node), uScriptGUIStyle.referenceDesc);

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

   string GetNodeType(EntityNode node)
   {
      string nodeType = ScriptEditor.FindNodeType(node);
      if (string.IsNullOrEmpty(nodeType))
      {
         // other node types...
         if (node is CommentNode)
         {
            nodeType = "CommentNode";
         }
         else if (node is ExternalConnection)
         {
            nodeType = "ExternalConnection";
         }
         else if (node is OwnerConnection)
         {
            nodeType = "OwnerConnection";
         }
         else if (node is LocalNode)
         {
            nodeType = "LocalNode";
         }
      }
      return nodeType;
   }
}
