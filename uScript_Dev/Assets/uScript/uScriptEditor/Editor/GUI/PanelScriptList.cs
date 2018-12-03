// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PanelScriptList.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PanelScript type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System.Collections.Generic;
   using System.IO;
   using System.Linq;

   using UnityEditor;

   using UnityEngine;

   public sealed partial class PanelScript
   {
      private class PanelScriptList
      {
         // TODO: Add support for "Rebuild Source" for selected graph
         // TODO: Add support for "Remove Generated Source" for selected graph

         // TODO: Better handling of the double-click execute command
         // TODO: Add support for column sorting

         private readonly ListView listView;

         private string filterText = string.Empty;
         private bool updateRequested = false;

         public PanelScriptList()
         {
            this.listView = new ListView(uScript.Instance, typeof(ListViewItemScript))
            {
               ForceHorizontalColumnFit = true,
               ShowColumnHeaders = true,
               SortByColumn = true,
               MultiSelectEnabled = false
            };

            ShowFriendlyNames = false;
            ShowLabelIcons = true;

            this.RestoreState();

            this.CreateColumns();

            this.RequestListUpdate();

            EditorApplication.projectWindowChanged += this.RequestListUpdate;
            uScript.GraphSaved += this.RequestListUpdate;
         }

         public void Draw()
         {
            var uScriptInstance = uScript.WeakInstance;

            if (uScriptInstance != null)
            {
               //if (this.listView.PendingExecution != null)
               //{
               //   Debug.Log("EXECUTE LOAD of \"" + this.listView.PendingExecution.Path + "\"\n");
               //   this.listView.PendingExecution = null;
               //}

               if (updateRequested)
               {
                  updateRequested = false;
                  UpdateListContents();
               }

               var rectPanel = EditorGUILayout.BeginVertical(uScriptGUIStyle.PanelBox, GUILayout.ExpandHeight(true));
               {
                  //Event e = Event.current;

                  //if (e.type == EventType.MouseDown || e.type == EventType.Used)
                  //{

                  //   //Focused = EditorWindow.focusedWindow && rectPanel.Contains(e.mousePosition);
                  //   bool newFocus = ((FocusedControl.ID == 0) && rectPanel.Contains(e.mousePosition));
                  //   if (newFocus == false && newFocus != _listView.hasFocus)
                  //   {
                  //      // check the hot control too
                  //      Debug.Log("REPAINT\n");
                  //      ListViewEditor.Instance.Repaint();
                  //   }

                  //   //Debug.Log("FOCUS: " + _listView.hasFocus.ToString() + ", KEYBOARD CONTROL: " + FocusedControl.ToString() + ", EVENT: " + e.ToString() + "\n");
                  //   Debug.Log("FOCUS: " + _listView.hasFocus.ToString() + ",\t\t" + "keyboardControl: " + FocusedControl.ToString() + "\t\tEventType: " + e.type.ToString()
                  //      + "\n" + "\t\t\t\t\t\t" + "hotControl: " + GUIUtility.hotControl.ToString() + "\t\t\t\t\t" + "FocusChanged: " + (newFocus != _listView.hasFocus).ToString());

                  //   _listView.hasFocus = newFocus;
                  //}

                  this.DrawDirectoryPanelToolbar();

                  if (uScriptInstance.wasCanvasDragged && Preferences.DrawPanelsOnUpdate == false)
                  {
                     Instance.DrawHiddenNotification();
                  }
                  else
                  {
                     this.listView.Draw(rectPanel);
                  }

                  //// Update the list view focus
                  //if (e.type == EventType.MouseDown || e.type == EventType.Used)
                  //{
                  //   bool newFocus = ((FocusedControl.ID == 0) && rectPanel.Contains(e.mousePosition));
                  //   if (newFocus != _listView.hasFocus)
                  //   {
                  //      ListViewEditor.Instance.Repaint();
                  //   }
                  //   _listView.hasFocus = newFocus;
                  //}
               }

               EditorGUILayout.EndVertical();
            }
         }

         public void FindMissingGraphs()
         {
            AssetDatabase.StartAssetEditing();
            List<string> paths = uScript.GetAllUScriptPaths();
            int found = 0;
            foreach (string path in paths)
            {
               if (!uScript.FileHasLabels(path, new string[] { "uScript", "uScriptSource" }))
               {
                  found++;
                  uScriptDebug.Log(string.Format("Found missing graph: {0} - updating labels...", path.RelativeAssetPath()));
                  uScript.SetLabelsOnFile(path, new string[] { "uScript", "uScriptSource" });

                  // TODO: if this graph file is missing its labels, chances are its generated files are missing theirs, too - check now
               }
            }
            AssetDatabase.StopAssetEditing();

            if (found == 0)
            {
               EditorUtility.DisplayDialog("Find Missing Graphs", "No missing graphs found.", "OK");
            }
            else
            {
               AssetDatabase.Refresh();
               this.RequestListUpdate();
               EditorUtility.DisplayDialog("Find Missing Graphs", string.Format("Found and fixed {0} missing graphs.", found), "OK");
            }
         }

         public void SaveState()
         {
            Preferences.ProjectGraphListFilter = this.filterText;
            Preferences.ProjectGraphListOffset = (int)this.listView.ListOffset.y;
         }

         /// <summary>
         /// Generate the initial list contents. Should be called during uScript Editor initialization and OnProjectChanged.
         /// </summary>
         public void RequestListUpdate()
         {
            updateRequested = true;
         }

         private void UpdateListContents()
         {
            if (uScript.IsOpen == false)
            {
               return;
            }

            if (this.listView == null)
            {
               uScriptDebug.Log("The ListView must be initialized before items can be added.", uScriptDebug.Type.Error);
               return;
            }

            // Get the graph paths, making the path relative to the project folder
#if (UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_2017 || UNITY_2018)
            var initialPaths = uScript.GetGraphPaths();
            var commonPath = uScriptUtility.FindCommonPath(initialPaths).Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            initialPaths = initialPaths.Select(path => path.Replace(commonPath, string.Empty)).ToList();
#else
            var initialPaths = uScript.GetGraphPaths().Select(path => path.Replace(Preferences.UserScripts + "/", string.Empty)).ToList();
#endif

            // Send final (filtered and sorted) list to the ListView control
            this.listView.ClearItems();

            foreach (var path in initialPaths)
            {
               this.listView.AddItem(path);
            }

            this.listView.FilterItems(this.filterText);
         }

         private void CreateColumns()
         {
            var column = new ListViewColumn("graph")
            {
               Content = new GUIContent("Graph"),
               LayoutMethod = ListViewColumn.LayoutMethodOption.Custom,
               MinWidth = 100,
               MaxWidth = 600,
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

            GUILayout.Label("Project Graphs", uScriptGUIStyle.PanelTitle, GUILayout.ExpandWidth(true));

            GUILayout.FlexibleSpace();

            GUI.SetNextControlName("ScriptFilterSearch");
            var newFilterText = uScriptGUI.ToolbarSearchField(this.filterText, GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
            if (this.filterText != newFilterText)
            {
               this.filterText = newFilterText.TrimStart();

               this.listView.FilterItems(this.filterText);
               //this.FilterListContents();
               //this.UpdateListHierarchy();

               // Drop focus if the user inserted a newline (hit enter)
               if (newFilterText.Contains("\n"))
               {
                  FocusedControl.Clear();
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

         private void RestoreState()
         {
            this.filterText = Preferences.ProjectGraphListFilter;
            this.listView.ListOffset = new Vector2(0, Preferences.ProjectGraphListOffset);
         }

         private List<string> SortPaths(List<string> paths)
         {
            return paths;
         }
      }
   }
}
