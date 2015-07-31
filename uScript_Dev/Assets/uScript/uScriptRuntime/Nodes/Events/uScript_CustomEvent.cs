// uScript uScript_CustomEvent.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEvent")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a standard custom event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Custom Event", "Fires an event signal when Instance receives a standard custom event.")]
public class uScript_CustomEvent : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventBoolArgs args);

   public class CustomEventBoolArgs : System.EventArgs
   {
      private string m_EventName;
      private GameObject m_Sender;
      
      [FriendlyName("Sender", "The GameObject that sent this event (if available).")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name", "The name of the custom event.")]
      public string EventName { get { return m_EventName; } }

      public CustomEventBoolArgs(string eventName, GameObject sender)
      {
         m_Sender = sender;
         m_EventName = eventName;
      }
   }
 
   [FriendlyName("On Custom Event")]
   public event uScriptEventHandler OnCustomEvent;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEvent != null && cEventData.EventData == null ) OnCustomEvent( this, new CustomEventBoolArgs(cEventData.EventName, cEventData.Sender) ); 
   }	
}
