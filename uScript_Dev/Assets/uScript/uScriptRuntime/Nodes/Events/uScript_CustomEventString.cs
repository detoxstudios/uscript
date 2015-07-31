// uScript uScript_CustomEventString.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventString")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Custom Event (String)", "Fires an event signal when Instance receives a custom event with a string.")]
public class uScript_CustomEventString : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventStringArgs args);

   public class CustomEventStringArgs : System.EventArgs
   {
      private string m_EventName;
      private string m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender", "The GameObject that sent this event (if available).")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name", "The name of the custom event.")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data", "The variable that was sent with this event.")]
      public string EventData { get { return m_EventData; } }

      public CustomEventStringArgs(string eventName, string eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event String")]
   public event uScriptEventHandler OnCustomEventString;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventString != null && cEventData.EventData != null
#if !UNITY_FLASH
        && cEventData.EventData.GetType() == typeof(System.String)
#endif
         ) OnCustomEventString( this, new CustomEventStringArgs(cEventData.EventName, (string)cEventData.EventData, cEventData.Sender) ); 
   }	
}
