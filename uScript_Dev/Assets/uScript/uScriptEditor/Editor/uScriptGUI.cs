// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUI.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   This file contains a collection of custom uScript GUI controls for use with uScriptEditor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

using Detox.FlowChart;
using Detox.ScriptEditor;

using UnityEditor;

using UnityEngine;

using Object = System.Object;

public static class uScriptGUI
{
   // === Constants ==================================================================

   public const string KeyEscape = "\u238B";
   public const string KeyShift = "\u21E7";
   public const string KeyControl = "\u2303";
   public const string KeyOption = "\u2325";
   public const string KeyCommand = "\u2318";
   public const string KeyDelete = "\u2326";
   public const string KeyBackspace = "\u232B";
   public const string KeyReturn = "\u23CE";

   // How much deep to scan. (of course you can also pass it to the method)
   private const int MaximumFolderRecursioDepth = 12;

   // === Fields =====================================================================

   public static Vector2 columnOffset;
   public static Rect svRect;
   public static string _focusedControl = string.Empty;
   public static string _previousControl = string.Empty;

   private static readonly Dictionary<int, string> ControlIDList = new Dictionary<int, string>();
   private static readonly Dictionary<string, bool> FoldoutExpanded = new Dictionary<string, bool>();
   ////private static Dictionary<string, object> _modifiedValue = new Dictionary<string, object>();

   private static Column columnEnabled;
   private static Column columnLabel;
   private static Column columnValue;
   private static Column columnType;
   private static GUIStyle styleEnabled;
   private static GUIStyle styleLabel;
   private static GUIStyle styleType;

   private static string nodeKey = string.Empty;
   private static int nodeCount;
   private static int propertyCount;
   private static bool isPropertyRowEven = false;
   private static int focusedControlID = -1;

   private static GUIStyle horizontalScrollbarLeftButton;
   private static GUIStyle horizontalScrollbarRightButton;
   private static GUIStyle horizontalScrollbarThumb;
   private static GUIStyle verticalScrollbarUpButton;
   private static GUIStyle verticalScrollbarDownButton;
   private static GUIStyle verticalScrollbarThumb;

   private static Type guiLayoutOptionEnumType;
   private static string[] guiLayoutOptionEnumOptions;
   private static string[] guiLayoutOptionDisplayNames;

   private static List<string> resourcePaths;

   // === Properties =================================================================

   public static int PanelDividerThickness { get; private set; }

   public static int PanelLeftWidth { get; set; }

   public static int PanelPropertiesHeight { get; set; }

   public static int PanelPropertiesWidth { get; set; }

   public static int PanelScriptsWidth { get; set; }

   public static bool PanelsHidden { get; set; }

   public static int SaveMethodPopupWidth { get; private set; }

   public static string WatchedControlName { get; set; }

   /// <summary>
   /// Gets or sets a value indicating whether the GUI is enabled. This method should
   /// be called instead of GUI.enabled when the state needs to change during OnGUI,
   /// especially during the uScriptGUI custom control calls.
   /// </summary>
   public static bool Enabled
   {
      get
      {
         return GUI.enabled;
      }

      set
      {
         var instance = uScript.Instance;
         GUI.enabled = value && (instance.isLicenseAccepted && !instance.isPreferenceWindowOpen && !instance.isContextMenuOpen && !instance.isFileMenuOpen);
      }
   }

   public static bool IsProSkin
   {
      get
      {
#if (UNITY_3_2 || UNITY_3_3 || UNITY_3_4)
         // The isProSkin property was introduced in Unity 3.5 API
         return (GUI.skin.name == "SceneGUISkin");
#else
         return EditorGUIUtility.isProSkin;
#endif
      }
   }

   /// <summary>
   /// Gets a string array containing the enumeration name of each selectable GUILayoutOption.Type option.
   /// </summary>
   public static string[] GUILayoutOptionEnumNames
   {
      get
      {
         if (guiLayoutOptionEnumOptions == null)
         {
            // Filter out all unnecessary options
            var names = new List<string>();
            foreach (var option in Enum.GetNames(GUILayoutOptionEnumType))
            {
               switch (option)
               {
                  case "fixedWidth":
                  case "fixedHeight":
                  case "minWidth":
                  case "maxWidth":
                  case "minHeight":
                  case "maxHeight":
                  case "stretchWidth":
                  case "stretchHeight":
                     names.Add(option);
                     break;
               }
            }

            guiLayoutOptionEnumOptions = names.ToArray();
         }

         return guiLayoutOptionEnumOptions;
      }
   }

   /// <summary>
   /// Gets a string array containing the display name of each selectable GUILayoutOption.Type option.
   /// </summary>
   public static string[] GUILayoutOptionDisplayNames
   {
      get
      {
         if (guiLayoutOptionDisplayNames == null)
         {
            var names = new List<string>();
            foreach (var option in GUILayoutOptionEnumNames)
            {
               switch (option)
               {
                  case "fixedWidth":
                     names.Add("Width");
                     break;

                  case "fixedHeight":
                     names.Add("Height");
                     break;

                  case "minWidth":
                     names.Add("MinWidth");
                     break;

                  case "maxWidth":
                     names.Add("MaxWidth");
                     break;

                  case "minHeight":
                     names.Add("MinHeight");
                     break;

                  case "maxHeight":
                     names.Add("MaxHeight");
                     break;

                  case "stretchWidth":
                     names.Add("ExpandWidth");
                     break;

                  case "stretchHeight":
                     names.Add("ExpandHeight");
                     break;

                  default:
                     Debug.LogError("Unhandled GUILayoutOption.Type value: \"" + option + "\"\n");
                     break;
               }
            }

            guiLayoutOptionDisplayNames = names.ToArray();
         }

         return guiLayoutOptionDisplayNames;
      }
   }

   private static Type GUILayoutOptionEnumType
   {
      get
      {
         if (guiLayoutOptionEnumType == null)
         {
            var option = GUILayout.Width(0);
            var fields = option.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            // should have two fields "type" and "value" ... we just care about "type"
            foreach (var field in fields.Where(field => field.Name == "type"))
            {
               guiLayoutOptionEnumType = field.GetValue(option).GetType();
            }
         }

         return guiLayoutOptionEnumType;
      }
   }

   // === Methods ====================================================================

   // TODO: Remove when no longer needed
   public static string GetImagePath(string imageName)
   {
      return string.Format("Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/{0}.png", imageName);
   }

   // TODO: Remove when no longer needed
   public static string GetSkinnedImagePath(string imageName)
   {
      return GetImagePath(string.Format("{0}_{1}", IsProSkin ? "DarkSkin" : "LightSkin", imageName));
   }

   public static Texture2D GetTexture(string textureName)
   {
      return AssetDatabase.LoadAssetAtPath(
         string.Format("Assets/uScript/uScriptEditor/Editor/_GUI/EditorImages/{0}.png", textureName),
         typeof(Texture2D)) as Texture2D;
   }

   public static Texture2D GetSkinnedTexture(string textureName)
   {
      return GetTexture(string.Format("{0}_{1}", IsProSkin ? "DarkSkin" : "LightSkin", textureName));
   }

   /// <summary>Deconstructs the specified GUILayoutOption object into individual variables.</summary>
   /// <returns>True if the deconstruction succeeded, False otherwise.</returns>
   /// <param name='option'>The GUILayoutOption object to split.</param>
   /// <param name='optionIndex'>The GUILayoutOption enumeration index.</param>
   /// <param name='optionValue'>The GUILayoutOption value as an integer.</param>
   public static bool DeconstructGUILayoutOption(GUILayoutOption option, out int optionIndex, out int optionValue)
   {
      var optionType = string.Empty;
      optionValue = 0;

      var fields = option.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

      // should have two fields "type" and "value"
      foreach (var field in fields)
      {
         switch (field.Name)
         {
            case "type":
               optionType = field.GetValue(option).ToString();
               break;

            case "value":
               optionValue = Convert.ToInt32(field.GetValue(option));
               break;

            default:
               Debug.LogError("Unknown field found in GUILayoutOption!\n");
               break;
         }
      }

      optionIndex = Array.IndexOf(GUILayoutOptionEnumNames, optionType);
      if (optionIndex == -1)
      {
         optionIndex = 0;
         optionValue = 0;
         return false;
      }

      return true;
   }

   public static void DebugBox(Rect rect)
   {
      DebugBox(rect, Color.black, string.Empty);
   }

   public static void DebugBox(Rect rect, Color color)
   {
      DebugBox(rect, color, string.Empty);
   }

   public static void DebugBox(Rect rect, string text)
   {
      DebugBox(rect, Color.black, text);
   }

   public static void DebugBox(Rect rect, Color color, string text)
   {
      var texture = GetTexture("DebugBox");

      var style = new GUIStyle(EditorStyles.miniLabel)
      {
         name = "uScript_debugBox",
         margin = new RectOffset(),
         border = new RectOffset(1, 1, 1, 1),
         ////clipping = TextClipping.Overflow,
         clipping = TextClipping.Clip,
         alignment = TextAnchor.MiddleCenter,
         ////normal = { background = textureDebugBox, textColor = Color.white }
         normal = { background = texture }
      };

      var originalColor = GUI.color;

      GUI.color = color;
      GUI.Box(rect, text, style);
      GUI.color = originalColor;
   }

   public static void GetResourceFolderPaths(string sourceDir, int recursionDepth)
   {
      if (recursionDepth > MaximumFolderRecursioDepth)
      {
         return;
      }

      // Grab the valid paths
      if ((sourceDir.EndsWith("/Resources") || sourceDir.Contains("/Resources/"))
          && sourceDir.Contains("/.svn") == false)
      {
         // get the substring we care about
         var path = sourceDir.Substring(sourceDir.IndexOf("Resources", StringComparison.Ordinal)).Replace('/', '\\');

         // add the path if it doesn't already exist
         if (resourcePaths.Contains(path) == false)
         {
            resourcePaths.Add(path);
         }

         // sort the list or it will place the paths in a strange order
         resourcePaths.Sort();
      }

      // Recurse into subdirectories of this directory.
      var subdirEntries = Directory.GetDirectories(sourceDir);
      foreach (var subdir in subdirEntries.Where(subdir => (File.GetAttributes(subdir) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint))
      {
         GetResourceFolderPaths(subdir, recursionDepth + 1);
      }
   }

   public static string ResourcePathField(string value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      // Resource Path
      //
      // The control uses a standard popup control for path selection, although the current
      // selection is stored as a string.  The string array used for the popup should only
      // include all valid Resource folders under assets.
      //
      //    Popup control
      //    (exposed socket should be a string)

      if (resourcePaths == null || resourcePaths.Count == 0)
      {
         // Create the path list and populate it with Resource folders
         resourcePaths = new List<string>();
         GetResourceFolderPaths(Application.dataPath, 0);
         //         choices = _resourcePaths.ToArray();
      }

      BeginStaticRow("Resource Path", ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         var menuIndex = 0;
         for (var i = 0; i < resourcePaths.Count; i++)
         {
            if (resourcePaths[i] == value.Replace('/', '\\'))
            {
               menuIndex = i;
            }
         }

         //send the new value to the popup and whatever it
         //returns (in case the user modified it here) is what our final value is
         //
         // When the popup control has options that include '/' characters, it automatically
         // creates subfolders for the popup. This is undesirable. Therefore, all '/' has been
         // replaced with '\', but the string returned by this function should use '/'.

         menuIndex = EditorGUILayout.Popup(menuIndex, resourcePaths.ToArray(), GUILayout.Width(columnValue.Width));
         value = resourcePaths[menuIndex].Replace('\\', '/');
      }

      EndRow(value.GetType().ToString());

      //      Debug.Log("Returning: " + value + "\n");
      return value;
   }

   public static string AssetPathField(string label, AssetType assetType, string assetPath, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      // Asset File Name
      //
      // The browser to default to the specific Resource folder path.
      // Once a file has been selected, validate that it exists in the previously specified
      // path. If not, make sure it exists under any Resource folder path, and update the
      // path control.
      //
      //    String field
      //    Button to launch file browser
      //    (exposed socket should be a string)

      //      string label = System.Enum.GetName(typeof(AssetType), (int)assetType) + " Path";

      var style = new GUIStyle(EditorStyles.miniButton)
      {
         margin = new RectOffset(4, 4, 2, 4),
         padding = new RectOffset(6, 6, 1, 2)
      };

      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         var buttonSize = style.CalcSize(new GUIContent("Browse"));

         assetPath = EditorGUILayout.TextField(assetPath, uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width - 4 - buttonSize.x));

         Enabled = !AssetBrowserWindow.isOpen;

         if (GUILayout.Button("Browse", style, GUILayout.Width(buttonSize.x)))
         {
            AssetBrowserWindow.assetType = assetType;
            AssetBrowserWindow.assetFilePath = assetPath;
            AssetBrowserWindow.shouldOpen = true;
            AssetBrowserWindow.nodeKey = nodeKey;

            //            AssetBrowserWindow.Init(resourcePath, AssetBrowserWindow.AssetType.Texture);
            //            AssetBrowserWindow.FocusWindowIfItsOpen<AssetBrowserWindow>();

            //            Debug.Log("BUTTON PRESSED\n");
            //            filepath = EditorUtility.OpenFilePanel(name, path, extension);
            //            Debug.Log("Results: " + filepath + "\n");
         }

         if (AssetBrowserWindow.nodeKey == nodeKey && AssetBrowserWindow.assetFilePath != string.Empty)
         {
            // Only get it once. Don't continue to get it, because it'll override
            // changes from other areas like undo/redo and drag/drop
            assetPath = AssetBrowserWindow.assetFilePath;
            AssetBrowserWindow.assetFilePath = string.Empty;
         }

         Enabled = true;
      }

      EndRow(assetPath.GetType().ToString());

      return assetPath;
   }

   public static bool IsGeneratedScriptMissing(string graphName)
   {
      var assetPathRelativeToProject = uScript.Preferences.GeneratedScripts.Substring(Application.dataPath.Length - 6) + "/" + graphName + ".cs";
      var result = uScript.GetAssetInstanceID(assetPathRelativeToProject, typeof(TextAsset));
      return result == -1;
   }

   public static bool PingObject(string assetPathRelativeToProject, Type type)
   {
      var instanceID = uScript.GetAssetInstanceID(assetPathRelativeToProject, type);
      if (instanceID == -1)
      {
         return false;
      }

      EditorGUIUtility.PingObject(instanceID);
      return true;
   }

   public static bool PingGeneratedScript(string scriptName)
   {
      var assetPath = uScript.Preferences.GeneratedScripts.Substring(Application.dataPath.Length - 6) + "/" + scriptName + ".cs";
      if (PingObject(assetPath, typeof(TextAsset)) == false)
      {
         // Whenever the user presses the "Source" button for a given script in the uScripts Panel,
         // if the source file is not found (because it was deleted while uScript was running),
         // the Dictionary cache should be updated for that script.
         uScript.Instance.SetStaleState(scriptName, true);
         return false;
      }

      return true;
   }

   public static bool PingScene(string assetPath)
   {
      var obj = AssetDatabase.LoadMainAssetAtPath(assetPath);
      if (obj == null)
      {
         Debug.LogWarning("Could not find \"" + assetPath + "\"\n");
         return false;
      }

      EditorGUIUtility.PingObject(obj.GetInstanceID());
      return true;
   }

   private static Dictionary<string, string> scenePaths;


   public static void GetScenePaths()
   {
      // TODO: Replace this logic, because it's slow. If we stored the full scene path with the script, this wouldn't be needed.

      scenePaths = new Dictionary<string, string>();

      // get every single one of the files in the Assets folder.
      var files = uScriptGUI.GetFilesFromDirectory(new System.IO.DirectoryInfo(Application.dataPath), "*.unity");

      foreach (var fi in files)
      {
         if (fi.Name.StartsWith("."))
         {
            // Unity ignores dotfiles
            continue;
         }

         var obj = AssetDatabase.LoadMainAssetAtPath(uScriptGUI.GetRelativeAssetPath(fi.FullName));
         var path = AssetDatabase.GetAssetPath(obj);
         var name = System.IO.Path.GetFileNameWithoutExtension(path);

         System.Diagnostics.Debug.Assert(name != null, "name != null");

         if (scenePaths.ContainsKey(name))
         {
            Debug.LogWarning("The project contains multiple scenes with the same name: \"" + name + "\".\n");
         }

         scenePaths.Add(name, path);
      }
   }

   public static void PingProjectGraph(string assetPath)
   {
      if (string.IsNullOrEmpty(assetPath))
      {
         return;
      }

      // The assetPath should be relative to the project folder
      // For example, "Assets/uScriptProjectFiles/uScripts/foobar.uscript"
      var projectPath = Application.dataPath.Substring(0, Application.dataPath.Length - 6);

      if (assetPath.StartsWith(projectPath) && assetPath.Length > projectPath.Length)
      {
         assetPath = assetPath.Substring(projectPath.Length);
      }

      var obj = AssetDatabase.LoadMainAssetAtPath(assetPath);
      if (obj == null)
      {
         Debug.LogWarning("Could not find \"" + assetPath + "\"\n");
      }
      else
      {
         EditorGUIUtility.PingObject(obj.GetInstanceID());
      }
   }

   public static void PingProjectScene(string scenePath)
   {
      // TODO: return true when successful, false otherwise.
      // TODO: inline PingScene()

      if (scenePaths == null)
      {
         GetScenePaths();
      }

      System.Diagnostics.Debug.Assert(scenePaths != null, "scenePaths should not be null here!");

      if (string.IsNullOrEmpty(scenePath))
      {
         return;
      }

      if (scenePaths.ContainsKey(scenePath))
      {
         if (PingScene(scenePaths[scenePath]) == false)
         {
            Debug.LogWarning("Could not find the scene asset in the Project.\n");
         }
      }
      else
      {
         Debug.LogWarning("The scene does not appear to exist in the project: \"" + scenePath + "\".\n");
      }
   }

   public static bool PingProjectScript(string scriptName)
   {
      // TODO: inline PingGeneratedScript()
      return PingGeneratedScript(scriptName);
   }









   public static string FixSlashes(string s)
   {
      // This may not longer be needed. When did Unity switch to using only fowardslashes?
      const string ForwardSlash = "/";
      const string BackSlash = "\\";

      return s.Replace(BackSlash, ForwardSlash);
   }

   /// <summary>
   /// Given a path to a file system object, remove everything in the path above the project Assets folder. The resulting path should work better with the Unity API.
   /// </summary>
   /// <param name="pathName"></param>
   /// <returns></returns>
   public static string GetRelativeAssetPath(string pathName)
   {
      //dataPath uses forward slashes on all platforms now
      return FixSlashes(pathName).Replace(Application.dataPath, "Assets");
   }

   /// <summary>
   /// Given a directory and a search filter, return a list of file references. This function may not work well with file system "hard links"
   /// </summary>
   /// <param name="directoryInfo"></param>
   /// <param name="searchFor"></param>
   /// <returns></returns>
   public static List<FileInfo> GetFilesFromDirectory(DirectoryInfo directoryInfo, string searchFor)
   {
      var files = directoryInfo.GetFiles(searchFor).ToList();

      // Recurse sub-directories
      var directories = directoryInfo.GetDirectories();
      foreach (var di in directories)
      {
         files.AddRange(GetFilesFromDirectory(di, searchFor));
      }

      return files;
   }










   public static string GetControlName()
   {
      return GetControlName(string.Empty);
   }

   public static void MonitorGUIControlFocusChanges()
   {
      if (GUIUtility.keyboardControl != focusedControlID)
      {
         if (ControlIDList.ContainsKey(focusedControlID))
         {
            var oldControlName = ControlIDList[focusedControlID];

            //            string newName = "UNKNOWN";
            //            if (controlIDList.ContainsKey(GUIUtility.keyboardControl))
            //            {
            //               newName = controlIDList[GUIUtility.keyboardControl];
            //            }
            //            Debug.Log("FOCUS CHANGED: \t" + focusedControlID.ToString() + " (" + oldName + ") -> " + GUIUtility.keyboardControl.ToString() + " (" + newName + ")\n");

            // When specific fields lose focus, send out an event
            if (oldControlName == WatchedControlName)
            {
               uScriptDebug.Log(
                  string.Format(
                     "The control lost focus: {0} (\"{1}\")\n",
                     focusedControlID.ToString(CultureInfo.InvariantCulture),
                     WatchedControlName),
                  uScriptDebug.Type.Debug);
            }
         }

         focusedControlID = GUIUtility.keyboardControl;
      }
   }

   public static void ResetFoldouts()
   {
      FoldoutExpanded.Clear();
   }

   public static void BeginColumns(string col1, string col2, string col3, Vector2 offset, Rect rect)
   {
      columnEnabled = new Column(string.Empty, 20);
      columnLabel = new Column(col1, 140);
      columnValue = new Column(col2, 220);
      columnType = new Column(col3, 0);

      nodeCount = 0;
      propertyCount = 0;

      columnOffset = offset;
      svRect = rect;

      if (null == styleEnabled)
      {
         styleEnabled = new GUIStyle(GUI.skin.toggle);
         styleEnabled.margin = new RectOffset(4, 0, 2, 4);
         styleEnabled.padding = new RectOffset(20, 0, 0, 0);
         styleEnabled.padding.left = 20;

         styleLabel = new GUIStyle(EditorStyles.label);
         styleLabel.margin.left = 0;

         styleType = new GUIStyle(EditorStyles.label);
         styleType.margin.left = 6;
      }

      GUILayout.Label(string.Empty, new GUIStyle(), GUILayout.Height(uScriptGUIStyle.ColumnHeaderHeight));
   }

   public static void EndColumns()
   {
      var x = 0;
      var y = columnOffset.y;

      // The columns have a margin of 4. Margins of adjacent cells overlap, so the spacing
      // betweem columns is the width of the largest margin, not the sum.
      //
      //    4.[A].4
      //          4.[B].4
      //                4.[C].4
      //
      //    4.[A].4.[B].4.[C].4
      //
      // The result should be that when laying out each column, the left-most and right-most
      // columns should allow for an extra 2px, while the inner columns assume that 2px will
      // be used on each side.
      //
      // Finally, the left margin of the left column, and the right margin of the right column
      // is excluded when positioning the GUI elements, since the offset is automatically applied.

      // First column - Checkbox
      GUI.Label(new Rect(x, y, columnEnabled.Width + 4 + 2, uScriptGUIStyle.ColumnHeaderHeight), columnEnabled.Label, uScriptGUIStyle.ColumnHeader);
      x += columnEnabled.Width + 2;

      // Interior column - Property name
      GUI.Label(new Rect(x, y, columnLabel.Width + 4, uScriptGUIStyle.ColumnHeaderHeight), columnLabel.Label, uScriptGUIStyle.ColumnHeader);
      x += columnLabel.Width + 4;

      // Interior column - Property value
      GUI.Label(new Rect(x, y, columnValue.Width + 4, uScriptGUIStyle.ColumnHeaderHeight), columnValue.Label, uScriptGUIStyle.ColumnHeader);
      x += columnValue.Width + 4;

      // Last column - Property type
      // This right-most column should appear to have an expanded width
      GUI.Label(new Rect(x, y, svRect.width, uScriptGUIStyle.ColumnHeaderHeight), columnType.Label, uScriptGUIStyle.ColumnHeader);
      //      GUI.Label(new Rect(x, y, _columnType.Width + 4 + 2, uScriptGUIStyle.columnHeaderHeight), _columnType.Label, style);
      //      GUI.Label(new Rect(x, y, svRect.width - _columnLabel.Width - columnValue.Width - 22 + columnOffset.x, uScriptGUIStyle.columnHeaderHeight), _columnType.Label, style);

      // Update control focus changes

      //if (Event.current.keyCode == KeyCode.Escape)
      //{
      //   Debug.Log("ESC was pressed\n");
      //   Event.current.Use();
      //}

      if (GUI.GetNameOfFocusedControl() != _focusedControl)
      {
         uScriptDebug.Log("Control focus changed from '" + _focusedControl + "' to '" + GUI.GetNameOfFocusedControl() + "'\n", uScriptDebug.Type.Debug);
         _previousControl = _focusedControl;
         _focusedControl = GUI.GetNameOfFocusedControl();
      }
   }

   public static void Separator()
   {
      GUILayout.Space(10);
   }

   public static void HR()
   {
      GUILayout.BeginHorizontal(uScriptGUIStyle.PanelHR, GUILayout.ExpandWidth(true));

      GUILayout.EndHorizontal();
   }

   public static bool BeginPropertyList(string label, Node node)
   {
      ScriptEditorCtrl scriptEditorCtrl = uScript.Instance.ScriptEditorCtrl;
      EntityNode entityNode = null;

      nodeCount++;
      nodeKey = node != null ? node.Guid.ToString() : "UNKNOWN";
      if (false == FoldoutExpanded.ContainsKey(nodeKey))
      {
         FoldoutExpanded[nodeKey] = true;
      }

      var isFoldoutExpanded = FoldoutExpanded[nodeKey];

      GUILayout.BeginHorizontal();
      {
         // Foldout
         var tmpColor = GUI.color;
         var textColor = uScriptGUIStyle.NodeButtonLeft.normal.textColor;

         if (null != node)
         {
            entityNode = ((DisplayNode)node).EntityNode;

            if (uScript.IsNodeTypeDeprecated(entityNode) || scriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(entityNode))
            {
               GUI.color = new Color(1, 0.5f, 1, 1);
               uScriptGUIStyle.NodeButtonLeft.normal.textColor = Color.white;
            }
         }

         // Socket segment
         GUILayout.Box(GUIContent.none, uScriptGUIStyle.PropertyButtonLeft);

#if UNITY_3_5 || UNITY_3_6
         // EditorGUI.showMixedValue was introduced in Unity 3.5

         // Display socket toggle, if appropriate
         if (isFoldoutExpanded)
         {
            if (node != null)
            {
               int expandCount = 0;
               int collapseCount = 0;

               foreach (Parameter p in entityNode.Parameters)
               {
                  if (scriptEditorCtrl.CanExpandParameter(p))
                  {
                     expandCount++;
                  }
                  else if (scriptEditorCtrl.CanCollapseParameter(node.Guid, p))
                  {
                     collapseCount++;
                  }
               }

               if (scriptEditorCtrl.CanExpandParameter(entityNode.Instance))
               {
                  expandCount++;
               }
               else if (scriptEditorCtrl.CanCollapseParameter(node.Guid, entityNode.Instance))
               {
                  collapseCount++;
               }

               if (expandCount != 0 || collapseCount != 0)
               {
                  Rect toggleRect = GUILayoutUtility.GetLastRect();
                  toggleRect.x += 3;
                  toggleRect.y += 1;
                  toggleRect.width = 20;
                  toggleRect.height = 20;

                  bool toggleState = (collapseCount > 0);

                  if (expandCount > 0 && collapseCount > 0)
                  {
                     EditorGUI.showMixedValue = true;
                  }

                  // The "ToggleMixed" style does not exist in Unity 3.x
                  GUIStyle toggleStyle = GUI.skin.toggle;
                  GUI.changed = false;
                  
                  toggleState = GUI.Toggle(toggleRect, toggleState, GUIContent.none, toggleStyle);
                  if (GUI.changed)
                  {
                     // When showing a mixed value on Unity 3.x, the toggle returns True when pressed.
                     // It returns False on Unity 4.x.
                     if (EditorGUI.showMixedValue)
                     {
                        toggleState = !toggleState;
                     }

                     if (toggleState)
                     {
                        scriptEditorCtrl.ExpandNode(node);
                     }
                     else
                     {
                        scriptEditorCtrl.CollapseNode(node);
                     }
                  }

                  EditorGUI.showMixedValue = false;
               }
            }
         }
#elif !UNITY_3_3 && !UNITY_3_4
         // Display socket toggle, if appropriate
         if (isFoldoutExpanded)
         {
            if (node != null)
            {
               var expandCount = 0;
               var collapseCount = 0;

               foreach (var p in entityNode.Parameters)
               {
                  if (scriptEditorCtrl.CanExpandParameter(p))
                  {
                     expandCount++;
                  }
                  else if (scriptEditorCtrl.CanCollapseParameter(node.Guid, p))
                  {
                     collapseCount++;
                  }
               }

               if (scriptEditorCtrl.CanExpandParameter(entityNode.Instance))
               {
                  expandCount++;
               }
               else if (scriptEditorCtrl.CanCollapseParameter(node.Guid, entityNode.Instance))
               {
                  collapseCount++;
               }

               if (expandCount != 0 || collapseCount != 0)
               {
                  var toggleRect = GUILayoutUtility.GetLastRect();
                  toggleRect.x += 3;
                  toggleRect.y += 1;
                  toggleRect.width = 20;
                  toggleRect.height = 20;

                  var toggleState = collapseCount > 0;

                  if (expandCount > 0 && collapseCount > 0)
                  {
                     EditorGUI.showMixedValue = true;
                  }

                  var toggleStyle = EditorGUI.showMixedValue ? "ToggleMixed" : GUI.skin.toggle;
                  GUI.changed = false;

                  toggleState = GUI.Toggle(toggleRect, toggleState, GUIContent.none, toggleStyle);
                  if (GUI.changed)
                  {
                     if (toggleState)
                     {
                        scriptEditorCtrl.ExpandNode(node);
                     }
                     else
                     {
                        scriptEditorCtrl.CollapseNode(node);
                     }
                  }

                  EditorGUI.showMixedValue = false;
               }
            }
         }
#endif

         // Name segment
         if (uScript.IsDevelopmentBuild)
         {
            // Add the node key for development builds
            label += "\t\t[" + nodeKey + "]";
         }

         isFoldoutExpanded = GUILayout.Toggle(
            isFoldoutExpanded,
            label,
            node == null ? uScriptGUIStyle.PropertyButtonRightName : uScriptGUIStyle.PropertyButtonMiddleName);

         // Node buttons
         if (null != node)
         {
            // Deprecation button
            if (uScript.IsNodeTypeDeprecated(entityNode) == false && scriptEditorCtrl.ScriptEditor.IsNodeInstanceDeprecated(entityNode))
            {
               if (scriptEditorCtrl.ScriptEditor.CanUpgradeNode(entityNode))
               {
                  if (GUILayout.Button(uScriptGUIContent.buttonNodeUpgrade, uScriptGUIStyle.PropertyButtonMiddleDeprecated))
                  {
                     var Click = new EventHandler(scriptEditorCtrl.m_MenuUpgradeNode_Click);

                     // clear all selected nodes first
                     scriptEditorCtrl.DeselectAll();
                     // toggle the clicked node
                     scriptEditorCtrl.ToggleNode(node.Guid);
                     Click(null, new EventArgs());
                  }
               }
               else
               {
                  if (GUILayout.Button(uScriptGUIContent.buttonNodeDeleteMissing, uScriptGUIStyle.PropertyButtonMiddleDeprecated))
                  {
                     var Click = new EventHandler(scriptEditorCtrl.m_MenuDeleteMissingNode_Click);

                     // clear all selected nodes first
                     scriptEditorCtrl.DeselectAll();
                     // toggle the clicked node
                     scriptEditorCtrl.ToggleNode(node.Guid);
                     Click(null, new EventArgs());
                  }
               }
            }

            // Favorite button
            var favoriteNodeType = uScript.GetNodeSignature(entityNode);
            var favoriteNodes = uScript.Preferences.FavoriteNodes;
            var favoriteIndex = Array.IndexOf(favoriteNodes, favoriteNodeType) + 1;

            var newIndex = EditorGUILayout.Popup(favoriteIndex, uScriptGUIPanelPalette.Instance.favoritePopupOptions, uScriptGUIStyle.PropertyButtonMiddleFavorite, GUILayout.Width(30));
            if (newIndex != favoriteIndex)
            {
               if (favoriteIndex == 0)
               {
                  uScript.Preferences.UpdateFavoriteNode(newIndex, favoriteNodeType);
               }
               else if (newIndex == 0)
               {
                  uScript.Preferences.UpdateFavoriteNode(favoriteIndex, string.Empty);
               }
               else
               {
                  uScript.Preferences.SwapFavoriteNodes(favoriteIndex, newIndex);
               }

               uScriptGUIPanelPalette.Instance.BuildFavoritesMenu();
            }

            // Favorite star
            var popupRect = GUILayoutUtility.GetLastRect();

            GUI.Label(popupRect, new GUIContent("\u2605"), uScriptGUIStyle.PropertyButtonMiddleFavoriteStar);

            // Search button
            if (GUILayout.Button(uScriptGUIContent.buttonNodeFind, uScriptGUIStyle.PropertyButtonRightSearch))
            {
               scriptEditorCtrl.CenterOnNode(node);
            }

            GUI.color = tmpColor;
            uScriptGUIStyle.NodeButtonLeft.normal.textColor = textColor;
         }  // Node buttons
      }

      GUILayout.EndHorizontal();

      // add a little extra space after the node foldout
      GUILayout.Space(2);

      // begin the first property of each node as an "odd" row
      isPropertyRowEven = false;

      // store the foldout state for future use
      FoldoutExpanded[nodeKey] = isFoldoutExpanded;

      return isFoldoutExpanded;
   }

   public static void EndPropertyList()
   {
      if (FoldoutExpanded[nodeKey])
      {
         Separator();
      }
   }

   public static int IntField(string label, int value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      return IntField(label, value, ref isSocketExposed, isLocked, isReadOnly, int.MinValue, int.MaxValue);
   }

   public static int IntField(string label, int value, ref bool isSocketExposed, bool isLocked, bool isReadOnly, int min, int max)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         value = EditorGUILayout.IntField(value, uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }

   public static float FloatField(string label, float value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         value = EditorGUILayout.FloatField(value, uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }

   public static T GetFieldValue<T>(Type type, string fieldName, BindingFlags bindingFlags)
   {
      var fieldInfo = type.GetField(fieldName, bindingFlags);
      System.Diagnostics.Debug.Assert(fieldInfo != null, "Unable to access a field named \"" + fieldName + "\"");
      return (T)fieldInfo.GetValue(null);
   }

   public static T GetPropertyValue<T>(Type type, string propertyName, BindingFlags bindingFlags)
   {
      var propertyInfo = type.GetProperty(propertyName, bindingFlags);
      System.Diagnostics.Debug.Assert(propertyInfo != null, "Unable to access a property named \"" + propertyName + "\"");
      return (T)propertyInfo.GetValue(null, null);
   }

   public static string VariableNameField(string label, string value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         // FIXME: Unity 4.1 has issues here as well, which should be fixed before this control is used.  See: http://uscript.net/forum/viewtopic.php?f=11&t=2434

         // Rebuild the functionality of the Unity TextField so that we can
         // assign the ControlID ourselves, and keep track if it for later use

         // Use reflection to access some internal or sealed members from
         // EditorGUI ... why Unity? Why?
         const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;

         // Unity 3.x uses a FIELD, whereas Unity 4.x uses a PROPERTY. Ugh.
         var maxWidth = uScript.UnityVersion < 4.0f
            ? GetFieldValue<float>(typeof(EditorGUILayout), "kLabelFloatMaxW", Flags)
            : GetPropertyValue<float>(typeof(EditorGUILayout), "kLabelFloatMaxW", Flags);
         var minWidth = GetFieldValue<float>(typeof(EditorGUI), "kNumberW", Flags);

         var style = uScriptGUIStyle.PropertyTextField;
         var position = GUILayoutUtility.GetRect(minWidth, maxWidth, 16f, 16f, style, GUILayout.Width(columnValue.Width));
         var controlName = GetControlName();
         var id = GUIUtility.GetControlID(controlName.GetHashCode(), FocusType.Keyboard, position);

         var fieldInfo = typeof(EditorGUI).GetField("s_RecycledEditor", Flags);
         System.Diagnostics.Debug.Assert(fieldInfo != null, "Unable to access the RecycledEditor field.");

         var parameters = new[]
         {
            fieldInfo.GetValue(null),                  // RecycledTextEditor editor
            id,                                 // int id
            EditorGUI.IndentedRect(position),   // Rect position
            value,                              // string text
            style,                              // GUIStyle style
            null,                               // string allowedLetters
            false,                               // out bool changed
            false,                              // bool reset
            false,                              // bool multiline
            false                               // bool passwordField
         };

         var methodInfo = typeof(EditorGUI).GetMethod("DoTextField", Flags);
         value = (string)methodInfo.Invoke(null, parameters);

         // Associate the id with the control name
         ControlIDList[id] = controlName;

         WatchedControlName = GetControlName();
      }

      EndRow(value.GetType().ToString());
      return value;
   }

   public static string TextField(string label, string value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         value = EditorGUILayout.TextField(value, uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }

   public static string TextArea(string label, string value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         value = EditorGUILayout.TextArea(value, GUILayout.Width(columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }

   public static bool BoolField(string label, bool value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         value = GUILayout.Toggle(value, GUIContent.none, uScriptGUIStyle.PropertyBoolField, GUILayout.Width(columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }

   public static void BlankField(string label, string text, ref bool isSocketExposed, bool isLocked)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, true);

      EditorGUILayout.TextField(text, uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width));

      EndRow(string.Empty);
   }

   public static Color ColorField(string label, Color value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         value = EditorGUILayout.ColorField(value, GUILayout.Width(columnValue.Width));
      }

      EndRow(value.GetType().ToString());

      //      Vector4 v = value;
      //      int r = (int)(255 * v.x);
      //      int g = (int)(255 * v.y);
      //      int b = (int)(255 * v.z);
      //      int a = (int)(255 * v.w);
      //
      //      EditorGUILayout.LabelField(string.Empty, value.ToString());
      //      EditorGUILayout.LabelField(string.Empty, v.ToString("F2"));
      //      EditorGUILayout.LabelField(string.Empty, (r << 24 | g << 16 | b << 8 | a).ToString("X8"));
      //      EditorGUILayout.LabelField(string.Empty, r.ToString("X2") + " " + g.ToString("X2") + " "
      //                                             + b.ToString("X2") + " " + a.ToString("X2"));
      //      EditorGUILayout.LabelField(string.Empty, r.ToString() + " " + g.ToString() + " "
      //                                             + b.ToString() + " " + a.ToString());

      return value;
   }

   public static GUILayoutOption GUILayoutOptionField(string label, GUILayoutOption value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         const int Spacing = 4; // 4 * 1
         var w = (columnValue.Width - Spacing) / 2;
         var p = (columnValue.Width - Spacing) % (w * 2);

         int optionIndex;
         int optionValue;

         DeconstructGUILayoutOption(value, out optionIndex, out optionValue);

         optionIndex = EditorGUILayout.Popup(optionIndex, GUILayoutOptionDisplayNames, GUILayout.Width(w));

         var optionName = GUILayoutOptionDisplayNames[optionIndex];
         if (optionName == "ExpandWidth" || optionName == "ExpandHeight")
         {
            var optionBool = optionValue != 0;
            optionBool = GUILayout.Toggle(optionBool, GUIContent.none, uScriptGUIStyle.PropertyBoolField, GUILayout.Width(w + p));
            optionValue = optionBool ? 1 : 0;
         }
         else
         {
            optionValue = Math.Max(0, EditorGUILayout.IntField(optionValue, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p)));
         }

         value = CreateGUILayoutOption(optionIndex, optionValue);
      }

      EndRow("GUILayoutOption");
      return value;
   }

   public static void HideScrollbars()
   {
      if (horizontalScrollbarLeftButton != null)
      {
         return;
      }

      horizontalScrollbarLeftButton = new GUIStyle(GUI.skin.horizontalScrollbarLeftButton);
      horizontalScrollbarRightButton = new GUIStyle(GUI.skin.horizontalScrollbarRightButton);
      horizontalScrollbarThumb = new GUIStyle(GUI.skin.horizontalScrollbarThumb);

      verticalScrollbarUpButton = new GUIStyle(GUI.skin.verticalScrollbarUpButton);
      verticalScrollbarDownButton = new GUIStyle(GUI.skin.verticalScrollbarDownButton);
      verticalScrollbarThumb = new GUIStyle(GUI.skin.verticalScrollbarThumb);

      GUI.skin.horizontalScrollbarLeftButton = GUIStyle.none;
      GUI.skin.horizontalScrollbarRightButton = GUIStyle.none;
      GUI.skin.horizontalScrollbarThumb = GUIStyle.none;

      GUI.skin.verticalScrollbarUpButton = GUIStyle.none;
      GUI.skin.verticalScrollbarDownButton = GUIStyle.none;
      GUI.skin.verticalScrollbarThumb = GUIStyle.none;
   }

   public static void ShowScrollbars()
   {
      if (horizontalScrollbarLeftButton == null)
      {
         return;
      }

      GUI.skin.horizontalScrollbarLeftButton = horizontalScrollbarLeftButton;
      GUI.skin.horizontalScrollbarRightButton = horizontalScrollbarRightButton;
      GUI.skin.horizontalScrollbarThumb = horizontalScrollbarThumb;

      GUI.skin.verticalScrollbarUpButton = verticalScrollbarUpButton;
      GUI.skin.verticalScrollbarDownButton = verticalScrollbarDownButton;
      GUI.skin.verticalScrollbarThumb = verticalScrollbarThumb;

      horizontalScrollbarLeftButton = null;
      horizontalScrollbarRightButton = null;
      horizontalScrollbarThumb = null;

      verticalScrollbarUpButton = null;
      verticalScrollbarDownButton = null;
      verticalScrollbarThumb = null;
   }

   public static Vector2 Vector2Field(string label, Vector2 value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         const int Spacing = 4; // 4 * 1
         var w = (columnValue.Width - Spacing) / 2;
         var p = (columnValue.Width - Spacing) % (w * 2);

         value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p));
      }

      EndRow(value.GetType() + " [X, Y]");
      return value;
   }

   public static Vector3 Vector3Field(string label, Vector3 value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         const int Spacing = 8; // 4 * 2
         var w = (columnValue.Width - Spacing) / 3;
         var p = (columnValue.Width - Spacing) % (w * 3);

         value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p));
      }

      EndRow(value.GetType() + " [X, Y, Z]");
      return value;
   }

   public static Vector4 Vector4Field(string label, Vector4 value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         const int Spacing = 12; // 4 * 3
         var w = (columnValue.Width - Spacing) / 4;
         var p = (columnValue.Width - Spacing) % (w * 4);

         value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.w = EditorGUILayout.FloatField(value.w, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p));
      }

      EndRow(value.GetType() + " [X, Y, Z, W]");
      return value;
   }

   public static Rect RectField(string label, Rect value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         const int Spacing = 12; // 4 * 3
         var w = (columnValue.Width - Spacing) / 4;
         var p = (columnValue.Width - Spacing) % (w * 4);

         value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.width = EditorGUILayout.FloatField(value.width, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.height = EditorGUILayout.FloatField(value.height, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p));
      }

      EndRow(value.GetType() + " [X, Y, W, H]");
      return value;
   }

   public static Quaternion QuaternionField(string label, Quaternion value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         const int Spacing = 12; // 4 * 3
         var w = (columnValue.Width - Spacing) / 4;
         var p = (columnValue.Width - Spacing) % (w * 4);

         value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.z = EditorGUILayout.FloatField(value.z, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         value.w = EditorGUILayout.FloatField(value.w, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p));
      }

      EndRow(value.GetType() + " [X, Y, Z, W]");
      return value;
   }

   public static Enum EnumField(string label, Enum value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         //int spacing = 12; // 4 * 3
         //int w = (columnValue.Width - spacing) / 4;
         //int p = (columnValue.Width - spacing) % (w * 4);
         //value.x = EditorGUILayout.FloatField(value.x, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         //value.y = EditorGUILayout.FloatField(value.y, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         //value.width = EditorGUILayout.FloatField(value.width, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         //value.height = EditorGUILayout.FloatField(value.height, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p));

         value = EditorGUILayout.EnumPopup(value, GUILayout.Width(columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }

   public static int LayerField(string label, int value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         //  0         1    Default
         //  1         2    TransparentFX
         //  2         4    Ignore Raycast
         //  3         8
         //  4        16    Water
         //  5        32
         //  6        64
         //  7       128
         //  8       256
         //  9       512
         // 10      1024    TEN

         value = Log2((uint)value);

         value = EditorGUILayout.LayerField(value, GUILayout.Width(columnValue.Width));

         value = 1 << value;
      }

      EndRow(value.GetType().ToString());
      return value;
   }

   public static int Log2(uint number)
   {
      var isPowerOfTwo = number > 0 && (number & (number - 1)) == 0;
      if (!isPowerOfTwo)
      {
         return 0;
         //throw new ArgumentException("Not a power of two", "number");
      }

      return (int)Math.Log(number, 2);
   }

   public static string TagField(string label, string value, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         value = EditorGUILayout.TagField(value, GUILayout.Width(columnValue.Width));
      }

      EndRow(value.GetType().ToString());
      return value;
   }

   public static string FormatMaskDisplay(string value)
   {
      int mask;

      if (int.TryParse(value, out mask))
      {
         if (mask == 0)
         {
            return "None";
         }

         if ((uint)mask == 0xffffffff)
         {
            return "All";
         }

         var isPowerOfTwo = (mask & (mask - 1)) == 0;

         return isPowerOfTwo ? Math.Log(mask, 2).ToString(CultureInfo.InvariantCulture) : "Mixed";
      }

      return "Invalid Value";
   }

   public static string ChoiceField(string label, string value, string[] choices, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

      if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
      {
         var menuIndex = 0;
         for (var i = 0; i < choices.Length; i++)
         {
            if (choices[i] == value)
            {
               menuIndex = i;
            }
         }

         //send the new value to the popup and whatever it
         //returns (in case the user modified it here) is what our final value is
         menuIndex = EditorGUILayout.Popup(menuIndex, choices, GUILayout.Width(columnValue.Width));
         value = choices[menuIndex];
      }

      EndRow(value.GetType().ToString());

      return value;
   }

   public static Enum EnumTextField(string label, Enum value, string textValue, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      EditorGUILayout.BeginVertical();
      {
         BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

         if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
         {
            //first show the text field and get back the same (or changed value)
            var userText = EditorGUILayout.TextField(textValue, uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width));
            Enum newEnum;

            //try and turn the text field value back into an enum, if it doesn't work
            //then revert back to the original value
            try
            {
               newEnum = (Enum)Enum.Parse(value.GetType(), userText);
            }
            catch
            {
               newEnum = value;
            }

            EndRow(textValue.GetType().ToString());

            var tmpBool = false;

            BeginStaticRow(string.Empty, ref tmpBool, true, isReadOnly);

            //send the new value to the enum popup and whatever it
            //returns (in case the user modified it here) is what our final value is
            value = EditorGUILayout.EnumPopup(newEnum, GUILayout.Width(columnValue.Width));
         }

         EndRow(value.GetType().ToString());
      }

      EditorGUILayout.EndVertical();
      return value;
   }

   public static string ObjectField(string label, UnityEngine.Object value, Type type, string textValue, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      EditorGUILayout.BeginVertical();
      {
         BeginStaticRow(label, ref isSocketExposed, isLocked, isReadOnly);

         if (IsFieldUsable(isSocketExposed, isLocked, isReadOnly))
         {
#if (UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3)
               textValue = EditorGUILayout.TextField(textValue, uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width));
      
               EndRow(textValue.GetType().ToString());

               bool tmpBool = false;

               BeginStaticRow(string.Empty, ref tmpBool, true, isReadOnly);
#endif

            // now try and update the object browser with an instance of the specified object
            var objects = UnityEngine.Object.FindObjectsOfType(type);
            var unityObject = objects.FirstOrDefault(o => o.name == textValue);

            // components should never be instances in the property grid
            // we must refer to (and select) their parent game object
            if (typeof(Component).IsAssignableFrom(type))
            {
               type = typeof(GameObject);
               if (null != unityObject)
               {
                  unityObject = ((Component)unityObject).gameObject;
               }
            }

            //if we're building with 3.4 or greater then check the client version
            //and figure out which one to display
#if (UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3)
            //if we're not building with 3.4 or greater then default to the old one
#pragma warning disable 618
            unityObject = EditorGUILayout.ObjectField(unityObject, type, GUILayout.Width(columnValue.Width)) as UnityEngine.Object;
#pragma warning restore 618
#else
            if (uScript.UnityVersion < 3.4f)
            {
#pragma warning disable 618
               unityObject = EditorGUILayout.ObjectField(unityObject, type, GUILayout.Width(columnValue.Width));
#pragma warning restore 618
            }
            else
            {
               unityObject = EditorGUILayout.ObjectField(unityObject, type, true, GUILayout.Width(columnValue.Width));
            }
#endif

            // if that object (or the changed object) does exist, use it's name to update the property value
            // if it doesn't exist then the 'val' will stay as what was entered into the TextField
            if (unityObject != null)
            {
               textValue = unityObject.name;
            }
         }

         EndRow(type.ToString());
      }

      EditorGUILayout.EndVertical();
      return textValue;
   }

   public static T[] ArrayFoldout<T>(string label, T[] array, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      return ArrayFoldout(label, array, ref isSocketExposed, isLocked, isReadOnly, null);
   }

   public static T[] ArrayFoldout<T>(string label, T[] array, ref bool isSocketExposed, bool isLocked, bool isReadOnly, Type type)
   {
      var propertyKey = string.Format("{0}_{1}", nodeKey, label);
      var isExpanded = !FoldoutExpanded.ContainsKey(propertyKey) || FoldoutExpanded[propertyKey];

      // The Foldout row
      BeginFoldoutRow(label, ref isSocketExposed, isLocked, isReadOnly, ref isExpanded);

      // Display the array info, readonly, socketUsed, or an empty area
      var isFieldUsable = IsFieldUsable(isSocketExposed, isLocked, isReadOnly);
      if (isFieldUsable)
      {
         GUILayout.Label("... (" + array.Length + " item" + (array.Length == 1 ? string.Empty : "s") + ")", styleLabel, GUILayout.Width(columnValue.Width));

         var btnRect = GUILayoutUtility.GetLastRect();
         btnRect.x = btnRect.xMax - 18;
         btnRect.width = 18;
         btnRect.height = 16;

         if (GUI.Button(btnRect, uScriptGUIContent.buttonArrayAdd, uScriptGUIStyle.PropertyArrayTextButton))
         {
            GUIUtility.keyboardControl = 0;
            // Special conversion case for strings and GUILayoutOption objects
            var element = typeof(T) == typeof(string)
               ? (T)(object)string.Empty
               : (typeof(T) == typeof(GUILayoutOption)
                  ? (T)(object)GUILayout.Width(0)
                  : default(T));
            array = ArrayAppend(array, element);
         }

         btnRect.x -= 18;

         if (GUI.Button(btnRect, uScriptGUIContent.buttonArrayClear, uScriptGUIStyle.PropertyArrayTextButton))
         {
            GUIUtility.keyboardControl = 0;
            array = new T[] { };
         }
      }

      EndRow(type != null ? type + "[]" : array.GetType().ToString());

      // The array size
      if (isExpanded && isFieldUsable)
      {
         var hideSocket = false;

         EditorGUI.indentLevel += 2;

         // The elements
         for (var i = 0; i < array.Length; i++)
         {
            var entry = default(T);

            if (i < array.Length)
            {
               entry = array[i];
            }

            if (entry == null)
            {
               if (typeof(T) == typeof(Enum))
               {
                  entry = (T)Enum.Parse(type, Enum.GetNames(type)[0]);
               }
            }

            array[i] = ArrayElementRow(ref array, i, entry, ref hideSocket, true, false, type);
         }

         EditorGUI.indentLevel -= 2;
      }

      FoldoutExpanded[propertyKey] = isExpanded;

      return array;
   }

   public static string GetHierarchyPath(Transform transform)
   {
      var result = string.Empty;
      while (transform)
      {
         result = transform.gameObject.name + '/' + result;
         transform = transform.parent;
      }

      return '/' + result.Remove(result.Length - 1);
   }

   public static T ArrayElementRow<T>(ref T[] array, int index, T value, ref bool isSocketExposed, bool isLocked, bool isReadOnly, Type type)
   {
      var r1 = GUILayoutUtility.GetLastRect();
      r1.y = r1.yMax + 2;

      BeginStaticRow(string.Format("[{0}]", index.ToString(CultureInfo.InvariantCulture)), ref isSocketExposed, isLocked, isReadOnly);

      // Get the last rect to determine where we want to draw the array modifier buttons
      var row = GUILayoutUtility.GetLastRect();

      var btnRect = row;
      btnRect.x = btnRect.xMax - 18;
      btnRect.width = 18;
      btnRect.height = 16;

      // Determine the rect for the entire property panel row
      row.x = uScriptGUIPanel.Rect.x;
      row.width = uScriptGUIPanel.Rect.width;

      // When the mouse is over the row
      //      if (row.Contains(Event.current.mousePosition))
      //      {
      //         // Draw once if the row has changed
      //         if (_previousHotRect != row)
      //         {
      //            _previousHotRect = row;
      //            uScript.RequestRepaint();
      //         }

      if (GUI.Button(btnRect, uScriptGUIContent.buttonArrayRemove, uScriptGUIStyle.PropertyArrayTextButton))
      {
         GUIUtility.keyboardControl = 0;
         array = ArrayRemove(array, index);
      }

      btnRect.x -= 18;

      if (GUI.Button(btnRect, uScriptGUIContent.buttonArrayDuplicate, uScriptGUIStyle.PropertyArrayTextButton))
      {
         GUIUtility.keyboardControl = 0;
         array = ArrayInsert(array, index, array[index]);
      }

      btnRect.x -= 18;

      if (GUI.Button(btnRect, uScriptGUIContent.buttonArrayInsert, uScriptGUIStyle.PropertyArrayTextButton))
      {
         GUIUtility.keyboardControl = 0;

         // Special conversion case for strings and GUILayoutOption objects
         var element = typeof(T) == typeof(string)
            ? (T)(object)string.Empty
            : (typeof(T) == typeof(GUILayoutOption)
               ? (T)(object)GUILayout.Width(0)
               : default(T));

         array = ArrayInsert(array, index, element);
      }
      //      }

      object t = value;
      var typeFormat = string.Empty;

      if (value is int)
      {
         t = EditorGUILayout.IntField((int)t, uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width));
      }
      else if (value is float)
      {
         t = EditorGUILayout.FloatField((float)t, uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width));
      }
      else if (value is string)
      {
         if (type != null)
         {
            EditorGUILayout.BeginHorizontal(GUILayout.Width(columnValue.Width));
            {
               t = EditorGUILayout.TextField((string)t, uScriptGUIStyle.PropertyTextField, GUILayout.ExpandWidth(true));

               Rect r = GUILayoutUtility.GetLastRect();

               if (r.Contains(Event.current.mousePosition) && GUI.enabled)
               {
                  var objectReferences = DragAndDrop.objectReferences;

                  if (objectReferences.Length == 1)
                  {
                     if (objectReferences[0] is GameObject)
                     {
                        var go = objectReferences[0] as GameObject;

                        DragAndDrop.visualMode = DragAndDropVisualMode.Link;

                        if (Event.current.type == EventType.DragPerform)
                        {
                           t = GetHierarchyPath(go.transform);
                           GUI.changed = true;
                           DragAndDrop.AcceptDrag();
                           DragAndDrop.activeControlID = 0;
                        }
                     }

                     Event.current.Use();
                  }
               }

               Enabled = string.IsNullOrEmpty((string)t) == false;

               if (GUILayout.Button(uScriptGUIContent.buttonArraySearch, uScriptGUIStyle.PropertyArrayIconButton))
               {
                  GUIUtility.keyboardControl = 0;
                  GameObject go = GameObject.Find((string)t);
                  if (go != null)
                  {
                     EditorGUIUtility.PingObject(go);
                  }
                  else
                  {
                     Debug.LogWarning(string.Format(
                        "No GameObject matching \"{0}\" was found in the Scene.\n\tAn associated Game Object may not yet exist,"
                        + " or might not be active.  Game Object names may contain leading and trailing whitespace.\n",
                        t));
                  }
               }

               Enabled = true;
            }

            EditorGUILayout.EndHorizontal();
         }
         else
         {
            t = EditorGUILayout.TextField((string)t, uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width));
         }
      }
      else if (value is bool)
      {
         t = GUILayout.Toggle((bool)t, GUIContent.none, uScriptGUIStyle.PropertyBoolField, GUILayout.Width(columnValue.Width));
      }
      else if (value is Enum)
      {
         t = EditorGUILayout.EnumPopup((Enum)t, GUILayout.Width(columnValue.Width));
      }
      else if (value is GUILayoutOption)
      {
         const int Spacing = 4; // 4 * 1
         var w = (columnValue.Width - Spacing) / 2;
         var p = (columnValue.Width - Spacing) % (w * 2);

         int optionIndex;
         int optionValue;

         DeconstructGUILayoutOption((GUILayoutOption)t, out optionIndex, out optionValue);

         optionIndex = EditorGUILayout.Popup(optionIndex, GUILayoutOptionDisplayNames, GUILayout.Width(w));

         string optionName = GUILayoutOptionDisplayNames[optionIndex];
         if (optionName == "ExpandWidth" || optionName == "ExpandHeight")
         {
            bool optionBool = optionValue != 0;
            optionBool = GUILayout.Toggle(optionBool, GUIContent.none, uScriptGUIStyle.PropertyBoolField, GUILayout.Width(w + p));
            optionValue = optionBool ? 1 : 0;
         }
         else
         {
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            optionValue = Math.Max(0, EditorGUILayout.IntField(optionValue, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p)));
            EditorGUI.indentLevel = indent;
         }

         t = CreateGUILayoutOption(optionIndex, optionValue);
      }
      else if (value is Color)
      {
         t = EditorGUILayout.ColorField((Color)t, GUILayout.Width(columnValue.Width));
      }
      else if (value is Vector2)
      {
         const int Spacing = 4; // 4 * 1
         var w = (columnValue.Width - Spacing) / 2;
         var p = (columnValue.Width - Spacing) % (w * 2);
         var val = (Vector2)t;

         val.x = EditorGUILayout.FloatField(val.x, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p));
         typeFormat = " [X, Y]";

         t = val;
      }
      else if (value is Vector3)
      {
         const int Spacing = 8; // 4 * 2
         var w = (columnValue.Width - Spacing) / 3;
         var p = (columnValue.Width - Spacing) % (w * 3);
         var val = (Vector3)t;

         val.x = EditorGUILayout.FloatField(val.x, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.z = EditorGUILayout.FloatField(val.z, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p));
         typeFormat = " [X, Y, Z]";

         t = val;
      }
      else if (value is Vector4)
      {
         const int Spacing = 12; // 4 * 3
         var w = (columnValue.Width - Spacing) / 4;
         var p = (columnValue.Width - Spacing) % (w * 4);
         var val = (Vector4)t;

         val.x = EditorGUILayout.FloatField(val.x, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.z = EditorGUILayout.FloatField(val.z, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.w = EditorGUILayout.FloatField(val.w, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p));
         typeFormat = " [X, Y, Z, W]";

         t = val;
      }
      else if (value is Rect)
      {
         const int Spacing = 12; // 4 * 3
         var w = (columnValue.Width - Spacing) / 4;
         var p = (columnValue.Width - Spacing) % (w * 4);
         var val = (Rect)t;

         val.x = EditorGUILayout.FloatField(val.x, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.width = EditorGUILayout.FloatField(val.width, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.height = EditorGUILayout.FloatField(val.height, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p));
         typeFormat = " [X, Y, W, H]";

         t = val;
      }
      else if (value is Quaternion)
      {
         const int Spacing = 12; // 4 * 3
         var w = (columnValue.Width - Spacing) / 4;
         var p = (columnValue.Width - Spacing) % (w * 4);
         var val = (Quaternion)t;

         val.x = EditorGUILayout.FloatField(val.x, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.y = EditorGUILayout.FloatField(val.y, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.z = EditorGUILayout.FloatField(val.z, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w));
         val.w = EditorGUILayout.FloatField(val.w, uScriptGUIStyle.PropertyTextField, GUILayout.Width(w + p));
         typeFormat = " [X, Y, Z, W]";

         t = val;
      }
      else if (value is UnityEngine.Object)
      {
         Debug.LogWarning("Arrays of Object[] are not handled yet!\n");
      }
      else
      {
         Debug.LogWarning("Unhandled array type: " + value.GetType() + "\n");
         //throw System.ArgumentException("Unhandled type: " + value.GetType().ToString());
      }

      value = (T)t;

      EndRow(type != null ? type.ToString() : value.GetType() + typeFormat);
      return value;
   }

   public static string ToolbarSearchField(string value, params GUILayoutOption[] options)
   {
      // Unity's built-in search field is internal. Lame.
      var method = typeof(EditorGUILayout).GetMethod(
         "ToolbarSearchField",
         BindingFlags.Static | BindingFlags.NonPublic,
         null,
         new[] { typeof(string), typeof(GUILayoutOption[]) },
         null);

      if (method != null)
      {
         value = (string)method.Invoke(null, new object[] { value, options });
      }

      return value;
   }

   public static GUILayoutOption CreateGUILayoutOption(string optionName, int optionValue)
   {
      switch (optionName)
      {
         case "Width":
            return GUILayout.Width(optionValue);

         case "Height":
            return GUILayout.Height(optionValue);

         case "MinWidth":
            return GUILayout.MinWidth(optionValue);

         case "MaxWidth":
            return GUILayout.MaxWidth(optionValue);

         case "MinHeight":
            return GUILayout.MinHeight(optionValue);

         case "MaxHeight":
            return GUILayout.MaxHeight(optionValue);

         case "ExpandWidth":
            return GUILayout.ExpandWidth(optionValue != 0);

         case "ExpandHeight":
            return GUILayout.ExpandHeight(optionValue != 0);
      }

      Debug.LogError("Unhandled option type: " + optionName + "\n");
      return null;
   }

   private static T[] ArrayAppend<T>(T[] array, T val)
   {
      var list = new List<T>(array);
      list.Add(val);
      return list.ToArray();
   }

   private static T[] ArrayInsert<T>(T[] array, int index, T val)
   {
      if (index < 0 || index >= array.Length)
      {
         uScriptDebug.Log("The specified index (" + index + ") is out of range [0.." + (array.Length - 1) + "]", uScriptDebug.Type.Error);
         return array;
      }

      var list = new List<T>(array);
      list.Insert(index, val);
      return list.ToArray();
   }

   private static T[] ArrayRemove<T>(T[] array, int index)
   {
      if (index < 0 || index >= array.Length)
      {
         uScriptDebug.Log("The specified index (" + index + ") is out of range [0.." + (array.Length - 1) + "]", uScriptDebug.Type.Error);
         return array;
      }

      var list = new List<T>(array);
      list.RemoveAt(index);
      return list.ToArray();
   }

   private static void BeginFoldoutRow(string label, ref bool isSocketExposed, bool isLocked, bool isReadOnly, ref bool isExpanded)
   {
      SetupRow(ref isSocketExposed, isLocked, isReadOnly);

      if (isSocketExposed && (isLocked || isReadOnly))
      {
         EditorGUILayout.PrefixLabel(label, styleLabel);
      }
      else
      {
         isExpanded = GUILayout.Toggle(isExpanded, label, EditorStyles.foldout, GUILayout.Width(columnLabel.Width - 3));
      }

      Enabled = (!isReadOnly) && (!isSocketExposed || !isLocked);
   }

   private static void BeginStaticRow(string label, ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      SetupRow(ref isSocketExposed, isLocked, isReadOnly);

      EditorGUILayout.PrefixLabel(string.IsNullOrEmpty(label) ? " " : label, styleLabel);
      Enabled = (!isReadOnly) && (!isSocketExposed || !isLocked);
   }

   private static void SetupRow(ref bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      // TODO: isReadOnly is not used. Investigate why and remove if not needed.

      EditorGUILayout.BeginHorizontal(isPropertyRowEven ? uScriptGUIStyle.PropertyRowEven : uScriptGUIStyle.PropertyRowOdd);
      isPropertyRowEven = !isPropertyRowEven;

      if (isSocketExposed == false && isLocked)
      {
         GUILayout.Space(columnEnabled.Width + 4);
      }
      else
      {
         Enabled = false == isLocked;
         isSocketExposed = GUILayout.Toggle(isSocketExposed, string.Empty, styleEnabled, GUILayout.Width(columnEnabled.Width));
         Enabled = true;
      }

      // Display the column label
      EditorGUIUtility.LookLikeControls(columnLabel.Width);
   }

   private static void EndRow(string type)
   {
      type = uScriptConfig.Variable.FriendlyName(type).Replace("UnityEngine.", string.Empty);
      var v = styleType.CalcSize(new GUIContent(type));
      columnType.Width = Mathf.Max(columnType.Width, (int)v.x);

      Enabled = true;
      GUILayout.Label(type, styleType);
      EditorGUILayout.EndHorizontal();

      propertyCount++;
   }

   private static bool IsFieldUsable(bool isSocketExposed, bool isLocked, bool isReadOnly)
   {
      if (isSocketExposed && (isLocked || isReadOnly))
      {
         EditorGUILayout.TextField(isReadOnly ? "(read-only)" : "(socket used)", uScriptGUIStyle.PropertyTextField, GUILayout.Width(columnValue.Width));
         return false;
      }

      return true;
   }

   private static void OpenAssetBrowserWindow(AssetType type, string currentSelection)
   {
      if (AssetBrowserWindow.isOpen)
      {
         Debug.LogWarning("The AssetBrowserWindow is already open!\n");
         return;
      }

      AssetBrowserWindow.assetType = type;
   }

   private static int GetControlID()
   {
      return GetControlID(string.Empty);
   }

   private static int GetControlID(string suffix)
   {
      return GetControlName(suffix).GetHashCode();
   }

   private static string GetControlName(string suffix)
   {
      return string.Format("{0}[{1}]{2}", nodeKey, propertyCount.ToString(CultureInfo.InvariantCulture), suffix);
   }

   /// <summary>Creates a GUILayoutOption object using the specified parameters.</summary>
   /// <returns>A GUILayoutOption object.</returns>
   /// <param name='optionIndex'>The GUILayoutOption enumeration index.</param>
   /// <param name='optionValue'>The GUILayoutOption value as an integer.</param>
   private static GUILayoutOption CreateGUILayoutOption(int optionIndex, int optionValue)
   {
      return CreateGUILayoutOption(GUILayoutOptionDisplayNames[optionIndex], optionValue);
   }

   // === Structs ====================================================================

   private struct Column
   {
      public readonly string Label;
      public int Width;

      public Column(string label, int width)
      {
         this.Label = label;
         this.Width = width;
      }
   }

   // === Classes ====================================================================

   // ================================================================================
   // ================================================================================
   // ================================================================================

//   public static int ToolbarButtonGroup(string label, int index, GUIContent[] content)
//   {
//      GUILayout.BeginHorizontal();
//
//      if (string.IsNullOrEmpty(label) == false)
//      {
//         GUIStyle style1 = new GUIStyle(EditorStyles.label);
//         style1.padding = new RectOffset(16, 4, 2, 2);
//         style1.margin = new RectOffset();
//         GUILayout.Label(label, style1);
//      }
//
//      for (int i = 0; i < content.Length; i++)
//      {
//         if (GUILayout.Toggle(index == i, content[i], EditorStyles.toolbarButton, GUILayout.ExpandWidth(false)))
//         {
//            index = i;
//         }
//      }
//
//      GUILayout.EndHorizontal();
//
//      return index;
//   }

//   static string[] choices = null;

//               EditorGUILayout.Separator();
//               EditorGUILayout.Space();

//   Slider         Make a slider the user can drag to change a value between a min and a max.
//   IntSlider      Make a slider the user can drag to change an integer value between a min and a max.
//   MinMaxSlider   Make a special slider the user can use to specify a range between a min and a max.
//   ObjectField    Make an object drop slot field.
//   CurveField     Make a field for editing an AnimationCurve.
//   PropertyField  Make a field for SerializedProperty.

   #region Panel-Related Members and Methods

   // ================================================================================
   //
   //    Main Editor GUI Members and Methods Used During UnityEngine.OnGUI()
   //
   // ================================================================================

   // Singleton pattern
//   static readonly uScriptGUI _instance = new uScriptGUI();
//   public static uScriptGUI Instance { get { return _instance; } }
//   private uScriptGUI() { Init(); }

   public enum Region
   {
      Outside,
      Canvas,
      Content,
      Palette,
      Property,
      Reference,
      Script,
      HandleContainerBottom,
      HandleContainerCenter,
      HandleContainerLeft,
      HandleContainerRight,
      HandlePanelContent,
      HandlePanelPalette,
      HandlePanelProperty,
      HandlePanelReference,
      HandlePanelScript,
      Statusbar
   }

   public static Region CurrentRegion { get; set; }

//   private static Region m_MouseDownRegion = Region.Outside;

   private static Dictionary<Region, Rect> regions = new Dictionary<Region, Rect>();

   public static Dictionary<Region, Rect> Regions
   {
      get
      {
         return regions;
      }
   }

   //   public static readonly int PanelDividerSize = 4;
//   public static bool PanelsHidden = false;
//   private static GUIStyle panelStyle = GUIStyle.none;
//   private static GUIStyle boxStyle;
//   private static string _statusbarMessage;
//   public static string StatusbarMessage
//   {
//      get { return _statusbarMessage; }
//      set { _statusbarMessage = value; }
//   }

//   public static void Draw()
//   {
//      uScriptGUIContent.Init(uScriptGUIContent.ContentStyle.Text);
//      uScriptGUIStyle.Init();
//      InitPanels();
//      boxStyle = new GUIStyle();
//      boxStyle.normal.background = GUI.skin.box.normal.background;
//      boxStyle.border = GUI.skin.box.border;
//      GUIStyle container = new GUIStyle();
//      container.margin = new RectOffset(1, 0, 1, 0);
//      if (!PanelsHidden)
//      {
//         EditorGUILayout.BeginHorizontal(container);
//         {
//            DrawPanelContainerLeft();
//            DrawPanelContainerCenter();
//            DrawPanelContainerRight();
//         }
//         EditorGUILayout.EndHorizontal();
////         DrawPanelContainerBottom();
//      }
//      DrawStatusbar();
//      // TODO: This bool flag could be removed if the GUI is repainted after the canvas stops panning
////      if (_wasMoving)
////      {
////         _wasMoving = false;
////         uScript.RequestRepaint();
////      }
//   }

//   private static void DrawPanelContainerLeft()
//   {
//      int containerCount = PanelContainerLeft.Count;
//      if (containerCount > 0)
//      {
////         Rect r = EditorGUILayout.BeginVertical(panelStyle, GUILayout.Width(ContainerLeftWidth), GUILayout.ExpandHeight(true));
//         /*Rect r =*/ EditorGUILayout.BeginVertical(panelStyle, GUILayout.Width(ContainerLeftWidth), GUILayout.Height(uScript.Instance.position.height - 23));
//         {
//            PanelContainerLeft[0].Draw();
//            for (int i=1; i < containerCount; i++)
//            {
//               DrawHorizontalDivider(PanelContainerLeft[i-1].Region);
//               PanelContainerLeft[i].Draw();
//            }
//         }
//         EditorGUILayout.EndVertical();
////         if (Event.current.type == EventType.Repaint)
////         {
////            Debug.Log("ContainerLeft: " + r.ToString() + ", EditorPosition: " + uScript.Instance.position.ToString() + "\n");
////         }
//         DrawVerticalDivider(Region.HandleContainerLeft);
//      }
//   }

//   private static void DrawPanelContainerCenter()
//   {
//      EditorGUILayout.BeginVertical(panelStyle, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
//      {
////         DrawPanel(PanelID.Canvas);
//         PanelCanvas.Draw();
////         DrawGUIContent();
//         int containerCount = PanelContainerCenter.Count;
//         if (containerCount > 0)
//         {
//            DrawHorizontalDivider(Region.HandleContainerCenter);
//            EditorGUILayout.BeginHorizontal(new GUIStyle(), GUILayout.ExpandWidth(true), GUILayout.Height(ContainerCenterHeight));
//            {
//               PanelContainerCenter[0].Draw();
//               for (int i=1; i < containerCount; i++)
//               {
//                  DrawVerticalDivider(PanelContainerCenter[i-1].Region);
//                  PanelContainerCenter[i].Draw();
//               }
//            }
//            EditorGUILayout.EndHorizontal();
//         }
//      }
//      EditorGUILayout.EndVertical();
//   }

//   private static void DrawPanelContainerRight()
//   {
//      int containerCount = PanelContainerRight.Count;
//      if (containerCount > 0)
//      {
//         DrawVerticalDivider(Region.HandleContainerRight);
//         EditorGUILayout.BeginVertical(panelStyle, GUILayout.Width(ContainerRightWidth), GUILayout.ExpandHeight(true));
//         {
//            PanelContainerRight[0].Draw();
//            for (int i=1; i < containerCount; i++)
//            {
//               DrawHorizontalDivider(PanelContainerRight[i-1].Region);
//               PanelContainerRight[i].Draw();
//            }
//         }
//         EditorGUILayout.EndVertical();
//      }
//   }

//   private static void DrawHorizontalDivider(Region region)
//   {
//      GUILayout.Box(string.Empty, uScriptGUIStyle.hDivider, GUILayout.Height(PanelDividerSize), GUILayout.ExpandWidth(true));
//      // If the divider directly follows a panel, map the associated handle to the panel
//      switch (region)
//      {
//         case Region.Content:    region = uScriptGUI.Region.HandlePanelContent;     break;
//         case Region.Palette:    region = uScriptGUI.Region.HandlePanelPalette;     break;
//         case Region.Property:   region = uScriptGUI.Region.HandlePanelProperty;    break;
//         case Region.Reference:  region = uScriptGUI.Region.HandlePanelReference;   break;
//         case Region.Script:     region = uScriptGUI.Region.HandlePanelScript;      break;
//      }
//      DefineRegion(region, MouseCursor.ResizeVertical);
//   }

//   private static void DrawVerticalDivider(Region region)
//   {
//      GUILayout.Box(string.Empty, uScriptGUIStyle.vDivider, GUILayout.Width(PanelDividerSize), GUILayout.ExpandHeight(true));
//      // If the divider directly follows a panel, map the associated handle to the panel
//      switch (region)
//      {
//         case Region.Content:    region = uScriptGUI.Region.HandlePanelContent;     break;
//         case Region.Palette:    region = uScriptGUI.Region.HandlePanelPalette;     break;
//         case Region.Property:   region = uScriptGUI.Region.HandlePanelProperty;    break;
//         case Region.Reference:  region = uScriptGUI.Region.HandlePanelReference;   break;
//         case Region.Script:     region = uScriptGUI.Region.HandlePanelScript;      break;
//      }
//      DefineRegion(region, MouseCursor.ResizeHorizontal);
//   }

//   private static void DrawStatusbar()
//   {
//      if (GUI.tooltip != _statusbarMessage || Event.current.type == EventType.MouseMove)
//      {
//         _statusbarMessage = GUI.tooltip;
//      }
//      EditorGUILayout.BeginHorizontal();
//      {
//         GUILayout.Label( _statusbarMessage, GUILayout.ExpandWidth( true ) );
//         GUILayout.Label( (Event.current.modifiers != 0 ? Event.current.modifiers + " :: " : "")
//                           + (int)Event.current.mousePosition.x + ", "
//                           + (int)Event.current.mousePosition.y + " (" + _region + ")",
//                           GUILayout.ExpandWidth( false ));
//      }
//      EditorGUILayout.EndHorizontal();
//      DefineRegion(Region.Statusbar);
////      if (Event.current.type == EventType.Repaint)
////      {
//////         _statusbarRect = GUILayoutUtility.GetLastRect();
////      }
////
////      //      Redraw();  // This is taking to much CPU time.
//   }

//   public static Rect GetRegion(Region region)
//   {
//      return (_regions.ContainsKey(region) ? _regions[region] : new Rect());
//   }
//   public static void DefineRegion(Region region)
//   {
//      DefineRegion(region, MouseCursor.Arrow);
//   }

//   public static void DefineRegion(Region region, MouseCursor cursor)
//   {
//      if (Event.current.type == EventType.Repaint)
//      {
//         _regions[region] = GUILayoutUtility.GetLastRect();
//      }
//      if ( (GUI.enabled) && (cursor != MouseCursor.Arrow) && (_regions.ContainsKey(region)) )
//      {
//         EditorGUIUtility.AddCursorRect( _regions[region], cursor);
//      }
//   }

//   private static bool HiddenRegion(Region region)
//   {
//      if (!PanelsHidden) return false;
//      return region != Region.Canvas && region != Region.Outside;
//   }

//   public static void CalculateMouseRegion()
//   {
//      foreach( KeyValuePair<Region, Rect> kvp in _regions )
//      {
//         if ( kvp.Value.Contains( Event.current.mousePosition ) && !HiddenRegion(kvp.Key) )
//         {
//            _region = kvp.Key;
//            break;
//            //EditorGUIUtility.DrawColorSwatch(_mouseRegionRect[region], UnityEngine.Color.cyan);
//         }
//      }
//   }
   #endregion

   #region Panel-Related Members and Methods

   // ================================================================================
   //    Panel-Related Members and Methods
   // ================================================================================

   // There are four panel containers, each of which must be able to hold all panels.
   // The size value returned applies to the axis appropraite for the container.
   // All panels within a container share the size of that axis.
   // The default container size is 250px, regardless of the axis it affects.
   // There should probably be a minimum size for each container, perhaps 50 or 100px.
   // The size of a container is really a suggestion, since panels in the container
   // might require a minimum size that is greater than the user-desired size.
   //    ContainerBottom   (height)
   //    ContainerCenter   (height)
   //    ContainerLeft     (width)
   //    ContainerRight    (width)
   // The default size for a given panel is determined by container that holds it
   // and the number of additional panels within that container. All panels within
   // a container are evenly sized. If there is 1000px of available space, four
   // panels would default to 250px each, whereas three panels would be 333px each.
   // In the event that a panel moves from one container to another, all panels in
   // the affected containers will have their size reset to the default value.
   //    PanelContent
   //    PanelPalette
   //    PanelProperty
   //    PanelReference
   //    PanelScripts
   // The container and panel sizes should be store in the Preferences.
   // When the user manually adjusts the size of a container or panel, the new size
   // is stored in Preferences.
   // Sizes that are updated automatically by GUI layout override the Preferences,
   // but are not stored.
   // Only container and panel layouts should reply on these values, and it should
   // be assumed that they may be incorrect.

   public enum PanelID
   {
      Canvas,
      Bottom1,
      Bottom2,
      Bottom3,
      Left1,
      Left2,
      Left3,
      Right1,
      Right2,
      Right3
   }

   public enum PanelType
   {
      GraphContent,
      NodePalette,
      Options,
      Properties,
      Reference,
      Scripts,
      Statusbar,
      Canvas
   }

   public enum FixedPanelSize
   {
      None,
      Horizontal,
      Vertical
   }

   public static int ContainerBottomHeight = 250;
   public static int ContainerCenterHeight = 250;
   public static int ContainerLeftWidth = 250;
   public static int ContainerRightWidth = 250;
   private static bool _panelsInitialized = false;

//   public static uScriptGUIPanelCanvas PanelCanvas = null;
//   public static List<uScriptGUIPanel> PanelContainerBottom = new List<uScriptGUIPanel>();
//   public static List<uScriptGUIPanel> PanelContainerCenter = new List<uScriptGUIPanel>();
//   public static List<uScriptGUIPanel> PanelContainerLeft = new List<uScriptGUIPanel>();
//   public static List<uScriptGUIPanel> PanelContainerRight = new List<uScriptGUIPanel>();

   public static uScriptGUIPanel PanelReference = null;

   private static class PanelContainer
   {
//      public static Rect Rect;

      private static List<uScriptGUIPanel> _panels = new List<uScriptGUIPanel>();

      public static List<uScriptGUIPanel> Panels
      {
         get { return _panels; }
      }

//      public static uScriptGUIPanel this[int index]
//      {
//      }

//      public static int GetSizeAccrued(
   }

   public static void InitPanels()
   {
      if (_panelsInitialized)
      {
         // The panels have already been initialized
         return;
      }

      _panelsInitialized = true;

      // Get the width of the SaveMethodType options for use in the toolbarDropDown
      foreach (string name in Enum.GetNames(typeof(Preferences.SaveMethodType)))
      {
         Vector2 size = EditorStyles.toolbarDropDown.CalcSize(new GUIContent(name));
         if (size.x > SaveMethodPopupWidth)
         {
            SaveMethodPopupWidth = (int)size.x;
         }
      }

      SaveMethodPopupWidth += 10;

//      panelStyle = new GUIStyle();

      // Get the panel dimensions from the saved Settings or use default values
      // TODO: Load these from the previous session if the data exists, but provide a way to reset, if necessary
      PanelDividerThickness = 4;
      PanelLeftWidth = 200;
      PanelPropertiesHeight = 250;
      PanelPropertiesWidth = 500;
      PanelScriptsWidth = 300;

//      Rect rectArea = new Rect(0, 0, uScript.Instance.position.width, uScript.Instance.position.height /* - statusbarHeight */);

      // The initial panel dimensions should be retrieved from the Settings file
      // For now, use hard coded values

//      PanelCanvas = uScriptGUIPanelCanvas.Instance;
//      PanelContainerLeft.Add(uScriptGUIPanelScript.Instance);
//      PanelContainerLeft.Add(uScriptGUIPanelContent.Instance);
//      PanelContainerLeft.Add(uScriptGUIPanelPalette.Instance);
////      PanelContainerLeft.Add(uScriptGUIPanelProperties.Instance);
////      PanelContainerCenter.Add(uScriptGUIPanelReference.Instance);
//      PanelContainerCenter.Add(uScriptGUIPanelProperty.Instance);
//      PanelContainerCenter.Add(uScriptGUIPanelReference.Instance);

      PanelReference = uScriptGUIPanelReference.Instance;

//      // Set the panel size options
//      int i;
//      for (i=0; i < PanelContainerLeft.Count; i++)
//      {
//         PanelContainerLeft[i].PanelOrientation = (PanelContainerLeft.Count > i + 1 ? FixedPanelSize.Vertical : FixedPanelSize.None);
//      }
//      for (i=0; i < PanelContainerRight.Count; i++)
//      {
//         PanelContainerRight[i].PanelOrientation = (PanelContainerRight.Count > i + 1 ? FixedPanelSize.Vertical : FixedPanelSize.None);
//      }
//      for (i=0; i < PanelContainerCenter.Count; i++)
//      {
//         PanelContainerCenter[i].PanelOrientation = (PanelContainerCenter.Count > i + 1 ? FixedPanelSize.Horizontal : FixedPanelSize.None);
//      }
//      for (i=0; i < PanelContainerBottom.Count; i++)
//      {
//         PanelContainerBottom[i].PanelOrientation = (PanelContainerBottom.Count > i + 1 ? FixedPanelSize.Horizontal : FixedPanelSize.None);
//      }
   }

   #endregion
}
