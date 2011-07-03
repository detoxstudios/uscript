// uScript uScript_CustomEventVector3.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when Instance receives a custom event with a Vector3.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventVector3")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a Vector3.")]
[NodeDescription("Fires an event signal when Instance receives a custom event with a Vector3.\n \nSender: The GameObject that sent this event (if available).\nEvent Name: The name of the custom event.\nEvent Data: The variable that was sent with this event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Custom_Event_.28Vector3.29")]

[FriendlyName("Custom Event (Vector3)")]
public class uScript_CustomEventVector3 : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventVector3Args args);

   public class CustomEventVector3Args : System.EventArgs
   {
      private string m_EventName;
      private Vector3 m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
      public Vector3 EventData { get { return m_EventData; } }

      public CustomEventVector3Args(string eventName, Vector3 eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event Vector3")]
   public event uScriptEventHandler OnCustomEventVector3;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventVector3 != null && cEventData.EventData != null && cEventData.EventData.GetType() == typeof(UnityEngine.Vector3) ) OnCustomEventVector3( this, new CustomEventVector3Args(cEventData.EventName, (Vector3)cEventData.EventData, cEventData.Sender) ); 
   }	
}
