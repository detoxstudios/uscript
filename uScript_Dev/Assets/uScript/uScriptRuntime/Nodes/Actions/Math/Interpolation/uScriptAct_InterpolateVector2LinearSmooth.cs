// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Interpolation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Linearly interpolate a Vector2 over time.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Interpolate Vector2 Linear (Smooth)", "Linearly interpolate a Vector2 over time.")]
public class uScriptAct_InterpolateVector2LinearSmooth : uScriptLogic
{ 
   private Vector2 m_Start;
   private Vector2 m_End;
   private Vector2 m_LastValue;
   private bool m_Began = false;

   private uScript_Lerper m_Lerper = new uScript_Lerper( );


   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Started       { get { return m_Lerper.AllowStartedOutput; } }
   public bool Stopped       { get { return m_Lerper.AllowStoppedOutput; } }
   public bool Interpolating { get { return m_Lerper.AllowInterpolatingOutput; } }
   public bool Finished      { get { return m_Lerper.AllowFinishedOutput; } }
   

   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in Resume()
   public void Begin(Vector2 startValue, Vector2 endValue, float time, uScript_Lerper.LoopType loopType, float loopDelay, bool smooth, int loopCount, out Vector2 currentValue)
   {
      m_Lerper.Set( time, loopType, loopDelay, smooth, loopCount );

      m_Start      = startValue;
      m_LastValue  = startValue;
      m_End        = endValue;

      m_Began      = true;

      currentValue = startValue;
   }

   // Parameter Attributes are applied below in Resume()
   public void Stop(Vector2 startValue, Vector2 endValue, float time, uScript_Lerper.LoopType loopType, float loopDelay, bool smooth, int loopCount, out Vector2 currentValue)
   {
      m_Lerper.Stop( );

      currentValue = m_LastValue;
      if (!m_Began)
      {
         currentValue = startValue;
      }
   }

   public void Resume(
      [FriendlyName("Start Value", "Starting value to interpolate from.")]
      Vector2 startValue,

      [FriendlyName("End Value", "Ending value to interpolate to.")]
      Vector2 endValue,

      [FriendlyName("Time", "Time to take to complete the interpolation (in seconds).")]
      float time,

      [FriendlyName("Loop Type", "The type of looping to use (available values are None, Repeat, and PingPong).")]
      [SocketState(false, false)]
      uScript_Lerper.LoopType loopType,

      [FriendlyName("Loop Delay", "Time delay (in seconds) between loops.")]
      [SocketState(false, false)]
      float loopDelay,

      [FriendlyName("Smooth", "Ease in and out of interpolation.")]
      [SocketState(false, false)]
      bool smooth,

      [FriendlyName("Loop Count", "Number of times to loop. For infinite looping, use -1 or connect the out socket of this node to its own in and use any positive value.")]
      [DefaultValue(-1), SocketState(false, false)]
      int loopCount,

      [FriendlyName("Output Value", "Current interpolated value.")]
      out Vector2 currentValue
      )
   {
      m_Lerper.Resume( );

      currentValue = m_LastValue;
      if (!m_Began)
      {
         currentValue = startValue;
      }
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
   [Driven]
   public bool Driven(out Vector2 currentValue)
   {
      float t;

      bool isRunning = m_Lerper.Run( out t );

      if ( isRunning )
      {
         m_LastValue = Vector2.Lerp( m_Start, m_End, t );
      }

      currentValue = m_LastValue;

      return isRunning;
   }

}
