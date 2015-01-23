// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Status.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the LogType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Utility
{
   using System;
   using System.IO;
   using System.Threading;

   public enum LogType
   {
      Info,
      Warning,
      Error
   }

   public class Status
   {
      private static string m_Path;

      private static StreamWriter m_Writer;

      private static Mutex m_Mutex;

      public delegate void StatusUpdateEventHandler(StatusUpdateEventArgs e);

      public static event StatusUpdateEventHandler StatusUpdate;

      public static void Create(string path)
      {
         m_Path = path;

         m_Writer = new StreamWriter(m_Path, true);
         m_Writer.WriteLine("-----------------------------------------");

         m_Mutex = new Mutex();
      }

      public static void Info(string message)
      {
         Log(LogType.Info, message);
      }

      public static void Warning(string message)
      {
         Log(LogType.Warning, message);
      }

      public static void Error(string message)
      {
         Log(LogType.Error, message);
      }

      public static void Log(LogType type, string message)
      {
         if (null != m_Writer)
         {
            m_Mutex.WaitOne();

            m_Writer.WriteLine("{0}:{1}", type, message);
            m_Writer.Flush();

            m_Mutex.ReleaseMutex();
         }

         OnStatusUpdate(type, message);
      }

      private static void OnStatusUpdate(LogType type, string message)
      {
         if (null != StatusUpdate)
         {
            StatusUpdate(new StatusUpdateEventArgs(type, message));
         }
      }
   }

   public class StatusUpdateEventArgs : EventArgs
   {
      public StatusUpdateEventArgs(LogType logType, string message)
      {
         this.Message = message;
         this.LogType = logType;
      }

      public LogType LogType { get; private set; }

      public string Message { get; private set; }
   }
}
