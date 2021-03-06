// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditorCommands.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the EditorCommands type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   using Detox.Editor.GUI.Windows;

   public static class EditorCommands
   {
      public static void OpenAboutWindow()
      {
         AboutWindow.Open();
      }

      public static void OpenEditorWindow()
      {
         uScript.Open();
      }

      public static void OpenHotkeyWindow()
      {
         HotkeyWindow.Open();
      }
      
      // maintained for backwards compatibility
      public static void OpenPreferenceWindow() { }

      public static void OpenWelcomeWindow()
      {
         WelcomeWindow.Open();
      }
   }
}
