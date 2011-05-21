// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Linearly interpolate a Quaternion over time.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math/Interpolation")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Linearly interpolate a Quaternion over time.")]
[NodeDescription("Linearly interpolate a Quaternion over time.\n \nStart Value: Starting value to interpolate from.\nEnd Value: Ending value to interpolate to.\nTime: Time to take to complete the interpolation (in seconds).\nLoop Type: The type of looping to use (available values are None, Repeat, and PingPong).\nLoop Delay: Time delay (in seconds) between loops.\nLoop Count: Number of times to loop. For infinite looping, use -1 or connect the out socket of this node to its own in and use any positive value.\nOutput Value (out): Current interpolated value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Interpolate Quaternion Linear")]
public class uScriptAct_InterpolateQuaternionLinear : uScriptLogic
{ 
   private Vector4 m_Start;
   private Vector4 m_End;

   private Quaternion m_LastValue;

   private uScript_Lerper m_Lerper = new uScript_Lerper( );

   public bool Started       { get { return m_Lerper.AllowStartedOutput; } }
   public bool Stopped       { get { return m_Lerper.AllowStoppedOutput; } }
   public bool Interpolating { get { return m_Lerper.AllowInterpolatingOutput; } }
   public bool Finished      { get { return m_Lerper.AllowFinishedOutput; } }
   
   public void Begin(
      [FriendlyName("Start Value")] Quaternion startValue, 
      [FriendlyName("End Value")] Quaternion endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] uScript_Lerper.LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Loop Count")] int loopCount, 
      [FriendlyName("Output Value")] out Quaternion currentValue
   )
   {
      m_Lerper.Set( time, loopType, loopDelay, loopCount );

      m_Start      = new Vector4(startValue.x, startValue.y, startValue.z, startValue.w);
      m_End        = new Vector4(endValue.x, endValue.y, endValue.z, endValue.w);

      m_LastValue  = startValue;
      currentValue = startValue;
   }

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

   public void Stop(
      [FriendlyName("Start Value")] Quaternion startValue, 
      [FriendlyName("End Value")] Quaternion endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] uScript_Lerper.LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Loop Count")] int loopCount, 
      [FriendlyName("Output Value")] out Quaternion currentValue
   )
   {
      m_Lerper.Stop( );

      currentValue = m_LastValue;
   }

   public void Resume(
      [FriendlyName("Start Value")] Quaternion startValue, 
      [FriendlyName("End Value")] Quaternion endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] uScript_Lerper.LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Loop Count")] int loopCount, 
      [FriendlyName("Output Value")] out Quaternion currentValue
   )
   {
      m_Lerper.Resume( );

      currentValue = m_LastValue;
   }
}
