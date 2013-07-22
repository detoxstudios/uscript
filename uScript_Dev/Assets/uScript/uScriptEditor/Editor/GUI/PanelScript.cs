// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PanelScript.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
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
      // === Constants ==================================================================

      // === Fields =====================================================================

      private static PanelScript instance;

      private static uScript uScriptInstance;

      private PanelScriptCurrent panelScriptCurrent;

      private PanelScriptList panelScriptList;

      // === Constructors ===============================================================

      private PanelScript()
      {
         instance = this;
         uScriptInstance = uScript.Instance;

         this.Init();
      }

      // === Properties =================================================================

      public static PanelScript Instance
      {
         get
         {
            return instance ?? (instance = new PanelScript());
         }
      }

      // === Methods ====================================================================

      /// <summary>
      /// Draw this panel.  This method should only be called during OnGUI.
      /// </summary>
      public override void Draw()
      {
         //Rect rect = EditorGUILayout.BeginVertical(/* uScriptGUIStyle.panelBox, GUILayout.Width(uScriptGUI.panelScriptsWidth) */);
         var rect = EditorGUILayout.BeginVertical(GUILayout.Width(uScriptGUI.PanelScriptsWidth));
         {
            if ((int)rect.width != 0 && (int)rect.width != uScriptGUI.PanelScriptsWidth)
            {
               // if we didn't get the width we requested, we must have hit a limit, stop dragging and reset the width
               uScriptGUI.PanelScriptsWidth = (int)rect.width;
               uScriptInstance.MouseDownRegion = uScript.MouseRegion.Canvas;
               uScriptInstance.ForceReleaseMouse();
            }
            else if (rect.x + rect.width > uScriptInstance.position.width)
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

      public void Init()
      {
         this._name = "uScripts";
         //      _size = 150;
         //      _region = uScriptGUI.Region.Script;

         this.panelScriptCurrent = new PanelScriptCurrent();
         this.panelScriptList = new PanelScriptList();

         this.panelScriptList.RebuildListContents();
      }

      public void RefreshSourceState()
      {
         // TODO: Remove this when there are no more references in code.
      }

      public void RebuildListContents()
      {
         // TODO: Remove this when there are no more references in code.
         this.OnProjectChange();
      }

      public void OnProjectChange()
      {
         this.panelScriptList.RebuildListContents();
         this.panelScriptCurrent.RefreshSourceState();
      }

      // === Structs ====================================================================

      // === Classes ====================================================================
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
