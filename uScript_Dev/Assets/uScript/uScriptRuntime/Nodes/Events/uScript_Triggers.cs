// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a GameObject enters, exits, or stays in a trigger.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Trigger_Events")]

[NodePropertiesPath("Properties/Triggers")]
[FriendlyName("Trigger Events", "Fires an event signal when a GameObject enters, exits, or stays in a trigger. The Instance GameObject must have a collider component on it set to be a trigger. Also, only other Gameobjects with a rigidbody component will trigger this event (the instigators).")]
public class uScript_Triggers : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, TriggerEventArgs args);

   public class TriggerEventArgs : System.EventArgs
   {
      [FriendlyName("Instigator", "The GameObject that interacted with this GameObject's (the Instance) collider component. ")]
      [SocketState(false, false)]
      public GameObject GameObject { get { return m_GameObject; } }
      private GameObject m_GameObject;

      public TriggerEventArgs(GameObject gameObject)
      {
         m_GameObject = gameObject;
      }
   }

   public event uScriptEventHandler OnEnterTrigger;
   public event uScriptEventHandler OnExitTrigger;
   public event uScriptEventHandler WhileInsideTrigger;
 
   private bool m_AlwaysTrigger = false;
   
   private int m_TimesToTrigger;
   [FriendlyName("Times to Trigger", "How many times this trigger should fire before it deactivates.")]
   public int TimesToTrigger 
   { 
      set 
      { 
         m_TimesToTrigger = value;
         if ( 0 == m_TimesToTrigger ) m_AlwaysTrigger = true;
      } 
   }

   void OnTriggerEnter(Collider other)
   {
      if ( 0 == m_TimesToTrigger && false == m_AlwaysTrigger ) return;
      --m_TimesToTrigger;

      if ( OnEnterTrigger != null ) OnEnterTrigger( this, new TriggerEventArgs(other.gameObject) ); 
   }

   void OnTriggerExit(Collider other)
   {
      if ( 0 == m_TimesToTrigger && false == m_AlwaysTrigger ) return;
      --m_TimesToTrigger;

      if ( OnExitTrigger != null ) OnExitTrigger( this, new TriggerEventArgs(other.gameObject) ); 
   }

   void OnTriggerStay(Collider other)
   {
      if ( 0 == m_TimesToTrigger && false == m_AlwaysTrigger ) return;
      --m_TimesToTrigger;

      if ( WhileInsideTrigger != null ) WhileInsideTrigger( this, new TriggerEventArgs(other.gameObject) ); 
   }
	
}
