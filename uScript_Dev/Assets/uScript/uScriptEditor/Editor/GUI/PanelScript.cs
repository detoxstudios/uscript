// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PanelScript.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PanelScript type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using UnityEditor;

   using UnityEngine;

   public sealed partial class PanelScript : uScriptGUIPanel
   {
      private static PanelScript instance;

      private static uScript uScriptInstance;

      private PanelScriptCurrent panelScriptCurrent;

      private PanelScriptList panelScriptList;

      private PanelScript()
      {
         instance = this;
         uScriptInstance = uScript.Instance;

         this.Init();
      }

      public static PanelScript Instance
      {
         get
         {
            return instance ?? (instance = new PanelScript());
         }
      }

      public static bool ShowFriendlyNames { get; set; }

      public static bool ShowLabelIcons { get; set; }

      /// <summary>
      /// Draw this panel.  This method should only be called during OnGUI.
      /// </summary>
      public override void Draw()
      {
         //Rect rect = EditorGUILayout.BeginVertical(/* uScriptGUIStyle.panelBox, GUILayout.Width(uScriptGUI.panelScriptsWidth) */);
         var rect = EditorGUILayout.BeginVertical(GUILayout.Width(uScriptGUI.PanelScriptsWidth));
         {
            if ((int)rect.width != 0 && ((int)rect.width != uScriptGUI.PanelScriptsWidth))
            {
               // if we didn't get the width we requested, we must have hit a limit, stop dragging and reset the width
               uScriptGUI.PanelScriptsWidth = (int)rect.width;
               uScriptInstance.MouseDownRegion = uScript.MouseRegion.Canvas;
               uScriptInstance.ForceReleaseMouse();
            }
            else if ((rect.x + rect.width) > uScriptInstance.position.width && (uScriptInstance.MouseDownRegion != uScript.MouseRegion.Canvas))
            {
               // panel is growing off the edge of the window, bring it back in and stop dragging
               uScriptGUI.PanelScriptsWidth = (int)(uScriptInstance.position.width - rect.x);
               uScriptInstance.MouseDownRegion = uScript.MouseRegion.Canvas;
               uScriptInstance.ForceReleaseMouse();
            }

            this.panelScriptCurrent.Draw();

            GUILayout.Space(uScriptGUI.PanelDividerThickness);

            this.panelScriptList.Draw();
         }

         EditorGUILayout.EndVertical();

         //uScriptGUI.DefineRegion(uScriptGUI.Region.Script);
         uScriptInstance.SetMouseRegion(uScript.MouseRegion.Scripts);
      }

      public void FindMissingGraphs()
      {
         this.panelScriptList.FindMissingGraphs();
      }

      public void Init()
      {
         this.Name = "uScripts";

         this.panelScriptCurrent = new PanelScriptCurrent();
         this.panelScriptList = new PanelScriptList();
      }

      public void OnProjectChange()
      {
         this.panelScriptCurrent.RefreshSourceState();
      }

      public void SaveState()
      {
         // TODO: Move this internally, by checking (EditorApplication.isCompiling) in Draw().
         this.panelScriptList.SaveState();
      }

      public static class SourceStateContent
      {
         static SourceStateContent()
         {
            Release = new GUIContent(
               uScriptGUI.GetTexture("iconScriptStatusRelease"), "Ping the source file associated with this uScript.");

            Debug = new GUIContent(
               uScriptGUI.GetTexture("iconScriptStatusDebug"),
               string.Format("{0} This script contains Debug information.", Release.tooltip));

            Stale = new GUIContent(
               uScriptGUI.GetTexture("iconScriptStatusMissing"),
               string.Format("{0} Save using Release or Debug to generate code for this script.", Release.tooltip));

            Missing = new GUIContent(
               uScriptGUI.GetTexture("iconScriptStatusUnknown"),
               "No source file was found. Save using Release or Debug to generate code for this script.");
         }

         public static GUIContent Debug { get; private set; }

         public static GUIContent Missing { get; private set; }

         public static GUIContent Release { get; private set; }

         public static GUIContent Stale { get; private set; }
      }
   }
}
