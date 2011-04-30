// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Tells a GameObject to look at another GameObject transform or Vector3 position.

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
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   private float m_Start;
   private float m_End;
   private float m_TotalTime;
   private float m_CurrentTime;
   private float m_LastValue;
   private bool  m_Running;
   
   private bool  m_AllowStoppedOutput;
   private bool  m_AllowStartedOutput;
   private bool  m_AllowInterpolatingOutput;
   private bool  m_AllowFinishedOutput;

   public bool Started       { get { return m_AllowStartedOutput; } }
   public bool Stopped       { get { return m_AllowStoppedOutput; } }
   public bool Interpolating { get { return m_AllowInterpolatingOutput; } }
   public bool Finished      { get { return m_AllowFinishedOutput; } }
   
   public void Begin(float startValue, float endValue, float time, out float currentValue)
   {
      m_CurrentTime = 0;
      m_Start       = startValue;
      m_End         = endValue;
      m_TotalTime   = time;

      m_Running = true;

      m_LastValue  = startValue;
      currentValue = startValue;

      m_AllowInterpolatingOutput = false;
      m_AllowStoppedOutput       = false;
      m_AllowFinishedOutput      = false;
      m_AllowStartedOutput       = true;
   }

   [Driven]
   public bool Driven(float startValue, float endValue, float time, out float currentValue)
   {
      m_AllowInterpolatingOutput = false;
      m_AllowStoppedOutput       = false;
      m_AllowFinishedOutput      = false;
      m_AllowStartedOutput       = false;

      if ( true == m_Running )
      {
         m_LastValue = Mathf.Lerp( m_Start, m_End, m_CurrentTime / m_TotalTime );
         
         //we'll hit it exactly because we clamp it on the previous tick's update
         if ( m_CurrentTime == m_TotalTime ) 
         {
            m_Running = false;
            m_AllowFinishedOutput = true;
         }
         else
         {
            m_AllowInterpolatingOutput = true;
   
            //clamp time at end but let it come through one more time
            //so we can hit the precise end value
            m_CurrentTime += Time.deltaTime;
            if ( m_CurrentTime > m_TotalTime ) m_CurrentTime = m_TotalTime;
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

   public void Stop(float startValue, float endValue, float time, out float currentValue)
   {
      m_Running = false;

      m_AllowInterpolatingOutput = false;
      m_AllowStoppedOutput       = true;
      m_AllowFinishedOutput      = false;
      m_AllowStartedOutput       = false;
         
      currentValue = m_LastValue;
   }

   public void Resume(float startValue, float endValue, float time, out float currentValue)
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
