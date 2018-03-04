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

   protected bool _inUScriptPanel = true;
   public virtual bool InUScriptPanel
   {
      get
      {
         return _inUScriptPanel;
      }

      set
      {
         _inUScriptPanel = value;
      }
   }

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

   protected void DrawOrphanNotification()
   {
      var message =
         string.Format(
            "The {0} panel is not drawn while the uScript window is closed.\n\nWaiting for uScript to reopen...",
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

         GUILayout.Space(20.0f);

         if (GUILayout.Button("Open uScript", GUILayout.ExpandWidth(true))) uScript.Instance.GetType();  // call any function just to force the instance to be rebuilt
      }
      EditorGUILayout.EndScrollView();
   }
}
