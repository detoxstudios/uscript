// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Counts the amount of time that elapses between starting and stopping.")]
/* M */[NodeDescription("Counts the amount of time that elapses between starting and stopping.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Count_Time")]

[FriendlyName("Count Time")]
public class uScriptAct_CountTime : uScriptLogic
{
   private bool m_TimerStarted = false;
   private float m_TotalTime = 0F;

   public bool Out { get { return true; } }

   public void In(out float seconds)
   {
      seconds = 0;
      m_TimerStarted = true;
   }

   public void Stop(out float Seconds)
   {
      m_TimerStarted = false;
      Seconds = m_TotalTime;
      m_TotalTime = 0F;
   }

   public void Update()
   {
      if (m_TimerStarted)
      {
         m_TotalTime = UnityEngine.Time.time;
      }
   }
}