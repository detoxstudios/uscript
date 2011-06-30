// uScript uScript_CustomEventVector2.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when Instance receives a custom event with a Vector2.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventVector2")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a Vector2.")]
[NodeDescription("Fires an event signal when Instance receives a custom event with a Vector2.\n \nSender: The GameObject that sent this event (if available).\nEvent Name: The name of the custom event.\nEvent Data: The variable that was sent with this event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Custom_Event_.28Vector2.29")]

[FriendlyName("Custom Event (Vector2)")]
public class uScript_CustomEventVector2 : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventVector2Args args);

   public class CustomEventVector2Args : System.EventArgs
   {
      private string m_EventName;
      private Vector2 m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
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
      if ( OnCustomEventVector2 != null && cEventData.EventData.GetType() == typeof(UnityEngine.Vector2) ) OnCustomEventVector2( this, new CustomEventVector2Args(cEventData.EventName, (Vector2)cEventData.EventData, cEventData.Sender) ); 
   }	
}