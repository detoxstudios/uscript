// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Delays the AfterDelay output signal by x seconds.

using UnityEngine;
using System.Collections;

[NodePath("Action/Time")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Delays execution of a script.")]
[NodeDescription("Delays execution of a script but can also fire off an immediate response.\n \nDuration: Amount of time (in seconds) to delay.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_delay.html")]

[FriendlyName("Delay")]
public class uScriptAct_Delay : uScriptLogic
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   private float m_TimeToTrigger;

   [FriendlyName("Immediate Out")]
   public bool Immediate { get { return true; } }
  
   [FriendlyName("Delayed Out")]
   public event uScriptEventHandler AfterDelay;

   [FriendlyName("In")]
   public void In(
      [FriendlyName("Duration")] float Duration
   )
   {
      m_TimeToTrigger = Duration;
   }

   public void OnDestroy( ) {}

   public override void Update( )
   {
      if ( m_TimeToTrigger > 0 )
      {
         m_TimeToTrigger -= UnityEngine.Time.deltaTime;
      
         if ( m_TimeToTrigger <= 0 )
         {
            if ( AfterDelay != null ) AfterDelay( this, new System.EventArgs());
         }
      }
   }
}


