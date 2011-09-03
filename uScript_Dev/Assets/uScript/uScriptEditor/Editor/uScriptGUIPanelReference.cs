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
   public EntityNode hotNodeControl = null;


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

   string helpNodeClassName = string.Empty;
   string helpNodeClassPath = string.Empty;

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

      GUIStyle helpDescriptionStyle = uScriptGUIStyle.panelMessage;

      DisplayNode dn = null;

      if (hotNodeControl != null)
      {
         string nodeType = ScriptEditor.FindNodeType(hotNodeControl);
         if (string.IsNullOrEmpty(nodeType))
         {
            // other node types...
            if (hotNodeControl is CommentNode)
            {
               nodeType = "CommentNode";
            }
            else if (hotNodeControl is ExternalConnection)
            {
               nodeType = "ExternalConnection";
            }
            else if (hotNodeControl is OwnerConnection)
            {
               nodeType = "OwnerConnection";
            }
            else if (hotNodeControl is LocalNode)
            {
               nodeType = "LocalNode";
            }
         }
         helpButtonURL = string.Empty;
         helpDescription = "HOT TIP:\n\n" + uScript.FindNodeDescription(nodeType, hotNodeControl);
         helpButtonTooltip = string.Empty;

         helpDescriptionStyle = uScriptGUIStyle.referenceText;
         helpNodeClassName = string.Empty;
         helpNodeClassPath = string.Empty;
      }
      else if (m_ScriptEditorCtrl.SelectedNodes.Length > 1)
      {
         helpDescription = "Help cannot be provided when multiple nodes are selected.";
         helpDescriptionStyle = uScriptGUIStyle.panelMessage;
         helpNodeClassName = string.Empty;
         helpNodeClassPath = string.Empty;
      }
      else if (m_ScriptEditorCtrl.SelectedNodes.Length == 1)
      {
         dn = m_ScriptEditorCtrl.SelectedNodes[0];
         if (dn != null)
         {
            string nodeType = ScriptEditor.FindNodeType(dn.EntityNode);
            if (string.IsNullOrEmpty(nodeType))
            {
               // other node types...
               if (dn.EntityNode is CommentNode)
               {
                  nodeType = "CommentNode";
               }
               else if (dn.EntityNode is ExternalConnection)
               {
                  nodeType = "ExternalConnection";
               }
               else if (dn.EntityNode is OwnerConnection)
               {
                  nodeType = "OwnerConnection";
               }
               else if (dn.EntityNode is LocalNode)
               {
                  nodeType = "LocalNode";
               }
            }
            helpButtonURL = uScript.FindNodeHelp(nodeType, dn);
            helpDescription = uScript.FindNodeDescription(nodeType, dn.EntityNode);
            helpButtonTooltip = "Open the online reference for the selected node in the default web browser.";

            helpDescriptionStyle = uScriptGUIStyle.referenceText;

            string className = ScriptEditor.FindNodeType(dn.EntityNode);
            if (className != helpNodeClassName)
            {
               helpNodeClassName = className;
               helpNodeClassPath = GetClassPath();
            }
         }
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

            uScriptGUI.enabled = (string.IsNullOrEmpty(helpNodeClassPath) == false);

            if (GUILayout.Button(uScriptGUIContent.toolbarButtonSource, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
            {
               UnityEngine.Object obj = Resources.LoadAssetAtPath(helpNodeClassPath, typeof(TextAsset));
               if (obj != null)
               {
                  int instanceID = obj.GetInstanceID();
                  EditorGUIUtility.PingObject(instanceID);
               }
               else
               {
                  Debug.Log("File not found: " + helpNodeClassPath + "\n");
               }
            }

            uScriptGUI.enabled = (string.IsNullOrEmpty(helpButtonURL) == false);

            uScriptGUIContent.ChangeTooltip(helpButtonTooltip);
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonOnlineReference, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               Help.BrowseURL(helpButtonURL);
            }

            uScriptGUI.enabled = hotNodeControl == null;

            if (GUILayout.Button(uScriptGUIContent.toolbarButtonOnlineForum, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
            {
               Help.BrowseURL("http://uscript.net/forum");
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
            // Node list
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

               // prevent the help TextArea from getting focus
               GUI.SetNextControlName("helpTextArea");
               GUILayout.TextArea(helpDescription, helpDescriptionStyle);
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


   string GetClassPath()
   {
      if (string.IsNullOrEmpty(helpNodeClassName) == false)
      {
         // Find the associated class file
         string startPath = Application.dataPath;
         string[] exts = new string[] { ".cs", ".js", ".boo" };

         foreach (string ext in exts)
         {
            string[] files = Directory.GetFiles(startPath, helpNodeClassName + ext, SearchOption.AllDirectories);
            if (files.Length == 1)
            {
               return files[0].Remove(0, startPath.Length - 6);
            }
         }
      }

      return string.Empty;
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
