// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RichTextExtensions.cs" company="Detox Studios LLC">
//   Copyright 2010-2015 Detox Studios LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.Extensions
{
   using System;

   using UnityEditor;

   using UnityEngine;

   internal static class RichTextExtensions
   {
      public static string Bold(this string value)
      {
#if UNITY_3_5
         return value;
#else
         return string.Format("<b>{0}</b>", value);
#endif
      }

      public static string Italic(this string value)
      {
#if UNITY_3_5
         return value;
#else
         return string.Format("<i>{0}</i>", value);
#endif
      }

      public static string Color(this string value, Color color)
      {
#if UNITY_3_5
         return value;
#else
         // ReSharper disable once InvokeAsExtensionMethod
         return string.Format("<color=#{0}>{1}</color>", UnityEditorExtensions.ToHex(color), value);
#endif
      }

      public static string HighlightMatch(
         this string value,
         string match,
         StringComparison comparison = StringComparison.OrdinalIgnoreCase)
      {
         return HighlightMatch(value, match, EditorStyles.label.onFocused.textColor, comparison);
      }

      public static string HighlightMatch(
         this string value,
         string match,
         Color color,
         StringComparison comparison = StringComparison.OrdinalIgnoreCase)
      {
#if UNITY_3_5
         return value;
#else
         if (string.IsNullOrEmpty(match))
         {
            return value;
         }

         var index = value.IndexOf(match, StringComparison.OrdinalIgnoreCase);
         if (index == -1)
         {
            return value;
         }

         match = value.Substring(index, match.Length);
         return value.Replace(match, match.Color(color));
#endif
      }
   }
}
