// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Counts the amount of time that elapses between starting and stopping.

using UnityEngine;
using System.Collections;

[NodePath("Action/Misc")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Counts the amount of time that elapses between starting and stopping.")]
[NodeDescription("Counts the amount of time that elapses between starting and stopping.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Count Time")]
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