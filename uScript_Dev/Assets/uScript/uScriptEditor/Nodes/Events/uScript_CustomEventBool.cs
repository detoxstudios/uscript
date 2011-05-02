// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being that needs to receive a custom event with a bool.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/CustomEventBool")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventBool")]
[FriendlyName("Custom Event (Bool)")]
public class uScript_CustomEventBool : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventBoolArgs args);

   public class CustomEventBoolArgs : System.EventArgs
   {
      private string m_EventName;
      private bool m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
      public bool EventData { get { return m_EventData; } }

      public CustomEventBoolArgs(string eventName, bool eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }
 
   [FriendlyName("On Custom Event Bool")]
   public event uScriptEventHandler OnCustomEventBool;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventBool != null ) OnCustomEventBool( this, new CustomEventBoolArgs(cEventData.EventName, (bool)cEventData.EventData, cEventData.Sender) ); 
   }	
	
#if UNITY_EDITOR
	// uScript GUI Options
	void OnDrawGizmos()
	{
		// @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
		if ( this.name != uScriptRuntimeConfig.MasterObjectName )
		{
        	Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
		}
    }
#endif

}
