// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Interpolation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Linearly interpolate a Rect over time.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Interpolate Rect Linear", "Linearly interpolate a Rect over time.")]
[NodeDeprecated(typeof(uScriptAct_InterpolateRectLinearSmooth))]
public class uScriptAct_InterpolateRectLinear : uScriptLogic
{ 
   private Rect m_Start;
   private Rect m_End;
   private Rect m_LastValue;
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
   public void Begin(Rect startValue, Rect endValue, float time, uScript_Lerper.LoopType loopType, float loopDelay, int loopCount, out Rect currentValue)
   {
      m_Lerper.Set( time, loopType, loopDelay, false, loopCount );

      m_Start      = startValue;
      m_LastValue  = startValue;
      m_End        = endValue;

      m_Began      = true;

      currentValue = startValue;
   }

   // Parameter Attributes are applied below in Resume()
   public void Stop(Rect startValue, Rect endValue, float time, uScript_Lerper.LoopType loopType, float loopDelay, int loopCount, out Rect currentValue)
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
      Rect startValue,

      [FriendlyName("End Value", "Ending value to interpolate to.")]
      Rect endValue,

      [FriendlyName("Time", "Time to take to complete the interpolation (in seconds).")]
      float time,

      [FriendlyName("Loop Type", "The type of looping to use (available values are None, Repeat, and PingPong).")]
      [SocketState(false, false)]
      uScript_Lerper.LoopType loopType,

      [FriendlyName("Loop Delay", "Time delay (in seconds) between loops.")]
      [SocketState(false, false)]
      float loopDelay,

      [FriendlyName("Loop Count", "Number of times to loop. For infinite looping, use -1 or connect the out socket of this node to its own in and use any positive value.")]
      [DefaultValue(-1), SocketState(false, false)]
      int loopCount,

      [FriendlyName("Output Value", "Current interpolated value.")]
      out Rect currentValue
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
   public bool Driven(out Rect currentValue)
   {
      float t;

      bool isRunning = m_Lerper.Run( out t );

      if ( isRunning )
      {
         float x = Mathf.Lerp(m_Start.x, m_End.x, t);
         float y = Mathf.Lerp(m_Start.y, m_End.y, t);
         float w = Mathf.Lerp(m_Start.width, m_End.width, t);
         float h = Mathf.Lerp(m_Start.height, m_End.height, t);
         m_LastValue = new Rect(x, y, w, h);
      }

      currentValue = m_LastValue;

      return isRunning;
   }

}
