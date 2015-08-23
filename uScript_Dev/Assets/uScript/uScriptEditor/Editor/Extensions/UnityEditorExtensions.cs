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
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Reflection;

   using Detox.Drawing;

   using UnityEditor;

   using UnityEngine;

   using Color = UnityEngine.Color;

   internal static class UnityEditorExtensions
   {
      public static Vector2 DockedGUIOffset(this EditorWindow editorWindow)
      {
         var offset = Vector2.zero;
         var borderSize = ParentBorderSize(editorWindow);

         offset.x = borderSize.left;
         offset.y = (borderSize.bottom == 2 || borderSize.bottom == 4) ? -3 : 0;

         return offset;
      }

      public static string DoTextField(
         int id,
         Rect position,
         string text,
         GUIStyle style,
         string allowedLetters,
         out bool changed,
         bool reset,
         bool multiLine,
         bool passwordField)
      {
         const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;

         var parameters = new[]
                             {
                                GetRecycledTextEditor(), id, position, text, style, allowedLetters, null, reset,
                                multiLine, passwordField
                             };

         var types = GetTypes(parameters);
         types[5] = typeof(string); // string could be null
         types[6] = typeof(bool).MakeByRefType(); // out bool

         var method = GetMethod<string>(typeof(EditorGUI), "DoTextField", types, Flags);

         var result = (string)method.Invoke(null, parameters);
         changed = (bool)parameters[6];

         return result;
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

      public static T GetFieldValue<T>(Type type, string fieldName, BindingFlags bindingFlags)
      {
         var info = type.GetField(fieldName, bindingFlags);

         if (info == null || info.FieldType.IsAssignableFrom(typeof(T)))
         {
            uScriptDebug.Log(
               string.Format("Unable to access field: {0}.{1}.", type, fieldName),
               uScriptDebug.Type.Error);
            throw new ArgumentException();
         }

         return (T)info.GetValue(null);
      }

      public static MethodInfo GetMethod<T>(Type type, string methodName, Type[] types, BindingFlags bindingFlags)
      {
         var info = typeof(EditorGUI).GetMethod(
            methodName,
            BindingFlags.NonPublic | BindingFlags.Static,
            null,
            types,
            null);

         if (info == null || info.ReturnType != typeof(T))
         {
            uScriptDebug.Log(
               string.Format("Unable to access method: {0}.{1}.", type, methodName),
               uScriptDebug.Type.Error);
            throw new ArgumentException();
         }

         return info;
      }

      public static T GetPropertyValue<T>(Type type, string propertyName, BindingFlags bindingFlags)
      {
         var info = type.GetProperty(propertyName, bindingFlags);

         if (info == null || info.PropertyType.IsAssignableFrom(typeof(T)))
         {
            uScriptDebug.Log(
               string.Format("Unable to access property: {0}.{1}.", type, propertyName),
               uScriptDebug.Type.Error);
            throw new ArgumentException();
         }

         return (T)info.GetValue(null, null);
      }

      public static object GetRecycledTextEditor()
      {
         const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;
         return GetFieldValue<object>(typeof(EditorGUI), "s_RecycledEditor", Flags);
      }

      public static Type[] GetTypes(IEnumerable<object> objects)
      {
         return objects.Select(o => o == null ? typeof(object) : o.GetType()).ToArray();
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

      public static string ToHex(this Color color)
      {
         return ((int)(color.r * 255)).ToString("X2") + ((int)(color.g * 255)).ToString("X2")
                + ((int)(color.b * 255)).ToString("X2");
      }

      public static Point ToPoint(this Vector2 vector)
      {
         return new Point((int)vector.x, (int)vector.y);
      }
   }
}
