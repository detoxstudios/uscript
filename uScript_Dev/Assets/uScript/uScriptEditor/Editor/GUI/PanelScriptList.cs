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
         // TODO: Add support for "Rebuild Source" for selected graph
         // TODO: Add support for "Remove Generated Source" for selected graph

         // TODO: Better handling of the double-click execute command
         // TODO: Add support for column sorting

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
            this.UpdateListHierarchy();
         }

         /// <summary>
         /// Filter the list contents. Should be called whenever the filter text search field changes.
         /// </summary>
         public void FilterListContents()
         {
            // Filter the list, hiding every item that does not contain the user-specified filter text
            var match = this.filterText.ToLower();

            foreach (var item in this.allItems)
            {
               item.IsVisible = string.IsNullOrEmpty(match)
                                || item.ItemPath.Substring(0, item.ItemPath.Length - 8).ToLower().Contains(match);
            }

            // TODO: Should the filterText apply to SceneName as well?
         }

         /// <summary>
         /// Sort the list contents. Should be called whenever sorting has changed, such as when column header buttons are clicked.
         /// </summary>
         public void SortListContents()
         {
            // Sort the list, using the user-specified ordering
            // TODO: replace all of this with the actual sort logic

            // TODO: A custom Comparer should be created to handle sorting, and it should be used by the ListView directly, not called here.
         }

         /// <summary>
         /// Update the list hierarchy, taking into account the directory foldout states. Should be called whenever a foldout state changes.
         /// </summary>
         public void UpdateListHierarchy()
         {
            // Send final (filtered and sorted) list to the ListView control
            this.listView.ClearItems();

            foreach (var item in this.allItems.Where(item => item.IsVisible))
            {
               this.listView.AddItem(item);
            }
            
            this.listView.RebuildListHierarchy();
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

               this.listView.FilterItems(this.filterText);
               //this.FilterListContents();
               //this.UpdateListHierarchy();

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
      }
   }
}
