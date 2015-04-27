// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuLocation.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptEngine type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System.IO;
   using System.Reflection;

   using UnityEditor;

   [InitializeOnLoad]
   public static class MenuLocation
   {
      private const string ScriptName = "uScriptMenuLocation.cs";

      private static readonly string ScriptPath;

      static MenuLocation()
      {
         uScript.LoadSettings();
         ScriptPath = uScript.Preferences.ProjectFiles + "/Editor/";

         if (FileDoesNotExist() || VersionIsObsolete())
         {
            Change(uScript.Preferences.MenuLocation);
         }
      }

      public static void Change(Preferences.MenuLocationType menuLocation)
      {
         switch (menuLocation)
         {
            case Preferences.MenuLocationType.Tools:
               Change("Tools/");
               break;
            case Preferences.MenuLocationType.Window:
               Change("Window/");
               break;
            case Preferences.MenuLocationType.Custom:
               Change(ReflectOldMenuRoot());
               break;
            default:
               Change(string.Empty);
               break;
         }
      }

      private static void Change(string menuRoot)
      {
         var content = FormatScript(menuRoot, uScriptBuild.Number);

         // WriteAllText creates a file, writes the specified string to the file, and then closes the file.
         Directory.CreateDirectory(ScriptPath);

         var path = string.Format("{0}{1}", ScriptPath, ScriptName);
         File.WriteAllText(path, content);
         AssetDatabase.ImportAsset(path.RelativeAssetPath(), ImportAssetOptions.ForceUpdate);
         AssetDatabase.Refresh();
      }

      private static string FormatScript(string menuRoot, string menuBuild)
      {
         // 51 Canvas
         // 52 Contents
         // 53 Graphs

         // 55 Properties
         // 56 Reference
         // 57 Toolbox

         return
            @"// --------------------------------------------------------------------------------------------------------------------
// <copyright file=""uScriptMenuLocation.cs"" company=""Detox Studios, LLC"">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptMenu type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   using UnityEditor;

   public static class uScriptMenuLocation
   {
      // WARNING:
      // --------------------
      // The contents of this file are dynamically generated. Any modifications made
      // to this file may be overwritten and lost the next time it is generated.
      
      // To customize the location of the uScript menu:
      //    1. Open the uScript Preferences window, set 'Menu Location' to ""Custom"", and save your changes.
      //    2. Modify the 'MenuRoot' string below (e.g., ""Plugins/"", ""Tools/"", ""Window/"", etc.)
      //.
      internal const string MenuRoot = """ + menuRoot + @""";

      // Specifies the build of uScript this file was meant to work with
      internal const string Build = """ + menuBuild + @""";

      [MenuItem(MenuRoot + ""uScript/uScript Editor %u"", false, 1)]
      internal static void OpenEditor()
      {
         EditorCommands.OpenEditorWindow();
      }

      [MenuItem(MenuRoot + ""uScript/Hotkeys"", false, 54)]
      internal static void OpenHotkeysWindow()
      {
         EditorCommands.OpenHotkeyWindow();
      }

      [MenuItem(MenuRoot + ""uScript/Preferences"", false, 901)]
      internal static void OpenPreferenceWindow()
      {
         EditorCommands.OpenPreferenceWindow();
      }

      [MenuItem(MenuRoot + ""uScript/About uScript"", false, 1001)]
      internal static void OpenAboutWindow()
      {
         EditorCommands.OpenAboutWindow();
      }

      [MenuItem(MenuRoot + ""uScript/Fix Missing uScript References"", false)]
      internal static void FixMissingReferences()
      {
         EditorCommands.FixUScriptReferences();
      }

      [MenuItem(MenuRoot + ""uScript/Fix Missing uScript References (Dry Run)"", false)]
      internal static void TestFixMissingReferences()
      {
         EditorCommands.TestFixUScriptReferences();
      }
   }
}
";
      }

      private static bool FileDoesNotExist()
      {
         return File.Exists(ScriptPath + ScriptName) == false;
      }

      private static string ReflectOldBuildNumber()
      {
         var type = System.Type.GetType("Detox.Editor.uScriptMenuLocation");
         if (type != null)
         {
            var field = type.GetField("Build", BindingFlags.NonPublic | BindingFlags.Static);
            if (field != null)
            {
               return field.GetValue(null) as string;
            }
         }
         return string.Empty;
      }

      private static string ReflectOldMenuRoot()
      {
         var type = System.Type.GetType("Detox.Editor.uScriptMenuLocation");
         if (type != null)
         {
            var field = type.GetField("MenuRoot", BindingFlags.NonPublic | BindingFlags.Static);
            if (field != null)
            {
               return field.GetValue(null) as string;
            }
         }
         return string.Empty;
      }

      private static bool VersionIsObsolete()
      {
         BuildInfo newBuild;
         BuildInfo oldBuild;

         BuildInfo.TryParse(uScriptBuild.Number, out newBuild);
         BuildInfo.TryParse(ReflectOldBuildNumber(), out oldBuild);

#if UNITY_3_5 // Override hack because 'oldBuild' comes back as 0.0.0 in Unity 3 when compiled to a DLL.
         return false;
#else
         return newBuild > oldBuild;
#endif

      }
   }
}
