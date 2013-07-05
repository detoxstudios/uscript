// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewItemScript.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ListViewItem_Script type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using UnityEngine;

   public class ListViewItemScript : ListViewItem
   {
      // === Constants ==================================================================

      // === Fields =====================================================================

      // === Constructors ===============================================================

      public ListViewItemScript(ListView listView, string path)
         : base(listView, path)
      {
         this.SourceState = 0;
         this.SceneName = string.Empty;
         this.FriendlyName = string.Empty;

         Debug.Log("NEW ListViewItem_Script\n");
      }

      // === Finalizers =================================================================

      // === Delegates ==================================================================

      // === Events =====================================================================

      // === Enums ======================================================================

      // === Interfaces =================================================================

      // === Properties =================================================================

      public string FriendlyName { get; set; }

      public string SceneName { get; set; }

      public int SourceState { get; set; }

      // === Indexers ===================================================================

      // === Methods ====================================================================

      // === Structs ====================================================================

      // === Classes ====================================================================

      private static class Content
      {
         static Content()
         {
            NoScene = new GUIContent("This script is not attached to any scene.  It may be used with Prefabs or as a Nested Script.");

            WrongScene = new GUIContent("This uScript file was previously attached to a different Unity Scene.  "
               + "It may not be compatible with the current Unity Scene, and may not run correctly, if edited while this scene is open.");

            IconScript = uScriptGUI.GetTexture("iconScriptFile01");
            IconScriptNested = uScriptGUI.GetTexture("iconScriptFile02");

            IconSourceDebug = uScriptGUI.GetTexture("iconScriptStatusDebug");
            IconSourceMissing = uScriptGUI.GetTexture("iconScriptStatusMissing");
            IconSourceRelease = uScriptGUI.GetTexture("iconScriptStatusRelease");
            IconSourceUnknown = uScriptGUI.GetTexture("iconScriptStatusUnknown");

            IconUnityScene = uScriptGUI.GetSkinnedTexture("UnityScene");
         }

         public static Texture2D IconScript { get; private set; }

         public static Texture2D IconScriptNested { get; private set; }

         public static Texture2D IconSourceDebug { get; private set; }

         public static Texture2D IconSourceMissing { get; private set; }

         public static Texture2D IconSourceRelease { get; private set; }

         public static Texture2D IconSourceUnknown { get; private set; }

         public static Texture2D IconUnityScene { get; private set; }

         public static GUIContent NoScene { get; private set; }

         public static GUIContent WrongScene { get; private set; }
      }

      private static class Style
      {
         static Style()
         {
            StatusIcon = new GUIStyle();
         }

         public static GUIStyle StatusIcon { get; private set; }
      }

      // ================================================================================
      // ================================================================================
      // ================================================================================

      //GUIStyle rowStyle = (this.selected ? Style.Label : (this.listView.ItemRow % 2 == 0 ? this.style.rowEven : this.style.rowOdd));

         //if (isRepaint)
         //{
         //   // Draw row background
         //   GUIStyle rowStyle = (this.selected ? Style.Label : (this.listView.ItemRow % 2 == 0 ? this.style.rowEven : this.style.rowOdd));

         //   // isHover, isActive, on, hasKeyboardFocus
         //   //    GREY (on)
         //   //    BLUE (on, hasKeyboardFocus)
         //   //    RING (isHover, isActive)
         //   rowStyle.Draw(this.rowRect, GUIContent.none, false, false, true, this.listView.HasFocus);
         //}

   }
}
