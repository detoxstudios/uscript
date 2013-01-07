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
   private uScriptGUIPanelReference() { Init(); }


   //
   // Members specific to this panel class
   //
   private string currentNodeClassName = string.Empty;

   private EntityNode _hotSelection = null;
   public EntityNode hotSelection { set { _hotSelection = value; } }


   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      _name = "Reference";
//      _size = 250;
//      _region = uScriptGUI.Region.Reference;
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





      // Setup the strings for the button
      string helpButtonTooltip   = string.Empty;
      string helpButtonURL       = string.Empty;

      string nodeType            = string.Empty;

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
            helpButtonTooltip   = "Open the online uScript reference in the default web browser.";
            helpButtonURL       = "http://www.uscript.net/docs/";
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
            if ( GUILayout.Button( uScriptGUIContent.buttonWebDocumentation, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
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
                  GUILayout.Label( (m_ScriptEditorCtrl.SelectedNodes.Length == 0
                                    ? "Select a node on the canvas to view the help text for that node.\n\nFriendly Name: Use this graph property to give this graph a name that will be used when shown as a nested node in other uScript graphs.\n\nDescription: Use this graph property to give this graph description help text when selected as a nested node in other uScript graphs (shown here in the Reference panel)."
                                    : "Help cannot be provided when multiple nodes are selected."
                                    ), uScriptGUIStyle.panelMessage);
               }
               else
               {
                  DrawReferenceContent(node, nodeType, _hotSelection != null);
               }
            }
            EditorGUILayout.EndScrollView();
         }
      }
      EditorGUILayout.EndVertical();

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Reference);
      uScriptInstance.SetMouseRegion( uScript.MouseRegion.Reference );
   }




   //
   //
   //
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


   //
   // Draws all the GUI controls necessary to display the reference information
   //
   void DrawReferenceContent(EntityNode node, string nodeType, bool isHotSelection)
   {
      // Expected array format 3+(3*n) in length:
      //
      //    Name           // "Node Name"
      //    Desc           // "This is the node description."
      //    Path           // "Actions > Assets"
      //
      //    [0] ParamName  // "Parameter Name"
      //        ParamDesc  // "This is the parameter description."
      //        ParamType  // "String (out)"
      //
      //    [1] Param...

//      string[] data = Parameter.StringToArray(uScript.FindNodeReferenceData(nodeType, node));
//
//      if (data.Length == 0 || data.Length % 3 != 0)
//      {
//         Debug.LogError("The node reference data length is invalid: " + data.Length + "\n");
//         return;
//      }


      // For now, display the following text if this is a hot selection
      if (isHotSelection)
      {
         GUILayout.Label("HOT TIP:", EditorStyles.boldLabel);
      }

      Rect r;

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

      // Node description
      GUILayout.Label(uScript.FindNodeDescription(nodeType, node), uScriptGUIStyle.referenceDesc);

      // Display the dynamic parameters
      foreach (Parameter p in node.Parameters)
      {
         // Parameter block
         GUILayout.BeginHorizontal();
         {
            // Icon
            GUILayout.Space(24);

            //
            GUILayout.BeginVertical();
            {
               // Parameter name and type
               GUILayout.Label(p.FriendlyName + ":", uScriptGUIStyle.referenceName);
               r = GUILayoutUtility.GetLastRect();
               GUI.Label(r, uScriptConfig.Variable.FriendlyName(p.Type).Replace("UnityEngine.", string.Empty) + (p.Input && p.Output ? " (In/Out)" : p.Output  ? " (out)" : string.Empty), uScriptGUIStyle.referenceInfo);

               // Parameter description
               GUILayout.Label(uScript.FindParameterDescription(nodeType, p), uScriptGUIStyle.referenceDesc);
            }
            GUILayout.EndVertical();
         }
         GUILayout.EndHorizontal();
      }

      // Display an "ShowComment" parameter if necessary
      if (node.ShowComment.Input)
      {
         // Parameter block
         GUILayout.BeginHorizontal();
         {
            // Icon
            GUILayout.Space(24);

            //
            GUILayout.BeginVertical();
            {
               // Parameter name and type
               GUILayout.Label(node.ShowComment.FriendlyName + ":", uScriptGUIStyle.referenceName);
               r = GUILayoutUtility.GetLastRect();
               GUI.Label(r, uScriptConfig.Variable.FriendlyName(node.ShowComment.Type).Replace("UnityEngine.", string.Empty), uScriptGUIStyle.referenceInfo);

               // Parameter description
               GUILayout.Label(uScript.FindParameterDescription(string.Empty, node.ShowComment), uScriptGUIStyle.referenceDesc);
            }
            GUILayout.EndVertical();
         }
         GUILayout.EndHorizontal();
      }

      // Display an "Comment" parameter if necessary
      if (node.Comment.Input)
      {
         // Parameter block
         GUILayout.BeginHorizontal();
         {
            // Icon
            GUILayout.Space(24);

            //
            GUILayout.BeginVertical();
            {
               // Parameter name and type
               GUILayout.Label(node.Comment.FriendlyName + ":", uScriptGUIStyle.referenceName);
               r = GUILayoutUtility.GetLastRect();
               GUI.Label(r, uScriptConfig.Variable.FriendlyName(node.Comment.Type).Replace("UnityEngine.", string.Empty), uScriptGUIStyle.referenceInfo);

               // Parameter description
               GUILayout.Label(uScript.FindParameterDescription(string.Empty, node.Comment), uScriptGUIStyle.referenceDesc);
            }
            GUILayout.EndVertical();
         }
         GUILayout.EndHorizontal();
      }

      // Display an "Instance" parameter if necessary
      if (node.Instance.Input)
      {
         // Parameter block
         GUILayout.BeginHorizontal();
         {
            // Icon
            GUILayout.Space(24);

            //
            GUILayout.BeginVertical();
            {
               // Parameter name and type
               GUILayout.Label(node.Instance.FriendlyName + ":", uScriptGUIStyle.referenceName);
               r = GUILayoutUtility.GetLastRect();
               GUI.Label(r, uScriptConfig.Variable.FriendlyName(node.Instance.Type).Replace("UnityEngine.", string.Empty), uScriptGUIStyle.referenceInfo);

               // Parameter description
               GUILayout.Label(uScript.FindParameterDescription(string.Empty, node.Instance), uScriptGUIStyle.referenceDesc);
            }
            GUILayout.EndVertical();
         }
         GUILayout.EndHorizontal();
      }


//      uScriptGUI.HR();
//
//      int dataIndex = 0;
//
//      // Node name and palette location
//      GUILayout.Label(data[dataIndex++], uScriptGUIStyle.referenceName);
//      r = GUILayoutUtility.GetLastRect();
//      GUI.Label(r, data[dataIndex++], uScriptGUIStyle.referenceInfo);
//
//      // Node description
//      GUILayout.Label(data[dataIndex++], uScriptGUIStyle.referenceDesc);
//
//      while (dataIndex < data.Length)
//      {
//         // Parameter block
//         GUILayout.BeginHorizontal();
//         {
//            // Icon
//            GUILayout.Space(24);
//
//            //
//            GUILayout.BeginVertical();
//            {
//               // Parameter name and type
//               GUILayout.Label(data[dataIndex++] + ":", uScriptGUIStyle.referenceName);
//               r = GUILayoutUtility.GetLastRect();
//               GUI.Label(r, data[dataIndex++], uScriptGUIStyle.referenceInfo);
//
//               // Parameter description
//               GUILayout.Label(data[dataIndex++], uScriptGUIStyle.referenceDesc);
//            }
//            GUILayout.EndVertical();
//         }
//         GUILayout.EndHorizontal();
//      }
//
//
//      uScriptGUI.HR();
//
//
//      // For now, display the original description text
//      GUILayout.Label(uScript.FindNodeDescription(nodeType, node), uScriptGUIStyle.referenceText);
   }




/*
   private void Old_Draw()
   {
//      if (data == null)
//      {
//         UnityEngine.Debug.LogWarning("ReferencePanel() received null data.\n");
//      }
//      else if (Type != uScriptGUI.PanelType.Reference)
//      {
//         UnityEngine.Debug.LogWarning("ReferencePanel() received bad data: " + Type + "\n");
//      }


      // Panel background
      GUI.BeginGroup(PanelPosition, uScriptGUIStyle.panelBox);
      {
         // Draw toolbar
         GUI.BeginGroup(ToolbarPosition, EditorStyles.toolbar);
         {
            GUIContent content = new GUIContent("Reference");
            Rect rect = new Rect();
            Vector2 size = uScriptGUIStyle.panelTitleDropDown.CalcSize(content);
            rect.width = size.x;
            rect.height = size.y;

            GUI.Label(rect, content, uScriptGUIStyle.panelTitle);
//            int index = EditorGUI.Popup(uScriptGUI._panelTitlesRect, (int)Type, uScriptGUI._panelTitles, uScriptGUIStyle.panelTitleDropDown);
//
//            if (index != (int)Type)
//            {
//               Debug.LogWarning("The user attempted to change the panel type, but this functionality has not been implemented yet.\n");
//            }


//            // disable the button if there is no target URL
//            uScriptGUI.enabled = (helpButtonURL != string.Empty);
//            if (GUI.Button(toolbarButton, uScriptGUIContent.toolbarButtonOnlineReference, EditorStyles.toolbarButton))
//            {
//               Help.BrowseURL(helpButtonURL);
//            }
//            uScriptGUI.enabled = true;
         }
         GUI.EndGroup();

         ScrollviewOffset = GUI.BeginScrollView(ScrollviewPosition, ScrollviewOffset, ContentPosition, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar);
         {
            ControlData control = ContentControls[0];

            // prevent the help TextArea from getting focus
            GUI.SetNextControlName(control.name);
            GUI.TextArea(control.rect, control.content.text, uScriptGUIStyle.referenceText);
            if (GUI.GetNameOfFocusedControl() == control.name)
            {
               GUIUtility.keyboardControl = 0;
            }
         }
         GUI.EndScrollView();
      }
      GUI.EndGroup();

//      uScript.SetMouseRegion( MouseRegion.Reference );//, 3, 3, -6, -3 );
   }
*/



//   private static void InitReferencePanel(Rect rect)
//   {
//      // Local variables
////      PanelData data = new PanelData(uScriptGUI.PanelType.Reference, rect);
//      ScriptEditorCtrl m_ScriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;
//      Vector2 tempCalculatedContentSize = Vector2.zero;
//      GUIContent control;
//      Rect controlRect;
//
//
//      // Toolbar controls
//
//      // This Online Reference toolbar button is unlike most others in that it has a dynamic tooltip
//      string helpButtonTooltip   = "Open the online uScript reference in the default web browser.";
//      string helpButtonURL       = "http://www.uscript.net/wiki/";
//
//      if ( m_ScriptEditorCtrl.SelectedNodes.Length == 1)
//      {
//         helpButtonURL = uScript.FindNodeHelp(uScript.FindNodeType(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode));
//         if (m_ScriptEditorCtrl.SelectedNodes[0] != null)
//         {
//            helpButtonTooltip = "Open the online reference for the selected node in the default web browser.";
//         }
//      }
//      helpButtonTooltip += " (" + helpButtonURL + ")";
//
//      uScriptGUIContent.ChangeTooltip(uScriptGUIContent.ContentID.OnlineReference, helpButtonTooltip);
//
//      controlRect = new Rect();
//      tempCalculatedContentSize = EditorStyles.toolbarButton.CalcSize(uScriptGUIContent.toolbarButtonOnlineReference);
//      controlRect.width = tempCalculatedContentSize.x;
//      controlRect.height = tempCalculatedContentSize.y;
//      controlRect.x = rect.width - controlRect.width - 8;
//
//
//      ToolbarControls.Add(new ControlData("toolbarButton", "controlName", controlRect, uScriptGUIContent.toolbarButtonOnlineReference));
//
//      // Content controls
//      control = new GUIContent();
//      if (m_ScriptEditorCtrl.SelectedNodes.Length < 1)
//      {
//         control.text = "Select a node on the canvas to view usage and behavior information.";
//      }
//      else if (m_ScriptEditorCtrl.SelectedNodes.Length > 1)
//      {
//         control.text = "Help cannot be provided when multiple nodes are selected.";
//      }
//      else if (m_ScriptEditorCtrl.SelectedNodes[0] != null)
//      {
//         control.text = uScript.FindNodeDescription(uScript.FindNodeType(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode));
//      }
//
//      // Calculate the control dimensions
//      float height = uScriptGUIStyle.referenceText.CalcHeight(control, rect.width - 2);
//      if (height <= rect.height - uScriptGUI._panelTitlesRect.height + 4)
//      {
//         // The content is not tall enough to require the vertical scrollbar
//         controlRect.width = rect.width - 2;
//         controlRect.height = height;
//      }
//      else
//      {
//         // The content width should be decreased to accomodate the vertical scrollbar,
//         // otherwise the horizontal scrollbar will also appear (and we don't want that)
//         controlRect.width = rect.width - 2 - 20;
//         controlRect.height = uScriptGUIStyle.referenceText.CalcHeight(control, rect.width - 2 - 20);
//      }
//      ContentControls.Add(new uScriptGUI.ControlData("textArea", "helpTextArea", controlRect, control));
//
//      // Update the ContentPosition
//      ContentPosition = new Rect(controlRect);
//
//      // Store the results
//      _panelData.Add(PanelID.Bottom2, data);
//   }

/*

   public void Init()
   {
      // Local variables
//      PanelData data = new PanelData(uScriptGUI.PanelType.Reference, rect);
      ScriptEditorCtrl m_ScriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;
      Vector2 tempCalculatedContentSize = Vector2.zero;
      GUIContent control;
      Rect controlRect;



      _toolbarPosition = new Rect(1, 1, _panelPosition.width-2, uScriptGUI._panelTitlesRect.height);
//      _toolbarControls = new List<ControlData>();

      _scrollviewPosition = new Rect(_toolbarPosition.x,
                                     _toolbarPosition.y + _toolbarPosition.height,
                                     _toolbarPosition.width,
                                     _panelPosition.height - _toolbarPosition.y - _toolbarPosition.height - 1);

      // Toolbar controls

      // This Online Reference toolbar button is unlike most others in that it has a dynamic tooltip
      string helpButtonTooltip   = "Open the online uScript reference in the default web browser.";
      string helpButtonURL       = "http://www.uscript.net/wiki/";

      if ( m_ScriptEditorCtrl.SelectedNodes.Length == 1)
      {
         helpButtonURL = uScript.FindNodeHelp(uScript.FindNodeType(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode));
         if (m_ScriptEditorCtrl.SelectedNodes[0] != null)
         {
            helpButtonTooltip = "Open the online reference for the selected node in the default web browser.";
         }
      }
      helpButtonTooltip += " (" + helpButtonURL + ")";

      uScriptGUIContent.ChangeTooltip(uScriptGUIContent.ContentID.OnlineReference, helpButtonTooltip);

      controlRect = new Rect();
      tempCalculatedContentSize = EditorStyles.toolbarButton.CalcSize(uScriptGUIContent.toolbarButtonOnlineReference);
      controlRect.width = tempCalculatedContentSize.x;
      controlRect.height = tempCalculatedContentSize.y;
      controlRect.x = _panelPosition.width - controlRect.width - 8;


      ToolbarControls.Add(new ControlData("toolbarButton", "controlName", controlRect, uScriptGUIContent.toolbarButtonOnlineReference));

      // Content controls
      control = new GUIContent();
      if (m_ScriptEditorCtrl.SelectedNodes.Length < 1)
      {
         control.text = "Select a node on the canvas to view usage and behavior information.";
      }
      else if (m_ScriptEditorCtrl.SelectedNodes.Length > 1)
      {
         control.text = "Help cannot be provided when multiple nodes are selected.";
      }
      else if (m_ScriptEditorCtrl.SelectedNodes[0] != null)
      {
         control.text = uScript.FindNodeDescription(uScript.FindNodeType(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode));
      }

      // Calculate the control dimensions
      float height = uScriptGUIStyle.referenceText.CalcHeight(control, _panelPosition.width - 2);
      if (height <= _panelPosition.height - uScriptGUI._panelTitlesRect.height + 4)
      {
         // The content is not tall enough to require the vertical scrollbar
         controlRect.width = _panelPosition.width - 2;
         controlRect.height = height;
      }
      else
      {
         // The content width should be decreased to accomodate the vertical scrollbar,
         // otherwise the horizontal scrollbar will also appear (and we don't want that)
         controlRect.width = _panelPosition.width - 2 - 20;
         controlRect.height = uScriptGUIStyle.referenceText.CalcHeight(control, _panelPosition.width - 2 - 20);
      }
      ContentControls.Add(new ControlData("textArea", "helpTextArea", controlRect, control));

      // Update the ContentPosition
      ContentPosition = new Rect(controlRect);
//
//      // Store the results
//      _panelData.Add(PanelID.Bottom2, data);
   }

   public void Update()
   {
//      if (_panelPosition != rect)
//      {
//         // Did the size change, or just the coords?
//         if (_panelPosition.width != rect.width || _panelPosition.height != rect.height)
//         {
//            // The dimensions changed, so recalculate the contents
//            Debug.Log("REFERENCE PANEL - Update(" + rect + ", " + forceUpdate +" ) - RecalculateContents()\n");
//            Init();
//         }
//         else
//         {
//            // Only the panel coordinates changed, so just update its position
//            Debug.Log("REFERENCE PANEL - Update(" + rect + ", " + forceUpdate +" ) - UpdatePosition()\n");
//         }
//         _panelPosition = rect;
//      }
   }
*/


}
