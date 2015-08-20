// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusBar.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using Detox.Windows.Forms;

   using UnityEditor;

   using UnityEngine;

   using GUI = UnityEngine.GUI;

   internal static class StatusBar
   {
      private static string tooltip;

      public static void Draw()
      {
         if (uScript.IsDevelopmentBuild == false)
         {
            return;
         }

         var e = Event.current;

         if (GUI.tooltip != tooltip || e.type == EventType.MouseMove)
         {
            tooltip = GUI.tooltip;
         }

         var keyboardFocusDetails = string.Format(
            "#{0} [{1}]\t{2}",
            FocusedControl.ID,
            GUI.GetNameOfFocusedControl(),
            tooltip);

         var inputDetails = GetInput();
         inputDetails = string.Format(
            "{0}{1}{2}, {3} ({4})",
            inputDetails,
            inputDetails == string.Empty ? string.Empty : " :: ",
            (int)e.mousePosition.x,
            (int)e.mousePosition.y,
            uScript.OverMouseRegion);

         EditorGUILayout.BeginHorizontal();
         {
            GUILayout.Label(keyboardFocusDetails);
            GUILayout.Label(inputDetails, GUILayout.ExpandWidth(false));
         }
         EditorGUILayout.EndHorizontal();
      }

      private static string GetInput()
      {
         var modifiers = GetInputModifiers();
         var button = GetInputButton();

         return (modifiers == string.Empty)
                   ? button
                   : (button == string.Empty) ? modifiers : string.Format("{0} + {1}", modifiers, button);
      }

      private static string GetInputButton()
      {
         return Detox.Windows.Forms.Control.MouseButtons.Buttons == 0
                   ? string.Empty
                   : Detox.Windows.Forms.Control.MouseButtons.Buttons == MouseButtons.Left
                        ? "Left-Click"
                        : Detox.Windows.Forms.Control.MouseButtons.Buttons == MouseButtons.Middle
                             ? "Middle-Click"
                             : "Right-Click";
      }

      private static string GetInputModifiers()
      {
         var e = Event.current;
         return e.modifiers == 0
                   ? string.Empty
                   : e.modifiers.ToString()
                        .Replace(", ", " + ")
                        .Replace("Shift", "SHIFT")
                        .Replace("Control", "CTRL")
                        .Replace("Command", Application.platform == RuntimePlatform.OSXEditor ? "CMD" : "WIN")
                        .Replace("Alt", "ALT");
      }
   }
}
