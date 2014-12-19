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

      private static readonly string ScriptPath = uScript.Preferences.ProjectFiles + "/Editor/";

      static MenuLocation()
      {
         if (File.Exists(ScriptPath + ScriptName) == false)
         {
            Change(Location.Default);
         }
      }

      public enum Location
      {
         Default,

         Tools,

         Window
      }

      public static void Change(Location menuLocation)
      {
         switch (menuLocation)
         {
            case Location.Tools:
               Change("Tools");
               break;
            case Location.Window:
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
         AssetDatabase.Refresh();
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
      public const string CurrentLocation = """ + menuPath + @"uScript"";

      [UnityEditor.MenuItem(""" + menuPath + @"uScript/uScript Editor %u"", false, 1)]
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

      [MenuItem(""" + menuPath + @"uScript/Menu Location/Default"", false, 201)]
      internal static void LocationRoot()
      {
         MenuLocation.Change(MenuLocation.Location.Default);
      }

      [MenuItem(""" + menuPath + @"uScript/Menu Location/Tools"", false, 202)]
      internal static void LocationTools()
      {
         MenuLocation.Change(MenuLocation.Location.Tools);
      }

      [MenuItem(""" + menuPath + @"uScript/Menu Location/Window"", false, 203)]
      internal static void LocationWindow()
      {
         MenuLocation.Change(MenuLocation.Location.Window);
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
