// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Counts the amount of time that elapses between starting and stopping.

using UnityEngine;
using System.Collections;

public class uScriptAct_CountTime : uScriptLogic
{
   private bool m_TimerStarted = false;
   private float m_TotalTime = 0F;

   public event uScriptEventHandler Out;

   public void Start()
   {
      m_TimerStarted = true;
      uScript_EventHandler.DoEvent(this, Out, new object[] { });
   }

   public void Stop(out float Seconds)
   {
      m_TimerStarted = false;
      Seconds = m_TotalTime;
      m_TotalTime = 0F;
   }

   public override void _InternalUpdate()
   {
      if (m_TimerStarted)
      {
         m_TotalTime = UnityEngine.Time.time;
      }
   }
}