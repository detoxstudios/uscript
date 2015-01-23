// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HierarchyWindowIcon.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the HierarchyWindowIcon type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using UnityEditor;

   using UnityEngine;

   [InitializeOnLoad]
   internal static class HierarchyWindowIcon
   {
      private static readonly Texture2D ComponentIcon;

      static HierarchyWindowIcon()
      {
         ComponentIcon = uScriptGUI.GetTexture("iconScriptFile02");
         EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
      }

      private static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
      {
         if (EditorApplication.isPlayingOrWillChangePlaymode)
         {
            return;
         }

         if (HasValidComponent(instanceID))
         {
            DrawIcon(selectionRect);
         }
      }

      private static void DrawIcon(Rect rect)
      {
         if (ComponentIcon == null)
         {
            return;
         }

         rect = GetRightAligned(rect, ComponentIcon);
         GUI.Box(rect, uScriptGUIContent.Temp(ComponentIcon, "uScript attached"), GUIStyle.none);
      }

      private static Rect GetRightAligned(Rect rect, Texture texture)
      {
         rect.x = rect.xMax - texture.width;
         rect.width = texture.width;
         rect.y += (rect.height - texture.height) / 2f;
         rect.height = texture.height;

         return rect;
      }

      private static bool HasValidComponent(int instanceID)
      {
         var go = (GameObject)EditorUtility.InstanceIDToObject(instanceID);
         return go != null
                && (go.GetComponent<uScriptEvent>() != null || go.GetComponent<uScriptCode>() != null
                    || go.GetComponent<uScript_MasterComponent>() != null);
      }
   }
}
