// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being used as a trigger (IsTrigger is checked/true).

using UnityEngine;
using System.Collections;


[AddComponentMenu("uScript/Collision")]
[NodeComponentType(typeof(CharacterController))]

[NodePath("Events/Physics Events")]

[FriendlyName("Controller Collision")]
public class uScript_ProxyController : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, ProxyControllerCollisionEventArgs args);

   public class ProxyControllerCollisionEventArgs : System.EventArgs
   {
      private ControllerColliderHit m_Hit;
      
      [FriendlyName("Character Controller")]
      public CharacterController Controller { get { return m_Hit.controller; } }

      [FriendlyName("Collider")]
      public Collider Collider { get { return m_Hit.collider; } }

      [FriendlyName("Rigid Body")]
      public Rigidbody RigidBody { get { return m_Hit.rigidbody; } }

      [FriendlyName("Instigator")]
      public GameObject GameObject { get { return m_Hit.gameObject; } }

      [FriendlyName("Transform")]
      public Transform Transform { get { return m_Hit.transform; } }

      [FriendlyName("Point")]
      public Vector3 Point { get { return m_Hit.point; } }

      [FriendlyName("Normal")]
      public Vector3 Normal { get { return m_Hit.normal; } }

      [FriendlyName("Move Direction")]
      public Vector3 MoveDirection { get { return m_Hit.moveDirection; } }

      [FriendlyName("Move Length")]
      public float MoveLength{ get { return m_Hit.moveLength; } }

      public ProxyControllerCollisionEventArgs(ControllerColliderHit hit)
      {
         m_Hit = hit;
      }
   }

   [FriendlyName("On Controller Collider Hit")]
   public event uScriptEventHandler OnHit;
 
   void OnControllerColliderHit(ControllerColliderHit hit)
   {
      if ( OnHit != null ) OnHit( this, new ProxyControllerCollisionEventArgs(hit) ); 
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
