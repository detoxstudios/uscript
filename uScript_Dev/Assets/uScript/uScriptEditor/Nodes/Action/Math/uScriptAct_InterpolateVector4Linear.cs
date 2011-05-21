// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Linearly interpolate a Vector4 over time.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math/Interpolation")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Linearly interpolate a Vector4 over time.")]
[NodeDescription("Linearly interpolate a Vector4 over time.\n \nStart Value: Starting value to interpolate from.\nEnd Value: Ending value to interpolate to.\nTime: Time to take to complete the interpolation (in seconds).\nLoop Type: The type of looping to use (available values are None, Repeat, and PingPong).\nLoop Delay: Time delay (in seconds) between loops.\nLoop Count: Number of times to loop. For infinite looping, use -1 or connect the out socket of this node to its own in and use any positive value.\nOutput Value (out): Current interpolated value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Interpolate Vector4 Linear")]
public class uScriptAct_InterpolateVector4Linear : uScriptLogic
{ 
   private Vector4 m_Start;
   private Vector4 m_End;
   private Vector4 m_LastValue;

   private uScript_Lerper m_Lerper = new uScript_Lerper( );

   public bool Started       { get { return m_Lerper.AllowStartedOutput; } }
   public bool Stopped       { get { return m_Lerper.AllowStoppedOutput; } }
   public bool Interpolating { get { return m_Lerper.AllowInterpolatingOutput; } }
   public bool Finished      { get { return m_Lerper.AllowFinishedOutput; } }
   
   public void Begin(
      [FriendlyName("Start Value")] Vector4 startValue, 
      [FriendlyName("End Value")] Vector4 endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] uScript_Lerper.LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Loop Count")] int loopCount, 
      [FriendlyName("Output Value")] out Vector4 currentValue
   )
   {
      m_Lerper.Set( time, loopType, loopDelay, loopCount );

      m_Start      = startValue;
      m_LastValue  = startValue;
      m_End        = endValue;

      currentValue = startValue;
   }

   [Driven]
   public bool Driven(out Vector4 currentValue)
   {
      float t;

      bool isRunning = m_Lerper.Run( out t );

      if ( isRunning )
      {
         m_LastValue = Vector4.Lerp( m_Start, m_End, t );
      }

      currentValue = m_LastValue;

      return isRunning;
   }

   public void Stop(
      [FriendlyName("Start Value")] Vector4 startValue, 
      [FriendlyName("End Value")] Vector4 endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] uScript_Lerper.LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Loop Count")] int loopCount, 
      [FriendlyName("Output Value")] out Vector4 currentValue
   )
   {
      m_Lerper.Stop( );

      currentValue = m_LastValue;
   }

   public void Resume(
      [FriendlyName("Start Value")] Vector4 startValue, 
      [FriendlyName("End Value")] Vector4 endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] uScript_Lerper.LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Loop Count")] int loopCount, 
      [FriendlyName("Output Value")] out Vector4 currentValue
   )
   {
      m_Lerper.Resume( );

      currentValue = m_LastValue;
   }
}
