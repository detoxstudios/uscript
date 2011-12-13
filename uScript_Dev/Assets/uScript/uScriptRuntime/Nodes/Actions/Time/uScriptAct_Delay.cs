// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Delays execution of a script.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Delay")]

[FriendlyName("Delay", "Delays execution of a script but can also fire off an immediate response.")]
public class uScriptAct_Delay : uScriptLogic
{
   private float m_TimeToTrigger;
   private bool  m_DelayedOut;
   private bool  m_ImmediateOut;

   [FriendlyName("Immediate Out")]
   public bool Immediate { get { return m_ImmediateOut; } }
  
   [FriendlyName("Delayed Out")]
   public bool AfterDelay { get { return m_DelayedOut; } }
   
   [FriendlyName("In")]
   public void In(
      [FriendlyName("Duration", "Amount of time (in seconds) to delay.")]
      float Duration
      )
   {
      m_ImmediateOut = true;
      m_DelayedOut = false;
      m_TimeToTrigger = Duration;
   }

   public void OnDestroy( ) {}

   [Driven]
   public bool DrivenDelay( )
   {
      m_ImmediateOut = false;
      m_DelayedOut = false;

      if ( m_TimeToTrigger > 0 )
      {
         m_TimeToTrigger -= UnityEngine.Time.deltaTime;
      
         if ( m_TimeToTrigger <= 0 )
         {
            m_DelayedOut = true;
         }

         return true;
      }

      return false;
   }
}


