// uScript uScript_CustomEventInt.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventInt")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a int.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Custom Event (Int)", "Fires an event signal when Instance receives a custom event with a int.")]
public class uScript_CustomEventInt : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventIntArgs args);

   public class CustomEventIntArgs : System.EventArgs
   {
      private string m_EventName;
      private int m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender", "The GameObject that sent this event (if available).")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name", "The name of the custom event.")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data", "The variable that was sent with this event.")]
      public int EventData { get { return m_EventData; } }

      public CustomEventIntArgs(string eventName, int eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event Int")]
   public event uScriptEventHandler OnCustomEventInt;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventInt != null && cEventData.EventData != null
#if !UNITY_FLASH
        && cEventData.EventData.GetType() == typeof(System.Int32)
#endif
         ) OnCustomEventInt( this, new CustomEventIntArgs(cEventData.EventName, (int)cEventData.EventData, cEventData.Sender) ); 
   }	
}
