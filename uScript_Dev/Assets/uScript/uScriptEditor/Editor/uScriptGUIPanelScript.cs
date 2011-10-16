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

   static Rect _previousHotRect = new Rect();
//   static int _previousHotIndex = 0;
//
   static Rect _scrollviewRect = new Rect();
//   static bool wasInside = false;

   static float _previousRowWidth = 0;
   static bool _isMouseOverScrollview = false;



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
                  }
               }

//               Debug.Log("Matches: " + filterMatches);

               GUIStyle padding = new GUIStyle(GUIStyle.none);
               padding.stretchWidth = true;
//               padding.margin = new RectOffset();



               // Draw the padding box to establish the row width (excluding scrollbar)
               // and force the scrollview content height
               GUILayout.Box(string.Empty, padding, GUILayout.Height(17 * filterMatches));
               if (Event.current.type == EventType.Repaint)
               {
                  _previousRowWidth = GUILayoutUtility.GetLastRect().width;
               }

               // Prepare to draw the rows
               Rect r = new Rect(0, 0, _previousRowWidth, 17);
               filterMatches = 0;

               foreach (string scriptFile in keys)
               {
                  scriptName = System.IO.Path.GetFileNameWithoutExtension(scriptFile);

                  if (scriptName != _currentScriptName                                          // is not the loaded script
                       && ( String.IsNullOrEmpty(_panelScriptFilterText)                        // there is no filter text
                            || scriptName.ToLower().Contains(_panelScriptFilterText.ToLower())  // or the filter text matches the scriptName
                          )
                     )
                  {
                     filterMatches++;
                     // the script path
                     string path = null;

                     // Draw the row background
                     if (_isListRowEven && Event.current.type == EventType.Repaint)
                     {
                        uScriptGUIStyle.listRow.Draw(r, false, false, true, false);
                     }

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

                     // Handle mouse hovering
                     if (_isMouseOverScrollview && r.Contains(Event.current.mousePosition))
                     {
                        if (_previousHotRect != r)
                        {
                           _previousHotRect = r;
                           uScript.Instance.Repaint();
                        }

                        Rect buttonRect = new Rect(r);
                        buttonRect.x = buttonRect.xMax - 81;
                        buttonRect.width = 43;

                        // Source
                        if (GUI.Button(buttonRect, uScriptGUIContent.buttonScriptSource, _styleMiniButtonLeft))
                        {
                           uScriptGUI.PingGeneratedScript(scriptName);
                        }

                        buttonRect.x += 43;
                        buttonRect.width = 34;
                        // Load
                        if (GUI.Button(buttonRect, uScriptGUIContent.buttonScriptLoad, _styleMiniButtonRight))
                        {
                           if ( null == path ) path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFile);

                           if (false == string.IsNullOrEmpty(path))
                           {
                              uScriptInstance.OpenScript(path);
                           }
                        }

                        r.width = _previousRowWidth - 85;
                     }

                     // Draw the script button
                     if (GUI.Button(r, scriptName + (sceneName == "None" ? string.Empty : " (" + sceneName + ")"), (wasClicked ? _scriptListBold : _scriptListNormal)))
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

                     // Prepare for the next row
                     _isListRowEven = !_isListRowEven;
                     r.width = _previousRowWidth;
                     r.y += r.height;
                  }
               }

               // Display a message if there were no matches
               if (filterMatches == 0)
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

            _isMouseOverScrollview = _scrollviewRect.Contains(Event.current.mousePosition);
         }
      }
      EditorGUILayout.EndVertical();

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Script);
      uScriptInstance.SetMouseRegion(uScript.MouseRegion.Scripts);
   }
}
