using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

using Detox.ScriptEditor;
using Detox.FlowChart;

//using Detox.Data.Tools;
//using System.Windows.Forms;
//using System.Linq;




public sealed class uScriptGUIPanelScript: uScriptGUIPanel
{
   //
   // Singleton pattern
   //
   static readonly uScriptGUIPanelScript _instance = new uScriptGUIPanelScript();
   public static uScriptGUIPanelScript Instance { get { return _instance; } }
   private uScriptGUIPanelScript() { Init(); }


   //
   // Members specific to this panel class
   //
//   public readonly uScriptGUI.Region;



   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      _name = "uScripts";
      _size = 150;
      _region = uScriptGUI.Region.Script;
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
            string currentUScript = "";
            if (m_ScriptEditorCtrl != null)
            {
               currentUScript = " (" + System.IO.Path.GetFileNameWithoutExtension(m_ScriptEditorCtrl.ScriptName) + ")";
            }

            GUILayout.Label(_name + currentUScript, uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));
         }
         EditorGUILayout.EndHorizontal();

         if (m_CanvasDragging && uScript.Preferences.DrawPanelsOnUpdate == false)
         {
            DrawHiddenNotification();
         }
         else
         {
            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
            {
               List<string> keylist = new List<string>();
               keylist.AddRange(uScriptBackgroundProcess.s_uScriptInfo.Keys);
               string[] keys = keylist.ToArray();
               foreach (string fileName in keys)
               {
                  string scriptName = System.IO.Path.GetFileNameWithoutExtension(fileName);
                  string scriptFile = System.IO.Path.GetFileName(fileName).Replace(".cs", ".uscript");

                  GUIStyle scriptStyle = new GUIStyle(EditorStyles.label);
                  bool currentScript = (scriptName == System.IO.Path.GetFileNameWithoutExtension(m_ScriptEditorCtrl.ScriptName));
                  bool attached = false;
                  bool dirty = false;

                  GUILayout.BeginHorizontal();
                  {
                     // uScript Label
                     if (currentScript)
                     {
                        scriptStyle.fontStyle = FontStyle.Bold;
                        attached = uScriptInstance.IsAttachedToMaster || uScriptInstance.IsAttached;
                        if (!attached)
                        {
                           scriptStyle.normal.textColor = UnityEngine.Color.red;
                        }
                        dirty = m_ScriptEditorCtrl.IsDirty;
                     }
                     string sceneName = "None";
                     if (!string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[scriptFile].m_SceneName))
                     {
                        sceneName = uScriptBackgroundProcess.s_uScriptInfo[scriptFile].m_SceneName;
                     }
                     GUILayout.Label(scriptName + " (" + sceneName + ")" + (dirty ? "*" : ""), scriptStyle);

                     GUILayout.FlexibleSpace();

                     // Load or Reload
                     GUIContent content = new GUIContent((currentScript ? "Reload" : "Load"), "Click to load this uScript.");
                     if (GUILayout.Button(content, (currentScript ? EditorStyles.miniButton : EditorStyles.miniButtonLeft)))
                     {
                        string path = uScript.Instance.FindFile(uScript.Preferences.UserScripts, scriptName + ".uscript");

                        if ("" != path)
                        {
//                           _openScriptToggle = false;
                           uScript.Instance.OpenScript(path);
                        }
                     }

                     // Insert as Nested uScript
                     if (currentScript == false)
                     {
                        content = new GUIContent("Insert", "Click to add an instance of this uScript.");
                        if (GUILayout.Button(content, EditorStyles.miniButtonRight))
                        {
                           if (m_ScriptEditorCtrl != null)
                           {
//                              Debug.Log("FIX THIS\n");
                              //float canvasX = _mouseRegionRect[MouseRegion.Canvas].x;
                              //float canvasY = _mouseRegionRect[MouseRegion.Canvas].y;
                              //m_ScriptEditorCtrl.ContextCursor = new Point((int)(canvasX - _guiPanelPalette_Width + uScript.Instance.NodeWindowRect.width / 2.0f), (int)(canvasY + uScript.Instance.NodeWindowRect.height / 2.0f));
                              m_ScriptEditorCtrl.ContextCursor = new Point((int) (uScript.Instance.NodeWindowRect.width / 2), (int) (uScript.Instance.NodeWindowRect.height / 2));                              
                              m_ScriptEditorCtrl.AddVariableNode(m_ScriptEditorCtrl.GetLogicNode(scriptName));
                           }
                        }
                     }
                  }
                  GUILayout.EndHorizontal();

                  if (currentScript && !attached)
                  {
                     GUIStyle errorStyle = new GUIStyle(GUI.skin.label);
                     errorStyle.normal.textColor = UnityEngine.Color.red;
                     errorStyle.wordWrap = true;
                     GUILayout.Label("This uScript is not attached to any GameObject in the scene.", errorStyle);
                  }
               }
            }
            EditorGUILayout.EndScrollView();
         }
      }
      EditorGUILayout.EndVertical();

      uScriptGUI.DefineRegion(uScriptGUI.Region.Script);
//      uScriptInstance.SetMouseRegion(uScript.MouseRegion.NestedScripts);


//      if (Event.current.type == EventType.Repaint)
//      {
//         Debug.Log("Region: " + uScriptGUI.GetRegion(uScriptGUI.Region.Script).ToString() + ", Rect: " + r.ToString() + "\n");
//      }





//      // Panel background
//      GUI.BeginGroup(PanelPosition, uScriptGUIStyle.panelBox);
//      {
//         // Draw toolbar
//         GUI.BeginGroup(ToolbarPosition, EditorStyles.toolbar);
//         {
//            GUIContent content = new GUIContent("uScripts");
//            Rect rect = new Rect();
//            Vector2 size = uScriptGUIStyle.panelTitleDropDown.CalcSize(content);
//            rect.width = size.x;
//            rect.height = size.y;
//
//            GUI.Label(rect, content, uScriptGUIStyle.panelTitle);
////            int index = EditorGUI.Popup(uScriptGUI._panelTitlesRect, (int)Type, uScriptGUI._panelTitles, uScriptGUIStyle.panelTitleDropDown);
////
////            if (index != (int)Type)
////            {
////               Debug.LogWarning("The user attempted to change the panel type, but this functionality has not been implemented yet.\n");
////            }
//         }
//         GUI.EndGroup();
//
//         ScrollviewOffset = GUI.BeginScrollView(ScrollviewPosition, ScrollviewOffset, ContentPosition, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar);
//         {
////            ControlData control = ContentControls[0];
////
////            // prevent the help TextArea from getting focus
////            GUI.SetNextControlName(control.name);
////            GUI.TextArea(control.rect, control.content.text, uScriptGUIStyle.referenceText);
////            if (GUI.GetNameOfFocusedControl() == control.name)
////            {
////               GUIUtility.keyboardControl = 0;
////            }
//         }
//         GUI.EndScrollView();
//      }
//      GUI.EndGroup();
   }






/*
   public void Init()
   {
//      Debug.Log("SCRIPTS PANEL - Init()\n");

//      // Local variables
//      ScriptEditorCtrl m_ScriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;
//      Vector2 tempCalculatedContentSize = Vector2.zero;
//      float yOffset = 0;
//
//      Rect        controlPosition;
//      GUIContent  controlContent;
//      GUIStyle    controlStyle;
//
//
//
//      _toolbarPosition = new Rect(1, 1, _panelPosition.width-2, uScriptGUI._panelTitlesRect.height);
////      _toolbarControls = new List<ControlData>();
//
//      _scrollviewPosition = new Rect(_toolbarPosition.x,
//                                     _toolbarPosition.y + _toolbarPosition.height,
//                                     _toolbarPosition.width,
//                                     _panelPosition.height - _toolbarPosition.y - _toolbarPosition.height - 1);
//
//      // Toolbar controls
//
//      // < none >
//
//      // Content controls
//      foreach (string fileName in System.IO.Directory.GetFiles(uScriptConfig.Paths.GeneratedScripts))
//      {
//         if ( fileName.Contains(".cs") )
//         {
//            if ( !fileName.Contains( uScriptConfig.Files.GeneratedComponentExtension ) )
//            {
//               string scriptName = System.IO.Path.GetFileNameWithoutExtension(fileName);
//               bool isCurrentScript = (scriptName == System.IO.Path.GetFileNameWithoutExtension(m_ScriptEditorCtrl.ScriptName));
//
//               // uScript Label
////               controlType = "label";
//               controlContent = new GUIContent(scriptName);
//               controlStyle = new GUIStyle(EditorStyles.label);
//               if (isCurrentScript)
//               {
//                  controlStyle.fontStyle = FontStyle.Bold;
//                  controlStyle.normal.textColor = (IsAttached ? UnityEngine.Color.white : UnityEngine.Color.red);
//               }
//
//
//               GUILayout.Label(scriptName, controlStyle);
//
////      // Calculate the control dimensions
////      float height = uScriptGUIStyle.referenceText.CalcHeight(controlContent, _panelPosition.width - 2);
////      if (height <= _panelPosition.height - uScriptGUI._panelTitlesRect.height + 4)
////      {
////         // The content is not tall enough to require the vertical scrollbar
////         controlPosition.width = _panelPosition.width - 2;
////         controlPosition.height = height;
////      }
////      else
////      {
////         // The content width should be decreased to accomodate the vertical scrollbar,
////         // otherwise the horizontal scrollbar will also appear (and we don't want that)
////         controlPosition.width = _panelPosition.width - 2 - 20;
////         controlPosition.height = uScriptGUIStyle.referenceText.CalcHeight(controlContent, _panelPosition.width - 2 - 20);
////      }
//               ContentControls.Add(new ControlData("textArea", "helpTextArea", controlPosition, controlContent));
//
//
//               // ControlData.Type
//               // ControlData.Position
//               // ControlData.Content
//               // ControlData.Style
//               // ControlData.Delegate
//               // ControlData.Params
//
//
//               GUILayout.BeginHorizontal();
//               {
//
//                  GUILayout.FlexibleSpace();
//
//                  // Load or Reload
//                  GUIContent content = new GUIContent((isCurrentScript ? "Reload" : "Load"), "Click to load this uScript.");
//                  if (GUILayout.Button(content, (isCurrentScript ? EditorStyles.miniButton : EditorStyles.miniButtonLeft)))
//                  {
//                     string path = FindFile(uScriptConfig.Paths.UserScripts, scriptName + ".uscript");
//
//                     if ("" != path)
//                     {
//                        _openScriptToggle = false;
//                        OpenScript(path);
//                     }
//                  }
//
//                  // Insert as Nested uScript
//                  if (isCurrentScript == false)
//                  {
//                     content = new GUIContent("Insert", "Click to add an instance of this uScript.");
//                     if (GUILayout.Button(content, EditorStyles.miniButtonRight))
//                     {
//                        UnityEngine.Debug.LogWarning("An instance of the \""+ scriptName +"\" uScript should have been inserted into the graph.\n");
//                     }
//                  }
//               }
//               GUILayout.EndHorizontal();
//            }
//         }
//      }





//
//
//      controlContent = new GUIContent();
//      if (m_ScriptEditorCtrl.SelectedNodes.Length < 1)
//      {
//         controlContent.text = "Select a node on the canvas to view usage and behavior information.";
//      }
//      else if (m_ScriptEditorCtrl.SelectedNodes.Length > 1)
//      {
//         controlContent.text = "Help cannot be provided when multiple nodes are selected.";
//      }
//      else if (m_ScriptEditorCtrl.SelectedNodes[0] != null)
//      {
//         controlContent.text = uScript.FindNodeDescription(uScript.FindNodeType(m_ScriptEditorCtrl.SelectedNodes[0].EntityNode));
//      }
//
//      // Calculate the control dimensions
//      float height = uScriptGUIStyle.referenceText.CalcHeight(controlContent, _panelPosition.width - 2);
//      if (height <= _panelPosition.height - uScriptGUI._panelTitlesRect.height + 4)
//      {
//         // The content is not tall enough to require the vertical scrollbar
//         controlPosition.width = _panelPosition.width - 2;
//         controlPosition.height = height;
//      }
//      else
//      {
//         // The content width should be decreased to accomodate the vertical scrollbar,
//         // otherwise the horizontal scrollbar will also appear (and we don't want that)
//         controlPosition.width = _panelPosition.width - 2 - 20;
//         controlPosition.height = uScriptGUIStyle.referenceText.CalcHeight(controlContent, _panelPosition.width - 2 - 20);
//      }
//      ContentControls.Add(new ControlData("textArea", "helpTextArea", controlPosition, controlContent));
//
//      // Update the ContentPosition
//      ContentPosition = new Rect(controlPosition);
////
////      // Store the results
////      _panelData.Add(PanelID.Bottom2, data);







//            foreach (string fileName in System.IO.Directory.GetFiles(uScriptConfig.Paths.GeneratedScripts))
//            {
//               if ( fileName.Contains(".cs") )
//               {
//                  if ( !fileName.Contains( uScriptConfig.Files.GeneratedComponentExtension ) )
//                  {
//                     string scriptName = System.IO.Path.GetFileNameWithoutExtension(fileName);
//
//                     GUIStyle scriptStyle = new GUIStyle(EditorStyles.label);
////                     GUIStyle errorStyle = new GUIStyle(EditorStyles.label);
//                     bool currentScript = (scriptName == System.IO.Path.GetFileNameWithoutExtension(m_ScriptEditorCtrl.ScriptName));
//
//                     GUILayout.BeginHorizontal();
//                     {
//                        // uScript Label
//                        if (currentScript)
//                        {
//                           scriptStyle.fontStyle = FontStyle.Bold;
//                           scriptStyle.normal.textColor = (IsAttached ? UnityEngine.Color.white : UnityEngine.Color.red);
//                        }
//                        GUILayout.Label(scriptName, scriptStyle);
//
//                        GUILayout.FlexibleSpace();
//
//                        // Load or Reload
//                        GUIContent content = new GUIContent((currentScript ? "Reload" : "Load"), "Click to load this uScript.");
//                        if (GUILayout.Button(content, (currentScript ? EditorStyles.miniButton : EditorStyles.miniButtonLeft)))
//                        {
//                           string path = FindFile(uScriptConfig.Paths.UserScripts, scriptName + ".uscript");
//
//                           if ("" != path)
//                           {
//                              _openScriptToggle = false;
//                              OpenScript(path);
//                           }
//                        }
//
//                        // Insert as Nested uScript
//                        if (currentScript == false)
//                        {
//                           content = new GUIContent("Insert", "Click to add an instance of this uScript.");
//                           if (GUILayout.Button(content, EditorStyles.miniButtonRight))
//                           {
//                              UnityEngine.Debug.LogWarning("An instance of the \""+ scriptName +"\" uScript should have been inserted into the graph.\n");
//                           }
//                        }
//                     }
//                     GUILayout.EndHorizontal();
//
////                     if (currentScript && IsAttached == false)
////                     {
////                        errorStyle.normal.textColor = UnityEngine.Color.red;
////                        errorStyle.wordWrap = true;
////                        GUILayout.Label("This uScript is not attached to any GameObject in the scene.", errorStyle);
////                     }
//                  }
//               }
//            }


   }

   public void Update()
   {
//      if (_panelPosition != rect)
//      {
//         // Did the size change, or just the coords?
//         if (_panelPosition.width != rect.width || _panelPosition.height != rect.height)
//         {
//            // The dimensions changed, so recalculate the contents
//            Debug.Log("SCRIPTS PANEL - Update(" + rect + ", " + forceUpdate +" ) - RecalculateContents()\n");
//            Init();
//         }
//         else
//         {
//            // Only the panel coordinates changed, so just update its position
//            Debug.Log("SCRIPTS PANEL - Update(" + rect + ", " + forceUpdate +" ) - UpdatePosition()\n");
//         }
//         _panelPosition = rect;
//      }
   }
*/

}
