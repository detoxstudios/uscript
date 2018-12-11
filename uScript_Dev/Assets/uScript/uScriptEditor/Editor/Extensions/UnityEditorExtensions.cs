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
   using Detox.Editor.GUI;

   using UnityEditor;

   using UnityEngine;

   using Color = UnityEngine.Color;
   using Debug = System.Diagnostics.Debug;

   internal static class UnityEditorExtensions
   {
      public static bool CurrentGUIViewHasFocus()
      {
         var unityEditor = Assembly.GetAssembly(typeof(EditorGUI));

         var guiView = unityEditor.GetType("UnityEditor.GUIView");
         if (guiView == null)
         {
            uScriptDebug.Log("UnityEditor.GUIView was not found in the assembly.", uScriptDebug.Type.Error);
            return false;
         }

         var currentPropertyInfo = guiView.GetProperty("current", BindingFlags.Public | BindingFlags.Static);
         if (currentPropertyInfo == null)
         {
            uScriptDebug.Log("UnityEditor.GUIView.current was not found in the assembly.", uScriptDebug.Type.Error);
            return false;
         }

         var hasFocusPropertyInfo = guiView.GetProperty("hasFocus", BindingFlags.Public | BindingFlags.Instance);
         if (hasFocusPropertyInfo == null)
         {
            uScriptDebug.Log("UnityEditor.GUIView.hasFocus was not found in the assembly.", uScriptDebug.Type.Error);
            return false;
         }

         var current = currentPropertyInfo.GetValue(null, null);
         return (bool)hasFocusPropertyInfo.GetValue(current, null);
      }

      public static Vector2 DockedGUIOffset(this EditorWindow editorWindow)
      {
         var offset = Vector2.zero;
         var borderSize = ParentBorderSize(editorWindow);

         offset.x = borderSize.left;
         offset.y = (borderSize.bottom == 2 || borderSize.bottom == 4) ? -3 : 0;

         return offset;
      }

      public static string DoTextField(int id, Rect position, string text, GUIStyle style, out bool changed)
      {
         return DoTextField(id, position, text, style, null, out changed, false, false, false);
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
         return EditorGUILayout.GetControlRect(hasLabel, height, style, options);
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

      public static MethodInfo GetMethod(Type type, string methodName, Type[] types, BindingFlags bindingFlags)
      {
         var info = type.GetMethod(methodName, bindingFlags, null, types, null);

         if (info == null || info.ReturnType != typeof(void))
         {
            uScriptDebug.Log(
               string.Format("Unable to access method: {0}.{1}.", type, methodName),
               uScriptDebug.Type.Error);
            throw new ArgumentException();
         }

         return info;
      }

      public static MethodInfo GetMethod<T>(Type type, string methodName, Type[] types, BindingFlags bindingFlags)
      {
         var info = type.GetMethod(methodName, bindingFlags, null, types, null);

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

      public static bool HasKeyboardFocus(int controlID)
      {
         return FocusedControl.ID == controlID && CurrentGUIViewHasFocus();
      }

      public static bool IsEditingControl(int id)
      {
         // Never returns True when Event.current is "Layout" or "Used"
         return id != 0 && HasKeyboardFocus(id) && IsEditingTextField();
      }

      public static bool IsEditingTextField()
      {
         var method = typeof(EditorGUI).GetMethod("IsEditingTextField", BindingFlags.NonPublic | BindingFlags.Static);
         if (method == null)
         {
            uScriptDebug.Log("EditorGUI.IsEditingTextField was not found in the assembly.", uScriptDebug.Type.Error);
            return false;
         }

         var result = (bool)method.Invoke(null, null);

         return result;
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

         Debug.Assert(borderSize != null, "borderSize is null");

         return borderSize;
      }

      /// <summary>
      /// The "Rect.position" property was not introduced until Unity 4.5
      /// </summary>
      /// <param name="rect">The target rectangle.</param>
      /// <returns>Returns the position of the target.</returns>
      public static Vector2 Position(this Rect rect)
      {
         return new Vector2(rect.xMin, rect.yMin);
      }

      public static void ReplaceRecycledTextEditorContents(string text)
      {
         const BindingFlags Flags = BindingFlags.Public | BindingFlags.Instance;

         var recycledEditor = GetRecycledTextEditor();

         var selectAllMethod = GetMethod(recycledEditor.GetType(), "SelectAll", new Type[0], Flags);
         selectAllMethod.Invoke(recycledEditor, null);

         var parameters = new object[] { text };
         var types = GetTypes(parameters);
         var replaceSelectionMethod = GetMethod(recycledEditor.GetType(), "ReplaceSelection", types, Flags);
         replaceSelectionMethod.Invoke(recycledEditor, parameters);
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
