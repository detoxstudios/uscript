// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being that needs to receive a custom event with a GameObject.

using UnityEngine;
using System.Collections;

[AddComponentMenu("uScript/CustomEvents/CustomEventGameObject")]
[NodeComponentType(typeof(Transform))]

[NodePath("Events/Custom Events")]
[NodePropertiesPath("Properties/CustomEventGameObject")]
[FriendlyName("Custom Event GameObject")]
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
      if ( OnCustomEventGameObject != null ) OnCustomEventGameObject( this, new CustomEventGameObjectArgs(cEventData.EventName, (GameObject)cEventData.EventData, cEventData.Sender) ); 
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
