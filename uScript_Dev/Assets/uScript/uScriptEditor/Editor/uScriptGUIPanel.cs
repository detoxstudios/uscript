// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUIPanel.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using UnityEditor;

using UnityEngine;

public abstract class uScriptGUIPanel
{
   public string Name { get; protected set; }

   public Vector2 ScrollviewOffset { get; protected set; }

   public bool InUScriptPanel { get; set; }

   public abstract void Draw();

   protected void DrawHiddenNotification()
   {
      // Hide the panels while the canvas is moving
      var message =
         string.Format(
            "The {0} panel is not drawn while the canvas is updated.\n\nThe drawing can be enabled via the Preferences panel, although canvas performance may be affected. ", 
            this.Name);

      EditorGUILayout.BeginScrollView(
         Vector2.zero, 
         false, 
         false, 
         uScriptGUIStyle.HorizontalScrollbar, 
         uScriptGUIStyle.VerticalScrollbar, 
         "scrollview");
      {
         GUILayout.Label(message, uScriptGUIStyle.PanelMessage);
      }
      EditorGUILayout.EndScrollView();
   }
}
