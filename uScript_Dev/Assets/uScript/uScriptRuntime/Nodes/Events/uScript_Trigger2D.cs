// uScript uScript_Triggers2D.cs
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Events")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a GameObject enters, exits, or stays in a 2D trigger.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[NodePropertiesPath("Properties/Triggers")]
[FriendlyName("Trigger Event (2D)", "Fires an event signal when a GameObject enters, exits, or stays in a 2D trigger. The Instance GameObject must have a 2D collider component on it set to be a trigger. Also, only other Gameobjects with a 2D rigidbody and 2D collider components will work with the trigger (the 'Triggerd By' GameObject).")]
public class uScript_Trigger2D : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, TriggerEventArgs args);

   public class TriggerEventArgs : System.EventArgs
   {
      [FriendlyName("Triggered By", "The GameObject that interacted with this GameObject's (the Instance) 2D collider component. ")]
      [SocketState(false, false)]
      public GameObject GameObject { get { return m_GameObject; } }
      private GameObject m_GameObject;

      public TriggerEventArgs(GameObject gameObject)
      {
         m_GameObject = gameObject;
      }
   }
   [FriendlyName("On Trigger Enter")]
   public event uScriptEventHandler OnEnterTrigger;
   [FriendlyName("On Trigger Exit")]
   public event uScriptEventHandler OnExitTrigger;
   [FriendlyName("While Inside Trigger")]
   public event uScriptEventHandler WhileInsideTrigger;
 
   void OnTriggerEnter2D(Collider2D other)
   {
      if ( OnEnterTrigger != null ) OnEnterTrigger( this, new TriggerEventArgs(other.gameObject) ); 
   }

   void OnTriggerExit2D(Collider2D other)
   {
      if ( OnExitTrigger != null ) OnExitTrigger( this, new TriggerEventArgs(other.gameObject) ); 
   }

   void OnTriggerStay2D(Collider2D other)
   {
      if ( WhileInsideTrigger != null ) WhileInsideTrigger( this, new TriggerEventArgs(other.gameObject) ); 
   }	
}

#endif
