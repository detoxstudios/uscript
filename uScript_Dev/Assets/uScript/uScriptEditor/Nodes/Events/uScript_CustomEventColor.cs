// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being that needs to receive a custom event with a Color.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/CustomEvents/CustomEventColor")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventColor")]
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
