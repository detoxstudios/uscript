// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being that needs to receive a custom event with a Vector3.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/CustomEvents/CustomEventVector3")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventVector3")]
[FriendlyName("Custom Event (Vector3)")]
public class uScript_CustomEventVector3 : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventVector3Args args);

   public class CustomEventVector3Args : System.EventArgs
   {
      private string m_EventName;
      private Vector3 m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
      public Vector3 EventData { get { return m_EventData; } }

      public CustomEventVector3Args(string eventName, Vector3 eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event Vector3")]
   public event uScriptEventHandler OnCustomEventVector3;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventVector3 != null ) OnCustomEventVector3( this, new CustomEventVector3Args(cEventData.EventName, (Vector3)cEventData.EventData, cEventData.Sender) ); 
   }	
	
	// uScript GUI Options
	void OnDrawGizmos()
	{
		// @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
		if ( this.name != uScriptConfig.MasterObjectName )
		{
        	Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
		}
    }
   
}
