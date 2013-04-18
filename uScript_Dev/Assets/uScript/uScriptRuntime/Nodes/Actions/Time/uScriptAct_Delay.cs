// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Delays execution of a script.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Delay")]

[FriendlyName("Delay", "Delays execution of a script but can also fire off an immediate response.\n\nNOTE: each time a signal is recieved on the In socket, the delay node will reset its countdown (start over). This can cause the Delayed Out socket to never fire if it is recieving signals on the In socket faster than the Duration specified.\n\nIf you are looking for a time-based filter for something that sends out a signal each tick (like On Update), you should use the Timed Gate node instead.")]
public class uScriptAct_Delay : uScriptLogic
{
   private float m_TimeToTrigger;
   private bool  m_DelayedOut;
   private bool  m_ImmediateOut;
   private bool  m_SingleFrame = false;

   [FriendlyName("Immediate")]
   public bool Immediate { get { return m_ImmediateOut; } }
  
   [FriendlyName("After Delay")]
   public bool AfterDelay { get { return m_DelayedOut; } }
   
   [FriendlyName("In")]
   public void In(
      [FriendlyName("Duration", "Amount of time (in seconds) to delay.")]
      float Duration,

      [FriendlyName("Single Frame", "Set to true to delay a single frame (overrides Duration if set).")]
      [DefaultValue(false)]
      bool SingleFrame
      )
   {
      m_ImmediateOut = true;
      m_DelayedOut = false;
      m_SingleFrame = SingleFrame;
      m_TimeToTrigger = Duration;
      if ( m_SingleFrame ) m_TimeToTrigger = 1.0f;
   }

   [Driven]
   public bool DrivenDelay( )
   {
      m_ImmediateOut = false;
      m_DelayedOut = false;
  
      if ( m_SingleFrame )
      {
         if ( m_TimeToTrigger > 0.0f ) 
         {
            m_TimeToTrigger = -1.0f;
         }
         else
         {
            m_DelayedOut = true;
            m_SingleFrame = false;
         }
         
         return true;
      }
      else if ( m_TimeToTrigger > 0 )
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


