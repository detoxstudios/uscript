// uScript uScript_CustomEventFloat.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when Instance receives a custom event with a float.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/Event Components/Custom Events/Custom Event (Float)")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventFloat")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a float.")]
[NodeDescription("Fires an event signal when Instance receives a custom event with a float.\n \nSender: The GameObject that sent this event (if available).\nEvent Name: The name of the custom event.\nEvent Data: The variable that was sent with this event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Custom Event (Float)")]
public class uScript_CustomEventFloat : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventFloatArgs args);

   public class CustomEventFloatArgs : System.EventArgs
   {
      private string m_EventName;
      private float m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
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
      if ( OnCustomEventFloat != null && cEventData.EventData.GetType() == typeof(System.Single) ) OnCustomEventFloat( this, new CustomEventFloatArgs(cEventData.EventName, (float)cEventData.EventData, cEventData.Sender) ); 
   }	
}
