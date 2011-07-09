// uScript uScript_CustomEventVector4.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when Instance receives a custom event with a Vector4.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventVector4")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a Vector4.")]
[NodeDescription("Fires an event signal when Instance receives a custom event with a Vector4.\n \nSender: The GameObject that sent this event (if available).\nEvent Name: The name of the custom event.\nEvent Data: The variable that was sent with this event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Custom_Event_.28Vector4.29")]

[FriendlyName("Custom Event (Vector4)")]
public class uScript_CustomEventVector4 : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventVector4Args args);

   public class CustomEventVector4Args : System.EventArgs
   {
      private string m_EventName;
      private Vector4 m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
      public Vector4 EventData { get { return m_EventData; } }

      public CustomEventVector4Args(string eventName, Vector4 eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event Vector4")]
   public event uScriptEventHandler OnCustomEventVector4;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventVector4 != null && cEventData.EventData != null && cEventData.EventData.GetType() == typeof(UnityEngine.Vector4) ) OnCustomEventVector4( this, new CustomEventVector4Args(cEventData.EventName, (Vector4)cEventData.EventData, cEventData.Sender) ); 
   }	   
}
