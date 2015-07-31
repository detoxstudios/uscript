// uScript uScript_CustomEventColor.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventColor")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a Color.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Custom Event (Color)", "Fires an event signal when Instance receives a custom event with a Color.")]
public class uScript_CustomEventColor : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventColorArgs args);

   public class CustomEventColorArgs : System.EventArgs
   {
      private string m_EventName;
      private UnityEngine.Color m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender", "The GameObject that sent this event (if available).")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name", "The name of the custom event.")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data", "The variable that was sent with this event.")]
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
      if ( OnCustomEventColor != null && cEventData.EventData != null
#if !UNITY_FLASH
        && cEventData.EventData.GetType() == typeof(UnityEngine.Color)
#endif
         ) OnCustomEventColor( this, new CustomEventColorArgs(cEventData.EventName, (UnityEngine.Color)cEventData.EventData, cEventData.Sender) ); 
   }	
}
