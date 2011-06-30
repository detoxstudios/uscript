// uScript uScript_CustomEventString.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when Instance receives a custom event with a string.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventString")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a string.")]
[NodeDescription("Fires an event signal when Instance receives a custom event with a string.\n \nSender: The GameObject that sent this event (if available).\nEvent Name: The name of the custom event.\nEvent Data: The variable that was sent with this event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Custom_Event_.28String.29")]

[FriendlyName("Custom Event (String)")]
public class uScript_CustomEventString : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventStringArgs args);

   public class CustomEventStringArgs : System.EventArgs
   {
      private string m_EventName;
      private string m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
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
      if ( OnCustomEventString != null && cEventData.EventData.GetType() == typeof(System.String) ) OnCustomEventString( this, new CustomEventStringArgs(cEventData.EventName, (string)cEventData.EventData, cEventData.Sender) ); 
   }	
}
