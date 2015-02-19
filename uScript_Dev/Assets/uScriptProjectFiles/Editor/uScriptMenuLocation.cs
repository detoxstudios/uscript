// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptMenuLocation.cs" company="Detox Studios, LLC">
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
      //    1. Open the uScript Preferences window, set 'Menu Location' to "Custom", and save your changes.
      //    2. Modify the 'MenuRoot' string below (e.g., "Plugins/", "Tools/", "Window/", etc.)
      //.
      internal const string MenuRoot = "Tools/";

      // Specifies the build of uScript this file was meant to work with
      internal const string Build = "1.0.2740";

      [MenuItem(MenuRoot + "uScript/uScript Editor %u", false, 1)]
      internal static void OpenEditor()
      {
         EditorCommands.OpenEditorWindow();
      }

      [MenuItem(MenuRoot + "uScript/Hotkeys", false, 54)]
      internal static void OpenHotkeysWindow()
      {
         EditorCommands.OpenHotkeyWindow();
      }

      [MenuItem(MenuRoot + "uScript/Preferences", false, 901)]
      internal static void OpenPreferenceWindow()
      {
         EditorCommands.OpenPreferenceWindow();
      }

      [MenuItem(MenuRoot + "uScript/About uScript", false, 1001)]
      internal static void OpenAboutWindow()
      {
         EditorCommands.OpenAboutWindow();
      }
   }
}
