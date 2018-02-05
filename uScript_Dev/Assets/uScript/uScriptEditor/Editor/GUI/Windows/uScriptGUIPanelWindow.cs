// --------------------------------------------------------------------------------------------------------------------
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
      public uScriptGUIPanel Panel { get; set; }

      private void OnGUI()
      {
         if (Panel != null) Panel.Draw();
      }

      private void OnDestroy()
      {
         if (Panel != null)
         {
            Panel.InUScriptPanel = true;
            switch (Panel.GetType().ToString())
            {
               case "uScriptGUIPanelContent":
               case "uScriptGUIPanelToolbox":
                  uScript.Instance.paletteVisible = true;
                  GetWindow<uScript>().Focus();
                  break;
               case "uScriptGUIPanelProperty":
                  uScript.Instance.propertiesVisible = true;
                  GetWindow<uScript>().Focus();
                  break;
               case "Detox.Editor.uScriptGUIPanelReference":
                  uScript.Instance.referenceVisible = true;
                  GetWindow<uScript>().Focus();
                  break;
               case "Detox.Editor.GUI.PanelScript":
                  uScript.Instance.filelistVisible = true;
                  GetWindow<uScript>().Focus();
                  break;
            }
         }
      }
   }
#if !UNITY_3_5
}
#endif
