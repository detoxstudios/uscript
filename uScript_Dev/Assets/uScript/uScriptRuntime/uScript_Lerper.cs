// uScript utility class
// (C) 2011 Detox Studios LLC
// Desc: Linearly interpolate a float from 0 to 1 over time.

using UnityEngine;
using System.Collections;

public class uScript_Lerper
{
   public enum LoopType
   {
      None,
      Repeat,
      PingPong,
   }
   
   private float m_TotalTime;
   private float m_CurrentTime;
   private float m_LoopDelay;
   private int   m_LoopCount;
   private int   m_LoopIteration;
   private float m_LoopRestartCountdown;
   private bool  m_IsReversed;
   private bool  m_Running;
   private bool  m_Smooth;

   private LoopType m_LoopType;   

   public bool  AllowStoppedOutput;
   public bool  AllowStartedOutput;
   public bool  AllowInterpolatingOutput;
   public bool  AllowFinishedOutput;
   
   public void Set( float time, LoopType loopType, float loopDelay, bool smooth, int loopCount )
   {
      m_CurrentTime   = 0;
      m_TotalTime     = time;
      m_LoopIteration = 0;
      m_LoopDelay     = loopDelay;
      m_LoopRestartCountdown = 0;
      m_Smooth = smooth;
      m_Running = true;

      AllowInterpolatingOutput = false;
      AllowStoppedOutput       = false;
      AllowFinishedOutput      = false;
      AllowStartedOutput       = true;
   
      m_IsReversed = false;
      m_LoopType   = loopType;
      m_LoopCount  = loopCount;

      //if LoopType is None, play once by default
      if (m_LoopType == LoopType.None)
      {
         m_LoopCount = 1;
      }
  
      //if loop count is 0 don't run at all
      if ( m_LoopIteration == m_LoopCount )
      {
         m_Running = false;
      }
      else
      {
         //otherwise start our first loop
         ++m_LoopIteration;
      }
   }

   public bool Run( out float currentTime )
   {
      AllowInterpolatingOutput = false;
      AllowStoppedOutput       = false;
      AllowFinishedOutput      = false;
      AllowStartedOutput       = false;

      //if we're counting down till we can run again
      //check and see if we've hit 0 so we can process this interpolation
      if ( m_LoopRestartCountdown > 0 )
      {
         m_LoopRestartCountdown -= Time.deltaTime;

         if ( m_LoopRestartCountdown <= 0 ) 
         {
            m_Running = true;
            m_LoopRestartCountdown = 0;
         }
      }

      //output the value before the modifications
      //to time..this way we can fully output each value and then
      //prepare the time for our next tick whether we start
      //pingpong, loop, etc... 
      currentTime = 1.0f;
      if (m_TotalTime != 0.0f)
      {
         currentTime = m_CurrentTime / m_TotalTime;
         if ( true == m_Smooth )
             currentTime = Mathf.SmoothStep(0, 1, currentTime);
      }

      //either we're still running or the loop restart countdown hit 0
      //and we've been restarted
      if ( true == m_Running )
      {
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
         if ( false == m_Running && ( m_LoopIteration < m_LoopCount || m_LoopCount == -1) )
         {
            m_LoopRestartCountdown = m_LoopDelay;

            //pingpong - reverse direction and restart
            if ( LoopType.PingPong == m_LoopType ) 
            {
               m_LoopIteration++;
               m_IsReversed = ! m_IsReversed;
               if ( 0 == m_LoopRestartCountdown ) m_Running = true;
            }
            //repeate = reset time and restart
            else if ( LoopType.Repeat == m_LoopType )
            {
               m_LoopIteration++;
               m_CurrentTime = (m_IsReversed == false) ? 0 : m_TotalTime;
               if ( 0 == m_LoopRestartCountdown ) m_Running = true;
            }
         }
         
         //still running or we were restarted
         if ( true == m_Running )
         {
            AllowInterpolatingOutput = true;
   
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
               AllowFinishedOutput = true;            
            }
         }

         return true;
      }
      else
      {
         //true if we're waiting for another loop restart
         //or false if we are not running and there is no loop restart
         return m_LoopRestartCountdown > 0;
      }
   }

   public void Stop( )
   {
      m_Running = false;

      AllowInterpolatingOutput = false;
      AllowStoppedOutput       = true;
      AllowFinishedOutput      = false;
      AllowStartedOutput       = false;
   }

   public void Resume( )
   {
      AllowStoppedOutput       = false;
      AllowStartedOutput       = false;
      AllowFinishedOutput      = false;
      AllowInterpolatingOutput = false;

      if ( m_CurrentTime < m_TotalTime )
      {
         m_Running = true;
         AllowStartedOutput = true;
      }
      else
      {
         AllowStoppedOutput = true;
      }
   }
}
