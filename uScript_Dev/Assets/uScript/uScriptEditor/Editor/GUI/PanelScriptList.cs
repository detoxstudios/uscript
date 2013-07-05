// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PanelScriptList.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PanelScript type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System;
   using System.Collections.Generic;
   using System.IO;
   using System.Linq;

   using UnityEditor;
   using UnityEngine;

   public sealed partial class PanelScript
   {
      private class PanelScriptList
      {
         // TODO: The default ListViewItem renderer should first draw the row, followed by each
         //       column using specified Rects. Each column will look for a property with a name
         //       that matches the column ID.  If one is found, the property value is printed as
         //       a string.
         //
         //       Custom ListViewItem renderers can do whatever they would like with regards to
         //       associating data with a particular column and how the data is represented.

         // Make the Script list a standard selectable ListView
         // One item can be selected at a time
         // If selected item is a script, allow
         //    View Source
         //    Rebuild Source
         //    Remove Generated Source
         //    Load
         // ListView contains multiple columns with headers
         //    Source Status
         //    Script name
         //    Scene script is attached to
         // Double-clicking the list item will execute the Load action
         // Support foldouts
         // Support column sort

         // === Constants ==================================================================

         // === Fields =====================================================================

         private readonly ListView listView;
         private string filterText = string.Empty;

         // === Constructors ===============================================================

         public PanelScriptList()
         {
            uScriptInstance = uScript.Instance;

            //this.listView = new ListView(ListViewEditor.Instance, typeof(ListViewItem_Script));
            this.listView = new ListView(uScript.Instance)
            {
               ForceHorizontalColumnFit = true,
               ShowColumnHeaders = true,
               SortByColumn = true,
               MultiSelectEnabled = false
            };

            //this.CreateColumns();
         }

         // === Properties =================================================================

         // === Methods ====================================================================

         public void Draw()
         {
            //if (this.listView.PendingExecution != null)
            //{
            //   Debug.Log("EXECUTE LOAD of \"" + this.listView.PendingExecution.Path + "\"\n");
            //   this.listView.PendingExecution = null;
            //}

            var rectPanel = EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox, GUILayout.ExpandHeight(true));
            {
               //Event e = Event.current;

               //if (e.type == EventType.MouseDown || e.type == EventType.Used)
               //{

               //   //Focused = EditorWindow.focusedWindow && rectPanel.Contains(e.mousePosition);
               //   bool newFocus = ((GUIUtility.keyboardControl == 0) && rectPanel.Contains(e.mousePosition));
               //   if (newFocus == false && newFocus != _listView.hasFocus)
               //   {
               //      // check hotcontrol too
               //      Debug.Log("REPAINT\n");
               //      ListViewEditor.Instance.Repaint();
               //   }

               //   //Debug.Log("FOCUS: " + _listView.hasFocus.ToString() + ", KEYBOARD CONTROL: " + GUIUtility.keyboardControl.ToString() + ", EVENT: " + e.ToString() + "\n");
               //   Debug.Log("FOCUS: " + _listView.hasFocus.ToString() + ",\t\t" + "keyboardControl: " + GUIUtility.keyboardControl.ToString() + "\t\tEventType: " + e.type.ToString()
               //      + "\n" + "\t\t\t\t\t\t" + "hotControl: " + GUIUtility.hotControl.ToString() + "\t\t\t\t\t" + "FocusChanged: " + (newFocus != _listView.hasFocus).ToString());

               //   _listView.hasFocus = newFocus;
               //}

               this.DrawDirectoryPanelToolbar();

               if (uScriptInstance.wasCanvasDragged && uScript.Preferences.DrawPanelsOnUpdate == false)
               {
                  Instance.DrawHiddenNotification();
               }
               else
               {
                  //this.listView.Draw(rectPanel);
                  this.DrawOld(rectPanel);
               }

               //// Update the listview focus
               //if (e.type == EventType.MouseDown || e.type == EventType.Used)
               //{
               //   bool newFocus = ((GUIUtility.keyboardControl == 0) && rectPanel.Contains(e.mousePosition));
               //   if (newFocus != _listView.hasFocus)
               //   {
               //      ListViewEditor.Instance.Repaint();
               //   }
               //   _listView.hasFocus = newFocus;
               //}
            }

            EditorGUILayout.EndVertical();
         }

         public void RebuildListContents()
         {
            if (this.listView == null)
            {
               uScriptDebug.Log("The ListView must be initialized before items can be added.", uScriptDebug.Type.Error);
               return;
            }

            // Read graph files from subfolders
            var fileNames = GetFileList(uScript.Preferences.UserScripts, "*.uscript");

            // Build the flat list of scripts
            foreach (var filename in fileNames)
            {
               this.listView.AddItem(filename.Replace(uScript.Preferences.UserScripts + "/", string.Empty));
            }

            // Mark the hierarchy dirty so that the hierarchy can be rebuilt and filtering and sorting can be applied
            this.listView.RebuildListHierarchy();
         }

         private static IEnumerable<string> GetFileList(string baseDir, string searchPattern)
         {
            var directories = new List<string>();
            var files = new List<string>();

            directories.Add(baseDir);

            while (directories.Count > 0)
            {
               string directory = directories[0];
               directories.RemoveAt(0);

               try
               {
                  files.AddRange(Directory.GetFiles(directory, searchPattern).Select(fileName => fileName.Replace('\\', '/')));

                  //foreach (string fileName in Directory.GetFiles(directory, searchPattern))
                  //{
                  //   files.Add(fileName.Replace('\\', '/'));
                  //}
               }
               catch (Exception e)
               {
                  uScriptDebug.Log(string.Format("Unable to access directory: \"{0}\"\n{1}", directory, e), uScriptDebug.Type.Error);
                  return files;
               }

               directories.AddRange(Directory.GetDirectories(directory).Select(directoryName => directoryName.Replace('\\', '/')));

               //foreach (string directoryName in Directory.GetDirectories(directory))
               //{
               //   directories.Add(directoryName.Replace('\\', '/'));
               //}
            }

            return files;
         }

         private void CreateColumns()
         {
            var column = new ListViewColumn("graph")
            {
               Content = new GUIContent("Graph"),
               LayoutMethod = ListViewColumn.LayoutMethodOption.Custom,
               MinWidth = 100,
               MaxWidth = 250,
               Width = 150
               //IsSelectable = false
               //IsSelectable = true
            };
            this.listView.AddColumn(column);

            column = new ListViewColumn("scene")
            {
               Content = new GUIContent("Scene"),
               LayoutMethod = ListViewColumn.LayoutMethodOption.Fluid,
               MinWidth = 50,
               MaxWidth = 250,
               Width = 150
               //IsSelectable = false
               //IsSelectable = true,
               //IsSortDirectionFixed = true
            };
            this.listView.AddColumn(column);

            //column = new ListViewColumn("temp1")
            //{
            //   Content = new GUIContent("temp1"),
            //   LayoutMethod = ListViewColumn.LayoutMethodOption.Fluid,
            //   MinWidth = 20,
            //   MaxWidth = 30,
            //   Width = 20
            //};
            //this.listView.AddColumn(column);

            //column = new ListViewColumn("temp2")
            //{
            //   Content = new GUIContent("temp2"),
            //   LayoutMethod = ListViewColumn.LayoutMethodOption.Fluid,
            //   MinWidth = 20,
            //   MaxWidth = 22,
            //   Width = 20
            //};
            //this.listView.AddColumn(column);

            //column = new ListViewColumn("temp3")
            //{
            //   Content = new GUIContent("temp3"),
            //   LayoutMethod = ListViewColumn.LayoutMethodOption.Fluid,
            //   MinWidth = 20,
            //   MaxWidth = 23,
            //   Width = 20
            //};
            //this.listView.AddColumn(column);

            column = new ListViewColumn("state")
            {
               Content = GUIContent.none,
               LayoutMethod = ListViewColumn.LayoutMethodOption.Fixed,
               MinWidth = 20,
               MaxWidth = 20,
               Width = 20
               //IsSelectable = false
            };
            this.listView.AddColumn(column);
         }

         private void DrawDirectoryPanelToolbar()
         {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);

            GUILayout.Label("uScript Directory", uScriptGUIStyle.PanelTitle, GUILayout.ExpandWidth(true));

            GUILayout.FlexibleSpace();

            GUI.SetNextControlName("ScriptFilterSearch");
            var newFilterText = uScriptGUI.ToolbarSearchField(this.filterText, GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
            if (this.filterText != newFilterText)
            {
               this.filterText = newFilterText.TrimStart();

               // Drop focus if the user inserted a newline (hit enter)
               if (newFilterText.Contains("\n"))
               {
                  GUIUtility.keyboardControl = 0;
               }
            }

            EditorGUILayout.EndHorizontal();
         }

         // === Structs ====================================================================

         // === Classes ====================================================================








         private static class Style
         {
            static Style()
            {
               ScriptListNormal = new GUIStyle(EditorStyles.label)
               {
                  margin = new RectOffset(4, 4, 1, 1),
                  padding = new RectOffset(2, 2, 0, 0)
               };

               ScriptListBold = new GUIStyle(ScriptListNormal) { fontStyle = FontStyle.Bold };

               MiniButtonLeft = new GUIStyle(EditorStyles.miniButtonLeft) { margin = new RectOffset(4, 0, 1, 1) };

               MiniButtonRight = new GUIStyle(EditorStyles.miniButtonRight) { margin = new RectOffset(0, 4, 1, 1) };

               // Get the width of the buttons, since the content
               // under Windows has a different size then under Mac
               WidthButtonSource = (int)MiniButtonLeft.CalcSize(uScriptGUIContent.buttonNodeSource).x;
               WidthButtonLoad = (int)MiniButtonRight.CalcSize(uScriptGUIContent.buttonScriptLoad).x;
            }

            public static GUIStyle ScriptListNormal { get; private set; }
            
            public static GUIStyle ScriptListBold { get; private set; }

            public static GUIStyle MiniButtonLeft { get; private set; }

            public static GUIStyle MiniButtonRight { get; private set; }

            public static int WidthButtonSource { get; private set; }

            public static int WidthButtonLoad { get; private set; }
         }

         private const double DoubleClickTime = 0.5; // default in Windows OS is 500ms
         private const int RowHeight = 17;
         private const int ButtonHeight = 15;
         private const int ButtonPadding = 4;

         //private static uScriptGUIPanelScript instance = new uScriptGUIPanelScript();
         private static Rect scrollviewRect;
         private static float previousRowWidth;

         private double clickTime;
         private string clickedControl = string.Empty;

         private string currentScriptName = string.Empty;
         private string currentScriptFileName = string.Empty;

         public void DrawOld(Rect rectPanel)
         {
            var scriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;

            // Update the panel in the following manner:
            //    Display the current active script first
            //    List the scene the script is associated with
            //    List error messages
            //    Display some type of separator
            //    Display all other scripts in the project (except the active script)
            //    Filter the list
            //    Support foldout containers eventually

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

            //  It should turn red when you load a script that belongs to an unloaded scene
            // Load a scene that has scripts associated with it.
            // Goto uscript and load associated script (all is well, not red).
            // make dirty and save (script turns red.  it shouldn't).
            // Consider losing the red altogether

            Instance._scrollviewOffset = EditorGUILayout.BeginScrollView(
               Instance._scrollviewOffset,
               false,
               false,
               uScriptGUIStyle.HorizontalScrollbar,
               uScriptGUIStyle.VerticalScrollbar,
               "scrollview");
            {
               var keylist = new List<string>();
               keylist.AddRange(uScriptBackgroundProcess.s_uScriptInfo.Keys);
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
                      && (string.IsNullOrEmpty(this.filterText)
                          || scriptName.ToLower().Contains(this.filterText.ToLower())))
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
               var rectLoadButton = new Rect(
                  previousRowWidth - Style.WidthButtonLoad - ButtonPadding, 1, Style.WidthButtonLoad, ButtonHeight);

               var rectSourceButton = new Rect(
                  rectLoadButton.x - Style.WidthButtonSource, 1, Style.WidthButtonSource, ButtonHeight);

               var rectLabelButton = new Rect(
                  ButtonPadding,
                  1,
                  previousRowWidth - Style.WidthButtonSource - Style.WidthButtonLoad - (ButtonPadding * 3),
                  RowHeight);

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
                      && (string.IsNullOrEmpty(this.filterText)
                          || scriptName.ToLower().Contains(this.filterText.ToLower())))
                  {
                     if (Instance._scrollviewOffset.y <= listItemMaxY)
                     {
                        // draw
                        if (Instance._scrollviewOffset.y + scrollviewRect.height > listItemMinY)
                        {
                           // the script path
                           string path = null;

                           // Draw the row background
                           if (isListRowEven && Event.current.type == EventType.Repaint)
                           {
                              uScriptGUIStyle.ListRow.Draw(rowRect, false, false, true, false);
                           }

                           // uScript Label
                           string scriptSceneName = "None";
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
                           if (this.clickedControl == scriptName)
                           {
                              if ((EditorApplication.timeSinceStartup - this.clickTime) < DoubleClickTime)
                              {
                                 wasClicked = true;
                                 uScript.RequestRepaint();
                              }
                           }

                           // Source button
                           GUIContent contentSourceButton;
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

                           if (GUI.Button(rectSourceButton, contentSourceButton, Style.MiniButtonLeft))
                           {
                              uScriptGUI.PingGeneratedScript(scriptName);
                           }

                           GUI.backgroundColor = Color.white;

                           // Load button
                           if (GUI.Button(rectLoadButton, uScriptGUIContent.buttonScriptLoad, Style.MiniButtonRight))
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
                           if (GUI.Button(
                              rectLabelButton,
                              scriptName + (scriptSceneName == "None" ? string.Empty : " (" + scriptSceneName + ")"),
                              wasClicked ? Style.ScriptListBold : Style.ScriptListNormal))
                           {
                              path = uScriptInstance.FindFile(uScript.Preferences.UserScripts, scriptFileName);

                              if (wasClicked)
                              {
                                 // double-click
                                 this.clickTime = EditorApplication.timeSinceStartup - this.clickTime;
                                    // prevents multiple double-clicks
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
   }
}
