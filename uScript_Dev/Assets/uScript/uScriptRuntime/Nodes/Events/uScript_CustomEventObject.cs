// uScript uScript_CustomEventObject.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventObject")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with an Object.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Custom_Event_.28Object.29")]

[FriendlyName("Custom Event (Object)", "Fires an event signal when Instance receives a custom event with an Object.")]
public class uScript_CustomEventObject : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventObjectArgs args);

   public class CustomEventObjectArgs : System.EventArgs
   {
      private string m_EventName;
      private Object m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender", "The GameObject that sent this event (if available).")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name", "The name of the custom event.")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data", "The variable that was sent with this event.")]
      public Object EventData { get { return m_EventData; } }

      public CustomEventObjectArgs(string eventName, Object eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event Object")]
   public event uScriptEventHandler OnCustomEventObject;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventObject != null && cEventData.EventData != null && typeof(UnityEngine.Object).IsAssignableFrom(cEventData.EventData.GetType()) ) OnCustomEventObject( this, new CustomEventObjectArgs(cEventData.EventName, (Object)cEventData.EventData, cEventData.Sender) ); 
   }	
}
