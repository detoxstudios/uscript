// uScript uScript_CustomEventInt.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when Instance receives a custom event with a int.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventInt")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when Instance receives a custom event with a int.")]
[NodeDescription("Fires an event signal when Instance receives a custom event with a int.\n \nSender: The GameObject that sent this event (if available).\nEvent Name: The name of the custom event.\nEvent Data: The variable that was sent with this event.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Custom_Event_.28Int.29")]

[FriendlyName("Custom Event (Int)")]
public class uScript_CustomEventInt : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventIntArgs args);

   public class CustomEventIntArgs : System.EventArgs
   {
      private string m_EventName;
      private int m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
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
      if ( OnCustomEventInt != null && cEventData.EventData.GetType() == typeof(System.Int32) ) OnCustomEventInt( this, new CustomEventIntArgs(cEventData.EventName, (int)cEventData.EventData, cEventData.Sender) ); 
   }	
}
