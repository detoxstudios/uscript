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
   const double _doubleClickTime = 0.5; // default in Windows OS is 500ms
   double _clickTime;
   string _clickedControl = string.Empty;

   string _currentScriptName = string.Empty;
   string _currentScriptName_uScript = string.Empty;

   GUIStyle _scriptStyleNormal = null;
   GUIStyle _scriptStyleBold = null;
   GUIStyle _scriptStyleError = null;




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



            if (_scriptStyleNormal == null)
            {
               _scriptStyleNormal = new GUIStyle(EditorStyles.label);

               _scriptStyleBold = new GUIStyle(EditorStyles.label);
               _scriptStyleBold.fontStyle = FontStyle.Bold;

               _scriptStyleError = new GUIStyle(EditorStyles.label);
               _scriptStyleError.fontStyle = FontStyle.Bold;
               _scriptStyleError.normal.textColor = UnityEngine.Color.red;
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
                               (isScriptAttachToScene ? _scriptStyleBold : _scriptStyleError)
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
                        if (_clickedControl == scriptName)
                        {
                           if ((EditorApplication.timeSinceStartup - _clickTime) < _doubleClickTime)
                           {
                              wasClicked = true;
                              uScript.Instance.Redraw();
                           }
                        }

                        // the script path
                        string path = null;

                        if (GUILayout.Button(scriptName + (sceneName == "None" ? string.Empty : " (" + sceneName + ")"), (wasClicked ? _scriptStyleBold : _scriptStyleNormal), GUILayout.ExpandWidth(true)))
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

                        // Source
                        if (GUILayout.Button(uScriptGUIContent.buttonScriptSource, EditorStyles.miniButtonLeft, GUILayout.ExpandWidth(false)))
                        {
                           uScriptGUI.PingGeneratedScript(scriptName);
                        }

                        // Load
                        if (GUILayout.Button(uScriptGUIContent.buttonScriptLoad, EditorStyles.miniButtonRight, GUILayout.ExpandWidth(false)))
                        {
                           if ( null == path ) path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFile);

                           if (false == string.IsNullOrEmpty(path))
                           {
                              uScriptInstance.OpenScript(path);
                           }
                        }

//                        // Insert as Nested uScript
//                        if (GUILayout.Button(_contentInsert, EditorStyles.miniButtonRight, GUILayout.ExpandWidth(false)))
//                        {
//                           if (m_ScriptEditorCtrl != null)
//                           {
//                              float canvasX = uScriptInstance._mouseRegionRect[uScript.MouseRegion.Canvas].x;
//                              float canvasY = uScriptInstance._mouseRegionRect[uScript.MouseRegion.Canvas].y;
//                              m_ScriptEditorCtrl.ContextCursor = new Point((int)(canvasX - uScriptInstance._guiPanelPalette_Width + uScript.Instance.NodeWindowRect.width / 2.0f), (int)(canvasY + uScript.Instance.NodeWindowRect.height / 2.0f));
//                              m_ScriptEditorCtrl.AddVariableNode(m_ScriptEditorCtrl.GetLogicNode(scriptName));
//                           }
//                        }
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
      uScriptInstance.SetMouseRegion(uScript.MouseRegion.Scripts);
   }


}
