// uScript uScript_CustomEvent.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when Instance receives a standard custom event.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEvent")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a standard custom event.")]
[NodeDescription("Fires an event signal when Instance receives a standard custom event.\n \nSender: The GameObject that sent this event (if available).\nEvent Name: The name of the custom event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

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
