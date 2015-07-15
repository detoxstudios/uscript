// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PromotionEditorWindow.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PromotionEditorWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.DetoxDevTools.Editor.Promotion
{
   using UnityEditor;

   using UnityEngine;

   public class PromotionEditorWindow : EditorWindow
   {
      [MenuItem("uScript/Internal/Promotion Editor")]
      public static void Open()
      {
         GetWindow(typeof(PromotionEditorWindow));
      }

      internal void OnGUI()
      {
         this.OnGUIDrawToolbar();
         this.OnGUIDrawList();
      }

      private void OnGUIDrawToolbar()
      {
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
         {
            if (GUILayout.Button("Add"))
            {
               PromotionAddWindow.Open();
            }
         }
         EditorGUILayout.EndHorizontal();
      }

      private void OnGUIDrawList()
      {
         EditorGUILayout.BeginHorizontal();
         {
            GUILayout.Box("ID");
            GUILayout.Box("StartDate");
            GUILayout.Box("EndDate");
            GUILayout.Box("Link");
            GUILayout.Box("Views");
            GUILayout.Box("Clicks");
         }
         EditorGUILayout.EndHorizontal();

         // ID
         // StartDate
         // EndDate
         // Image
         // Link
         // Views
         // Clicks
      }
   }
}
