// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being that needs to receive a custom event with a Vector4.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/CustomEvents/CustomEventVector4")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventVector4")]
[FriendlyName("Custom Event (Vector4)")]
public class uScript_CustomEventVector4 : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CustomEventVector4Args args);

   public class CustomEventVector4Args : System.EventArgs
   {
      private string m_EventName;
      private Vector4 m_EventData;
      private GameObject m_Sender;
      
      [FriendlyName("Sender")]
      public GameObject Sender { get { return m_Sender; } }

      [FriendlyName("Event Name")]
      public string EventName { get { return m_EventName; } }

      [FriendlyName("Event Data")]
      public Vector4 EventData { get { return m_EventData; } }

      public CustomEventVector4Args(string eventName, Vector4 eventData, GameObject sender)
      {
         m_Sender = sender;
         m_EventData = eventData;
         m_EventName = eventName;
      }
   }

   [FriendlyName("On Custom Event Vector4")]
   public event uScriptEventHandler OnCustomEventVector4;
 
   void CustomEvent(uScriptCustomEvent.CustomEventData cEventData)
   {
      if ( OnCustomEventVector4 != null ) OnCustomEventVector4( this, new CustomEventVector4Args(cEventData.EventName, (Vector4)cEventData.EventData, cEventData.Sender) ); 
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
