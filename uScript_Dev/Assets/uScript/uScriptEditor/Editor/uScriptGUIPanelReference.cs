// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUIPanelReference.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptGUIPanelReference type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   using System;
   using System.Globalization;
   using System.Linq;

   using Detox.FlowChart;
   using Detox.ScriptEditor;

   using UnityEditor;

   using UnityEngine;

   using ScriptEditor = Detox.ScriptEditor.ScriptEditor;

   public sealed class uScriptGUIPanelReference : uScriptGUIPanel
   {
      private static uScriptGUIPanelReference instance;

      private string currentNodeClassName = string.Empty;
      private EntityNode hotSelection;

      private Node focusedNode;

      private string nodeSignature = string.Empty;
      private uScriptGUIPanelPalette.PaletteMenuItem toolboxMenuItem;
      private string toolboxPath = string.Empty;
     
      private uScriptGUIPanelReference()
      {
         this.Init();
      }

      public static uScriptGUIPanelReference Instance
      {
         get
         {
            return instance ?? (instance = new uScriptGUIPanelReference());
         }
      }

      public EntityNode HotSelection { set { this.hotSelection = value; } }

      public void Init()
      {
         this._name = "Reference";

         //_size = 250;
         //_region = uScriptGUI.Region.Reference;
      }

      public override void Draw()
      {
         // Local references to uScript
         var uScriptInstance = uScript.Instance;
         var scriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;

         // Setup the strings for the button
         var helpButtonTooltip = string.Empty;
         var helpButtonURL = string.Empty;

         EntityNode node = null;

         // Hot node selection has priority.  If the mouse isn't hovering over a node in the Node Palette,
         // use the current node selection to determine the contents of the panel.

         // Setup the toolbar buttons
         if (this.hotSelection != null)
         {
            node = this.hotSelection;

            this.currentNodeClassName = string.Empty;
            helpButtonURL = string.Empty;
            helpButtonTooltip = string.Empty;
         }
         else
         {
            if (scriptEditorCtrl.SelectedNodes.Length != 1)
            {
               this.currentNodeClassName = string.Empty;
               helpButtonTooltip = "Open the online uScript User Guide in the default web browser.";
               helpButtonURL = "http://docs.uscript.net/";
            }
            else
            {
               node = scriptEditorCtrl.SelectedNodes[0].EntityNode;

               if (node != null)
               {
                  var newNodeClassName = ScriptEditor.FindNodeType(node);
                  this.currentNodeClassName = newNodeClassName;

                  //currentNodeClassPath = GetClassPath(newNodeClassName);

                  helpButtonTooltip = "Open the online reference for the selected node in the default web browser.";
                  helpButtonURL = uScript.FindNodeHelp(uScript.GetNodeType(node), node);
               }
            }

            helpButtonTooltip += string.Format(" ({0})", helpButtonURL);
         }

         //EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, _options);
         EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox);
         {
            //EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            {
               GUILayout.Label(this._name, uScriptGUIStyle.PanelTitle, GUILayout.ExpandWidth(true));

               //var style = new GUIStyle(UnityEngine.GUI.skin.label)
               //               {
               //                  richText = true,
               //                  normal = { textColor = Color.white }
               //               };

               //GUILayout.Label(
               //   ("HELLO: " + "bold".Bold().Color(Color.cyan) + ", " + "italic".Italic() + ", "
               //    + "bold and italic".BoldItalic()
               //    + ", <color=black>black</color>, <color=white>white</color>, <color=green>red</color>, "
               //    + "red".Red() + ", " + "green".Green() + ", <color=blue>blue</color>, " + "blue".Blue()
               //    + ", <color=#F70>uScript</color> XXX").Black(),
               //   style);

               uScriptGUI.Enabled = string.IsNullOrEmpty(this.currentNodeClassName) == false;

               if (GUILayout.Button(uScriptGUIContent.buttonNodeSource, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
               {
                  uScriptGUI.PingObject(uScript.GetClassPath(this.currentNodeClassName), typeof(TextAsset));
               }

               uScriptGUI.Enabled = string.IsNullOrEmpty(helpButtonURL) == false;

               uScriptGUIContent.buttonWebDocumentation.tooltip = helpButtonTooltip;
               if (GUILayout.Button(uScriptGUIContent.buttonWebDocumentation, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
               {
                  Help.BrowseURL(helpButtonURL);
               }

               uScriptGUI.Enabled = this.hotSelection == null;

               if (GUILayout.Button(uScriptGUIContent.buttonWebForum, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
               {
                  Help.BrowseURL("http://uscript.net/forum");
               }

               if (GUILayout.Button(uScriptGUIContent.commandReference, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
               {
                  ReferenceWindow.Init();
               }

               uScriptGUI.Enabled = true;
            }

            EditorGUILayout.EndHorizontal();

            if (uScriptInstance.wasCanvasDragged && uScript.Preferences.DrawPanelsOnUpdate == false)
            {
               this.DrawHiddenNotification();
            }
            else
            {
               // Selection description
               this._scrollviewOffset = EditorGUILayout.BeginScrollView(this._scrollviewOffset, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, "scrollview");
               {
                  if ((scriptEditorCtrl.SelectedNodes.Length == 1) && (scriptEditorCtrl.SelectedNodes[0] != null))
                  {
                     if (uScript.IsNodeTypeDeprecated(scriptEditorCtrl.SelectedNodes[0].EntityNode) || scriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(scriptEditorCtrl.SelectedNodes[0].EntityNode))
                     {
                        GUILayout.Box("SELECTED NODE IS DEPRECATED: UPDATE OR REPLACE", uScriptGUIStyle.PanelMessageError);
                     }
                  }

                  if (node == null)
                  {
                     this.DrawGraphReferenceContent();
                  }
                  else
                  {
                     this.DrawNodeReferenceContent(node);
                  }
               }

               EditorGUILayout.EndScrollView();
            }
         }

         EditorGUILayout.EndVertical();

         //uScriptGUI.DefineRegion(uScriptGUI.Region.Reference);
         uScriptInstance.SetMouseRegion(uScript.MouseRegion.Reference);
      }

      private void DrawFormattedParameter(Parameter p)
      {
         this.DrawFormattedParameter(p, string.Empty);
      }

      private void DrawFormattedParameter(Parameter p, string nodeType)
      {
         var type = string.Format(
            "{0}{1}",
            uScriptConfig.Variable.FriendlyName(p.Type).Replace("UnityEngine.", string.Empty),
            p.Input && p.Output ? " (in/out)" : p.Output ? " (out)" : string.Empty);
         this.DrawFormattedParameter(p.FriendlyName, type, uScript.FindParameterDescription(nodeType, p));
      }

      private void DrawFormattedParameter(string name, string type, string description)
      {
         GUILayout.BeginHorizontal();
         {
            // Icon
            GUILayout.Space(24);

            GUILayout.BeginVertical();
            {
               // Parameter name and type
               GUILayout.Label(string.Format("{0}:", name), uScriptGUIStyle.ReferenceName);
               UnityEngine.GUI.Label(GUILayoutUtility.GetLastRect(), type, uScriptGUIStyle.ReferenceInfo);

               // Parameter description
               GUILayout.Label(description, uScriptGUIStyle.ReferenceDesc);
            }

            GUILayout.EndVertical();
         }

         GUILayout.EndHorizontal();
      }

      private void DrawGraphDetails()
      {
         var scriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;
         var flowChart = scriptEditorCtrl.FlowChart;

         EditorGUILayout.BeginVertical(uScriptGUIStyle.ReferenceDetailBox);
         {
            int count;
            float titleWidth = uScriptGUIStyle.ReferenceDetailTitle.CalcSize(new GUIContent("Graph contains:")).x;
            float countWidth;
            GUIContent tempContent;

            EditorGUILayout.BeginHorizontal();
            {
               GUILayout.Label("Graph contains:", uScriptGUIStyle.ReferenceDetailTitle, GUILayout.Width(titleWidth));

               EditorGUILayout.BeginVertical();
               {
                  var countMax = Math.Max(flowChart.Nodes.Length, flowChart.Links.Length);
                  tempContent = uScriptGUIContent.Temp(countMax.ToString(CultureInfo.InvariantCulture));
                  countWidth = uScriptGUIStyle.ReferenceDetailValue.CalcSize(tempContent).x;

                  tempContent = uScriptGUIContent.Temp("nodes");
                  var labelWidth = uScriptGUIStyle.ReferenceDetailLabel.CalcSize(tempContent).x + 12;

                  EditorGUILayout.BeginHorizontal();
                  {
                     count = flowChart.Nodes.Length;

                     tempContent = uScriptGUIContent.Temp(count.ToString(CultureInfo.InvariantCulture));
                     GUILayout.Label(tempContent, uScriptGUIStyle.ReferenceDetailValue, GUILayout.Width(countWidth));

                     tempContent = uScriptGUIContent.Temp(count == 1 ? "node" : "nodes");
                     GUILayout.Label(tempContent, uScriptGUIStyle.ReferenceDetailLabel, GUILayout.Width(labelWidth));

                     if (flowChart.SelectedNodes.Length > 0)
                     {
                        tempContent =
                           uScriptGUIContent.Temp(string.Format("({0} selected)", flowChart.SelectedNodes.Length));
                        GUILayout.Label(tempContent, uScriptGUIStyle.ReferenceDetailLabel);
                     }
                  }

                  EditorGUILayout.EndHorizontal();

                  EditorGUILayout.BeginHorizontal();
                  {
                     tempContent = uScriptGUIContent.Temp(flowChart.Links.Length.ToString(CultureInfo.InvariantCulture));
                     GUILayout.Label(tempContent, uScriptGUIStyle.ReferenceDetailValue);

                     tempContent = uScriptGUIContent.Temp(count == 1 ? "link" : "links");
                     GUILayout.Label(tempContent, uScriptGUIStyle.ReferenceDetailLabel, GUILayout.Width(labelWidth));

                     if (flowChart.SelectedLinks.Length > 0)
                     {
                        tempContent =
                           uScriptGUIContent.Temp(string.Format("({0} selected)", flowChart.SelectedLinks.Length));
                        GUILayout.Label(tempContent, uScriptGUIStyle.ReferenceDetailLabel);
                     }
                  }

                  EditorGUILayout.EndHorizontal();
               }

               EditorGUILayout.EndVertical();
            }

            EditorGUILayout.EndHorizontal();

            count = scriptEditorCtrl.ScriptEditor.DeprecatedNodes.Length;
            if (count > 0)
            {
               EditorGUILayout.BeginHorizontal();
               {
                  EditorGUILayout.BeginHorizontal(GUILayout.Width(titleWidth));
                  {
                     GUILayout.FlexibleSpace();

                     if (GUILayout.Button(uScriptGUIContent.buttonNodeFindDeprecated, uScriptGUIStyle.ReferenceButtonIcon))
                     {
                        this.focusedNode = scriptEditorCtrl.GetNextDeprecatedNode(this.focusedNode);
                        if (this.focusedNode != null)
                        {
                           scriptEditorCtrl.CenterOnNode(this.focusedNode);
                        }
                     }

                     if (GUILayout.Button(uScriptGUIContent.buttonNodeFixAllDeprecated, uScriptGUIStyle.ReferenceButtonText))
                     {
                        scriptEditorCtrl.UpgradeDeprecatedNodes(flowChart.Nodes.Cast<DisplayNode>().ToArray());
                     }
                  }

                  EditorGUILayout.EndHorizontal();

                  tempContent = uScriptGUIContent.Temp(count.ToString(CultureInfo.InvariantCulture));
                  GUILayout.Label(tempContent, uScriptGUIStyle.ReferenceDetailAlertValue, GUILayout.Width(countWidth));

                  tempContent =
                     uScriptGUIContent.Temp(
                        string.Format("deprecated {0} must be updated or replaced.", count == 1 ? "node" : "nodes"));
                  GUILayout.Label(tempContent, uScriptGUIStyle.ReferenceDetailAlertLabel);
               }

               EditorGUILayout.EndHorizontal();
            }
         }

         EditorGUILayout.EndVertical();
      }

      private void DrawGraphReferenceContent()
      {
         var scriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;

         // Graph name
         var graphName = scriptEditorCtrl.ScriptName;

         var index = graphName.ToLower().LastIndexOf(".uscript", StringComparison.Ordinal);
         if (index >= 0)
         {
            graphName = graphName.Remove(index);
         }

         if (string.IsNullOrEmpty(scriptEditorCtrl.ScriptEditor.FriendlyName.Default) == false)
         {
            graphName = string.Format("{0} ({1})", scriptEditorCtrl.ScriptEditor.FriendlyName.Default, graphName);
         }

         GUILayout.Label(uScriptGUIContent.Temp(graphName), uScriptGUIStyle.ReferenceName);

         // General reference description
         var tempContent = uScriptGUIContent.Temp("Select a node on the canvas to view the help text for that node.");
         GUILayout.Label(tempContent, uScriptGUIStyle.ReferenceDesc);

         this.DrawGraphDetails();

         if (scriptEditorCtrl.SelectedNodes.Length > 1)
         {
            tempContent = uScriptGUIContent.Temp("Help cannot be provided when multiple nodes are selected.");
            GUILayout.Label(tempContent, uScriptGUIStyle.PanelMessage);
            return;
         }

         // Display an "Friendly Name" and "Description" parameters
         this.DrawFormattedParameter(scriptEditorCtrl.ScriptEditor.FriendlyName);
         this.DrawFormattedParameter(scriptEditorCtrl.ScriptEditor.Description);
      }

      private void DrawNodeReferenceContent(EntityNode node)
      {
         var signature = uScript.GetNodeSignature(node);

         if (this.nodeSignature != signature)
         {
            this.nodeSignature = signature;

            this.toolboxMenuItem = uScriptGUIPanelPalette.Instance.GetToolboxMenuItem(signature);

            this.toolboxPath = this.toolboxMenuItem != null ? this.toolboxMenuItem.Path : string.Empty;
            var lastSeparatorIndex = this.toolboxPath.LastIndexOf('/');
            this.toolboxPath = lastSeparatorIndex < 0
                                  ? string.Empty
                                  : this.toolboxPath.Substring(0, lastSeparatorIndex).Replace("/", " > ");
         }

         var rectNameRow = EditorGUILayout.BeginHorizontal();
         {
            // Node name
            var nodeName = this.toolboxMenuItem == null
                              ? uScript.FindNodeName(uScript.GetNodeType(node), node)
                              : this.toolboxMenuItem.Name;
            var nodeNameContent = uScriptGUIContent.Temp(nodeName);
            GUILayout.Label(nodeNameContent, uScriptGUIStyle.ReferenceName);

            // Node breadcrumbs
            if (Event.current.type != EventType.Layout && string.IsNullOrEmpty(this.toolboxPath) == false)
            {
               var sizeNameLabel = uScriptGUIStyle.ReferenceName.CalcSize(nodeNameContent);

               // TODO: Move content from uScriptGUIContent to this class
               var breadcrumbs = uScriptGUIContent.toolboxBreadcrumbs;
               breadcrumbs.text = this.toolboxPath;

               while (breadcrumbs.text != string.Empty
                      && rectNameRow.width < sizeNameLabel.x + 32 + uScriptGUIStyle.ReferenceInfo.CalcSize(breadcrumbs).x)
               {
                  var lastSeparatorIndex = breadcrumbs.text.LastIndexOf(" > ", StringComparison.Ordinal);
                  breadcrumbs.text = lastSeparatorIndex < 0
                                        ? string.Empty
                                        : breadcrumbs.text.Substring(0, lastSeparatorIndex + 2);
               }

               if (breadcrumbs.text != this.toolboxPath)
               {
                  breadcrumbs.text += breadcrumbs.text == string.Empty ? "..." : " ...";
               }

               rectNameRow.xMin = rectNameRow.xMax - uScriptGUIStyle.ReferenceInfo.CalcSize(breadcrumbs).x;

               if (UnityEngine.GUI.Button(rectNameRow, breadcrumbs, uScriptGUIStyle.ReferenceInfo))
               {
                  UnityEngine.GUI.FocusControl("PaletteFilterSearch");
                  uScriptGUIPanelPalette.Instance.FilterToolboxMenuItems(nodeNameContent.text, true);
               }

               EditorGUIUtility.AddCursorRect(rectNameRow, MouseCursor.Link);
            }
         }

         EditorGUILayout.EndHorizontal();

         // Node description
         var nodeType = uScript.GetNodeType(node);
         GUILayout.Label(uScript.FindNodeDescription(nodeType, node), uScriptGUIStyle.ReferenceDesc);

         // Display the dynamic parameters
         foreach (var p in node.Parameters)
         {
            this.DrawFormattedParameter(p, nodeType);
         }

         // Display a "ShowComment" parameter if necessary
         if (node.ShowComment.Input)
         {
            this.DrawFormattedParameter(node.ShowComment);
         }

         // Display a "Comment" parameter if necessary
         if (node.Comment.Input)
         {
            this.DrawFormattedParameter(node.Comment);
         }

         // Display an "Instance" parameter if necessary
         if (node.Instance.Input)
         {
            this.DrawFormattedParameter(node.Instance);
         }
      }
   }
}
