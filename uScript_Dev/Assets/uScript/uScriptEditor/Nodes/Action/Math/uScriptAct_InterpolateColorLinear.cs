// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Linearly interpolate a Color over time.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math/Interpolation")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Linearly interpolate a color over time.")]
[NodeDescription("Linearly interpolate a color over time.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Interpolate Color Linear")]
public class uScriptAct_InterpolateColorLinear : uScriptLogic
{ 
   private Color m_Start;
   private Color m_End;
   private Color m_LastValue;

   private uScript_Lerper m_Lerper = new uScript_Lerper( );

   public bool Started       { get { return m_Lerper.AllowStartedOutput; } }
   public bool Stopped       { get { return m_Lerper.AllowStoppedOutput; } }
   public bool Interpolating { get { return m_Lerper.AllowInterpolatingOutput; } }
   public bool Finished      { get { return m_Lerper.AllowFinishedOutput; } }
   
   public void Begin(
      [FriendlyName("Start Value")] Color startValue, 
      [FriendlyName("End Value")] Color endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] uScript_Lerper.LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Loop Count")]  int loopCount, 
      [FriendlyName("Output Value")] out Color currentValue
   )
   {
      m_Lerper.Set( time, loopType, loopDelay, loopCount );

      m_Start      = startValue;
      m_LastValue  = startValue;
      m_End        = endValue;

      currentValue = startValue;
   }

   [Driven]
   public bool Driven(out Color currentValue)
   {
      float t;

      bool isRunning = m_Lerper.Run( out t );

      if ( isRunning )
      {
         m_LastValue = Color.Lerp( m_Start, m_End, t );
      }

      currentValue = m_LastValue;

      return isRunning;
   }

   public void Stop(
      [FriendlyName("Start Value")] Color startValue, 
      [FriendlyName("End Value")] Color endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] uScript_Lerper.LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Loop Count")] int loopCount, 
      [FriendlyName("Output Value")] out Color currentValue
   )
   {
      m_Lerper.Stop( );

      currentValue = m_LastValue;
   }

   public void Resume(
      [FriendlyName("Start Value")] Color startValue, 
      [FriendlyName("End Value")] Color endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] uScript_Lerper.LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Loop Count")] int loopCount, 
      [FriendlyName("Output Value")] out Color currentValue
   )
   {
      m_Lerper.Resume( );

      currentValue = m_LastValue;
   }
}
