// uScript uScript_Particle.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Particles")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a particle collides with a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Particle_Collision")]

[FriendlyName("Particle Collision", "Fires an event signal when a particle collides with a GameObject.")]
public class uScript_Particle : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, ParticleCollisionEventArgs args);

   public class ParticleCollisionEventArgs : System.EventArgs
   {
      private GameObject m_GameObject;

      [FriendlyName("Instigator", "The GameObject that was collided with.")]
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
