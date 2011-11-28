// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Orbits GameObjects around a world location.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Orbits GameObjects around a world location.")]
/* M */[NodeDescription("Orbits GameObjects around a world location.\n\nTarget: The GameObject(s) you wish to orbit.\nLocation: The location you wish to have the Target orbit around.\nAxis: The axis you wish to orbit on.\nOrbit Speed: How fast the Target rotates around the Location.\nOrbit State (out): Reflects the current orbit state as a bool variable (on = true/off = false).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Orbit Around Location")]
public class uScriptAct_OrbitLocation : uScriptLogic
{
   private bool m_IsOrbitting;
   private float m_CurrentSpeed;
   private GameObject[] m_Targets;
   private Vector2 m_Location;
   private Vector3 m_Axis;

   [FriendlyName("Orbitting")]
   public bool Orbitting { get { return m_IsOrbitting; } }
   [FriendlyName("Not Orbitting")]
   public bool NotOrbitting { get { return !m_IsOrbitting; } }

   [FriendlyName("Start Orbit")]
   public void StartOrbit(
      GameObject[] Target,
      Vector3 Location,
      Vector3 Axis,
      [FriendlyName("Orbit Speed")] float OrbitSpeed,
      [FriendlyName("Orbit State")] out bool OrbitState
   )
   {
      if (!m_IsOrbitting)
      {
         m_CurrentSpeed = OrbitSpeed;
         m_Targets = Target;
         m_Location = Location;
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
      Vector3 Location,
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
      Vector3 Location,
      Vector3 Axis,
      [FriendlyName("Orbit Speed")] float OrbitSpeed,
      [FriendlyName("Orbit State")] out bool OrbitState
   )
   {
      m_CurrentSpeed = OrbitSpeed;
      m_Targets = Target;
      m_Location = Location;
      m_Axis = Axis;
      m_CurrentSpeed = OrbitSpeed;
      OrbitState = m_IsOrbitting;
   }


   public void Update()
   {
      if (m_IsOrbitting == true && m_CurrentSpeed != 0f)
      {
         foreach (GameObject target in m_Targets)
         {
            if (target != null)
            {
               target.transform.RotateAround(m_Location, m_Axis, (m_CurrentSpeed * Time.deltaTime));
            }
         }
      }
         
   }

   
}
