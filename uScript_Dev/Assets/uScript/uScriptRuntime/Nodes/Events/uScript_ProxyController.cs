// uScript uScript_ProxyController.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when a CharacterController collides with an object.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(CharacterController))]

[NodePath("Events/Physics Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a CharacterController collides with an object.\n \nCharacter Controller: The controller that hit Collider.\nCollider: The collider that was hit by Character Controller.\nRigid Body: The rigidbody that was hit by Character Controller.\nInstigator: The GameObject that was hit by Character Controller.\nTransform: The transform that was hit by Character Controller.\nPoint: The impact point in world space.\nNormal: The normal of the surface we collided with in world space.\nMove Direction: Approximately the direction from the center of the capsule to the point we touch.\nMove Length: How far the character has travelled until it hit the collider.\n")]
[NodeDescription("Fires an event signal when a CharacterController collides with an object.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Controller_Collision")]

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
}
