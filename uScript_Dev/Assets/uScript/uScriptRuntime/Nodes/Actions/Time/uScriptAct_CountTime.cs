// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Counts the amount of time that elapses between starting and stopping.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Counts the amount of time that elapses between starting and stopping.")]
[NodeDescription("Counts the amount of time that elapses between starting and stopping.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Count_Time")]

[FriendlyName("Count Time")]
public class uScriptAct_CountTime : uScriptLogic
{
   private bool m_TimerStarted = false;
   private float m_TotalTime = 0F;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   public event uScriptEventHandler Out;

   public void In()
   {
      m_TimerStarted = true;
      if ( Out != null ) Out(this, new System.EventArgs());
   }

   public void Stop(out float Seconds)
   {
      m_TimerStarted = false;
      Seconds = m_TotalTime;
      m_TotalTime = 0F;
   }

   public override void Update()
   {
      if (m_TimerStarted)
      {
         m_TotalTime = UnityEngine.Time.time;
      }
   }
}