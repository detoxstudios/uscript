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
   private string currentNodeClassPath = string.Empty;

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
         currentNodeClassPath = string.Empty;
         helpButtonURL = string.Empty;
         helpButtonTooltip = string.Empty;
      }
      else
      {
         if (m_ScriptEditorCtrl.SelectedNodes.Length != 1)
         {
            currentNodeClassName = string.Empty;
            currentNodeClassPath = string.Empty;
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

//            uScriptGUI.enabled = (string.IsNullOrEmpty(currentNodeClassPath) == false);

            if (GUILayout.Button(uScriptGUIContent.buttonNodeSource, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
            {
               // BEGIN TEMP
               currentNodeClassPath = GetClassPath(currentNodeClassName);
               // END TEMP

               uScriptGUI.PingObject(currentNodeClassPath, typeof(TextAsset));
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

               if (node == null)
               {
                  GUILayout.Label( (m_ScriptEditorCtrl.SelectedNodes.Length == 0
                                    ? "Select a node on the canvas to view usage and behavior information."
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
   // This method can be expensive, so call it sparingly
   //
   string GetClassPath(string newName)
   {
      if (string.IsNullOrEmpty(newName) == false)
      {
         // Find the associated class file
         string startPath = Application.dataPath;
         string[] exts = new string[] { ".cs", ".js", ".boo" };

         foreach (string ext in exts)
         {
            string[] files = Directory.GetFiles(startPath, newName + ext, SearchOption.AllDirectories);
            if (files.Length == 1)
            {
               return files[0].Remove(0, startPath.Length - 6);
            }
         }
      }

      return string.Empty;
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
      if (isHotSelection)
      {
         GUILayout.Label("HOT TIP:", EditorStyles.boldLabel);
      }

      GUILayout.Label(uScript.FindNodeDescription(nodeType, node), uScriptGUIStyle.referenceText);


//               // Node name and palette location
//               GUILayout.Label("Load Material", uScriptGUIStyle.referenceName);
//               Rect r = GUILayoutUtility.GetLastRect();
//               GUI.Label(r, "Actions > Assets", uScriptGUIStyle.referenceInfo);
//
//               // Node description
//               GUILayout.Label("Loads a Material file from your Resources directory.", uScriptGUIStyle.referenceDesc);
//
//               // Parameter block
//               GUILayout.BeginHorizontal();
//               {
//                  // Icon
//                  GUILayout.Space(24);
//
//                  //
//                  GUILayout.BeginVertical();
//                  {
//                     // Parameter name and type
//                     GUILayout.Label("Asset Path:", uScriptGUIStyle.referenceName);
//                     r = GUILayoutUtility.GetLastRect();
//                     GUI.Label(r, "String", uScriptGUIStyle.referenceInfo);
//
//                     // Parameter description
//                     GUILayout.Label("The Material file to load.  The supported file format is: \"mat\".", uScriptGUIStyle.referenceDesc);
//                  }
//                  GUILayout.EndVertical();
//               }
//               GUILayout.EndHorizontal();
//
//               // Parameter block
//               GUILayout.BeginHorizontal();
//               {
//                  // Icon
//                  GUILayout.Space(24);
////                  r = GUILayoutUtility.GetLastRect();
////                  r.height = 20;
////                  GUI.Label(r, "(o)", styleInfo);
//
//                  //
//                  GUILayout.BeginVertical();
//                  {
//                     // Parameter name and type
//                     GUILayout.Label("Loaded Asset:", uScriptGUIStyle.referenceName);
//                     r = GUILayoutUtility.GetLastRect();
//                     GUI.Label(r, "Material", uScriptGUIStyle.referenceInfo);
//
//                     // Parameter description
//                     GUILayout.Label("The Material loaded from the specified file path.", uScriptGUIStyle.referenceDesc);
//                  }
//                  GUILayout.EndVertical();
//               }
//               GUILayout.EndHorizontal();

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
