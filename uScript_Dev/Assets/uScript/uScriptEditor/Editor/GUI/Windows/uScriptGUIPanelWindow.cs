// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUIPanelWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptGUIPanelWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI.Windows
{
   using UnityEditor;
   using UnityEngine;

   public class uScriptGUIPanelWindow : EditorWindow
   {
      public string PanelType { get; set; }

      private uScriptGUIPanel _panel = null;
      public uScriptGUIPanel Panel {
         get
         {
            return _panel;
         }
         set
         {
            if (value != null) PanelType = value.GetType().ToString();
            _panel = value;
         }
      }

      private void OnGUI()
      {
         if (Panel != null)
         {
            if (Event.current.type == EventType.MouseDown)
            {
               if (this == EditorWindow.focusedWindow)
               {
                  // works around a bug with EditorGUILayout.TextField where values from different text fields can overwrite one another.
                  // https://forum.unity.com/threads/textfields-become-soul-mates-and-show-the-same-text.106885/
                  GUI.FocusControl( "" );
               }
            }

            Panel.Draw();
         }
      }

      private void OnDestroy()
      {
         if (Panel != null)
         {
            Panel.InUScriptPanel = true;

            bool validPanel = false;
            var uScriptInstance = uScript.WeakInstance;
            switch (Panel.GetType().ToString())
            {
               case "uScriptGUIPanelContent":
               case "uScriptGUIPanelToolbox":
                  if (uScriptInstance != null) uScriptInstance.PaletteVisible = true;
                  validPanel = true;
                  break;
               case "uScriptGUIPanelProperty":
                  if (uScriptInstance != null) uScriptInstance.PropertiesVisible = true;
                  validPanel = true;
                  break;
               case "Detox.Editor.uScriptGUIPanelReference":
                  if (uScriptInstance != null) uScriptInstance.ReferenceVisible = true;
                  validPanel = true;
                  break;
               case "Detox.Editor.GUI.PanelScript":
                  if (uScriptInstance != null) uScriptInstance.ScriptsVisible = true;
                  validPanel = true;
                  break;
            }

            if (validPanel)
            {
               if (uScriptInstance != null)
               {
                  uScriptInstance.Focus();
               }
               uScript.RequestRepaint(2);
            }
         }
      }
   }
}
