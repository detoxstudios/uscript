using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Detox.Drawing;
using Detox.FlowChart;
using Detox.ScriptEditor;

//using Detox.Data.Tools;
//using Detox.Windows.Forms;
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
   string _panelFilterText = string.Empty;

   const double _doubleClickTime = 0.5; // default in Windows OS is 500ms
   double _clickTime;
   string _clickedControl = string.Empty;

   string _currentScriptName = string.Empty;
   string _currentScriptName_uScript = string.Empty;

   GUIStyle _styleButtonGroup = null;

   GUIStyle _scriptCurrentNormal = null;
   GUIStyle _scriptCurrentError = null;
   GUIStyle _scriptListNormal = null;
   GUIStyle _scriptListBold = null;

   GUIStyle _styleMiniButtonLeft = null;
   GUIStyle _styleMiniButtonRight = null;

   static Rect _scrollviewRect = new Rect();

   static float _previousRowWidth = 0;

   int _widthButtonSource;
   int _widthButtonLoad;

   const int ROW_HEIGHT = 17;
   const int BUTTON_HEIGHT = 15;
   const int BUTTON_PADDING = 4;

//   float _tListData_count;
//   float _tListData_height;

//   float _mListData_count;
//   float _mListData_height;

//   float _bListData_count;
//   float _bListData_height;

//   LocalTestDebug _debugScript;


   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      _name = "uScripts";
//      _size = 150;
//      _region = uScriptGUI.Region.Script;

      // Setup the custom GUI styles
      _scriptCurrentNormal = new GUIStyle(EditorStyles.boldLabel);

      _scriptCurrentError = new GUIStyle(_scriptCurrentNormal);
      _scriptCurrentError.normal.textColor = UnityEngine.Color.red;

      _scriptListNormal = new GUIStyle(EditorStyles.label);
      _scriptListNormal.margin = new RectOffset(4, 4, 1, 1);
      _scriptListNormal.padding = new RectOffset(2, 2, 0, 0);

      _scriptListBold = new GUIStyle(_scriptListNormal);
      _scriptListBold.fontStyle = FontStyle.Bold;

      _styleMiniButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft);
      _styleMiniButtonLeft.margin = new RectOffset(4, 0, 1, 1);

      _styleMiniButtonRight = new GUIStyle(EditorStyles.miniButtonRight);
      _styleMiniButtonRight.margin = new RectOffset(0, 4, 1, 1);

      _styleButtonGroup = new GUIStyle();
      _styleButtonGroup.margin.top = 2;

      // Get the width of the buttons, since the content
      // under Windows has a different size then under Mac
      _widthButtonSource = (int)_styleMiniButtonLeft.CalcSize(uScriptGUIContent.buttonNodeSource).x;
      _widthButtonLoad = (int)_styleMiniButtonRight.CalcSize(uScriptGUIContent.buttonScriptLoad).x;
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


//      // Grab the deubgging script
//      if (_debugScript == null)
//      {
//         _debugScript = GameObject.Find("_uScript").GetComponent(typeof(LocalTestDebug)) as LocalTestDebug;
//      }
//      _debugScript.Top = Vector2.zero;
//      _debugScript.Middle = Vector2.zero;
//      _debugScript.Bottom = Vector2.zero;
//      _debugScript.svRect = _scrollviewRect;
//
//      // Update debug data
//      _tListData_count = 0;
//      _mListData_count = 0;
//      _bListData_count = 0;


      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, GUILayout.Width(uScriptInstance._guiPanelSequence_Width));
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label("uScripts", uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));

            GUILayout.FlexibleSpace();

            GUI.SetNextControlName ("ScriptFilterSearch" );
            string _filterText = uScriptGUI.ToolbarSearchField(_panelFilterText, GUILayout.Width(100));
//            GUI.SetNextControlName ("" );
            if (_filterText != _panelFilterText)
            {
               // Drop focus if the user inserted a newline (hit enter)
               if (_filterText.Contains("\n"))
               {
                  GUIUtility.keyboardControl = 0;
               }

               // Trim leading whitespace
               _filterText = _filterText.TrimStart( new char[] { ' ' } );

               _panelFilterText = _filterText;
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

            string currentSceneName = System.IO.Path.GetFileNameWithoutExtension(UnityEditor.EditorApplication.currentScene);
            string scriptSceneName = string.Empty;

            //
            // Current script
            //
            if (_currentScriptName_uScript != m_ScriptEditorCtrl.ScriptName)
            {
               _currentScriptName_uScript = m_ScriptEditorCtrl.ScriptName;
               _currentScriptName = System.IO.Path.GetFileNameWithoutExtension(_currentScriptName_uScript);
            }

            if (null == _currentScriptName_uScript)
               _currentScriptName_uScript = string.Empty;

            // uScript Label
            scriptSceneName = string.Empty;
            if (uScriptBackgroundProcess.s_uScriptInfo.ContainsKey(_currentScriptName_uScript))
            {
               if (string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[_currentScriptName_uScript].m_SceneName) == false)
               {
                  scriptSceneName = uScriptBackgroundProcess.s_uScriptInfo[_currentScriptName_uScript].m_SceneName;
               }
            }

            bool isScriptNew = String.IsNullOrEmpty(_currentScriptName_uScript);
            bool isScriptAttachToScene = (scriptSceneName == currentSceneName);
            bool isScriptDirty = m_ScriptEditorCtrl.IsDirty;

            GUILayout.Label(( (isScriptNew ? "(new)" : _currentScriptName)
                              + (isScriptDirty ? " *" : string.Empty) ), _scriptCurrentNormal );

            GUILayout.BeginHorizontal();
            {
               // '\u21b3' // DOWNWARDS ARROW WITH TIP RIGHTWARDS
               // '\u21aa' // RIGHTWARDS ARROW WITH HOOK
               // '\u293f' // LOWER LEFT SEMICIRCULAR ANTICLOCKWISE ARROW
               // '\u2937' // ARROW POINTING DOWNWARDS THEN CURVING RIGHTWARDS
               GUILayout.Label(new GUIContent((Application.platform == RuntimePlatform.OSXEditor
                                                 ? '\u21aa'
                                                 : '\u00bb') + "\t",
                                              "Points to the scene the script is attached to."),
                               _scriptCurrentNormal,
                               GUILayout.ExpandWidth(false));

               GUILayout.Label(new GUIContent((scriptSceneName == string.Empty ? "(none)" : scriptSceneName),
                                              (scriptSceneName == string.Empty
                                                 ? "This script is not attached to any scene.  It may be used with Prefabs or as a Nested Script."
                                                 : "The name of the scene that the script is attached to.")),
                               (isScriptAttachToScene || scriptSceneName == string.Empty
                                  ? _scriptCurrentNormal
                                  : _scriptCurrentError));
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            {
               GUILayout.BeginHorizontal(_styleButtonGroup);
               {
                  if (isScriptNew == false)
                  {
                     // Source button
                     GUI.backgroundColor = (uScriptInstance.IsStale(_currentScriptName) ? UnityEngine.Color.red : UnityEngine.Color.white);
                     if (GUILayout.Button(uScriptGUIContent.buttonScriptSource, EditorStyles.miniButtonLeft))
                     {
                        uScriptGUI.PingGeneratedScript(_currentScriptName);
                     }
                     GUI.backgroundColor = UnityEngine.Color.white;
   
                     // Reload button
                     if (GUILayout.Button(uScriptGUIContent.buttonScriptReload, EditorStyles.miniButtonMid))
                     {
                        string path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, _currentScriptName_uScript);
   
                        if (path != string.Empty)
                        {
                           uScriptInstance.OpenScript(path);
                        }
                     }
                  }

                  // Save button
                  if (GUILayout.Button((uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick
                                          ? uScriptGUIContent.buttonScriptSaveQuick
                                          : (uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug
                                             ? uScriptGUIContent.buttonScriptSaveDebug
                                             : uScriptGUIContent.buttonScriptSaveRelease)),
                                       isScriptNew ? EditorStyles.miniButton : EditorStyles.miniButtonRight))
                  {
                     uScriptInstance.RequestSave(uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
                                                 uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug, false);
                  }
               }
               GUILayout.EndHorizontal();
            }
            GUILayout.EndHorizontal();


            //  It should turn red when you load a script that belongs to an unloaded scene
            //
            // Load a scene that has scripts associated with it.
            // Goto uscript and load associated script (all is well, not red).
            // make dirty and save (script turns red.  it shouldn't).
            //
            // Consider losing the red altogether


            //
            // Spacer
            //
            uScriptGUI.HR();


            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview");
            {
//               // Debug
//               if (debugScript.svOffset != _scrollviewOffset)
//               {
//                  Debug.Log("Offset delta: " + (_scrollviewOffset.y - debugScript.svOffset.y).ToString() + ", Event: " + Event.current.type.ToString() + "\n");
//               }
//               _debugScript.svOffset = _scrollviewOffset;


               // Commonly used variables
               List<string> keylist = new List<string>();
               keylist.AddRange(uScriptBackgroundProcess.s_uScriptInfo.Keys);
               string[] keys = keylist.ToArray();

               string scriptName = string.Empty;
               int listItem_count = 0;
               int listItem_yMin = 0;
               int listItem_yMax = 0;
               bool isListRowEven = false;


               // Apply the filter and determine how many items will be drawn.
               //
               foreach (string scriptFileName in keys)
               {
                  scriptName = System.IO.Path.GetFileNameWithoutExtension(scriptFileName);

                  if (scriptName != _currentScriptName                                 // is not the loaded script
                      && (String.IsNullOrEmpty(_panelFilterText)                       // there is no filter text
                          || scriptName.ToLower().Contains(_panelFilterText.ToLower()) // or the filter text matches the scriptName
                         )
                     )
                  {
                     listItem_count++;
                  }
               }

               // Draw the padding box to establish the row width (excluding scrollbar)
               // and force the scrollview content height
               //
               GUIStyle padding = new GUIStyle(GUIStyle.none);
               padding.stretchWidth = true;
//               padding.margin = new RectOffset();

               GUILayout.Box(string.Empty, padding, GUILayout.Height(ROW_HEIGHT * listItem_count));
               if (Event.current.type == EventType.Repaint)
               {
                  _previousRowWidth = GUILayoutUtility.GetLastRect().width;
               }


               // Prepare to draw each row of the filtered list
               //
               Rect rowRect = new Rect(0, 0, _previousRowWidth, ROW_HEIGHT);
               listItem_count = 0;

               // The following button rect are initialized in this specific
               // order, because later initializations refer to earlier ones.
               Rect rectLoadButton = new Rect(_previousRowWidth - _widthButtonLoad - BUTTON_PADDING, 1, _widthButtonLoad, BUTTON_HEIGHT);
               Rect rectSourceButton = new Rect(rectLoadButton.x - _widthButtonSource, 1, _widthButtonSource, BUTTON_HEIGHT);
               Rect rectLabelButton = new Rect(BUTTON_PADDING, 1, _previousRowWidth - _widthButtonSource - _widthButtonLoad - (BUTTON_PADDING * 3), ROW_HEIGHT);

               foreach (string scriptFileName in keys)
               {
                  scriptName = System.IO.Path.GetFileNameWithoutExtension(scriptFileName);
                  listItem_yMin = ROW_HEIGHT * listItem_count;
                  listItem_yMax = listItem_yMin + ROW_HEIGHT;

                  if (scriptName != _currentScriptName                                 // is not the loaded script
                      && (String.IsNullOrEmpty(_panelFilterText)                       // there is no filter text
                          || scriptName.ToLower().Contains(_panelFilterText.ToLower()) // or the filter text matches the scriptName
                         )
                     )
                  {
                     if (_scrollviewOffset.y <= listItem_yMax)
                     {
                        // draw
                        if (_scrollviewOffset.y + _scrollviewRect.height > listItem_yMin)
                        {
//                           _mListData_count++;
//                           _mListData_height = listItem_yMax - 0 - _tListData_height;

                           //
                           // draw the row normally
                           //

                           // the script path
                           string path = null;

                           // Draw the row background
                           if (isListRowEven && Event.current.type == EventType.Repaint)
                           {
                              uScriptGUIStyle.listRow.Draw(rowRect, false, false, true, false);
                           }

                           // uScript Label
                           scriptSceneName = "None";
                           if (!string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[scriptFileName].m_SceneName))
                           {
                              scriptSceneName = uScriptBackgroundProcess.s_uScriptInfo[scriptFileName].m_SceneName;
                           }

                           if (Event.current.type == EventType.Layout)
                           {
                              scriptName = string.Empty;
                           }

                           // prepare for double-click
                           bool wasClicked = false;
                           if (_clickedControl == scriptName)
                           {
                              if ((EditorApplication.timeSinceStartup - _clickTime) < _doubleClickTime)
                              {
                                 wasClicked = true;
                                 uScript.RequestRepaint();
                              }
                           }

                           // Source button
                           GUI.backgroundColor = (uScriptInstance.IsStale(scriptName) ? UnityEngine.Color.red : UnityEngine.Color.white);
                           if (GUI.Button(rectSourceButton, uScriptGUIContent.buttonScriptSource, _styleMiniButtonLeft))
                           {
                              uScriptGUI.PingGeneratedScript(scriptName);
                           }
                           GUI.backgroundColor = UnityEngine.Color.white;

                           // Load button
                           if (GUI.Button(rectLoadButton, uScriptGUIContent.buttonScriptLoad, _styleMiniButtonRight))
                           {
                              if ( null == path ) path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFileName);

                              if (false == string.IsNullOrEmpty(path))
                              {
                                 uScriptInstance.OpenScript(path);
                              }
                           }

                           // Script Label buton
                           if (GUI.Button(rectLabelButton, scriptName + (scriptSceneName == "None" ? string.Empty : " (" + scriptSceneName + ")"), (wasClicked ? _scriptListBold : _scriptListNormal)))
                           {
                              path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFileName);

                              if (wasClicked)
                              {
                                 // double-click
                                 _clickTime = EditorApplication.timeSinceStartup - _clickTime; // prevents multiple double-clicks
                                 if (false == string.IsNullOrEmpty(path))
                                 {
                                    uScriptInstance.OpenScript(path);
                                 }
                              }
                              else
                              {
                                 // single-click
                                 _clickTime = EditorApplication.timeSinceStartup;
                                 _clickedControl = scriptName;
                              }
                           }
                        }
//                        else
//                        {
//                           // skip the items below the viewable area
//                           _bListData_count++;
//                           _bListData_height = listItem_yMax - 0 - _tListData_height - _mListData_height;
//                        }
                     }
//                     else
//                     {
//                        // skip the items above the viewable area
//                        _tListData_count++;
//                        _tListData_height = listItem_yMax - 0;
//                     }


//                     // Debug
//                     _debugScript.Top = new Vector2(_tListData_count, _tListData_height);
//                     _debugScript.Middle = new Vector2(_mListData_count, _mListData_height);
//                     _debugScript.Bottom = new Vector2(_bListData_count, _bListData_height);


                     // Prepare for the next row
                     listItem_count++;
                     isListRowEven = !isListRowEven;
                     rowRect.y += ROW_HEIGHT;

                     rectLabelButton.y += ROW_HEIGHT;
                     rectLoadButton.y += ROW_HEIGHT;
                     rectSourceButton.y += ROW_HEIGHT;
                  }
               }

               // Display a message if there were no matches
               if (listItem_count == 0)
               {
                  GUIStyle style = new GUIStyle(EditorStyles.boldLabel);
                  style.alignment = TextAnchor.MiddleCenter;
                  GUILayout.Label("The search found no matches!", style);
               }
            }
            EditorGUILayout.EndScrollView();

            if (Event.current.type == EventType.Repaint)
            {
               _scrollviewRect = GUILayoutUtility.GetLastRect();
            }

//            _isMouseOverScrollview = _scrollviewRect.Contains(Event.current.mousePosition);
         }
      }
      EditorGUILayout.EndVertical();

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Script);
      uScriptInstance.SetMouseRegion(uScript.MouseRegion.Scripts);
   }
}
