// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUIPanelScript.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptGUIPanelScript type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using UnityEditor;

using UnityEngine;

public sealed class uScriptGUIPanelScript : uScriptGUIPanel
{
   private const double DoubleClickTime = 0.5; // default in Windows OS is 500ms
   private const int RowHeight = 17;
   private const int ButtonHeight = 15;
   private const int ButtonPadding = 4;

   private static uScriptGUIPanelScript instance = new uScriptGUIPanelScript();
   private static Rect scrollviewRect;
   private static float previousRowWidth;

   private string panelFilterText = string.Empty;

   private double clickTime;
   private string clickedControl = string.Empty;

   private string currentScriptName = string.Empty;
   private string currentScriptFileName = string.Empty;

   private GUIStyle styleButtonGroup;
   private GUIStyle styleCurrentScriptNormal;
   private GUIStyle styleCurrentScriptError;
   private GUIStyle styleScriptListNormal;
   private GUIStyle styleScriptListBold;
   private GUIStyle styleMiniButtonLeft;
   private GUIStyle styleMiniButtonRight;

   private int widthButtonSource;
   private int widthButtonLoad;

   private uScriptGUIPanelScript()
   {
      this.Init();
   }

   public static uScriptGUIPanelScript Instance
   {
      get
      {
         return instance;
      }
   }

   public void Init()
   {
      this._name = "uScripts";
//      _size = 150;
//      _region = uScriptGUI.Region.Script;

      this.styleCurrentScriptNormal = new GUIStyle(EditorStyles.boldLabel);

      this.styleCurrentScriptError = new GUIStyle(this.styleCurrentScriptNormal)
      {
         normal = { textColor = Color.red }
      };

      this.styleScriptListNormal = new GUIStyle(EditorStyles.label)
      {
         margin = new RectOffset(4, 4, 1, 1),
         padding = new RectOffset(2, 2, 0, 0)
      };

      this.styleScriptListBold = new GUIStyle(this.styleScriptListNormal) { fontStyle = FontStyle.Bold };

      this.styleMiniButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft) { margin = new RectOffset(4, 0, 1, 1) };

      this.styleMiniButtonRight = new GUIStyle(EditorStyles.miniButtonRight) { margin = new RectOffset(0, 4, 1, 1) };

      this.styleButtonGroup = new GUIStyle { margin = { top = 2 } };

      // Get the width of the buttons, since the content
      // under Windows has a different size then under Mac
      this.widthButtonSource = (int)this.styleMiniButtonLeft.CalcSize(uScriptGUIContent.buttonNodeSource).x;
      this.widthButtonLoad = (int)this.styleMiniButtonRight.CalcSize(uScriptGUIContent.buttonScriptLoad).x;
   }

   public void Update()
   {
      // Called whenever member data should be updated
   }

   public override void Draw()
   {
      // Called during OnGUI()

      // Local references to uScript
      var uScriptInstance = uScript.Instance;
      var scriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;

      var rect = EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox, GUILayout.Width(uScriptGUI.PanelScriptsWidth));
      if ((int)rect.width != 0 && (int)rect.width != uScriptGUI.PanelScriptsWidth)
      {
         // if we didn't get the width we requested, we must have hit a limit, stop dragging and reset the width
         uScriptGUI.PanelScriptsWidth = (int)rect.width;
         uScript.Instance.MouseDownRegion = uScript.MouseRegion.Canvas;
         uScript.Instance.ForceReleaseMouse();
      }
      else if (rect.x + rect.width > uScript.Instance.position.width)
      {
         // panel is growing off the edge of the window, bring it back in and stop dragging
         uScriptGUI.PanelScriptsWidth = (int)(uScript.Instance.position.width - rect.x);
         uScript.Instance.MouseDownRegion = uScript.MouseRegion.Canvas;
         uScript.Instance.ForceReleaseMouse();
      }

      {
         // Toolbar
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            GUILayout.Label(this._name, uScriptGUIStyle.PanelTitle, GUILayout.ExpandWidth(true));

            GUILayout.FlexibleSpace();

            GUI.SetNextControlName("ScriptFilterSearch");

            var filterText = uScriptGUI.ToolbarSearchField(this.panelFilterText, GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
            if (filterText != this.panelFilterText)
            {
               // Drop focus if the user inserted a newline (hit enter)
               if (filterText.Contains("\n"))
               {
                  GUIUtility.keyboardControl = 0;
               }

               // Trim leading whitespace
               filterText = filterText.TrimStart(new[] { ' ' });

               this.panelFilterText = filterText;
            }
         }

         EditorGUILayout.EndHorizontal();

         if (uScriptInstance.wasCanvasDragged && uScript.Preferences.DrawPanelsOnUpdate == false)
         {
            this.DrawHiddenNotification();
         }
         else
         {
            // Update the panel in the following manner:
            //    Display the current active script first
            //    List the scene the script is associated with
            //    List error messages
            //    Display some type of separator
            //    Display all other scripts in the project (except the active script)
            //    Filter the list
            //    Support foldout containers eventually

            var currentSceneName = System.IO.Path.GetFileNameWithoutExtension(EditorApplication.currentScene);

            // Current script
            if (this.currentScriptFileName != scriptEditorCtrl.ScriptName)
            {
               this.currentScriptFileName = scriptEditorCtrl.ScriptName;
               this.currentScriptName = System.IO.Path.GetFileNameWithoutExtension(this.currentScriptFileName);
            }

            if (null == this.currentScriptFileName)
            {
               this.currentScriptFileName = string.Empty;
            }

            // uScript Label
            string scriptSceneName = string.Empty;
            if (uScriptBackgroundProcess.GraphInfoList.ContainsKey(this.currentScriptFileName))
            {
               if (string.IsNullOrEmpty(uScriptBackgroundProcess.GraphInfoList[this.currentScriptFileName].SceneName) == false)
               {
                  scriptSceneName = uScriptBackgroundProcess.GraphInfoList[this.currentScriptFileName].SceneName;
               }
            }

            var isScriptNew = string.IsNullOrEmpty(this.currentScriptFileName);
            var isScriptAttachToScene = scriptSceneName == currentSceneName;
            var isScriptDirty = scriptEditorCtrl.IsDirty;

            GUILayout.Label(
               (isScriptNew ? "(new)" : this.currentScriptName) + (isScriptDirty ? " *" : string.Empty),
               this.styleCurrentScriptNormal);

            GUILayout.BeginHorizontal();
            {
               // '\u21b3' // DOWNWARDS ARROW WITH TIP RIGHTWARDS
               // '\u21aa' // RIGHTWARDS ARROW WITH HOOK
               // '\u293f' // LOWER LEFT SEMICIRCULAR ANTICLOCKWISE ARROW
               // '\u2937' // ARROW POINTING DOWNWARDS THEN CURVING RIGHTWARDS
               GUILayout.Label(
                  new GUIContent(
                     (Application.platform == RuntimePlatform.OSXEditor ? '\u21aa' : '\u00bb') + "\t",
                     "Points to the scene the script is attached to."),
                     this.styleCurrentScriptNormal,
                     GUILayout.ExpandWidth(false));

               var text = scriptSceneName == string.Empty ? "(none)" : scriptSceneName;
               var tooltip = scriptSceneName == string.Empty
                  ? "This script is not attached to any scene.  It may be used with Prefabs or as a Nested Script."
                  : "The name of the scene that the script is attached to.";
               var style = isScriptAttachToScene || scriptSceneName == string.Empty
                  ? this.styleCurrentScriptNormal
                  : this.styleCurrentScriptError;

               GUILayout.Label(new GUIContent(text, tooltip), style);
            }

            GUILayout.EndHorizontal();

            GUIContent contentSourceButton;

            GUILayout.BeginHorizontal();
            {
               GUILayout.BeginHorizontal(this.styleButtonGroup);
               {
                  if (isScriptNew == false)
                  {
                     // Source button
                     if (uScriptInstance.IsStale(this.currentScriptName))
                     {
                        contentSourceButton = uScriptGUIContent.buttonScriptSourceStale;
                        GUI.backgroundColor = Color.red;
                     }
                     else if (uScriptInstance.HasDebugCode(this.currentScriptName))
                     {
                        contentSourceButton = uScriptGUIContent.buttonScriptSourceDebug;
                        GUI.backgroundColor = Color.yellow;
                     }
                     else
                     {
                        contentSourceButton = uScriptGUIContent.buttonScriptSource;
                     }

                     if (GUILayout.Button(contentSourceButton, EditorStyles.miniButtonLeft))
                     {
                        uScriptGUI.PingGeneratedScript(this.currentScriptName);
                     }

                     GUI.backgroundColor = Color.white;

                     // Reload button
                     if (GUILayout.Button(uScriptGUIContent.buttonScriptReload, EditorStyles.miniButtonMid))
                     {
                        var path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, this.currentScriptFileName);
   
                        if (path != string.Empty)
                        {
                           uScriptInstance.OpenScript(path);
                        }
                     }
                  }

                  // Save button
                  if (
                     GUILayout.Button(
                        uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick
                           ? uScriptGUIContent.buttonScriptSaveQuick
                           : (uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug
                              ? uScriptGUIContent.buttonScriptSaveDebug
                              : uScriptGUIContent.buttonScriptSaveRelease),
                        isScriptNew ? EditorStyles.miniButton : EditorStyles.miniButtonRight))
                  {
                     uScriptInstance.RequestSave(
                        uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Quick,
                        uScript.Preferences.SaveMethod == Preferences.SaveMethodType.Debug,
                        false);
                  }
               }

               GUILayout.EndHorizontal();
            }

            GUILayout.EndHorizontal();

            //  It should turn red when you load a script that belongs to an unloaded scene
            // Load a scene that has scripts associated with it.
            // Goto uscript and load associated script (all is well, not red).
            // make dirty and save (script turns red.  it shouldn't).
            // Consider losing the red altogether

            // Spacer
            uScriptGUI.HR();

            this._scrollviewOffset = EditorGUILayout.BeginScrollView(this._scrollviewOffset, false, false, uScriptGUIStyle.HorizontalScrollbar, uScriptGUIStyle.VerticalScrollbar, "scrollview");
            {
               var keylist = new List<string>();
               keylist.AddRange(uScriptBackgroundProcess.GraphInfoList.Keys);
               var keys = keylist.ToArray();

               string scriptName;
               var listItemCount = 0;
               var isListRowEven = false;

               // Apply the filter and determine how many items will be drawn.
               foreach (var scriptFileName in keys)
               {
                  scriptName = System.IO.Path.GetFileNameWithoutExtension(scriptFileName);

                  // is not the loaded script
                  // there is no filter text
                  // or the filter text matches the scriptName
                  if (scriptName != this.currentScriptName
                      && (string.IsNullOrEmpty(this.panelFilterText)
                          || scriptName.ToLower().Contains(this.panelFilterText.ToLower())))
                  {
                     listItemCount++;
                  }
               }

               // Draw the padding box to establish the row width (excluding scrollbar)
               // and force the scrollview content height
               var padding = new GUIStyle(GUIStyle.none) { stretchWidth = true };

               GUILayout.Box(string.Empty, padding, GUILayout.Height(RowHeight * listItemCount));
               if (Event.current.type == EventType.Repaint)
               {
                  previousRowWidth = GUILayoutUtility.GetLastRect().width;
               }

               // Prepare to draw each row of the filtered list
               var rowRect = new Rect(0, 0, previousRowWidth, RowHeight);
               listItemCount = 0;

               // The following button rect are initialized in this specific
               // order, because later initializations refer to earlier ones.
               var rectLoadButton = new Rect(previousRowWidth - this.widthButtonLoad - ButtonPadding, 1, this.widthButtonLoad, ButtonHeight);
               var rectSourceButton = new Rect(rectLoadButton.x - this.widthButtonSource, 1, this.widthButtonSource, ButtonHeight);
               var rectLabelButton = new Rect(ButtonPadding, 1, previousRowWidth - this.widthButtonSource - this.widthButtonLoad - (ButtonPadding * 3), RowHeight);

               foreach (var scriptFileName in keys)
               {
                  scriptName = System.IO.Path.GetFileNameWithoutExtension(scriptFileName);
                  var listItemMinY = RowHeight * listItemCount;
                  var listItemMaxY = listItemMinY + RowHeight;

                  // Check that:
                  // is not the loaded script
                  // there is no filter text
                  // or the filter text matches the scriptName
                  if (scriptName != this.currentScriptName
                      && (string.IsNullOrEmpty(this.panelFilterText)
                          || scriptName.ToLower().Contains(this.panelFilterText.ToLower())))
                  {
                     if (_scrollviewOffset.y <= listItemMaxY)
                     {
                        // draw
                        if (_scrollviewOffset.y + scrollviewRect.height > listItemMinY)
                        {
                           // the script path
                           string path = null;

                           // Draw the row background
                           if (isListRowEven && Event.current.type == EventType.Repaint)
                           {
                              uScriptGUIStyle.ListRow.Draw(rowRect, false, false, true, false);
                           }

                           // uScript Label
                           scriptSceneName = "None";
                           if (!string.IsNullOrEmpty(uScriptBackgroundProcess.GraphInfoList[scriptFileName].SceneName))
                           {
                              scriptSceneName = uScriptBackgroundProcess.GraphInfoList[scriptFileName].SceneName;
                           }

                           if (Event.current.type == EventType.Layout)
                           {
                              scriptName = string.Empty;
                           }

                           // prepare for double-click
                           bool wasClicked = false;
                           if (this.clickedControl == scriptName)
                           {
                              if ((EditorApplication.timeSinceStartup - this.clickTime) < DoubleClickTime)
                              {
                                 wasClicked = true;
                                 uScript.RequestRepaint();
                              }
                           }

                           // Source button
                           if (uScriptInstance.IsStale(scriptName))
                           {
                              contentSourceButton = uScriptGUIContent.buttonScriptSourceStale;
                              GUI.backgroundColor = Color.red;
                           }
                           else if (uScriptInstance.HasDebugCode(scriptName))
                           {
                              contentSourceButton = uScriptGUIContent.buttonScriptSourceDebug;
                              GUI.backgroundColor = Color.yellow;
                           }
                           else
                           {
                              contentSourceButton = uScriptGUIContent.buttonScriptSource;
                           }

                           if (GUI.Button(rectSourceButton, contentSourceButton, this.styleMiniButtonLeft))
                           {
                              uScriptGUI.PingGeneratedScript(scriptName);
                           }

                           GUI.backgroundColor = Color.white;

                           // Load button
                           if (GUI.Button(rectLoadButton, uScriptGUIContent.buttonScriptLoad, this.styleMiniButtonRight))
                           {
                              if (null == path)
                              {
                                 path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFileName);
                              }

                              if (false == string.IsNullOrEmpty(path))
                              {
                                 uScriptInstance.OpenScript(path);
                              }
                           }

                           // Script Label buton
                           if (GUI.Button(rectLabelButton, scriptName + (scriptSceneName == "None" ? string.Empty : " (" + scriptSceneName + ")"), wasClicked ? this.styleScriptListBold : this.styleScriptListNormal))
                           {
                              path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFileName);

                              if (wasClicked)
                              {
                                 // double-click
                                 this.clickTime = EditorApplication.timeSinceStartup - this.clickTime; // prevents multiple double-clicks
                                 if (false == string.IsNullOrEmpty(path))
                                 {
                                    uScriptInstance.OpenScript(path);
                                 }
                              }
                              else
                              {
                                 // single-click
                                 this.clickTime = EditorApplication.timeSinceStartup;
                                 this.clickedControl = scriptName;
                              }
                           }
                        }
                     }

                     // Prepare for the next row
                     listItemCount++;
                     isListRowEven = !isListRowEven;
                     rowRect.y += RowHeight;

                     rectLabelButton.y += RowHeight;
                     rectLoadButton.y += RowHeight;
                     rectSourceButton.y += RowHeight;
                  }
               }

               // Display a message if there were no matches
               if (listItemCount == 0)
               {
                  var style = new GUIStyle(EditorStyles.boldLabel) { alignment = TextAnchor.MiddleCenter };
                  GUILayout.Label("The search found no matches!", style);
               }
            }

            EditorGUILayout.EndScrollView();

            if (Event.current.type == EventType.Repaint)
            {
               scrollviewRect = GUILayoutUtility.GetLastRect();
            }
         }
      }

      EditorGUILayout.EndVertical();

//      uScriptGUI.DefineRegion(uScriptGUI.Region.Script);
      uScriptInstance.SetMouseRegion(uScript.MouseRegion.Scripts);
   }
}
