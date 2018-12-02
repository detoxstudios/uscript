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

      private PanelScriptCurrent panelScriptCurrent;

      private PanelScriptList panelScriptList;

      private PanelScript()
      {
         instance = this;
         InUScriptPanel = true;

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
         var uScriptInstance = uScript.WeakInstance;

         if (uScriptInstance == null && !InUScriptPanel)
         {
            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
            {
               // draw empty panel
               this.DrawOrphanNotification();
            }
            EditorGUILayout.EndVertical();
         }
         else
         {
            if (InUScriptPanel && !uScriptInstance.IsOnlyBottomPanelVisible(GetType().ToString()))
            {
               if (uScriptInstance.ReferenceVisible)
               {
                  EditorGUILayout.BeginVertical(GUILayout.Width(uScriptGUI.PanelScriptsWidth));
               }
               else
               {
                  EditorGUILayout.BeginVertical(GUILayout.Width(uScriptInstance.position.width - uScriptGUI.DefaultPanelDividerThickness - uScriptGUI.PanelPropertiesWidth));
               }
            }
            else
            {
               EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
            }
            {
               this.panelScriptCurrent.Draw(this);

               GUILayout.Space(uScriptGUI.PanelDividerThickness);

               this.panelScriptList.Draw();
            }

            EditorGUILayout.EndVertical();

            if (InUScriptPanel) uScriptInstance.SetMouseRegion(uScript.MouseRegion.Scripts);
         }
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
         if (this.panelScriptList != null) this.panelScriptList.SaveState();
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
