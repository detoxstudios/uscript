// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject that needs to receive a standard custom event.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/CustomEvent")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEvent")]
[FriendlyName("Custom Event")]
public class uScript_CustomEvent : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventBoolArgs args);

   public class CustomEventBoolArgs : System.EventArgs
   {
      private string m_EventName;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
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
      if ( OnCustomEvent != null && cEventData.EventData.GetType() == typeof(System.Boolean) ) OnCustomEvent( this, new CustomEventBoolArgs(cEventData.EventName, cEventData.Sender) ); 
   }	
}
