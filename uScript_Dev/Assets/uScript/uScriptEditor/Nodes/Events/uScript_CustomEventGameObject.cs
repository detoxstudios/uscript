// uScript uScript_CustomEventGameObject.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when Instance receives a custom event with a GameObject.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/CustomEvents/CustomEventGameObject")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventGameObject")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a GameObject.")]
[NodeDescription("Fires an event signal when Instance receives a custom event with a GameObject.\n \nSender: The GameObject that sent this event (if available).\nEvent Name: The name of the custom event.\nEvent Data: The variable that was sent with this event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Custom Event (GameObject)")]
public class uScript_CustomEventGameObject : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventGameObjectArgs args);

   public class CustomEventGameObjectArgs : System.EventArgs
   {
      private string m_EventName;
      private GameObject m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
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
      if ( OnCustomEventGameObject != null && cEventData.EventData.GetType() == typeof(UnityEngine.GameObject) ) OnCustomEventGameObject( this, new CustomEventGameObjectArgs(cEventData.EventName, (GameObject)cEventData.EventData, cEventData.Sender) ); 
   }	
}
