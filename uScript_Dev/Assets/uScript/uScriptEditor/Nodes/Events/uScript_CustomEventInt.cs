// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being that needs to receive a custom event with an int.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/CustomEvents/CustomEventInt")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventInt")]
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
      if ( OnCustomEventInt != null ) OnCustomEventInt( this, new CustomEventIntArgs(cEventData.EventName, (int)cEventData.EventData, cEventData.Sender) ); 
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
