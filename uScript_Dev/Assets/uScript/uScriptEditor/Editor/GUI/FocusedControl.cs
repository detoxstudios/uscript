// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FocusedControl.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System.Globalization;

   using UnityEngine;

   public static class FocusedControl
   {
      public static int ID
      {
         get
         {
            return GUIUtility.keyboardControl;
         }

         set
         {
            GUIUtility.keyboardControl = value;
         }
      }

      public static string Name
      {
         get
         {
            return GUI.GetNameOfFocusedControl();
         }
      }

      public static void Clear()
      {
         ID = 0;
      }

      public static new string ToString()
      {
         return Name == string.Empty ? ID.ToString(CultureInfo.InvariantCulture) : string.Format("{0} ({1})", ID, Name);
      }
   }
}
