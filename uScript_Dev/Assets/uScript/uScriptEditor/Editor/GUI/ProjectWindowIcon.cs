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
      private static readonly Texture2D GraphIcon16;
      private static readonly Texture2D GraphIcon64;

      static ProjectWindowIcon()
      {
         GraphIcon16 = uScriptGUI.GetTexture("iconScriptFile01");
         GraphIcon64 = uScriptGUI.GetTexture("Bilinear/iconScriptFile01_64");
         //GraphIcon64 = uScriptGUI.GetTexture("Bilinear/iconScriptFile03_64");
         EditorApplication.projectWindowItemOnGUI += ProjectWindowItemOnGUI;
      }

      private static void ProjectWindowItemOnGUI(string guid, Rect selectionRect)
      {
         if (EditorApplication.isPlayingOrWillChangePlaymode)
         {
            return;
         }

         if (HasValidComponent(guid))
         {
            DrawIcon(selectionRect);
         }
      }

      private static void DrawIcon(Rect rect)
      {
         Texture2D icon;
         if (rect.height > 16)
         {
            icon = GraphIcon64;
            rect = GetGridIconPosition(rect, icon);
         }
         else
         {
            icon = GraphIcon16;
            rect = GetListIconPosition(rect, icon);
         }

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

      private static bool HasValidComponent(string guid)
      {
         var path = AssetDatabase.GUIDToAssetPath(guid);
         var extension = Path.GetExtension(path) ?? string.Empty;

         return extension.ToLower() == ".uscript";
      }
   }
}
