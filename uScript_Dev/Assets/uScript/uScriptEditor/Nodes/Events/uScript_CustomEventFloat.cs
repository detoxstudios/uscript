// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being that needs to receive a custom event with a float.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/CustomEvents/CustomEventFloat")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventFloat")]
[FriendlyName("Custom Event Float")]
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
      if ( OnCustomEventFloat != null ) OnCustomEventFloat( this, new CustomEventFloatArgs(cEventData.EventName, (float)cEventData.EventData, cEventData.Sender) ); 
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
