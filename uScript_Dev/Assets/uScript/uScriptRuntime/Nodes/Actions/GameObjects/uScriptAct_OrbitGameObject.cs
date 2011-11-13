// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Orbits GameObjects around another GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Orbits GameObjects around another GameObject.")]
[NodeDescription("Orbits GameObjects around another GameObject.\n\nTarget: The GameObject(s) you wish to orbit.\nOrbiter: The GameObject you wish to have the Target orbit around.\nAxis: The axis you wish to orbit on.\nOrbit Speed: How fast the Target rotates around the Orbiter.\nOrbit State (out): Reflects the current orbit state as a bool variable (on = true/off = false).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Orbit Around GameObject")]
public class uScriptAct_OrbitGameObject : uScriptLogic
{
   private bool m_IsOrbitting;
   private float m_CurrentSpeed;
   private GameObject[] m_Targets;
   private GameObject m_Orbiter;
   private Vector3 m_Axis;

   [FriendlyName("Orbitting")]
   public bool Orbitting { get { return m_IsOrbitting; } }
   [FriendlyName("Not Orbitting")]
   public bool NotOrbitting { get { return !m_IsOrbitting; } }

   [FriendlyName("Start Orbit")]
   public void StartOrbit(
      GameObject[] Target,
      GameObject Orbiter,
      Vector3 Axis,
      [FriendlyName("Orbit Speed")] float OrbitSpeed,
      [FriendlyName("Orbit State")] out bool OrbitState
   )
   {
      if (!m_IsOrbitting)
      {
         m_CurrentSpeed = OrbitSpeed;
         m_Targets = Target;
         m_Orbiter = Orbiter;
         m_Axis = Axis;
         m_IsOrbitting = true;
         OrbitState = true;
      }
      else
      {
         OrbitState = m_IsOrbitting;
      }
   }

   [FriendlyName("Stop Orbit")]
   public void StopOrbit(
      GameObject[] Target,
      GameObject Orbiter,
      Vector3 Axis,
      [FriendlyName("Orbit Speed")] float OrbitSpeed,
      [FriendlyName("Orbit State")] out bool OrbitState
   )
   {
      if (m_IsOrbitting)
      {
         OrbitState = false;
         m_IsOrbitting = false;
      }
      else
      {
         OrbitState = m_IsOrbitting;
      }

   }

   [FriendlyName("Update Orbit Data")]
   public void UpdateSpeed(
      GameObject[] Target,
      GameObject Orbiter,
      Vector3 Axis,
      [FriendlyName("Orbit Speed")] float OrbitSpeed,
      [FriendlyName("Orbit State")] out bool OrbitState
   )
   {
      m_CurrentSpeed = OrbitSpeed;
      m_Targets = Target;
      m_Orbiter = Orbiter;
      m_Axis = Axis;
      m_CurrentSpeed = OrbitSpeed;
      OrbitState = m_IsOrbitting;
   }


   public void Update()
   {
      if (m_IsOrbitting == true && m_CurrentSpeed != 0f)
      {
         if (m_Orbiter != null)
         {
            foreach (GameObject target in m_Targets)
            {
               if (target != null)
               {
                  target.transform.RotateAround(m_Orbiter.transform.position, m_Axis, (m_CurrentSpeed * Time.deltaTime));
               }
            }
         }
         else
         {
            uScriptDebug.Log("Orbit Around GameObject] The specified Orbiter GameObject is null. Cannot orbit Targets.", uScriptDebug.Type.Error);
         }
         
      }
      
   }

   
}
