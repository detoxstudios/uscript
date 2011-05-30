// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Blocks signals until Closed Duration is finished, then will allow one signal through and resart Closed Duration. Closed Duration time can be updated at any time and will go into effect on next cycle.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Gates")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Blocks signals until Closed Duration is finished.")]
[NodeDescription("Blocks signals until Closed Duration is finished, then will allow one signal through and resart Closed Duration. Closed Duration time can be updated at any time and will go into effect on next cycle.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Timed Gate")]
public class uScriptCon_TimedGate : uScriptLogic
{
   private bool m_gateOpen = true;
   private float m_TimeToTrigger;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   public event uScriptEventHandler Out;

   public void In(
      [FriendlyName("Closed Duration"), DefaultValue(0f)] float Duration
   )
   {

      if (m_gateOpen)
      {
         if ( Out != null ) Out(this, new System.EventArgs( ));
         m_gateOpen = false;
         m_TimeToTrigger = Duration;
      }
   }


   public override void Update()
   {
      if (m_TimeToTrigger > 0)
      {
         m_TimeToTrigger -= UnityEngine.Time.deltaTime;

         if (m_TimeToTrigger <= 0)
         {
            m_gateOpen = true;
         }
      }
   }
}