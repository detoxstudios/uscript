// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUI.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   This file contains a collection of custom uScript GUI controls for use with uScriptEditor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   using System;
   using System.Collections.Generic;
   using System.Globalization;
   using System.IO;
   using System.Linq;
   using System.Reflection;

   using UnityEditor;

   using UnityEngine;

   public static class uScriptGUI
   {
      public const string KeyEscape = "\u238B";
      public const string KeyShift = "\u21E7";
      public const string KeyControl = "\u2303";
      public const string KeyOption = "\u2325";
      public const string KeyCommand = "\u2318";
      public const string KeyDelete = "\u2326";
      public const string KeyBackspace = "\u232B";
      public const string KeyReturn = "\u23CE";

      private static TextEditor activeTextEditor;
      private static MethodInfo activeTextEditorMethodEndEditing;

      //private static string previousControl = string.Empty;

      private static GUIStyle horizontalScrollbarLeftButton;
      private static GUIStyle horizontalScrollbarRightButton;
      private static GUIStyle horizontalScrollbarThumb;
      private static GUIStyle verticalScrollbarUpButton;
      private static GUIStyle verticalScrollbarDownButton;
      private static GUIStyle verticalScrollbarThumb;

      private static Dictionary<string, string> scenePaths;

      private static bool panelsInitialized;

      private static MethodInfo methodCheckOnGUI;

      public static bool IsDrawingGUIWindows { get; set; }

      public static int PanelDividerThickness { get; private set; }

      public static int PanelLeftWidth { get; set; }

      public static int PanelPropertiesHeight { get; set; }

      public static int PanelPropertiesWidth { get; set; }

      public static int PanelScriptsWidth { get; set; }

      public static bool PanelsHidden { get; set; }

      public static int SaveMethodPopupWidth { get; private set; }

      public static bool IsRepainting
      {
         get
         {
            // TODO: Test to make sure we're actually in OnGUI
            return Event.current.type == EventType.Repaint;
         }
      }

      public static void AntiAlias(float zoomScale)
      {
         uScript.Instance.antiAlias = zoomScale < 1 ? 2 : 0;
      }

      public static void InitPanels()
      {
         if (panelsInitialized)
         {
            // The panels have already been initialized
            return;
         }

         panelsInitialized = true;

         // Get the width of the SaveMethodType options for use in the toolbarDropDown
         foreach (
            var size in
               Enum.GetNames(typeof(Preferences.SaveMethodType))
                  .Select(name => EditorStyles.toolbarDropDown.CalcSize(new GUIContent(name)))
                  .Where(size => size.x > SaveMethodPopupWidth))
         {
            SaveMethodPopupWidth = (int)size.x;
         }

         SaveMethodPopupWidth += 10;

         PanelDividerThickness = 4;
         PanelLeftWidth = 200;
         PanelPropertiesHeight = 250;
         PanelPropertiesWidth = 500;
         PanelScriptsWidth = 300;
      }

      internal static void CheckOnGUI()
      {
         if (methodCheckOnGUI == null)
         {
            methodCheckOnGUI = typeof(GUIUtility).GetMethod("CheckOnGUI", BindingFlags.Static | BindingFlags.NonPublic);
            if (methodCheckOnGUI == null)
            {
               uScriptDebug.Log("Could not access GUIUtility.CheckOnGUI() via reflection.", uScriptDebug.Type.Error);
               return;
            }
         }

         methodCheckOnGUI.Invoke(null, null);
      }

      public static Texture2D GetTexture(string textureName)
      {
         var path = string.Format(
            "Assets{0}/Editor/_GUI/EditorImages/{1}.png",
            uScriptConfig.ConstantPaths.Editor.Replace("\\", "/").Replace(Application.dataPath, string.Empty),
            textureName);
         return AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D)) as Texture2D;
      }

      public static Texture2D GetSkinnedTexture(string textureName)
      {
         return GetTexture(string.Format("{0}_{1}", EditorGUIUtility.isProSkin ? "DarkSkin" : "LightSkin", textureName));
      }

      public static Font GetFont(string fontPathWithFileExtension)
      {
         return AssetDatabase.LoadAssetAtPath(fontPathWithFileExtension, typeof(Font)) as Font;
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
         if (Event.current.type != EventType.Repaint)
         {
            return;
         }

         var texture = GetTexture("DebugBox");

         var style = new GUIStyle(EditorStyles.miniLabel)
                        {
                           name = "uScript_debugBox",
                           margin = new RectOffset(),
                           border = new RectOffset(1, 1, 1, 1),
                           clipping = TextClipping.Clip,
                           alignment = TextAnchor.MiddleCenter,
                           normal = { background = texture }
                        };

         var originalColor = UnityEngine.GUI.color;

         UnityEngine.GUI.color = color;
         UnityEngine.GUI.Box(rect, text, style);
         UnityEngine.GUI.color = originalColor;
      }

      public static bool IsGeneratedScriptMissing(string graphName)
      {
         var scriptName = string.Format("{0}.cs", graphName);
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4)
         // first see if we've already saved the file and then just use that path
         var files = uScript.GetGraphPaths("uScriptCode");
         if (files.Any(file => file.Contains(scriptName)))
         {
            return false;
         }
#endif
         var assetPathRelativeToProject = string.Format(
            "{0}/{1}",
            uScript.Preferences.GeneratedScripts.Substring(Application.dataPath.Length - 6),
            scriptName);
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

      public static void GetScenePaths()
      {
         // TODO: Replace this logic, because it's slow. If we stored the full scene path with the script, this wouldn't be needed.

         scenePaths = new Dictionary<string, string>();

         // get every single one of the files in the Assets folder.
         var files = GetFilesFromDirectory(new DirectoryInfo(Application.dataPath), "*.unity");

         foreach (var fi in files)
         {
            if (fi.Name.StartsWith("."))
            {
               // Unity ignores dotfiles
               continue;
            }

            var obj = AssetDatabase.LoadMainAssetAtPath(GetRelativeAssetPath(fi.FullName));
            var path = AssetDatabase.GetAssetPath(obj);
            var name = Path.GetFileNameWithoutExtension(path);

            uScriptDebug.Assert(name != null, "name != null");

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

         uScriptDebug.Assert(scenePaths != null, "scenePaths should not be null here!");

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
      /// <param name="pathName">The path to process.</param>
      /// <returns>The relative path.</returns>
      public static string GetRelativeAssetPath(string pathName)
      {
         //dataPath uses forward slashes on all platforms now
         return FixSlashes(pathName).Replace(Application.dataPath, "Assets");
      }

      /// <summary>
      /// Given a directory and a search filter, return a list of file references. This function may not work well with file system "hard links"
      /// </summary>
      /// <param name="directoryInfo">The directory to examine.</param>
      /// <param name="searchFor">The search filter.</param>
      /// <returns>List of file information.</returns>
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

      public static void HorizontalRule()
      {
         GUILayout.BeginHorizontal(uScriptGUIStyle.PanelHR, GUILayout.ExpandWidth(true));

         GUILayout.EndHorizontal();
      }

      public static void HideScrollbars()
      {
         if (horizontalScrollbarLeftButton != null)
         {
            return;
         }

         horizontalScrollbarLeftButton = new GUIStyle(UnityEngine.GUI.skin.horizontalScrollbarLeftButton);
         horizontalScrollbarRightButton = new GUIStyle(UnityEngine.GUI.skin.horizontalScrollbarRightButton);
         horizontalScrollbarThumb = new GUIStyle(UnityEngine.GUI.skin.horizontalScrollbarThumb);

         verticalScrollbarUpButton = new GUIStyle(UnityEngine.GUI.skin.verticalScrollbarUpButton);
         verticalScrollbarDownButton = new GUIStyle(UnityEngine.GUI.skin.verticalScrollbarDownButton);
         verticalScrollbarThumb = new GUIStyle(UnityEngine.GUI.skin.verticalScrollbarThumb);

         UnityEngine.GUI.skin.horizontalScrollbarLeftButton = GUIStyle.none;
         UnityEngine.GUI.skin.horizontalScrollbarRightButton = GUIStyle.none;
         UnityEngine.GUI.skin.horizontalScrollbarThumb = GUIStyle.none;

         UnityEngine.GUI.skin.verticalScrollbarUpButton = GUIStyle.none;
         UnityEngine.GUI.skin.verticalScrollbarDownButton = GUIStyle.none;
         UnityEngine.GUI.skin.verticalScrollbarThumb = GUIStyle.none;
      }

      public static void ShowScrollbars()
      {
         if (horizontalScrollbarLeftButton == null)
         {
            return;
         }

         UnityEngine.GUI.skin.horizontalScrollbarLeftButton = horizontalScrollbarLeftButton;
         UnityEngine.GUI.skin.horizontalScrollbarRightButton = horizontalScrollbarRightButton;
         UnityEngine.GUI.skin.horizontalScrollbarThumb = horizontalScrollbarThumb;

         UnityEngine.GUI.skin.verticalScrollbarUpButton = verticalScrollbarUpButton;
         UnityEngine.GUI.skin.verticalScrollbarDownButton = verticalScrollbarDownButton;
         UnityEngine.GUI.skin.verticalScrollbarThumb = verticalScrollbarThumb;

         horizontalScrollbarLeftButton = null;
         horizontalScrollbarRightButton = null;
         horizontalScrollbarThumb = null;

         verticalScrollbarUpButton = null;
         verticalScrollbarDownButton = null;
         verticalScrollbarThumb = null;
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

      internal static void OverrideTextEditorTabBehavior()
      {
         // This method contains reflections into Unity's assembly. It has been tested on Unity 3.5.7 and 4.6.1.

#if !UNITY_3_5
         var e = Event.current;

         // Both Tab and Shift Tab will be included. Tab with other modifier keys don't work consistently, and should be avoided.
         if (e.type == EventType.KeyDown && (e.character == '\t' || e.keyCode == KeyCode.Tab))
         {
            if (activeTextEditor == null)
            {
               var fi = typeof(EditorGUI).GetField("activeEditor", BindingFlags.Static | BindingFlags.NonPublic);
               uScriptDebug.Assert(fi != null, "Could not access the field: EditorGUI.activeEditor");

               activeTextEditor = (TextEditor)fi.GetValue(null);
            }

            if (activeTextEditor != null)
            {
               if (activeTextEditorMethodEndEditing == null)
               {
                  activeTextEditorMethodEndEditing = activeTextEditor.GetType().GetMethod("EndEditing");
                  uScriptDebug.Assert(activeTextEditorMethodEndEditing != null, "Could not access the method: EditorGUI.activeEditor.EndEditing()");
               }

               if (activeTextEditorMethodEndEditing != null && activeTextEditor.controlID != 0)
               {
                  activeTextEditorMethodEndEditing.Invoke(activeTextEditor, null);
               }
            }
         }
#endif
      }
   }
}
