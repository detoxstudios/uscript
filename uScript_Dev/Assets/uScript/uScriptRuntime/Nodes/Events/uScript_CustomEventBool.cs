// uScript uScript_CustomEventBool.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when Instance receives a custom event with a bool.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventBool")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a bool.")]
[NodeDescription("Fires an event signal when Instance receives a custom event with a bool.\n \nSender: The GameObject that sent this event (if available).\nEvent Name: The name of the custom event.\nEvent Data: The variable that was sent with this event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Custom_Event_.28Bool.29")]

[FriendlyName("Custom Event (Bool)")]
public class uScript_CustomEventBool : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventBoolArgs args);

   public class CustomEventBoolArgs : System.EventArgs
   {
      private string m_EventName;
      private bool m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
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
      if ( OnCustomEventBool != null && cEventData.EventData.GetType() == typeof(System.Boolean) ) OnCustomEventBool( this, new CustomEventBoolArgs(cEventData.EventName, (bool)cEventData.EventData, cEventData.Sender) ); 
   }	
}