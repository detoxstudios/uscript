// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being used as a trigger (IsTrigger is checked/true).

using UnityEngine;
using System.Collections;


[AddComponentMenu("uScript/Trigger")]
[NodeComponentType(typeof(Collider))]

[NodePath("Events")]
[FriendlyName("Trigger Event")]
public class uScript_Triggers : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, TriggerEventArgs args);

   public class TriggerEventArgs : System.EventArgs
   {
      private GameObject m_GameObject;
      
      [FriendlyName("Game Object")]
      public GameObject GameObject { get { return m_GameObject; } }

      public TriggerEventArgs(GameObject gameObject)
      {
         m_GameObject = gameObject;
      }
   }

   public event uScriptEventHandler OnEnterTrigger;
   public event uScriptEventHandler OnExitTrigger;
   public event uScriptEventHandler WhileInsideTrigger;

   private int m_TimesToTrigger;
   public int TimesToTrigger { set { m_TimesToTrigger = value; } }

   void OnTriggerEnter(Collider other)
   {
      if ( 0 == m_TimesToTrigger ) return;
      --m_TimesToTrigger;

      if ( OnEnterTrigger != null ) OnEnterTrigger( this, new TriggerEventArgs(other.gameObject) ); 
   }

   void OnTriggerExit(Collider other)
   {
      if ( 0 == m_TimesToTrigger ) return;
      --m_TimesToTrigger;

      if ( OnExitTrigger != null ) OnExitTrigger( this, new TriggerEventArgs(other.gameObject) ); 
   }

   void OnTriggerStay(Collider other)
   {
      if ( 0 == m_TimesToTrigger ) return;
      --m_TimesToTrigger;

      if ( WhileInsideTrigger != null ) WhileInsideTrigger( this, new TriggerEventArgs(other.gameObject) ); 
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
