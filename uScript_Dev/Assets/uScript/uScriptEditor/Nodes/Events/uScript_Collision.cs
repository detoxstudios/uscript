// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being used as a trigger (IsTrigger is checked/true).

using UnityEngine;
using System.Collections;


[AddComponentMenu("uScript/Collision")]
[NodeComponentType(typeof(Collider), typeof(Rigidbody))]

[NodePath("Events/Physics Events")]

[FriendlyName("On Collision")]
public class uScript_Collision : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, CollisionEventArgs args);

   public class CollisionEventArgs : System.EventArgs
   {
      private Collision m_Collision;

      [FriendlyName("Relative Velocity")]
      public Vector3 RelativeVelocity { get { return m_Collision.relativeVelocity; } }

      [FriendlyName("Rigid Body")]
      public Rigidbody RigidBody { get { return m_Collision.rigidbody; } }

      [FriendlyName("Collider")]
      public Collider Collider { get { return m_Collision.collider; } }

      [FriendlyName("Transform")]
      public Transform Transform { get { return m_Collision.transform; } }

      [FriendlyName("Contact Points")]
      public ContactPoint[] Contacts { get { return m_Collision.contacts; } }

      [FriendlyName("Instigator")]
      public GameObject GameObject { get { return m_Collision.gameObject; } }

      public CollisionEventArgs(Collision collision)
      {
         m_Collision = collision;
      }
   }

   [FriendlyName("On Collision Enter")]
   public event uScriptEventHandler OnEnterCollision;

   [FriendlyName("On Collision Exit")]
   public event uScriptEventHandler OnExitCollision;

   [FriendlyName("On Collision Stay")]
   public event uScriptEventHandler WhileInsideCollision;
 
   void OnCollisionEnter(Collision collision)
   {
      if ( OnEnterCollision != null ) OnEnterCollision( this, new CollisionEventArgs(collision) ); 
   }

   void OnCollisionExit(Collision collision)
   {
      if ( OnExitCollision != null ) OnExitCollision( this, new CollisionEventArgs(collision) ); 
   }

   void OnCollisionStay(Collision collision)
   {
      if ( WhileInsideCollision != null ) WhileInsideCollision( this, new CollisionEventArgs(collision) ); 
   }
}
