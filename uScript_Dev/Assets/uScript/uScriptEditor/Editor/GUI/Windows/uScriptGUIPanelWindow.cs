﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptGUIPanelWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptGUIPanelWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if !UNITY_3_5
namespace Detox.Editor.GUI.Windows
{
#endif
   using UnityEditor;

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
         if (Panel != null) Panel.Draw();
      }

      private void OnDestroy()
      {
         if (Panel != null)
         {
            Panel.InUScriptPanel = true;

            bool validPanel = false;
            switch (Panel.GetType().ToString())
            {
               case "uScriptGUIPanelContent":
               case "uScriptGUIPanelToolbox":
                  uScript.Instance.PaletteVisible = true;
                  validPanel = true;
                  break;
               case "uScriptGUIPanelProperty":
                  uScript.Instance.PropertiesVisible = true;
                  validPanel = true;
                  break;
               case "Detox.Editor.uScriptGUIPanelReference":
                  uScript.Instance.ReferenceVisible = true;
                  validPanel = true;
                  break;
               case "Detox.Editor.GUI.PanelScript":
                  uScript.Instance.ScriptsVisible = true;
                  validPanel = true;
                  break;
            }

            if (validPanel)
            {
               uScript us = uScript.Instance;
               if (us != null)
               {
                  us.Focus();
               }
               uScript.RequestRepaint(2);
            }
         }
      }
   }
#if !UNITY_3_5
}
#endif
