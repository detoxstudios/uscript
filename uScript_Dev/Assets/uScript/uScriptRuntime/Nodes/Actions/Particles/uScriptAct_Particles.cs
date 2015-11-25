// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

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
            Component comp = currentTarget.GetComponent(typeof(ParticleEmitter));
            if (comp != null)
            {
               ParticleEmitter pe = comp as ParticleEmitter;
               if (pe != null)
               {
                  if (ClearParticles)
                  {
                     pe.ClearParticles();
                  }
                 pe.emit = true;
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
            Component comp = currentTarget.GetComponent(typeof(ParticleEmitter));
            if (comp != null)
            {
               ParticleEmitter pe = comp as ParticleEmitter;
               if (pe != null)
               {
                  pe.emit = false;
                  if (ClearParticles)
                  {
                     pe.ClearParticles();
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
