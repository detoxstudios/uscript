// uScript uScript_CustomEventFloat.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventFloat")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a float.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Custom Event (Float)", "Fires an event signal when Instance receives a custom event with a float.")]
public class uScript_CustomEventFloat : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventFloatArgs args);

   public class CustomEventFloatArgs : System.EventArgs
   {
      private string m_EventName;
      private float m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender", "The GameObject that sent this event (if available).")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name", "The name of the custom event.")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data", "The variable that was sent with this event.")]
      public float EventData { get { return m_EventData; } }

      public CustomEventFloatArgs(string eventName, float eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event Float")]
   public event uScriptEventHandler OnCustomEventFloat;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventFloat != null && cEventData.EventData != null
#if !UNITY_FLASH
        && cEventData.EventData.GetType() == typeof(System.Single)
#endif
         ) OnCustomEventFloat( this, new CustomEventFloatArgs(cEventData.EventName, (float)cEventData.EventData, cEventData.Sender) ); 
   }	
}
