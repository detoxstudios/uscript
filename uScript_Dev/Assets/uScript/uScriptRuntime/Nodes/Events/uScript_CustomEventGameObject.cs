// uScript uScript_CustomEventGameObject.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventGameObject")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Custom Event (GameObject)", "Fires an event signal when Instance receives a custom event with a GameObject.")]
public class uScript_CustomEventGameObject : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventGameObjectArgs args);

   public class CustomEventGameObjectArgs : System.EventArgs
   {
      private string m_EventName;
      private GameObject m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender", "The GameObject that sent this event (if available).")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name", "The name of the custom event.")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data", "The variable that was sent with this event.")]
      public GameObject EventData { get { return m_EventData; } }

      public CustomEventGameObjectArgs(string eventName, GameObject eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event GameObject")]
   public event uScriptEventHandler OnCustomEventGameObject;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventGameObject != null && cEventData.EventData != null
#if !UNITY_FLASH
        && cEventData.EventData.GetType() == typeof(UnityEngine.GameObject)
#endif
         ) OnCustomEventGameObject( this, new CustomEventGameObjectArgs(cEventData.EventName, (GameObject)cEventData.EventData, cEventData.Sender) ); 
   }	
}
