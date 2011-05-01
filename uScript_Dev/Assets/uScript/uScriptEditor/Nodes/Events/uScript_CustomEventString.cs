// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being that needs to receive a custom event with a string.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/CustomEvents/CustomEventString")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventString")]
[FriendlyName("Custom Event (String)")]
public class uScript_CustomEventString : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventStringArgs args);

   public class CustomEventStringArgs : System.EventArgs
   {
      private string m_EventName;
      private string m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
      public string EventData { get { return m_EventData; } }

      public CustomEventStringArgs(string eventName, string eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event String")]
   public event uScriptEventHandler OnCustomEventString;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventString != null ) OnCustomEventString( this, new CustomEventStringArgs(cEventData.EventName, (string)cEventData.EventData, cEventData.Sender) ); 
   }	
	
#if UNITY_EDITOR
	// uScript GUI Options
	void OnDrawGizmos()
	{
		// @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
		if ( this.name != uScriptConfig.MasterObjectName )
		{
        	Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
		}
    }
#endif
   
}
