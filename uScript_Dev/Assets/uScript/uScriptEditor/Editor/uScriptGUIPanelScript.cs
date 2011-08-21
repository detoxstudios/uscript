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

   String _panelScriptFilterText = string.Empty;




   //
   // Members specific to this panel class
   //
   const double doubleClickTime = 0.5; // default in Windows OS is 500ms
   double clickTime;
   string clickedControl = string.Empty;




   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      _name = "uScripts";
//      _size = 150;
//      _region = uScriptGUI.Region.Script;
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
//      bool m_CanvasDragging = uScriptInstance.m_CanvasDragging;

      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, GUILayout.Width(uScriptInstance._guiPanelSequence_Width));
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label("uScripts", uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));

            GUILayout.FlexibleSpace();

            GUI.SetNextControlName ("ScriptFilterSearch" );
            string _filterText = uScriptGUI.ToolbarSearchField(_panelScriptFilterText, GUILayout.Width(100));
            GUI.SetNextControlName ("" );
            if (_filterText != _panelScriptFilterText)
            {
               // Drop focus if the user inserted a newline (hit enter)
               if (_filterText.Contains("\n"))
               {
                  GUIUtility.keyboardControl = 0;
               }

               // Trim leading whitespace
               _filterText = _filterText.TrimStart( new char[] { ' ' } );

               _panelScriptFilterText = _filterText;
            }
         }
         EditorGUILayout.EndHorizontal();

         if (uScriptInstance.wasCanvasDragged && uScript.Preferences.DrawPanelsOnUpdate == false)
         {
            DrawHiddenNotification();
         }
         else
         {
            // Update the panel in the following manner:
            //
            //    Display the current active script first
            //    List the scene the script is associated with
            //    List error messages
            //
            //    Display some type of separator
            //
            //    Display all other scripts in the project (except the active script)
            //    Filter the list
            //    Support foldout containers eventually


            GUIStyle scriptStyle = new GUIStyle(EditorStyles.label);

            GUIContent contentInsert = new GUIContent("Insert", "Click to add an instance of this uScript.");
            GUIContent contentLoad = new GUIContent("Load", "Click to load this uScript.");
            GUIContent contentReload = new GUIContent("Reload", "Click to reload this uScript.");
            GUIContent contentSave = new GUIContent("Save", "Click to save the current uScript.");

            string sceneName = string.Empty;

            string scriptName = string.Empty;
            string scriptFile = string.Empty;

            bool currentScript = false;
            bool attached = false;
            bool dirty = false;


            //
            // Current script
            //
            GUILayout.BeginHorizontal();
            {
               scriptName = System.IO.Path.GetFileNameWithoutExtension(m_ScriptEditorCtrl.ScriptName);
               scriptFile = System.IO.Path.GetFileName(m_ScriptEditorCtrl.ScriptName).Replace(".cs", ".uscript");

               currentScript = true;
               bool hasScriptName = String.IsNullOrEmpty(m_ScriptEditorCtrl.ScriptName) == false;


               // uScript Label
               sceneName = "None";
               if (uScriptBackgroundProcess.s_uScriptInfo.ContainsKey(scriptFile))
               {
                  if (!string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[scriptFile].m_SceneName))
                  {
                     sceneName = uScriptBackgroundProcess.s_uScriptInfo[scriptFile].m_SceneName;
                  }
               }

               scriptStyle.fontStyle = FontStyle.Bold;
               attached = sceneName == System.IO.Path.GetFileNameWithoutExtension(UnityEditor.EditorApplication.currentScene);
               if (!attached)
               {
                  scriptStyle.normal.textColor = UnityEngine.Color.red;
               }
               dirty = m_ScriptEditorCtrl.IsDirty;

               GUILayout.Label( (String.IsNullOrEmpty(scriptName) ? "(new)" : scriptName) + (dirty ? " *" : ""), scriptStyle);

               GUILayout.FlexibleSpace();

               // Reload
               if (hasScriptName)
               {
                  if (GUILayout.Button(contentReload, EditorStyles.miniButtonLeft))
                  {
                     string path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptName + ".uscript");

                     if ("" != path)
                     {
                        uScriptInstance.OpenScript(path);
                     }
                  }
               }

               if (GUILayout.Button(contentSave, hasScriptName ? EditorStyles.miniButtonRight : EditorStyles.miniButton))
               {
                  bool saved = false;
                  AssetDatabase.StartAssetEditing();
                  {
                     saved = uScriptInstance.SaveScript(false);
                  }
                  AssetDatabase.StopAssetEditing();

                  if (saved)
                  {
                     uScriptInstance.RefreshScript();
                  }
               }
            }
            GUILayout.EndHorizontal();

//            GUILayout.Label("Current Scene: " + sceneName);
//
//            if (!attached)
//            {
//               GUIStyle errorStyle = new GUIStyle(GUI.skin.label);
//               errorStyle.normal.textColor = UnityEngine.Color.red;
//               errorStyle.wordWrap = true;
//               GUILayout.Label("The Unity Scene this uScript uses is not loaded in Unity or it has not been saved yet. Work may be lost if you save!", errorStyle);
//            }


            //
            // Spacer
            //
            uScriptGUI.HR();


            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
            {
               //
               // Filtered script list
               //
               List<string> keylist = new List<string>();
               keylist.AddRange(uScriptBackgroundProcess.s_uScriptInfo.Keys);
               string[] keys = keylist.ToArray();

               int filterMatches = 0;

               foreach (string fileName in keys)
               {
                  scriptName = System.IO.Path.GetFileNameWithoutExtension(fileName);
                  scriptFile = System.IO.Path.GetFileName(fileName).Replace(".cs", ".uscript");

                  currentScript = (scriptName == System.IO.Path.GetFileNameWithoutExtension(m_ScriptEditorCtrl.ScriptName));
                  attached = false;
                  dirty = false;

                  scriptStyle = new GUIStyle(EditorStyles.label);

                  if (currentScript == false
                      && (String.IsNullOrEmpty(_panelScriptFilterText)
                          || scriptName.ToLower().Contains(_panelScriptFilterText.ToLower())
                          )
                      )
                  {
                     filterMatches++;

                     GUILayout.BeginHorizontal();
                     {
                        // uScript Label
                        sceneName = "None";
                        if (!string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[scriptFile].m_SceneName))
                        {
                           sceneName = uScriptBackgroundProcess.s_uScriptInfo[scriptFile].m_SceneName;
                        }

                        if (Event.current.type == EventType.Layout)
                        {
                           scriptName = string.Empty;
                        }

                        // prepare for double-click
                        bool wasClicked = false;
                        if ((EditorApplication.timeSinceStartup - clickTime) < doubleClickTime
                            && clickedControl == scriptName)
                        {
                           wasClicked = true;
                           scriptStyle.fontStyle = FontStyle.Bold;
                        }
                        else
                        {
                           scriptStyle.fontStyle = FontStyle.Normal;
                           uScript.Instance.Redraw();
                        }

                        // the script path
                        string path = null;

                        if (GUILayout.Button(scriptName + (sceneName == "None" ? string.Empty : " (" + sceneName + ")"), scriptStyle, GUILayout.ExpandWidth(true)))
                        {
                           path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptName + ".uscript");
   
                           if (wasClicked)
                           {
                              // double-click
                              clickTime = EditorApplication.timeSinceStartup - clickTime; // prevents multiple double-clicks
                              if (false == string.IsNullOrEmpty(path))
                              {
                                 uScriptInstance.OpenScript(path);
                              }
                           }
                           else
                           {
                              // single-click
                              clickTime = EditorApplication.timeSinceStartup;
                              clickedControl = scriptName;
                           }
                        }

                        // Load
                        if (GUILayout.Button(contentLoad, EditorStyles.miniButtonLeft, GUILayout.ExpandWidth(false)))
                        {
                           if ( null == path ) path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptName + ".uscript");

                           if (false == string.IsNullOrEmpty(path))
                           {
                              uScriptInstance.OpenScript(path);
                           }
                        }

                        // Insert as Nested uScript
                        if (GUILayout.Button(contentInsert, EditorStyles.miniButtonRight, GUILayout.ExpandWidth(false)))
                        {
                           if (m_ScriptEditorCtrl != null)
                           {
                              float canvasX = uScriptInstance._mouseRegionRect[uScript.MouseRegion.Canvas].x;
                              float canvasY = uScriptInstance._mouseRegionRect[uScript.MouseRegion.Canvas].y;
                              m_ScriptEditorCtrl.ContextCursor = new Point((int)(canvasX - uScriptInstance._guiPanelPalette_Width + uScript.Instance.NodeWindowRect.width / 2.0f), (int)(canvasY + uScript.Instance.NodeWindowRect.height / 2.0f));
                              m_ScriptEditorCtrl.AddVariableNode(m_ScriptEditorCtrl.GetLogicNode(scriptName));
                           }
                        }
                     }
                     GUILayout.EndHorizontal();
                  }
               }

               if (filterMatches == 0)
               {
                  GUIStyle style = new GUIStyle(EditorStyles.boldLabel);
                  style.alignment = TextAnchor.MiddleCenter;
                  GUILayout.Label("The search found no matches!", style);
               }
            }
            EditorGUILayout.EndScrollView();
         }
      }
      EditorGUILayout.EndVertical();

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Script);
      uScriptInstance.SetMouseRegion(uScript.MouseRegion.NestedScripts);
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
