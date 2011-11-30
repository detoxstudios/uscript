// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Gates")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Blocks signals until Closed Duration is finished.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Timed_Gate")]

[FriendlyName("Timed Gate", "Blocks signals until Closed Duration is finished, then will allow one signal through and resart Closed Duration. Closed Duration time can be updated at any time and will go into effect on next cycle.")]
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
      [FriendlyName("Closed Duration", "Amount of time (in seconds) to keep the gate closed for.")]
      [DefaultValue(1f)]
      float Duration
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

   public void Update()
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