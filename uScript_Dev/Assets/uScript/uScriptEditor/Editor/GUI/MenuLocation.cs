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
   using System.Linq;

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

         if (File.Exists(ScriptPath + ScriptName) == false)
         {
            Change(uScript.Preferences.MenuLocation);
         }
      }

      public static void Change(Preferences.MenuLocationType menuLocation)
      {
         switch (menuLocation)
         {
            case Preferences.MenuLocationType.Tools:
               Change("Tools");
               break;
            case Preferences.MenuLocationType.Window:
               Change("Window");
               break;
            default:
               Change(string.Empty);
               break;
         }
      }

      private static void Change(string menuPath)
      {
         menuPath = menuPath ?? string.Empty;

         if (menuPath != string.Empty && menuPath.Last() != '/' && menuPath.Last() != '\\')
         {
            menuPath += "/";
         }

         var content = FormatScript(menuPath);

         // WriteAllText creates a file, writes the specified string to the file, and then closes the file.
         Directory.CreateDirectory(ScriptPath);
         File.WriteAllText(ScriptPath + ScriptName, content);
         AssetDatabase.ImportAsset(ScriptPath + ScriptName, ImportAssetOptions.ForceUpdate);
      }

      private static string FormatScript(string menuPath)
      {
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
   using Detox.Editor.GUI;

   using UnityEditor;

   public static class uScriptMenuLocation
   {
      [MenuItem(""" + menuPath + @"uScript/uScript Editor %u"", false, 1)]
      internal static void OpenEditor()
      {
         uScript.Open();
      }

      // 51 Canvas
      // 52 Contents
      // 53 Graphs

      [MenuItem(""" + menuPath + @"uScript/Hotkeys"", false, 54)]
      internal static void OpenHotkeysWindow()
      {
         uScriptHotkeyWindow.Open();
      }

      // 55 Properties
      // 56 Reference
      // 57 Toolbox

      [MenuItem(""" + menuPath + @"uScript/Preferences"", false, 901)]
      internal static void OpenPreferencesWindow()
      {
         PreferenceWindow.Open();
      }

      [MenuItem(""" + menuPath + @"uScript/About uScript"", false, 1001)]
      internal static void OpenAboutWindow()
      {
         AboutWindow.Open();
      }
   }
}
";
      }
   }
}
