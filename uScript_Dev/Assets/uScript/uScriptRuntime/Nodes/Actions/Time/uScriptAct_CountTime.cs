// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Counts the amount of time that elapses between starting and stopping.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Count_Time")]
[NodeDeprecated()]

[FriendlyName("Count Time", "Counts the amount of time that elapses between starting and stopping.")]
public class uScriptAct_CountTime : uScriptLogic
{
   private bool m_TimerStarted = false;
   private bool m_GoStarted = false;
   private bool m_GoStopped = false;

   private float m_TotalTime = 0F;
	private float m_StartTime = 0F;


   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Out { get { return true; } }
   public bool Started { get { return m_GoStarted; } }
   public bool Stopped { get { return m_GoStopped; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in Stop()
   [FriendlyName("Start")]
   public void In(
		[FriendlyName("Seconds", "Amount of seconds which passed since Start was called.")]
		out float seconds)
   {
      m_TotalTime = 0;
	  seconds = m_TotalTime;
      m_TimerStarted = true;
      m_GoStarted = true;
      m_GoStopped = false;
   }

   public void Stop(
      [FriendlyName("Seconds", "Amount of seconds which passed since Start was called.")]
      out float Seconds
      )
   {
      m_GoStarted = false;
      m_GoStopped = true;

      m_TimerStarted = false;
      Seconds = m_TotalTime - m_StartTime;
      m_TotalTime = 0F;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
   public void Update()
   {
      m_GoStarted = false;
      m_GoStopped = false;

      if (m_TimerStarted)
      {
         m_TotalTime = UnityEngine.Time.time;
      }
	  else
	  {
	     m_StartTime = UnityEngine.Time.time;
	  }
   }

}
