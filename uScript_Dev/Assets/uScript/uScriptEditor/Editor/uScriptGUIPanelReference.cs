using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

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
      string helpDescription     = "Select a node on the canvas to view usage and behavior information.";
      string helpButtonTooltip   = "Open the online uScript reference in the default web browser.";
      string helpButtonURL       = "http://www.uscript.net/docs/";

      if (m_ScriptEditorCtrl.SelectedNodes.Length == 1)
      {
         if (m_ScriptEditorCtrl.SelectedNodes[0] != null)
         {
            string nodeType = ScriptEditor.FindNodeType(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode);
            if (string.IsNullOrEmpty(nodeType))
            {
               // other node types...
               if (m_ScriptEditorCtrl.SelectedNodes[0].EntityNode is CommentNode)
               {
                  nodeType = "CommentNode";
               }
               else if (m_ScriptEditorCtrl.SelectedNodes[0].EntityNode is ExternalConnection)
               {
                  nodeType = "ExternalConnection";
               }
               else if (m_ScriptEditorCtrl.SelectedNodes[0].EntityNode is OwnerConnection)
               {
                  nodeType = "OwnerConnection";
               }
               else if (m_ScriptEditorCtrl.SelectedNodes[0].EntityNode is LocalNode)
               {
                  nodeType = "LocalNode";
               }
            }
            helpButtonURL = uScript.FindNodeHelp(nodeType, m_ScriptEditorCtrl.SelectedNodes[0]);
            helpDescription = uScript.FindNodeDescription(nodeType, m_ScriptEditorCtrl.SelectedNodes[0]);
            helpButtonTooltip = "Open the online reference for the selected node in the default web browser.";
         }
      }
      else if (m_ScriptEditorCtrl.SelectedNodes.Length > 1)
      {
         helpDescription = "Help cannot be provided when multiple nodes are selected.";
      }

      helpButtonTooltip += " (" + helpButtonURL + ")";

//      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, _options);
      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox);
      {
         // Toolbar
         //
//         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label(_name, uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();

            if (helpButtonURL == string.Empty)
            {
               GUI.enabled = false;
            }

            uScriptGUIContent.ChangeTooltip(uScriptGUIContent.ContentID.OnlineReference, helpButtonTooltip);
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonOnlineReference, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               Help.BrowseURL(helpButtonURL);
            }

            GUI.enabled = true;
         }
         EditorGUILayout.EndHorizontal();


         if (uScriptInstance.wasCanvasDragged && uScript.Preferences.DrawPanelsOnUpdate == false)
         {
            DrawHiddenNotification();
         }
         else
         {
            // Node list
            //
//            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview", GUILayout.ExpandWidth(true));
            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
            {
               if ((m_ScriptEditorCtrl.SelectedNodes.Length == 1) && (m_ScriptEditorCtrl.SelectedNodes[0] != null))
               {
                  if (uScript.IsNodeTypeDeprecated(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode) || m_ScriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode))
                  {
                     GUIStyle style = new GUIStyle(GUI.skin.box);
                     style.normal.textColor = EditorStyles.boldLabel.normal.textColor;
                     style.font = EditorStyles.boldLabel.font;
                     style.wordWrap = true;
                     style.stretchWidth = true;
                     GUILayout.Box("SELECTED NODE IS DEPRECATED: UPDATE OR REPLACE", style);
                  }
               }

               // prevent the help TextArea from getting focus
               GUI.SetNextControlName("helpTextArea");
               GUILayout.TextArea(helpDescription, uScriptGUIStyle.referenceText);
               if (GUI.GetNameOfFocusedControl() == "helpTextArea")
               {
                  GUIUtility.keyboardControl = 0;
               }
            }
            EditorGUILayout.EndScrollView();
         }
      }
      EditorGUILayout.EndVertical();

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Reference);
      uScriptInstance.SetMouseRegion( uScript.MouseRegion.Reference );
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
//            GUI.enabled = (helpButtonURL != string.Empty);
//            if (GUI.Button(toolbarButton, uScriptGUIContent.toolbarButtonOnlineReference, EditorStyles.toolbarButton))
//            {
//               Help.BrowseURL(helpButtonURL);
//            }
//            GUI.enabled = true;
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
