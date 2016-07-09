// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNIY_3_5 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3)

using UnityEngine;
using System.Collections;

[NodePath("Actions/Particles")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Start and stop particle emitters. Optionally clear all particles before starting or after stopping.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Particles", "Start and stop particle emitters.")]
public class uScriptAct_Particles : uScriptLogic
{
   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Out { get { return true; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in StopEmitting()
   [FriendlyName("Start Emitting")]
   public void StartEmitting(GameObject[] Target, bool ClearParticles)
   {
      foreach ( GameObject currentTarget in Target )
      {
         if (currentTarget != null)
         {
            ParticleEmitter peComp = currentTarget.GetComponent<ParticleEmitter>();
            if (peComp != null)
            {
               if (peComp != null)
               {
                  if (ClearParticles)
                  {
                     peComp.ClearParticles();
                  }
                  peComp.emit = true;
               }
            }
            else
            {
               ParticleSystem psComp = currentTarget.GetComponent<ParticleSystem>();
               if (psComp != null)
               {
                  if (ClearParticles)
                  {
                     psComp.Stop();
                  }

                  psComp.Play();
               }
            }
         }
      }
   }
 
   [FriendlyName("Stop Emitting")]
   public void StopEmitting(
      [FriendlyName("Target", "The Target GameObject(s) to start/stop particles on. Note: The Target GameObject must be setup in Unity to use particles (have the appropriate particle component assigned and set up)."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Clear Particles", "Whether or not to immediately clear all the particles already emitted by Target emitters - will be cleared before starting or after stopping.")]
      [DefaultValue(false), SocketState(false, false)]
      bool ClearParticles
      )
   {
      foreach ( GameObject currentTarget in Target )
      {
         if (currentTarget != null)
         {
            ParticleEmitter peComp = currentTarget.GetComponent<ParticleEmitter>();
            if (peComp != null)
            {
               if (peComp != null)
               {
                  peComp.emit = false;
                  if (ClearParticles)
                  {
                     peComp.ClearParticles();
                  }
               }
            }
            else
            {
               ParticleSystem psComp = currentTarget.GetComponent<ParticleSystem>();
               if (psComp != null)
               {
                  if (ClearParticles)
                  {
                     psComp.Stop();
                  }
                  else
                  {
                     psComp.Pause();
                  }
               }
            }
         }
      }
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}

#endif
