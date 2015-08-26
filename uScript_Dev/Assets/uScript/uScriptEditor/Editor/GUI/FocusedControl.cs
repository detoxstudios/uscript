// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FocusedControl.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor.GUI
{
   using System.Diagnostics;
   using System.Globalization;

   using UnityEditor;

   using UnityEngine;

   using Debug = UnityEngine.Debug;

   public static class FocusedControl
   {
      private static int previousControlID;

      static FocusedControl()
      {
         EditorApplication.update += Update;
      }

      public static int ID
      {
         get
         {
            return GUIUtility.keyboardControl;
         }

         set
         {
            GUIUtility.keyboardControl = value;

            if (value == 0)
            {
               var callingMethodName = GetCallingMethodName();
               if (callingMethodName != "Detox.Editor.GUI.FocusedControl.Clear()")
               {
                  Debug.LogWarning(
                     "Do not directly set FocusedControl.ID to 0.\nCall FocusedControl.Clear() instead.\n");
               }
            }
            else
            {
               //Debug.LogFormat("FocusedControl.ID = {0}\n    {1}\n", value, GetCallingMethodName());
            }
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
         previousControlID = ID = 0;

         //Debug.LogFormat("FocusedControl.Clear()\n    {0}\n", GetCallingMethodName());
      }

      public static new string ToString()
      {
         return Name == string.Empty ? ID.ToString(CultureInfo.InvariantCulture) : string.Format("{0} ({1})", ID, Name);
      }

      private static string GetCallingMethodName(int skipFrames = 2)
      {
         var frame = new StackFrame(skipFrames);
         var method = frame.GetMethod();
         var type = method.DeclaringType;
         var name = method.Name;

         return string.Format("{0}.{1}()", type, name);
      }

      private static void Update()
      {
         if (/*ID == 0 ||*/ ID == previousControlID)
         {
            return;
         }

         //Debug.LogFormat("KeyboardControlID changed from {0} to {1}\n", previousControlID, ID);

         previousControlID = ID;
      }
   }
}
