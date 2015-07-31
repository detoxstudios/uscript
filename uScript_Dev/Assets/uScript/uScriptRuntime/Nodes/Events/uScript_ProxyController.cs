// uScript uScript_ProxyController.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Physics Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a CharacterController collides with an object.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Controller Collision", "Fires an event signal when a CharacterController collides with an object.")]
public class uScript_ProxyController : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, ProxyControllerCollisionEventArgs args);

   public class ProxyControllerCollisionEventArgs : System.EventArgs
   {
      private ControllerColliderHit m_Hit;

      [FriendlyName("Triggered By", "The GameObject that was hit by Character Controller and caused this event to fire.")]
      public GameObject GameObject { get { return m_Hit.gameObject; } }

      [FriendlyName("Character Controller", "The controller that hit Collider.")]
      [SocketState(false, false)]
      public CharacterController Controller { get { return m_Hit.controller; } }

      [FriendlyName("Collider", "The collider that was hit by Character Controller.")]
      [SocketState(false, false)]
      public Collider Collider { get { return m_Hit.collider; } }

      [FriendlyName("Rigid Body", "The rigidbody that was hit by Character Controller.")]
      [SocketState(false, false)]
      public Rigidbody RigidBody { get { return m_Hit.rigidbody; } }

      [FriendlyName("Transform", "The transform that was hit by Character Controller.")]
      [SocketState(false, false)]
      public Transform Transform { get { return m_Hit.transform; } }

      [FriendlyName("Point", "The impact point in world space.")]
      [SocketState(false, false)]
      public Vector3 Point { get { return m_Hit.point; } }

      [FriendlyName("Normal", "The normal of the surface we collided with in world space.")]
      [SocketState(false, false)]
      public Vector3 Normal { get { return m_Hit.normal; } }

      [FriendlyName("Move Direction", "Approximately the direction from the center of the capsule to the point we touch.")]
      [SocketState(false, false)]
      public Vector3 MoveDirection { get { return m_Hit.moveDirection; } }

      [FriendlyName("Move Length", "How far the character has travelled until it hit the collider.")]
      [SocketState(false, false)]
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
