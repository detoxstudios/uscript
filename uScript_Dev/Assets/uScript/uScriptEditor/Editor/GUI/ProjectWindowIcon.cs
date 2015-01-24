// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectWindowIcon.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ProjectWindowIcon type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System.IO;

   using UnityEditor;

   using UnityEngine;

   [InitializeOnLoad]
   internal static class ProjectWindowIcon
   {
      private static Texture2D graphIcon16;
      private static Texture2D graphIcon64;

      static ProjectWindowIcon()
      {
         EditorApplication.projectWindowItemOnGUI += ProjectWindowItemOnGUI;
      }

      private static Texture2D GraphIcon16
      {
         get
         {
            return graphIcon16 ?? (graphIcon16 = uScriptGUI.GetTexture("iconScriptFile01"));
         }
      }

      private static Texture2D GraphIcon64
      {
         get
         {
            // Alternate texture: "Bilinear/iconScriptFile03_64"
            return graphIcon64 ?? (graphIcon64 = uScriptGUI.GetTexture("Bilinear/iconScriptFile01_64"));
         }
      }

      private static void ProjectWindowItemOnGUI(string guid, Rect selectionRect)
      {
         if (EditorApplication.isPlayingOrWillChangePlaymode)
         {
            return;
         }

         if (ShouldDrawIcon(guid))
         {
            DrawIcon(selectionRect);
         }
      }

      private static void DrawIcon(Rect rect)
      {
         var isGridIcon = rect.height > 16;
         var icon = isGridIcon ? GraphIcon64 : GraphIcon16;
         if (icon == null)
         {
            return;
         }

         rect = isGridIcon ? GetGridIconPosition(rect, icon) : GetListIconPosition(rect, icon);

         GUI.Box(rect, uScriptGUIContent.Temp(icon, "uScript Graph"), GUIStyle.none);
      }

      private static Rect GetGridIconPosition(Rect rect, Texture texture)
      {
         // Using the larger, scalable bilinear texture (64x64)
         uScriptDebug.Assert(
            texture.width == texture.height,
            "The Project Window item icons should be square 64x64 pixels.");

         if (rect.width > 64)
         {
            var offset = (rect.width - 64) * 0.5f;
            rect.x += offset;
            rect.y += offset;
         }

         rect.width = Mathf.Min(rect.width, texture.width);
         rect.height = Mathf.Min(rect.width, texture.width);

         return rect;
      }

      private static Rect GetListIconPosition(Rect rect, Texture texture)
      {
         // Using the small, fixed-size texture (16x16)
         var verticalOffset = (rect.height - texture.height) / 2f;

         rect.y += verticalOffset;
         rect.width = texture.width;
         rect.height = texture.height;

         return rect;
      }

      private static bool ShouldDrawIcon(string guid)
      {
         var path = AssetDatabase.GUIDToAssetPath(guid);
         var extension = Path.GetExtension(path) ?? string.Empty;

         return extension.ToLower() == ".uscript";
      }
   }
}
