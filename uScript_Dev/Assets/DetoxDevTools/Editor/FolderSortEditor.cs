// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios, LLC" file="FolderSortEditor.cs">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Editor window for testing the performance of GenericMenu initialization.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Assets.Editor
{
   using System;
   using System.Collections.Generic;
   using System.IO;
   using System.Linq;

   using UnityEditor;

   using UnityEngine;

   public class FolderSortEditor : EditorWindow
   {
      private static FolderSortEditor window;

      private static List<string> initialPathList;
      private static string initialPaths;
      private static Vector2 initialScrollviewPosition;

      private static List<string> sortedPathList;
      private static string sortedPaths;
      private static Vector2 sortedScrollviewPosition;

      private string filterTextCache = string.Empty;
      private string filterText = string.Empty;

      private bool sortDescending;
      private bool sortFoldersFirst;
      private bool sortNatural;

      public static FolderSortEditor Instance
      {
         get
         {
            if (window == null)
            {
               Init();
            }

            return window;
         }
      }

      public void OnGUI()
      {
         if (initialPathList == null)
         {
            initialPathList = new List<string>();

            this.GetFolderList();

            //initialPathList = new List<string>
            //{
            //   "==FILENAME 1",
            //   "folder1/==FILENAME 4",
            //   "folder2/subfolder2/subfolder1/==FILENAME 8",
            //   "==FILENAME 2",
            //   "folder2/subfolder1/==FILENAME 5",
            //   "folder3/subfolder1/subfolder1/subfolder1/==FILENAME 9",
            //   "folder2/subfolder1/==FILENAME 6",
            //   "folder1/==FILENAME 3",
            //   "folder2/subfolder2/==FILENAME 7",
            //   "a1",
            //   "a10",
            //   "a11",
            //   "a2",
            //   "a3",
            //   "ZZZ",
            //   "YYY",
            //   "XXX"
            //};

            initialPaths = string.Join("\n", initialPathList.ToArray()) + "\n";
         }

         this.DrawToolbar();

         EditorGUILayout.BeginHorizontal();
         {
            var panelWidth = (int)(this.position.width - 47) / 2;
            DrawPanel("Initial Paths", ref initialPaths, ref initialScrollviewPosition, panelWidth);
            DrawPanel("Sorted Paths", ref sortedPaths, ref sortedScrollviewPosition, panelWidth);
         }

         EditorGUILayout.EndHorizontal();
      }

      private static void ConvertInitialPathsToList()
      {
         initialPathList = new List<string>();

         foreach (var path in initialPaths.Split('\n').Where(path => path.Trim() != string.Empty))
         {
            initialPathList.Add(path.Trim());
         }
      }

      private static void ConvertSortedListToPaths()
      {
         sortedPaths = string.Join("\n", sortedPathList.ToArray());
      }

      private static void DrawPanel(string title, ref string content, ref Vector2 scrollviewPosition, int panelWidth)
      {
         EditorGUILayout.BeginVertical(Style.Panel, GUILayout.Width(panelWidth));

         GUILayout.Label(title, EditorStyles.boldLabel);

         EditorGUILayout.BeginVertical(Style.TextAreaContainer);
         {
            scrollviewPosition = EditorGUILayout.BeginScrollView(scrollviewPosition);
            {
               content = EditorGUILayout.TextArea(content, GUI.skin.label, GUILayout.ExpandHeight(true));
            }
            EditorGUILayout.EndScrollView();
         }
         EditorGUILayout.EndVertical();

         var count = string.IsNullOrEmpty(content)
            ? 0
            : content.Split('\n').Count(item => item.Trim() != string.Empty);

         GUILayout.Label(string.Format("Items: {0}", count));

         EditorGUILayout.EndVertical();
      }

      [MenuItem("Tools/Detox Studios/Internal/Folder Sort Editor")]
      private static void Init()
      {
         // Get existing open window or if none, make a new one:
         window = GetWindow(typeof(FolderSortEditor), false, "Folder Sort") as FolderSortEditor;
         if (window != null)
         {
            window.minSize = new Vector2(320, 240);
         }
      }


      private void GetFolderList()
      {

         //if (this.listView == null)
         //{
         //   uScriptDebug.Log("The ListView must be initialized before items can be added.", uScriptDebug.Type.Error);
         //   return;
         //}

         // Read graph files from subfolders
         var fileNames = GetFileList(uScript.Preferences.UserScripts, "*.uscript");

         // Build the flat list of scripts
         foreach (var filename in fileNames)
         {
            initialPathList.Add(filename.Replace(uScript.Preferences.UserScripts + "/", string.Empty));
         }

         // Mark the hierarchy dirty so that the hierarchy can be rebuilt and filtering and sorting can be applied
         //this.listView.RebuildListHierarchy();
      }

      public static IEnumerable<string> GetFileList(string baseDir, string searchPattern)
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



      private void DrawToolbar()
      {
         EditorGUILayout.BeginHorizontal(Style.Toolbar);

         if (GUILayout.Button("Execute Sort", Style.SortButton))
         {
            GUIUtility.keyboardControl = 0;
            this.RefreshSort();
         }

         GUILayout.FlexibleSpace();

         GUILayout.Label("Filter", Style.TextFieldLabel);

         var filterFieldFocused = GUI.GetNameOfFocusedControl() == "filterField";

         GUI.SetNextControlName("filterField");
         this.filterText = GUILayout.TextField(this.filterText, Style.TextField);
         if (GUI.GetNameOfFocusedControl() == "filterField")
         {
            if (!filterFieldFocused)
            {
               this.filterTextCache = this.filterText;
            }

            if (Event.current.isKey)
            {
               switch (Event.current.keyCode)
               {
                  case KeyCode.Return:
                     GUIUtility.keyboardControl = 0;
                     Event.current.Use();
                     break;

                  case KeyCode.Escape:
                     GUIUtility.keyboardControl = 0;
                     this.filterText = this.filterTextCache;
                     Event.current.Use();
                     this.RefreshSort();
                     break;

                  case KeyCode.LeftArrow:
                  case KeyCode.RightArrow:
                  case KeyCode.UpArrow:
                  case KeyCode.DownArrow:
                  case KeyCode.End:
                  case KeyCode.Home:
                  case KeyCode.PageDown:
                  case KeyCode.PageUp:
                     // Do nothing
                     break;

                  default:
                     this.RefreshSort();
                     break;
               }
            }
         }

         GUI.changed = false;

         GUI.enabled = this.filterText != string.Empty;

         if (GUILayout.Button("X", Style.TextFieldButton))
         {
            this.filterText = string.Empty;
         }

         GUI.enabled = true;

         this.sortDescending = GUILayout.Toggle(this.sortDescending, "Descending", Style.Toggle);
         this.sortFoldersFirst = GUILayout.Toggle(this.sortFoldersFirst, "Folders First", Style.Toggle);
         this.sortNatural = GUILayout.Toggle(this.sortNatural, "Natural", Style.Toggle);

         if (GUI.changed)
         {
            GUIUtility.keyboardControl = 0;
            this.RefreshSort();
         }

         EditorGUILayout.EndHorizontal();
      }

      private void RefreshSort()
      {
         // Convert the initialPaths string into a List<string>
         //ConvertInitialPathsToList();

         // build hierarchy

         // sort hierarchy


         // Perform the sort using specified options ...
         this.Sort();

         ConvertSortedListToPaths();
      }

      private void Sort()
      {
         if (this.sortFoldersFirst)
         {
            // get the files
            var fileList = (this.sortDescending
               ? from element in initialPathList orderby element descending select element
               : from element in initialPathList orderby element ascending select element).ToList<string>();

            // get the folders
            var folderList = new List<string>();
            foreach (var item in fileList)
            {
               var path = string.Empty;
               var folders = new List<string>(item.Split('/'));

               while (folders.Count > 1)
               {
                  var folder = folders.ElementAt(0);
                  path += folder + "/";
                  folders.RemoveAt(0);

                  if (!folderList.Contains(path))
                  {
                     folderList.Add(path);
                  }
               }
            }

            // build sorted list
            sortedPathList = new List<string>();

            if (this.sortDescending)
            {
               var folderIndex = folderList.Count - 1;

               // First add all root files, removing them from the list
               for (var fileIndex = fileList.Count - 1; fileIndex >= 0; fileIndex--)
               {
                  var file = fileList[fileIndex];
                  if (file.LastIndexOf('/') == -1)
                  {
                     sortedPathList.Add(file);
                     fileList.RemoveAt(fileIndex);
                  }
               }

               for (var fileIndex = fileList.Count - 1; fileIndex >= 0; fileIndex--)
               {
                  var file = fileList[fileIndex];
                  var path = file.Substring(0, file.LastIndexOf('/') + 1);

                  while (folderIndex >= 0 && folderList[folderIndex].StartsWith(path) == false)
                  {
                     sortedPathList.Add(folderList[folderIndex--]);
                  }

                  sortedPathList.Add(file);
               }

               // Add the remaining folders
               while (folderIndex >= 0)
               {
                  sortedPathList.Add(folderList[folderIndex--]);
               }

               sortedPathList.Reverse();
            }
            else
            {
               fileList.Reverse();

               for (var folderIndex = 0; folderIndex < folderList.Count; folderIndex++)
               {
                  var folder = folderList[folderIndex];

                  sortedPathList.Add(folder);

                  if (folderIndex + 1 < folderList.Count && folderList[folderIndex + 1].StartsWith(folder))
                  {
                     // Move on to the first child folder
                     continue;
                  }

                  var folders = folder.Split('/').ToList();
                  folders.RemoveAt(folders.Count - 1);

                  while (folders.Count > 0)
                  {
                     folder = string.Join("/", folders.ToArray()) + "/";

                     for (var fileIndex = fileList.Count - 1; fileIndex >= 0; fileIndex--)
                     {
                        var file = fileList[fileIndex];
                        var pathLength = file.LastIndexOf('/');

                        if (pathLength < 0 || file.Substring(0, pathLength + 1) != folder)
                        {
                           // Skip files are root and those that are in another folder
                           continue;
                        }

                        sortedPathList.Add(file);
                        fileList.RemoveAt(fileIndex);
                     }

                     folders.RemoveAt(folders.Count - 1);
                  }
               }

               // Add the remaining files at root
               for (var fileIndex = fileList.Count - 1; fileIndex >= 0; fileIndex--)
               {
                  sortedPathList.Add(fileList[fileIndex]);
               }
            }
         }
         else
         {
            var sortedList = new List<string>(initialPathList);

            // Examine each item
            foreach (var item in initialPathList)
            {
               var path = string.Empty;
               var folders = new List<string>(item.Split('/'));

               while (folders.Count > 1)
               {
                  var folder = folders.ElementAt(0);
                  path += folder + "/";
                  folders.RemoveAt(0);

                  if (!sortedList.Contains(path))
                  {
                     sortedList.Add(path);
                  }
               }
            }

            sortedList.Sort();
            sortedPathList = sortedList;

            if (this.sortDescending)
            {
               sortedPathList.Reverse();
            }
         }
      }

      private static class Style
      {
         static Style()
         {
            Panel = new GUIStyle(GUI.skin.box)
            {
               margin = new RectOffset(16, 16, 16, 16),
               stretchHeight = true,
               stretchWidth = true
            };

            SortButton = new GUIStyle(GUI.skin.button)
            {
               fontStyle = FontStyle.Bold,
               margin = new RectOffset(),
               padding = new RectOffset(8, 12, 2, 3)
            };

            TextAreaContainer = new GUIStyle(GUI.skin.textArea);
            TextAreaContainer.padding = new RectOffset(1, 0, 1, 1);

            TextField = new GUIStyle(GUI.skin.textField)
            {
               fixedWidth = 150,
               margin = new RectOffset(6, 6, 1, 3)
            };

            TextFieldButton = new GUIStyle(EditorStyles.miniButton)
            {
               fontStyle = FontStyle.Bold,
               margin = new RectOffset(4, 20, 2, 3),
               padding = new RectOffset(5, 6, 1, 3)
            };

            TextFieldLabel = new GUIStyle(GUI.skin.label)
            {
               margin = new RectOffset(6, 6, 1, 3)
            };

            Toggle = new GUIStyle(GUI.skin.toggle)
            {
               margin = new RectOffset(20, 0, 0, 3),
               padding = new RectOffset(20, 0, 2, 3)
            };

            Toolbar = new GUIStyle
            {
               margin = new RectOffset(16, 16, 16, 16)
            };
         }

         public static GUIStyle Panel { get; private set; }

         public static GUIStyle SortButton { get; private set; }

         public static GUIStyle TextAreaContainer { get; private set; }

         public static GUIStyle TextField { get; private set; }

         public static GUIStyle TextFieldButton { get; private set; }

         public static GUIStyle TextFieldLabel { get; private set; }
         
         public static GUIStyle Toggle { get; private set; }

         public static GUIStyle Toolbar { get; private set; }
      }
   }
}
