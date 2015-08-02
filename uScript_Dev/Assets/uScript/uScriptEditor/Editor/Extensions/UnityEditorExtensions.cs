// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityEditorExtensions.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the Extensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.Extensions
{
   using System.Reflection;

   using UnityEditor;

   using UnityEngine;

   public static class UnityEditorExtensions
   {
      public static Vector2 DockedGUIOffset(this EditorWindow editorWindow)
      {
         var offset = Vector2.zero;
         var borderSize = ParentBorderSize(editorWindow);

         offset.x = borderSize.left;
         offset.y = (borderSize.bottom == 2 || borderSize.bottom == 4) ? -3 : 0;

         return offset;
      }

      public static Rect GetControlRect(params GUILayoutOption[] options)
      {
         return GetControlRect(true, 16f, EditorStyles.layerMaskField, options);
      }

      public static Rect GetControlRect(bool hasLabel, params GUILayoutOption[] options)
      {
         return GetControlRect(hasLabel, 16f, EditorStyles.layerMaskField, options);
      }

      public static Rect GetControlRect(bool hasLabel, float height, params GUILayoutOption[] options)
      {
         return GetControlRect(hasLabel, height, EditorStyles.layerMaskField, options);
      }

      public static Rect GetControlRect(bool hasLabel, float height, GUIStyle style, params GUILayoutOption[] options)
      {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
         // EditorGUILayout.GetControlRect was introduced in 4.3.0
         var value = new Rect();

         var method = typeof(GUILayoutUtility).GetMethod("GetControlRect", BindingFlags.NonPublic | BindingFlags.Static);
         if (method != null)
         {
            var parameters = new object[] { hasLabel, height, style, options };
            value = (Rect)method.Invoke(null, parameters);
         }

         return value;
#else
         return EditorGUILayout.GetControlRect(hasLabel, height, style, options);
#endif
      }

      public static RectOffset ParentBorderSize(this EditorWindow editorWindow)
      {
         RectOffset borderSize = null;

         // Get the viewport border size from Unity via reflection
         const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
         var fi = editorWindow.GetType().GetField("m_Parent", Flags);
         if (fi == null)
         {
            uScriptDebug.Log("The m_Parent field info is null.", uScriptDebug.Type.Error);
         }
         else
         {
            var parent = fi.GetValue(editorWindow);
            if (parent == null)
            {
               uScriptDebug.Log("The parent EditorWindow is null.", uScriptDebug.Type.Error);
            }
            else
            {
               var pi = parent.GetType().GetProperty("borderSize", Flags);
               borderSize = pi.GetValue(parent, null) as RectOffset;
            }
         }

         System.Diagnostics.Debug.Assert(borderSize != null, "borderSize is null");

         return borderSize;
      }
   }
}
