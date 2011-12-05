// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Interpolation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Linearly interpolate a Quaternion over time.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Interpolate_Quaternion_Linear")]

[FriendlyName("Interpolate Quaternion Linear", "Linearly interpolate a Quaternion over time.")]
public class uScriptAct_InterpolateQuaternionLinear : uScriptLogic
{ 
   private Vector4 m_Start;
   private Vector4 m_End;
   private Quaternion m_LastValue;
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
   public void Begin(Quaternion startValue, Quaternion endValue, float time, uScript_Lerper.LoopType loopType, float loopDelay, int loopCount, out Quaternion currentValue)
   {
      m_Lerper.Set( time, loopType, loopDelay, loopCount );

      m_Start      = new Vector4(startValue.x, startValue.y, startValue.z, startValue.w);
      m_End        = new Vector4(endValue.x, endValue.y, endValue.z, endValue.w);
      m_LastValue  = startValue;
  
      m_Began      = true;

      currentValue = startValue;
   }

   // Parameter Attributes are applied below in Resume()
   public void Stop(Quaternion startValue, Quaternion endValue, float time, uScript_Lerper.LoopType loopType, float loopDelay, int loopCount, out Quaternion currentValue)
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
      Quaternion startValue,

      [FriendlyName("End Value", "Ending value to interpolate to.")]
      Quaternion endValue,

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
      out Quaternion currentValue
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
   //    Miscellaneous Node Funtionality
   // ================================================================================
   //
   [Driven]
   public bool Driven(out Quaternion currentValue)
   {
      float t;
      bool isRunning = m_Lerper.Run( out t );

      if ( isRunning )
      {
         //Quaternion.Lerp throws an exception
         //so i'm using v4 lerp for now
         Vector4 v = Vector4.Lerp( m_Start, m_End, t );
         
         m_LastValue.x = v.x;
         m_LastValue.y = v.y;
         m_LastValue.z = v.z;
         m_LastValue.w = v.w;
      }

      currentValue = m_LastValue;

      return isRunning;
   }

}
