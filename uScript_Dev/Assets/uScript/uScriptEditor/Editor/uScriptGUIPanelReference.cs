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

      private EntityNode hotSelection;

      private Node deprecatedNode;

      private string nodeSignature;
      private uScriptGUIPanelToolbox.PaletteMenuItem toolboxMenuItem;
      private string toolboxPath;

      private string selectedNodeClassName;
      private string toolbarButtonHelpTooltip;
      private string toolbarButtonHelpURL;

      private int detailsMaxValue = int.MinValue;

      private uScriptGUIPanelReference()
      {
         InUScriptPanel = true;
         this.Init();
      }

      private delegate void ToolbarCommand();

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
         this.Name = "Reference";

         //_size = 250;
         //_region = uScriptGUI.Region.Reference;
      }

      public override void Draw()
      {
         var uScriptInstance = uScript.Instance;
         var scriptEditor = uScriptInstance.ScriptEditorCtrl.ScriptEditor;

         EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox);
         {
            var node = this.GetSelectedNodeAndUpdateInformation();

            this.DrawToolbar();

            if (uScriptInstance.wasCanvasDragged && Preferences.DrawPanelsOnUpdate == false)
            {
               this.DrawHiddenNotification();
            }
            else
            {
               this.ScrollviewOffset = EditorGUILayout.BeginScrollView(
                  this.ScrollviewOffset,
                  false,
                  false,
                  uScriptGUIStyle.HorizontalScrollbar,
                  uScriptGUIStyle.VerticalScrollbar,
                  "scrollview");
               {
                  if (node == null)
                  {
                     this.DrawGraphInformation();
                  }
                  else
                  {
                     if (uScript.IsNodeTypeDeprecated(node) || scriptEditor.IsNodeInstanceDeprecated(node))
                     {
                        GUILayout.Box("SELECTED NODE IS DEPRECATED: UPDATE OR REPLACE", Style.DeprecatedNodeMessage);
                     }

                     this.DrawNodeInformation(node);
                  }
               }
               EditorGUILayout.EndScrollView();
            }
         }
         EditorGUILayout.EndVertical();

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
            // Icon will go here, if needed in the future
            GUILayout.Space(24);

            GUILayout.BeginVertical();
            {
               // Parameter name and type
               GUILayout.Label(string.Format("{0}:", name), Style.ReferenceName);
               UnityEngine.GUI.Label(GUILayoutUtility.GetLastRect(), type, Style.ReferenceInfo);

               // Parameter description
               GUILayout.Label(description, Style.ReferenceDesc);
            }
            GUILayout.EndVertical();
         }
         GUILayout.EndHorizontal();
      }

      private void DrawGraphDetailItem(string label, int total, int selected)
      {
         EditorGUILayout.BeginHorizontal();
         {
            GUILayout.Label(uScriptGUIContent.Temp(total.ToString(CultureInfo.InvariantCulture)), Style.DetailValue);
            GUILayout.Label(uScriptGUIContent.Temp(total == 1 ? label : label + "s"), Style.DetailLabel);
            if (selected > 0)
            {
               GUILayout.Label(uScriptGUIContent.Temp(string.Format("({0} selected)", selected)), Style.DetailSelected);
            }
         }
         EditorGUILayout.EndHorizontal();
      }

      private void DrawGraphDetailItemDeprecated()
      {
         var scriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;
         var flowChart = scriptEditorCtrl.FlowChart;

         var count = scriptEditorCtrl.ScriptEditor.DeprecatedNodes.Length;
         if (count <= 0)
         {
            return;
         }

         EditorGUILayout.BeginHorizontal();
         {
            var tempContent = uScriptGUIContent.Temp(count.ToString(CultureInfo.InvariantCulture));
            GUILayout.Label(tempContent, Style.DetailAlertValue);

            var message = string.Format("deprecated {0} must be updated or replaced.", count == 1 ? "node" : "nodes");
            tempContent = uScriptGUIContent.Temp(message);
            GUILayout.Label(tempContent, Style.DetailAlertLabel);
         }
         EditorGUILayout.EndHorizontal();

         EditorGUILayout.BeginHorizontal();
         {
            GUILayout.Space(24 + Style.DetailAlertValue.fixedWidth);

            if (GUILayout.Button(Content.ButtonFindDeprecated, Style.ButtonFindDeprecated))
            {
               this.deprecatedNode = scriptEditorCtrl.GetNextDeprecatedNode(this.deprecatedNode);
               if (this.deprecatedNode != null)
               {
                  scriptEditorCtrl.CenterOnNode(this.deprecatedNode);
               }
            }

            if (GUILayout.Button(Content.ButtonFixAllDeprecated, Style.ButtonFixAllDeprecated))
            {
               scriptEditorCtrl.UpgradeDeprecatedNodes(flowChart.Nodes.Cast<DisplayNode>().ToArray());
            }
         }
         EditorGUILayout.EndHorizontal();

         GUILayout.Space(4);
      }

      private void DrawGraphDetails()
      {
         this.UpdateLayout();

         EditorGUILayout.BeginVertical(Style.DetailBox);
         {
            GUILayout.Label(Content.DetailTitle, Style.DetailTitle);

            var flowChart = uScript.Instance.ScriptEditorCtrl.FlowChart;
            this.DrawGraphDetailItem("node", flowChart.Nodes.Length, flowChart.SelectedNodes.Length);
            this.DrawGraphDetailItem("link", flowChart.Links.Length, flowChart.SelectedLinks.Length);

            this.DrawGraphDetailItemDeprecated();
         }
         EditorGUILayout.EndVertical();
      }

      private void DrawGraphInformation()
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

         GUILayout.Label(uScriptGUIContent.Temp(graphName), Style.ReferenceName);

         // General reference description
         GUILayout.Label(Content.ReferenceDesc, Style.ReferenceDesc);

         this.DrawGraphDetails();

         if (scriptEditorCtrl.SelectedNodes.Length > 1)
         {
            GUILayout.Label(Content.PanelMessage, uScriptGUIStyle.PanelMessage);
            return;
         }

         // Display "Friendly Name" and "Description" parameters
         this.DrawFormattedParameter(scriptEditorCtrl.ScriptEditor.FriendlyName);
         this.DrawFormattedParameter(scriptEditorCtrl.ScriptEditor.Description);
      }

      private void DrawNodeInformation(EntityNode node)
      {
         var signature = uScript.GetNodeSignature(node);

         if (this.nodeSignature != signature)
         {
            this.nodeSignature = signature;

            this.toolboxMenuItem = uScriptGUIPanelToolbox.Instance.GetToolboxMenuItem(signature);

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
            GUILayout.Label(nodeNameContent, Style.ReferenceName);

            // Node breadcrumbs
            if (Event.current.type != EventType.Layout && string.IsNullOrEmpty(this.toolboxPath) == false)
            {
               var sizeNameLabel = Style.ReferenceName.CalcSize(nodeNameContent);

               var breadcrumbs = Content.ToolboxBreadcrumbs;
               breadcrumbs.text = this.toolboxPath;

               while (breadcrumbs.text != string.Empty
                      && rectNameRow.width < sizeNameLabel.x + 32 + Style.ReferenceInfo.CalcSize(breadcrumbs).x)
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

               rectNameRow.xMin = rectNameRow.xMax - Style.ReferenceInfo.CalcSize(breadcrumbs).x;

               if (UnityEngine.GUI.Button(rectNameRow, breadcrumbs, Style.ReferenceInfo))
               {
                  UnityEngine.GUI.FocusControl("PaletteFilterSearch");
                  uScriptGUIPanelToolbox.Instance.FilterToolboxMenuItems(nodeNameContent.text, true);
               }

               EditorGUIUtility.AddCursorRect(rectNameRow, MouseCursor.Link);
            }
         }
         EditorGUILayout.EndHorizontal();

         // Node description
         var nodeType = uScript.GetNodeType(node);
         GUILayout.Label(uScript.FindNodeDescription(nodeType, node), Style.ReferenceDesc);

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

      private void DrawToolbar()
      {
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label(this.Name, uScriptGUIStyle.PanelTitle, GUILayout.ExpandWidth(true));

            Content.ButtonHelp.tooltip = this.toolbarButtonHelpTooltip;

            DrawToolbarButton(Content.ButtonSource, this.PingSource, string.IsNullOrEmpty(this.selectedNodeClassName));
            DrawToolbarButton(Content.ButtonHelp, this.OpenWebHelp, string.IsNullOrEmpty(this.toolbarButtonHelpURL));
            DrawToolbarButton(Content.ButtonForum, this.OpenWebForum, this.hotSelection != null);
            DrawToolbarButton(Content.ButtonKeyboard, this.OpenReferenceWindow);

            if (InUScriptPanel)
            {
               if (GUILayout.Button(Content.ButtonPopout, EditorStyles.toolbarButton, GUILayout.Width(EditorStyles.toolbarButton.CalcSize(Content.ButtonPopout).x)))
               {
                  if (uScript.GetUScriptGUIPanelWindow<uScriptGUIPanelProperty>() == null) uScript.OpenPopOutWindow(this);
                  uScript.Instance.CommandCanvasShowReferencePanel();
               }
               if (GUILayout.Button(Content.ButtonClose, EditorStyles.toolbarButton, GUILayout.Width(EditorStyles.toolbarButton.CalcSize(Content.ButtonClose).x)))
               {
                  uScript.Instance.CommandCanvasShowReferencePanel();
               }
            }
         }
         EditorGUILayout.EndHorizontal();
      }

      private void DrawToolbarButton(GUIContent content, ToolbarCommand command)
      {
         DrawToolbarButton(content, command, false);
      }

      private void DrawToolbarButton(GUIContent content, ToolbarCommand command, bool isDisabled)
      {
         EditorGUI.BeginDisabledGroup(isDisabled);
         if (GUILayout.Button(content, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
         {
            command();
         }
         EditorGUI.EndDisabledGroup();
      }

      private EntityNode GetSelectedNodeAndUpdateInformation()
      {
         this.ResetInformation();

         // The soft-selected node will be returned, if there is one.
         var node = this.hotSelection;
         if (node == null)
         {
            var selectedNodes = uScript.Instance.ScriptEditorCtrl.SelectedNodes;
            if (selectedNodes.Length != 1)
            {
               this.UpdateInformationForGraph();
            }
            else
            {
               // Since there is only one selected node, return it.
               node = selectedNodes[0].EntityNode;
               this.UpdateInformationForNode(node);
            }
         }

         return node;
      }

      private void OpenReferenceWindow()
      {
         ReferenceWindow.Init();
      }

      private void OpenWebForum()
      {
         Help.BrowseURL("http://uscript.net/forum");
      }

      private void OpenWebHelp()
      {
         Help.BrowseURL(this.toolbarButtonHelpURL);
      }

      private void PingSource()
      {
         uScriptGUI.PingObject(uScript.GetRelativePathToNodeSource(this.selectedNodeClassName), typeof(TextAsset));
      }

      private void ResetInformation()
      {
         this.selectedNodeClassName = string.Empty;
         this.toolbarButtonHelpTooltip = string.Empty;
         this.toolbarButtonHelpURL = string.Empty;
      }

      private void UpdateInformationForGraph()
      {
         this.toolbarButtonHelpURL = "http://docs.uscript.net/";
         this.toolbarButtonHelpTooltip = string.Format(
            "{0}\n\n({1})",
            "Open the online uScript User Guide in the default web browser.",
            this.toolbarButtonHelpURL);
      }

      private void UpdateInformationForNode(EntityNode node)
      {
         if (node == null)
         {
            return;
         }

         this.selectedNodeClassName = ScriptEditor.FindNodeType(node);
         this.toolbarButtonHelpURL = uScript.FindNodeHelp(uScript.GetNodeType(node), node);
         this.toolbarButtonHelpTooltip = string.Format(
            "{0}\n\n({1})",
            "Open the online reference for the selected node in the default web browser.",
            this.toolbarButtonHelpURL);
      }

      private void UpdateLayout()
      {
         if (Style.DetailValue.fixedWidth < 1)
         {
            // Execute once, before the width of the value has been calculated
            Style.DetailLabel.fixedWidth = Style.DetailLabel.CalcSize(uScriptGUIContent.Temp("nodes")).x;
         }

         var maxValue = Math.Max(
            uScript.Instance.ScriptEditorCtrl.FlowChart.Nodes.Length,
            uScript.Instance.ScriptEditorCtrl.FlowChart.Links.Length);

         if (this.detailsMaxValue != maxValue)
         {
            this.detailsMaxValue = maxValue;

            // Reset the fixedWidth so CalcSize will determine the new size
            Style.DetailAlertValue.fixedWidth = 0;
            Style.DetailAlertValue.fixedWidth =
               Style.DetailAlertValue.CalcSize(uScriptGUIContent.Temp(maxValue.ToString(CultureInfo.InvariantCulture))).x;
            Style.DetailValue.fixedWidth = Style.DetailAlertValue.fixedWidth;
         }
      }

      private static class Content
      {
         static Content()
         {
            ButtonFindDeprecated = new GUIContent
            {
               image = uScriptGUI.GetSkinnedTexture("iconMiniSearch"),
               tooltip = "Center the canvas on the next deprecated node."
            };

            ButtonFixAllDeprecated = new GUIContent("Fix All", "Upgrade all deprecated nodes in this graph. If this graph is assigned to a specific Unity scene, please be sure that scene is open before doing this or you could loose work!");

            ButtonForum = new GUIContent("Forum", "Open the online forum in the default web browser.");
            
            ButtonHelp = new GUIContent("Online Reference", "Open the online uScript reference in the default web browser.");
            
            ButtonKeyboard = new GUIContent
            {
               image = uScriptGUI.GetSkinnedTexture("iconKeyboard"),
               tooltip = "Open the Quick Command Reference window."
            };

            ButtonPopout = new GUIContent
            {
               image = uScriptGUI.GetSkinnedTexture("iconPopout"),
               tooltip = "Open a standalone window with this panel's contents within it."
            };

            ButtonClose = new GUIContent
            {
               image = uScriptGUI.GetSkinnedTexture("iconMiniDelete"),
               tooltip = "Close this panel."
            };

            ButtonSource = new GUIContent("Source", "Ping the source file associated with this node.");
            
            DetailTitle = new GUIContent("Graph contains:");
            
            PanelMessage = new GUIContent("Help cannot be provided when multiple nodes are selected.");
            
            ReferenceDesc = new GUIContent("Select a node on the canvas to view the help text for that node.");
            
            ToolboxBreadcrumbs = new GUIContent
            {
               image = uScriptGUI.GetSkinnedTexture("iconSearch"),
               tooltip = "Search for this node in the Toolbox."
            };
         }

         public static GUIContent ButtonFindDeprecated { get; private set; }

         public static GUIContent ButtonFixAllDeprecated { get; private set; }

         public static GUIContent ButtonForum { get; private set; }

         public static GUIContent ButtonHelp { get; private set; }

         public static GUIContent ButtonKeyboard { get; private set; }

         public static GUIContent ButtonPopout { get; private set; }

         public static GUIContent ButtonClose { get; private set; }

         public static GUIContent ButtonSource { get; private set; }

         public static GUIContent DetailTitle { get; private set; }

         public static GUIContent PanelMessage { get; private set; }

         public static GUIContent ReferenceDesc { get; private set; }

         public static GUIContent ToolboxBreadcrumbs { get; private set; }
      }

      private static class Style
      {
         static Style()
         {
            ButtonFindDeprecated = new GUIStyle(UnityEngine.GUI.skin.button)
            {
               alignment = TextAnchor.MiddleCenter,
               imagePosition = ImagePosition.ImageOnly,
               padding = new RectOffset(),
               margin = new RectOffset(4, 4, 4, 4),
               fixedHeight = 20,
               fixedWidth = 24
            };

            ButtonFixAllDeprecated = new GUIStyle(UnityEngine.GUI.skin.button)
            {
               alignment = TextAnchor.MiddleCenter,
               padding = new RectOffset(8, 8, 2, 4),
               margin = new RectOffset(4, 4, 4, 4),
               fontSize = 11,
               fixedHeight = 20,
               stretchWidth = false
            };

            DeprecatedNodeMessage = new GUIStyle(UnityEngine.GUI.skin.box)
            {
               normal = { textColor = EditorStyles.boldLabel.normal.textColor },
               font = EditorStyles.boldLabel.font,
               wordWrap = true,
               stretchWidth = true
            };

            DetailTitle = new GUIStyle(EditorStyles.boldLabel)
            {
               normal = { background = uScriptGUI.GetSkinnedTexture("Underline") },
               border = new RectOffset(0, 0, 0, 2),
               padding = new RectOffset(0, 0, 0, 2),
               margin = new RectOffset(0, 0, 0, 4)
            };

            DetailLabel = new GUIStyle(EditorStyles.label)
            {
               margin = new RectOffset(),
               padding = new RectOffset(2, 2, 2, 2),
               stretchWidth = false
            };

            DetailSelected = new GUIStyle(DetailLabel);

            DetailValue = new GUIStyle(DetailLabel)
            {
               margin = new RectOffset(24, 0, 0, 0),
               alignment = TextAnchor.UpperRight,
            };

            DetailBox = new GUIStyle(UnityEngine.GUI.skin.box)
            {
               margin = new RectOffset(24, 24, 16, 16),
               padding = new RectOffset(4, 4, 4, 4)
            };

            DetailAlertLabel = new GUIStyle(EditorStyles.boldLabel)
            {
               margin = new RectOffset(),
               padding = new RectOffset(2, 2, 8, 2),
               normal = { textColor = Color.red },
               wordWrap = true
            };

            DetailAlertValue = new GUIStyle(DetailAlertLabel)
            {
               alignment = TextAnchor.UpperRight,
               margin = new RectOffset(24, 0, 0, 0),
               stretchWidth = false,
               wordWrap = false
            };

            ReferenceName = new GUIStyle(EditorStyles.boldLabel)
            {
               normal = { background = uScriptGUI.GetSkinnedTexture("Underline") },
               border = new RectOffset(0, 0, 0, 2),
               padding = new RectOffset(0, 0, 2, 2)
            };

            ReferenceInfo = new GUIStyle(EditorStyles.miniLabel)
            {
               alignment = TextAnchor.LowerRight,
               padding = new RectOffset(0, 0, 3, 2)
            };

            ReferenceDesc = new GUIStyle(EditorStyles.label)
            {
               padding = new RectOffset(0, 0, 0, 3),
               stretchHeight = false,
               stretchWidth = true,
               wordWrap = true
            };

            uScriptDebug.Assert(
               DetailLabel.fixedWidth < 1 && DetailValue.fixedWidth < 1 && DetailAlertValue.fixedWidth < 1,
               "Certain styles have dynamic fixedWidths, and should not be set during initialization.",
               uScriptDebug.Type.Warning);
         }

         public static GUIStyle ButtonFindDeprecated { get; private set; }

         public static GUIStyle ButtonFixAllDeprecated { get; private set; }

         public static GUIStyle DeprecatedNodeMessage { get; private set; }

         public static GUIStyle DetailAlertLabel { get; private set; }

         public static GUIStyle DetailAlertValue { get; private set; }

         public static GUIStyle DetailBox { get; private set; }

         public static GUIStyle DetailLabel { get; private set; }

         public static GUIStyle DetailSelected { get; private set; }

         public static GUIStyle DetailTitle { get; private set; }

         public static GUIStyle DetailValue { get; private set; }

         public static GUIStyle ReferenceInfo { get; private set; }

         public static GUIStyle ReferenceName { get; private set; }

         public static GUIStyle ReferenceDesc { get; private set; }
      }
   }
}
