// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Blocks signals until Closed Duration is finished, then will allow one signal through and resart Closed Duration. Closed Duration time can be updated at any time and will go into effect on next cycle.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Gates")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Blocks signals until Closed Duration is finished.")]
[NodeDescription("Blocks signals until Closed Duration is finished, then will allow one signal through and resart Closed Duration. Closed Duration time can be updated at any time and will go into effect on next cycle.\n \nClosed Duration: Amount of time (in seconds) to keep the gate closed for.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Timed Gate")]
public class uScriptCon_TimedGate : uScriptLogic
{
   private bool m_GateOpen = true;
   private bool m_TooSoon = false;

   private float m_TimeToTrigger;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   [FriendlyName("Gate Open")]
   public event uScriptEventHandler Out;

   [FriendlyName("Gate Closed")]
   public bool TooSoon { get { return m_TooSoon; } }

   public void In(
      [FriendlyName("Closed Duration"), DefaultValue(1f)] float Duration
   )
   {
      m_TooSoon = false;

      if (m_GateOpen)
      {
         if (Out != null) Out(this, new System.EventArgs());
         m_GateOpen = false;
         m_TimeToTrigger = Duration;
      }
      else
      {
         m_TooSoon = true;
      }
   }

   public override void Update()
   {
      if (m_TimeToTrigger > 0)
      {
         m_TimeToTrigger -= UnityEngine.Time.deltaTime;

         if (m_TimeToTrigger <= 0)
         {
            m_GateOpen = true;
         }
      }
   }
}