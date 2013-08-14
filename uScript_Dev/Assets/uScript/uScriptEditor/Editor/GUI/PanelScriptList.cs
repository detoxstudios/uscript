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
   using System.Collections.Generic;
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

         private readonly List<ListViewItemScript> allItems = new List<ListViewItemScript>();

         private string filterText = string.Empty;

         // === Constructors ===============================================================

         public PanelScriptList()
         {
            uScriptInstance = uScript.Instance;

            this.listView = new ListView(uScript.Instance, typeof(ListViewItemScript))
            {
               ForceHorizontalColumnFit = true,
               ShowColumnHeaders = true,
               SortByColumn = true,
               MultiSelectEnabled = false
            };

            ShowFriendlyNames = false;
            ShowLabelIcons = true;

            this.CreateColumns();
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
               //      // check the hot control too
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
                  this.listView.Draw(rectPanel);
//                  this.DrawOld(rectPanel);
               }

               //// Update the list view focus
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

         /// <summary>
         /// Generate the initial list contents. Should be called during uScript Editor initialization and OnProjectChanged.
         /// </summary>
         public void GetListContents()
         {
            if (this.listView == null)
            {
               uScriptDebug.Log("The ListView must be initialized before items can be added.", uScriptDebug.Type.Error);
               return;
            }

            // Get the graph paths, making the path relative to the project folder
            var initialPaths = uScript.GetGraphPaths().Select(path => path.Replace(uScript.Preferences.UserScripts + "/", string.Empty)).ToList();

            // Create a ListViewItem for each path
            foreach (var path in initialPaths)
            {
               // TODO: Consider passing the actual GraphInfo instead, since ListViewItemScript pulls info from it anyway
               this.allItems.Add(new ListViewItemScript(this.listView, path));
            }
 
            this.FilterListContents();
            this.SortListContents();
            this.BuildListHierarchy();
         }

         private void ApplyFilterAndSort()
         {
            
         }

         /// <summary>
         /// Filter the list contents. Should be called whenever the filter text search field changes.
         /// </summary>
         public void FilterListContents()
         {
            // Filter the list, removing every item that does not contain the user-specified filter text
            var match = this.filterText.ToLower();

            //this.filteredItems.Clear();

            //foreach (
            //   var item in
            //      this.allItems.Where(
            //         item =>
            //            string.IsNullOrEmpty(this.filterText)
            //            || item.Path.Substring(0, item.Path.Length - 8).ToLower().Contains(match)))
            //{
            //   this.filteredItems.Add(item);
            //}


            foreach (var item in this.allItems)
            {
               item.IsVisible = string.IsNullOrEmpty(match)
                                || item.Path.Substring(0, item.Path.Length - 8).ToLower().Contains(match);
            }

            //DebugVisibleList(this.allItems, "VISIBLE ITEMS");
            //DebugHiddenList(this.allItems, "HIDDEN ITEMS");
         }


         /// <summary>
         /// Sort the list contents. Should be called whenever sorting has changed, such as when column header buttons are clicked.
         /// </summary>
         public void SortListContents()
         {
            // Sort the list, using the user-specified ordering
            // TODO: replace all of this with the actual sort logic
         }

         /// <summary>
         /// Build the initial list hierarchy, inserting folder items before file items where necessary.
         /// </summary>
         public void BuildListHierarchy()
         {
            // Build the 

            // 5. BUILD HIERARCHY
            // foreach filtered list item
            //    ...
            //    ... Insert folder items before filter list items
            // return hierarchy list
            // Update item visibility

            //foreach (var item in this.allItems)
            //{
            //   item.IsVisible = string.IsNullOrEmpty(this.filterText) || item.Path.Contains(this.filterText);
            //}


            //foreach (var item in this.filteredPaths)
            //{
            //   Debug.Log(string.Format("ADDING: \"{0}\"\n", item));
            //   this.listView.AddItem(string.Format("{0}.uscript", item));
            //}

            this.UpdateListHierarchy();
         }

         /// <summary>
         /// Update the list hierarchy, taking into account the directory foldout states. Should be called whenever a foldout state changes.
         /// </summary>
         public void UpdateListHierarchy()
         {
            // 6. BUILD FINAL LIST
            // create final list
            // skipPath = ""
            // foreach item
            //    if item is folder and collapsed
            //       skipPath = item path
            //       continue
            //    if item path begins with skipPath
            //       continue
            //    add the item to final list
            // return final list
            // send final list to the ListView control

            //var list = new List<ListViewItemScript>(this.allItems);

            //foreach (var item in this.allItems)



            this.listView.ClearItems();

            foreach (var item in this.allItems.Where(item => item.IsVisible))
            {
               //Debug.Log(string.Format("ADDING: \"{0}\"\n", item.Name));
               this.listView.AddItem(item);
            }
            
            this.listView.RebuildListHierarchy();
         }

         private static void DebugList(IEnumerable<string> list, string label = "")
         {
            var hasLabel = label != string.Empty;
            Debug.Log(
               string.Format(
                  "{0}{1}\n{2}",
                  hasLabel ? label + ":\n" : string.Empty,
                  list.Aggregate(string.Empty, (current, path) => current + ((hasLabel ? "\t" : string.Empty) + path + "\n")),
                  new string('-', 40)));
         }

         private static void DebugList(IEnumerable<ListViewItemScript> list, string label = "")
         {
            var hasLabel = label != string.Empty;
            Debug.Log(
               string.Format(
                  "{0}{1}\n{2}",
                  hasLabel ? label + ":\n" : string.Empty,
                  list.Aggregate(string.Empty, (current, item) => current + ((hasLabel ? "\t" : string.Empty) + item.Path + "\n")),
                  new string('-', 40)));
         }

         private static void DebugHiddenList(IEnumerable<ListViewItemScript> list, string label = "")
         {
            var hasLabel = label != string.Empty;
            Debug.Log(
               string.Format(
                  "{0}{1}\n{2}",
                  hasLabel ? label + ":\n" : string.Empty,
                  list.Where(item => !item.IsVisible).Aggregate(string.Empty, (current, item) => current + ((hasLabel ? "\t" : string.Empty) + item.Path + "\n")),
                  new string('-', 40)));
         }

         private static void DebugVisibleList(IEnumerable<ListViewItemScript> list, string label = "")
         {
            var hasLabel = label != string.Empty;
            Debug.Log(
               string.Format(
                  "{0}{1}\n{2}",
                  hasLabel ? label + ":\n" : string.Empty,
                  list.Where(item => item.IsVisible).Aggregate(string.Empty, (current, item) => current + ((hasLabel ? "\t" : string.Empty) + item.Path + "\n")),
                  new string('-', 40)));
         }

         private void CreateColumns()
         {
            var column = new ListViewColumn("graph")
            {
               Content = new GUIContent("Graph"),
               LayoutMethod = ListViewColumn.LayoutMethodOption.Custom,
               MinWidth = 100,
               MaxWidth = 300,
               Width = 200
               //IsSelectable = true
            };
            this.listView.AddColumn(column);

            column = new ListViewColumn("scene")
            {
               Content = new GUIContent("Scene"),
               LayoutMethod = ListViewColumn.LayoutMethodOption.Fluid,
               MinWidth = 18,
               MaxWidth = 200,
               Width = 18
               //IsSelectable = true
               //IsSortDirectionFixed = true
            };
            this.listView.AddColumn(column);

            column = new ListViewColumn("state")
            {
               Content = GUIContent.none,
               LayoutMethod = ListViewColumn.LayoutMethodOption.Fixed,
               MinWidth = 20,
               MaxWidth = 20,
               Width = 20
               //IsSelectable = true
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

               this.FilterListContents();
               this.BuildListHierarchy();

               // Drop focus if the user inserted a newline (hit enter)
               if (newFilterText.Contains("\n"))
               {
                  GUIUtility.keyboardControl = 0;
               }
            }

            EditorGUILayout.EndHorizontal();
         }

         private List<string> FilterPaths(List<string> paths, string filter)
         {
            if (string.IsNullOrEmpty(filter))
            {
               return paths;
            }

            var result = paths.Where(path => path.ToLower().Contains(filter.ToLower())).ToList();

            paths.Clear();
            paths.AddRange(result);

            //for (int index = paths.Count - 1; index >= 0; index--)
            //{
            //   if (paths[index].ToLower().Contains(filter.ToLower()) == false)
            //   {
            //      paths.RemoveAt(index);
            //   }
            //}

            return result;
         }

         private List<string> SortPaths(List<string> paths)
         {
            return paths;
         }



         // === Structures =================================================================

         // === Classes ====================================================================

/*
         // TODO: REMOVE THE FOLLOWING:

         // ================================================================================
         // ================================================================================
         // === Everything from here down is old and should eventually be removed ==========
         // ================================================================================
         // ================================================================================


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
               this.currentScriptName = Path.GetFileNameWithoutExtension(this.currentScriptFileName);
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
                  scriptName = Path.GetFileNameWithoutExtension(scriptFileName);

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
                  scriptName = Path.GetFileNameWithoutExtension(scriptFileName);
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
*/
      }
   }
}
