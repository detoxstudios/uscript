// uScript uScript_Triggers.cs
// (C) 2010 Detox Studios LLC
// Desc: Assign this component to any GameObject being used as a trigger (IsTrigger is checked/true).

using UnityEngine;
using System.Collections;


[NodeComponentType(typeof(Collider))]

[NodePath("Events/Particles")]

[FriendlyName("Particle Collision")]
public class uScript_Particle : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, ParticleCollisionEventArgs args);

   public class ParticleCollisionEventArgs : System.EventArgs
   {
      private GameObject m_GameObject;

      [FriendlyName("Instigator")]
      public GameObject GameObject { get { return m_GameObject; } }

      public ParticleCollisionEventArgs(GameObject hit)
      {
         m_GameObject = hit;
      }
   }

   [FriendlyName("On Particle Collision")]
   public event uScriptEventHandler Collision;
 
   void OnParticleCollision(GameObject gameObject)
   {
      if ( Collision != null ) Collision( this, new ParticleCollisionEventArgs(gameObject) ); 
   }
}
