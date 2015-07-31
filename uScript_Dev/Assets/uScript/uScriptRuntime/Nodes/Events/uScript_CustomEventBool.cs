// uScript uScript_CustomEventBool.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventBool")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a bool.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Custom Event (Bool)", "Fires an event signal when Instance receives a custom event with a bool.")]
public class uScript_CustomEventBool : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventBoolArgs args);

   public class CustomEventBoolArgs : System.EventArgs
   {
      private string m_EventName;
      private bool m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender", "The GameObject that sent this event (if available).")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name", "The name of the custom event.")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data", "The variable that was sent with this event.")]
      public bool EventData { get { return m_EventData; } }

      public CustomEventBoolArgs(string eventName, bool eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }
 
   [FriendlyName("On Custom Event Bool")]
   public event uScriptEventHandler OnCustomEventBool;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventBool != null && cEventData.EventData != null
#if !UNITY_FLASH
        && cEventData.EventData.GetType() == typeof(System.Boolean)
#endif
         ) OnCustomEventBool( this, new CustomEventBoolArgs(cEventData.EventName, (bool)cEventData.EventData, cEventData.Sender) ); 
   }	
}
