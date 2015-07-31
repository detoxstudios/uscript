// uScript uScript_CustomEventVector3.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventVector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Custom Event (Vector3)", "Fires an event signal when Instance receives a custom event with a Vector3.")]
public class uScript_CustomEventVector3 : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventVector3Args args);

   public class CustomEventVector3Args : System.EventArgs
   {
      private string m_EventName;
      private Vector3 m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender", "The GameObject that sent this event (if available).")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name", "The name of the custom event.")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data", "The variable that was sent with this event.")]
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
      if ( OnCustomEventVector3 != null && cEventData.EventData != null
#if !UNITY_FLASH
        && cEventData.EventData.GetType() == typeof(UnityEngine.Vector3)
#endif
         ) OnCustomEventVector3( this, new CustomEventVector3Args(cEventData.EventName, (Vector3)cEventData.EventData, cEventData.Sender) ); 
   }	
}
