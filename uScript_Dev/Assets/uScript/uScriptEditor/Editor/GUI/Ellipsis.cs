// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios, LLC" file="Ellipsis.cs">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the Ellipsis type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * This script is based on the "Auto Ellipsis" project by Thomas Polaert (2009-06-20).
 *    http://www.codeproject.com/Articles/37503/Auto-Ellipsis
 *
 * The project resides on CodeProject.com, and is free to use under the CPOL license.
 *    http://www.codeproject.com/info/cpol10.aspx
 *
 * Changes from the standard version:
 *    The class and members were updated to work with the Unity API.
 *    The namespace was changed.
 *    The FormatEllipsis enum was moved to the Ellipsis class and renamed to Format.
 */

namespace Detox.Editor.GUI
{
   using System;
   using System.IO;
   using System.Text.RegularExpressions;

   using UnityEngine;

   using Debug = System.Diagnostics.Debug;

   public class Ellipsis
   {
      /// <summary>
      /// String used as a place holder for trimmed text.
      /// </summary>
      public static readonly string EllipsisChars = "...";

      private static readonly Regex PrevWord = new Regex(@"\W*\w*$");
      private static readonly Regex NextWord = new Regex(@"\w*\W*");

      /// <summary>
      /// Specifies ellipsis format and alignment.
      /// </summary>
      [Flags]
      public enum Format
      {
         /// <summary>
         /// Text is not modified.
         /// </summary>
         None = 0,

         /// <summary>
         /// Text is trimmed at the end of the string. An ellipsis (...) is drawn in place of remaining text.
         /// </summary>
         End = 1,

         /// <summary>
         /// Text is trimmed at the beginning of the string. An ellipsis (...) is drawn in place of remaining text.
         /// </summary>
         Start = 2,

         /// <summary>
         /// Text is trimmed in the middle of the string. An ellipsis (...) is drawn in place of remaining text.
         /// </summary>
         Middle = 3,

         /// <summary>
         /// Preserve as much as possible of the drive and filename information. Must be combined with alignment information.
         /// </summary>
         Path = 4,

         /// <summary>
         /// Text is trimmed at a word boundary. Must be combined with alignment information.
         /// </summary>
         Word = 8
      }

      /// <summary>
      /// Truncates a text string to fit within a given control width by replacing trimmed text with ellipses.
      /// </summary>
      /// <param name="text">String to be trimmed.</param>
      /// <param name="style">The GUIStyle that will be used for measurements.</param>
      /// <param name="maxSize">The area that the string must fit inside.</param>
      /// <param name="options">Format and alignment of ellipsis.</param>
      /// <returns>This function returns text trimmed to the specified width.</returns>
      public static string Compact(string text, GUIStyle style, Rect maxSize, Format options)
      {
         if (string.IsNullOrEmpty(text))
         {
            return text;
         }

         // no aligment information
         if ((Format.Middle & options) == 0)
         {
            return text;
         }

         if (style == null)
         {
            throw new ArgumentNullException("style");
         }

         Vector2 s = style.CalcSize(new GUIContent(text));

         // control is large enough to display the whole text
         if (s.x <= maxSize.width)
         {
            return text;
         }

         string pre = string.Empty;
         string mid = text;
         string post = string.Empty;

         bool isPath = (Format.Path & options) != 0;

         // split path string into <drive><directory><filename>
         if (isPath)
         {
            pre = Path.GetPathRoot(text);
            
            string directoryName = Path.GetDirectoryName(text);
            if (directoryName != null)
            {
               mid = directoryName.Substring(pre.Length);
            }

            post = Path.GetFileName(text);
            Debug.Assert(post != null, "post is null");
         }

         int len = 0;
         int seg = mid.Length;
         string fit = string.Empty;

         // find the longest string that fits into
         // the control boundaries using bisection method
         while (seg > 1)
         {
            seg -= seg / 2;

            int left = len + seg;
            int right = mid.Length;

            if (left > right)
            {
               continue;
            }

            if ((Format.Middle & options) == Format.Middle)
            {
               right -= left / 2;
               left -= left / 2;
            }
            else if ((Format.Start & options) != 0)
            {
               right -= left;
               left = 0;
            }

            // trim at a word boundary using regular expressions
            if ((Format.Word & options) != 0)
            {
               if ((Format.End & options) != 0)
               {
                  left -= PrevWord.Match(mid, 0, left).Length;
               }

               if ((Format.Start & options) != 0)
               {
                  right += NextWord.Match(mid, right).Length;
               }
            }

            // build and measure a candidate string with ellipsis
            string tst = mid.Substring(0, left) + EllipsisChars + mid.Substring(right);

            // restore path with <drive> and <filename>
            if (isPath)
            {
               tst = Path.Combine(Path.Combine(pre, tst), post);
            }

            s = style.CalcSize(new GUIContent(tst));

            // candidate string fits into control boundaries, try a longer string
            // stop when seg <= 1
            if (s.x <= maxSize.width)
            {
               len += seg;
               fit = tst;
            }
         }

         // string can't fit into control
         if (len == 0)
         {
            // "path" mode is off, just return ellipsis characters
            if (!isPath)
            {
               return EllipsisChars;
            }

            // <drive> and <directory> are empty, return <filename>
            if (pre.Length == 0 && mid.Length == 0)
            {
               return post;
            }

            // measure "C:\...\filename.ext"
            fit = Path.Combine(Path.Combine(pre, EllipsisChars), post);

            s = style.CalcSize(new GUIContent(fit));

            // if still not fit then return "...\filename.ext"
            if (s.x > maxSize.width)
            {
               fit = Path.Combine(EllipsisChars, post);
            }
         }

         return fit;
      }
   }
}
