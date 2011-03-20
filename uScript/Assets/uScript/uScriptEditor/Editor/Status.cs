using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace Detox.Utility
{
   public enum LogType
   {
      Info,
      Warning,
      Error
   }

   public class StatusUpdateEventArgs : EventArgs
   {
      private LogType m_LogType;
      private string  m_Message;

      public LogType LogType  { get { return m_LogType; } }
      public string  Message  { get { return m_Message; } }

      public StatusUpdateEventArgs (LogType logType, string message)
      {
         m_Message = message;
         m_LogType = logType;
      }
   }

   public class Status
   {
      public delegate void StatusUpdateEventHandler(StatusUpdateEventArgs e);
      static public event StatusUpdateEventHandler StatusUpdate;

      static private void OnStatusUpdate(LogType type, string message)
      {
         if (null != StatusUpdate) StatusUpdate( new StatusUpdateEventArgs(type, message) );
      }

      static private string       m_Path   = null;
      static private StreamWriter m_Writer = null;
      static private Mutex        m_Mutex = null;

      static public void Create(string path)
      {
         m_Path = path;

         m_Writer = new StreamWriter( m_Path, true );
         m_Writer.WriteLine( "-----------------------------------------" );

         m_Mutex = new Mutex( );
      }

      static public void Info(string message)
      {
         Log(LogType.Info, message);
      }

      static public void Warning(string message)
      {
         Log(LogType.Warning, message);
      }

      static public void Error(string message)
      {
         Log(LogType.Error, message);
      }

      static public void Log(LogType type, string message)
      {
         if ( null != m_Writer )
         {
            m_Mutex.WaitOne( );
            
            m_Writer.WriteLine(type.ToString() + ":" + message);
            m_Writer.Flush( );

            m_Mutex.ReleaseMutex( );
         }
         
         OnStatusUpdate(type, message);
      }
   }
}
