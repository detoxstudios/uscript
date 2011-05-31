// uScript uScript_CustomEventColor.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when Instance receives a custom event with a Color.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/CustomEvents/CustomEventColor")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventColor")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a Color.")]
[NodeDescription("Fires an event signal when Instance receives a custom event with a Color.\n \nSender: The GameObject that sent this event (if available).\nEvent Name: The name of the custom event.\nEvent Data: The variable that was sent with this event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Custom Event (Color)")]
public class uScript_CustomEventColor : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventColorArgs args);

   public class CustomEventColorArgs : System.EventArgs
   {
      private string m_EventName;
      private UnityEngine.Color m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
      public UnityEngine.Color EventData { get { return m_EventData; } }

      public CustomEventColorArgs(string eventName, UnityEngine.Color eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event Color")]
   public event uScriptEventHandler OnCustomEventColor;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventColor != null ) OnCustomEventColor( this, new CustomEventColorArgs(cEventData.EventName, (UnityEngine.Color)cEventData.EventData, cEventData.Sender) ); 
   }	
}
