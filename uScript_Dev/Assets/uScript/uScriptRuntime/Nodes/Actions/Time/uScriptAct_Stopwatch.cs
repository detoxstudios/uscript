// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Used for measuring time like a stopwatch. Start, stop, reset, and check time functions.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Stopwatch", "Used for measuring time like a stopwatch. Start, stop, reset, and check time functions.")]
public class uScriptAct_Stopwatch : uScriptLogic
{
   private bool m_TimerRunning = false;
   private bool m_GoStarted = false;
   private bool m_GoStopped = false;
   private bool m_GoReset = false;
   private bool m_GoCheckedTime = false;

   private float m_TimeSoFar = 0.0f;


   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Started { get { return m_GoStarted; } }
   public bool Stopped { get { return m_GoStopped; } }
   public bool Reset { get { return m_GoReset; } }
   public bool CheckedTime { get { return m_GoCheckedTime; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   [FriendlyName("Start")]
   public void StartTimer(
		[FriendlyName("Seconds", "Amount of seconds which passed since stopwatch was started.")]
		out float Seconds
   )
   {
      m_GoStarted = true;
      m_GoStopped = false;
      m_GoReset = false;
      m_GoCheckedTime = false;

      m_TimerRunning = true;
      Seconds = m_TimeSoFar;
   }

   public void Stop(
      [FriendlyName("Seconds", "Amount of seconds which passed since stopwatch was started.")]
      out float Seconds
   )
   {
      m_GoStarted = false;
      m_GoStopped = true;
      m_GoReset = false;
      m_GoCheckedTime = false;
      
      m_TimerRunning = false;
      Seconds = m_TimeSoFar;
   }
 
   [FriendlyName("Reset")]
   public void ResetTimer(
      [FriendlyName("Seconds", "Amount of seconds which passed since stopwatch was started.")]
      out float Seconds
   )
   {
      m_GoStarted = false;
      m_GoStopped = false;
      m_GoReset = true;
      m_GoCheckedTime = false;
      
      m_TimeSoFar = 0.0f;
      Seconds = m_TimeSoFar;
   }

   public void CheckTime(
      [FriendlyName("Seconds", "Amount of seconds which passed since stopwatch was started.")]
      out float Seconds
   )
   {
      m_GoStarted = false;
      m_GoStopped = false;
      m_GoReset = false;
      m_GoCheckedTime = true;

      Seconds = m_TimeSoFar;
   }

   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
   public void Update()
   {
      m_GoStarted = false;
      m_GoStopped = false;
      m_GoReset = false;
      m_GoCheckedTime = false;
      
      if (m_TimerRunning)
      {
         m_TimeSoFar += UnityEngine.Time.deltaTime;
      }
   }
}
