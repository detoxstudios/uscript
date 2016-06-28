// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JobManager.cs" company="Detox Studios LLC">
//   Copyright 2010-2015 Detox Studios LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   // REFERENCED:
   // ----------
   //    http://answers.unity3d.com/questions/221651/yielding-with-www-in-editor.html
   //
   // USAGE:
   // ~~~~~
   //    var www = new WWW("someURL");
   //    ContinuationManager.Add(() => www.isDone, () =>
   //    {
   //       if (!string.IsNullOrEmpty(www.error))
   //       {
   //          Debug.Log("WWW failed: " + www.error);
   //       }
   //       Debug.Log("WWW result : " + www.text);
   //    });

   using System;
   using System.Collections.Generic;
   using System.Linq;

   using UnityEditor;

   internal static class JobManager
   {
      private static readonly List<Job> Jobs = new List<Job>();

      /// <summary>
      /// The Job has a completed condition that when met will execute a final task.
      /// </summary>
      /// <param name="completed">The completion condition.</param>
      /// <param name="continueWith">The function that will be executed upon completion.</param>
      public static void Add(Func<bool> completed, Action continueWith)
      {
         if (completed == null || continueWith == null)
         {
            return;
         }

         if (Jobs.Any() == false)
         {
            EditorApplication.update += Update;
         }

         Jobs.Add(new Job(completed, continueWith));
      }

      private static void Update()
      {
         for (var i = 0; i >= 0; --i)
         {
            var job = Jobs[i];
            if (job.Completed != null && job.Completed() == false)
            {
               continue;
            }

            if (job.ContinueWith != null)
            {
               job.ContinueWith();
            }

            Jobs.RemoveAt(i);
         }

         if (Jobs.Any() == false)
         {
            EditorApplication.update -= Update;
         }
      }

      private class Job
      {
         public Job(Func<bool> completed, Action continueWith)
         {
            this.Completed = completed;
            this.ContinueWith = continueWith;
         }

         public Func<bool> Completed { get; private set; }

         public Action ContinueWith { get; private set; }
      }
   }
}
