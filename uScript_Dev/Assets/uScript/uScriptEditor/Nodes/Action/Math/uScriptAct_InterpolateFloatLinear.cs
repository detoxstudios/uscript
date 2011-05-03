// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Linearly interpolate a float over time.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math/Interpolation")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Linearly interpolate a float over time.")]
[NodeDescription("Linearly interpolate a float over time.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Interpolate Float Linearly")]
public class uScriptAct_InterpolateFloatLinear : uScriptLogic
{
   public enum LoopType
   {
      None,
      Repeat,
      PingPong,
   }
   
   private float m_Start;
   private float m_End;
   private float m_TotalTime;
   private float m_CurrentTime;
   private float m_LastValue;
   private float m_LoopDelay;
   private int   m_LoopCount;
   private int   m_LoopIteration;
   private float m_LoopRestartCountdown;
   private bool  m_IsReversed;
   private bool  m_Running;

   private LoopType m_LoopType;   

   private bool  m_AllowStoppedOutput;
   private bool  m_AllowStartedOutput;
   private bool  m_AllowInterpolatingOutput;
   private bool  m_AllowFinishedOutput;

   public bool Started       { get { return m_AllowStartedOutput; } }
   public bool Stopped       { get { return m_AllowStoppedOutput; } }
   public bool Interpolating { get { return m_AllowInterpolatingOutput; } }
   public bool Finished      { get { return m_AllowFinishedOutput; } }
   
   public void Begin(
      [FriendlyName("Start Value")] float startValue, 
      [FriendlyName("End Value")] float endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Times to Loop")] int loopCount, 
      [FriendlyName("Output Value")] out float currentValue)
   {
      m_CurrentTime   = 0;
      m_Start         = startValue;
      m_End           = endValue;
      m_TotalTime     = time;
      m_LoopIteration = 0;
      m_LoopDelay     = loopDelay;
      m_LoopRestartCountdown = 0;
      m_Running = true;

      m_LastValue  = startValue;
      currentValue = startValue;

      m_AllowInterpolatingOutput = false;
      m_AllowStoppedOutput       = false;
      m_AllowFinishedOutput      = false;
      m_AllowStartedOutput       = true;
   
      m_IsReversed = false;
      m_LoopType   = loopType;
      m_LoopCount  = loopCount;
   }

   [Driven]
   public bool Driven(out float currentValue)
   {
      m_AllowInterpolatingOutput = false;
      m_AllowStoppedOutput       = false;
      m_AllowFinishedOutput      = false;
      m_AllowStartedOutput       = false;

      //if we're counting down till we can run again
      //check and see if we've hit 0 so we can process this interpolation
      if ( m_LoopRestartCountdown > 0 )
      {
         m_LoopRestartCountdown -= Time.deltaTime;

         if ( m_LoopRestartCountdown <= 0 ) 
         {
            m_Running = true;
            m_LoopRestartCountdown = 0;

            ++m_LoopIteration;
         }
      }

      //either we're still running or the loop restart countdown hit 0
      //and we've been restarted
      if ( true == m_Running )
      {
         m_LastValue = Mathf.Lerp( m_Start, m_End, m_CurrentTime / m_TotalTime );
         
         //we'll hit it exactly because we clamp it on the previous tick's update
         if ( false == m_IsReversed && m_CurrentTime == m_TotalTime ) 
         {
            m_Running = false;
         }
         else if ( true == m_IsReversed && m_CurrentTime == 0 )
         {
            m_Running = false;
         }

         //done running? see if we should loop and restart
         if ( false == m_Running && m_LoopIteration < m_LoopCount )
         {
            m_LoopRestartCountdown = m_LoopDelay;

            //pingpong - reverse direction and restart
            if ( LoopType.PingPong == m_LoopType ) 
            {
               m_IsReversed = ! m_IsReversed;
               if ( 0 == m_LoopRestartCountdown ) m_Running = true;
            }
            //repeate = reset time and restart
            else if ( LoopType.Repeat == m_LoopType )
            {
               m_CurrentTime = (m_IsReversed == false) ? 0 : m_TotalTime;
               if ( 0 == m_LoopRestartCountdown ) m_Running = true;
            }
         }         
         
         //still running or we were restarted
         if ( true == m_Running )
         {
            m_AllowInterpolatingOutput = true;
   
            //clamp time at end but let it come through one more time
            //so we can hit the precise end value
            m_CurrentTime = (m_IsReversed == false) ? m_CurrentTime + Time.deltaTime : m_CurrentTime - Time.deltaTime;            
            m_CurrentTime = Mathf.Clamp( m_CurrentTime, 0, m_TotalTime );
         }
         else
         {
            if ( m_LoopRestartCountdown == 0 )
            {
               //no looping so consider us done and output the finished flag
               m_AllowFinishedOutput = true;            
            }
         }

         currentValue = m_LastValue;         
         return true;
      }
      else
      {
         currentValue = m_LastValue;
         return false;      
      }
   }

   public void Stop(
      [FriendlyName("Start Value")] float startValue, 
      [FriendlyName("End Value")] float endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Times to Loop")] int loopCount, 
      [FriendlyName("Output Value")] out float currentValue
   )
   {
      m_Running = false;

      m_AllowInterpolatingOutput = false;
      m_AllowStoppedOutput       = true;
      m_AllowFinishedOutput      = false;
      m_AllowStartedOutput       = false;
         
      currentValue = m_LastValue;
   }

   public void Resume(
      [FriendlyName("Start Value")] float startValue, 
      [FriendlyName("End Value")] float endValue, 
      [FriendlyName("Time")] float time, 
      [FriendlyName("Loop Type")] LoopType loopType, 
      [FriendlyName("Loop Delay")] float loopDelay, 
      [FriendlyName("Times to Loop")] int loopCount, 
      [FriendlyName("Output Value")] out float currentValue
   )
   {
      m_AllowStoppedOutput       = false;
      m_AllowStartedOutput       = false;
      m_AllowFinishedOutput      = false;
      m_AllowInterpolatingOutput = false;

      if ( m_CurrentTime < m_TotalTime )
      {
         m_Running = true;
         m_AllowStartedOutput = true;
      }
      else
      {
         m_AllowStoppedOutput = true;
      }

      currentValue = m_LastValue;
   }
}
