// uScript uScript_CustomEventVector2.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventVector2")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a Vector2.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Custom Event (Vector2)", "Fires an event signal when Instance receives a custom event with a Vector2.")]
public class uScript_CustomEventVector2 : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventVector2Args args);

   public class CustomEventVector2Args : System.EventArgs
   {
      private string m_EventName;
      private Vector2 m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender", "The GameObject that sent this event (if available).")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name", "The name of the custom event.")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data", "The variable that was sent with this event.")]
      public Vector2 EventData { get { return m_EventData; } }

      public CustomEventVector2Args(string eventName, Vector2 eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event Vector2")]
   public event uScriptEventHandler OnCustomEventVector2;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventVector2 != null && cEventData.EventData != null
#if !UNITY_FLASH
        && cEventData.EventData.GetType() == typeof(UnityEngine.Vector2)
#endif
         ) OnCustomEventVector2( this, new CustomEventVector2Args(cEventData.EventName, (Vector2)cEventData.EventData, cEventData.Sender) ); 
   }	
}
