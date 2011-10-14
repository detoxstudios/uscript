using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using Detox.Drawing;
using System.Reflection;

using Detox.ScriptEditor;
using Detox.FlowChart;

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

   String _panelScriptFilterText = string.Empty;




   //
   // Members specific to this panel class
   //
   const double _doubleClickTime = 0.5; // default in Windows OS is 500ms
   double _clickTime;
   string _clickedControl = string.Empty;

   string _currentScriptName = string.Empty;
   string _currentScriptName_uScript = string.Empty;

   GUIStyle _scriptCurrentNormal = null;
   GUIStyle _scriptCurrentError = null;
   GUIStyle _scriptListNormal = null;
   GUIStyle _scriptListBold = null;

   GUIStyle _styleMiniButtonLeft = null;
   GUIStyle _styleMiniButtonRight = null;

//   static Rect _previousHotRect = new Rect();
//   static int _previousHotIndex = 0;
//
//   static Rect _scrollviewRect = new Rect();
//   static bool wasInside = false;




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



            if (_scriptCurrentNormal == null)
            {
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
            }



            string sceneName = string.Empty;



            //
            // Current script
            //
            GUILayout.BeginHorizontal();
            {
               if (_currentScriptName_uScript != m_ScriptEditorCtrl.ScriptName)
               {
                  _currentScriptName_uScript = m_ScriptEditorCtrl.ScriptName;
                  _currentScriptName = System.IO.Path.GetFileNameWithoutExtension(_currentScriptName_uScript);
               }

               // uScript Label
               sceneName = string.Empty;
               if (uScriptBackgroundProcess.s_uScriptInfo.ContainsKey(_currentScriptName_uScript))
               {
                  if (string.IsNullOrEmpty(uScriptBackgroundProcess.s_uScriptInfo[_currentScriptName_uScript].m_SceneName) == false)
                  {
                     sceneName = uScriptBackgroundProcess.s_uScriptInfo[_currentScriptName_uScript].m_SceneName;
                  }
               }

               bool isScriptNew = String.IsNullOrEmpty(_currentScriptName_uScript);
               bool isScriptAttachToScene = (sceneName == System.IO.Path.GetFileNameWithoutExtension(UnityEditor.EditorApplication.currentScene));
               bool isScriptDirty = m_ScriptEditorCtrl.IsDirty;

               GUILayout.Label(// Label
                               ( (isScriptNew ? "(new)" : _currentScriptName)
                                 + (isScriptDirty ? " *" : string.Empty) ),
                               // Style
                               (isScriptAttachToScene ? _scriptCurrentNormal : _scriptCurrentError)
                              );

               GUILayout.FlexibleSpace();

               if (isScriptNew == false)
               {
                  // Source
                  if (GUILayout.Button(uScriptGUIContent.buttonScriptSource, EditorStyles.miniButtonLeft, GUILayout.ExpandWidth(false)))
                  {
                     uScriptGUI.PingGeneratedScript(_currentScriptName);
                  }

                  // Reload
                  if (GUILayout.Button(uScriptGUIContent.buttonScriptReload, EditorStyles.miniButtonMid))
                  {
                     string path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, _currentScriptName_uScript);

                     if (path != string.Empty)
                     {
                        uScriptInstance.OpenScript(path);
                     }
                  }
               }

               if (GUILayout.Button(uScriptGUIContent.buttonScriptSave, isScriptNew ? EditorStyles.miniButton : EditorStyles.miniButtonRight))
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
               //
               // Filtered script list
               //
               List<string> keylist = new List<string>();
               keylist.AddRange(uScriptBackgroundProcess.s_uScriptInfo.Keys);
               string[] keys = keylist.ToArray();

               string scriptName = string.Empty;
               int filterMatches = 0;
               bool _isListRowEven = false;
//               bool _wereButtonsDrawn = false;

               foreach (string scriptFile in keys)
               {
                  scriptName = System.IO.Path.GetFileNameWithoutExtension(scriptFile);

                  if ( // is not the loaded script
                       scriptName != _currentScriptName
                       && ( // there is no filter text
                            String.IsNullOrEmpty(_panelScriptFilterText)
                            // or the filter text matches the scriptName
                            || scriptName.ToLower().Contains(_panelScriptFilterText.ToLower())
                          )
                     )
                  {
                     filterMatches++;

                     // the script path
                     string path = null;

                     GUILayout.BeginHorizontal((_isListRowEven ? uScriptGUIStyle.scriptRowEven : uScriptGUIStyle.scriptRowOdd));
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
                        if (_clickedControl == scriptName)
                        {
                           if ((EditorApplication.timeSinceStartup - _clickTime) < _doubleClickTime)
                           {
                              wasClicked = true;
                              uScript.Instance.Redraw();
                           }
                        }

                        if (GUILayout.Button(scriptName + (sceneName == "None" ? string.Empty : " (" + sceneName + ")"), (wasClicked ? _scriptListBold : _scriptListNormal), GUILayout.ExpandWidth(true)))
                        {
                           path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFile);
   
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

//                        if (filterMatches == _previousHotIndex)
//                        {
//                           GUILayout.Space(85);
//                        }

                        // Source
                        if (GUILayout.Button(uScriptGUIContent.buttonScriptSource, _styleMiniButtonLeft, GUILayout.ExpandWidth(false)))
                        {
                           uScriptGUI.PingGeneratedScript(scriptName);
                        }

                        // Load
                        if (GUILayout.Button(uScriptGUIContent.buttonScriptLoad, _styleMiniButtonRight, GUILayout.ExpandWidth(false)))
                        {
                           if ( null == path ) path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFile);

                           if (false == string.IsNullOrEmpty(path))
                           {
                              uScriptInstance.OpenScript(path);
                           }
                        }
                     }
                     GUILayout.EndHorizontal();

//                     // When the mouse is over the row
//                     Rect row = GUILayoutUtility.GetLastRect();
//                     if (row.Contains(Event.current.mousePosition))
//                     {
//                        // Draw once if the row has changed
//                        if (_previousHotRect != row)
//                        {
//                           Debug.Log("HOVER over " + scriptName + ", Repaint: " + Event.current.type + "\n");
//                           _previousHotRect = row;
//                           _previousHotIndex = filterMatches;
//                           uScript.Instance.Repaint();
//                        }
//
//                        Rect btnRect = row;
//                        btnRect.x = btnRect.xMax - 4;
//                        btnRect.y += 1;
//                        btnRect.height = 15;
//
//                        // Load
//                        btnRect.width = 34;
//                        btnRect.x -= btnRect.width;
//                        if (GUI.Button(btnRect, uScriptGUIContent.buttonScriptLoad, EditorStyles.miniButtonRight))
//                        {
//                           if ( null == path ) path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFile);
//
//                           if (false == string.IsNullOrEmpty(path))
//                           {
//                              uScriptInstance.OpenScript(path);
//                           }
//                        }
//
//                        // Source
//                        btnRect.width = 43;
//                        btnRect.x -= btnRect.width;
//                        if (GUI.Button(btnRect, uScriptGUIContent.buttonScriptSource, EditorStyles.miniButtonLeft))
//                        {
//                           uScriptGUI.PingGeneratedScript(scriptName);
//                        }
//
//                        _wereButtonsDrawn = true;
//                        wasInside = true;
//                     }
//
//                     if (_scrollviewRect.Contains(Event.current.mousePosition) == false)
//                     {
//                        if (wasInside && (Event.current.type != EventType.Repaint && Event.current.type != EventType.MouseMove))
//                        {
//                           wasInside = false;
//                           Debug.Log("OUT Repaint: " + GUIUtility.hotControl + "\n");
//                           _previousHotRect = new Rect();
//                           _previousHotIndex = 0;
//                           uScript.Instance.Repaint();
//                        }
//                     }

                     _isListRowEven = !_isListRowEven;
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

//            if (Event.current.type == EventType.Repaint)
//            {
//               _scrollviewRect = GUILayoutUtility.GetLastRect();
//            }
         }
      }
      EditorGUILayout.EndVertical();

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Script);
      uScriptInstance.SetMouseRegion(uScript.MouseRegion.Scripts);
   }


}
