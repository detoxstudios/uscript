// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Orbits GameObjects around a world location.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Orbit Around Location", "Orbits GameObjects around a world location.")]
public class uScriptAct_OrbitLocation : uScriptLogic
{
   private bool m_IsOrbitting;
   private float m_CurrentSpeed;
   private GameObject[] m_Targets;
   private Vector2 m_Location;
   private Vector3 m_Axis;


   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   [FriendlyName("Orbitting")]
   public bool Orbitting { get { return m_IsOrbitting; } }

   [FriendlyName("Not Orbitting")]
   public bool NotOrbitting { get { return !m_IsOrbitting; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in UpdateSpeed()
   [FriendlyName("Start Orbit")]
   public void StartOrbit(GameObject[] Target, Vector3 Location, Vector3 Axis, float OrbitSpeed, out bool OrbitState)
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

   // Parameter Attributes are applied below in UpdateSpeed()
   [FriendlyName("Stop Orbit")]
   public void StopOrbit(GameObject[] Target, Vector3 Location, Vector3 Axis, float OrbitSpeed, out bool OrbitState)
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
      [FriendlyName("Target", "The GameObject(s) you wish to orbit."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Location", "The location you wish to have the Target orbit around.")]
      Vector3 Location,
      
      [FriendlyName("Axis", "The axis you wish to orbit on.")]
      Vector3 Axis,
      
      [FriendlyName("Orbit Speed", "How fast the Target rotates around the Location.")]
      float OrbitSpeed,
      
      [FriendlyName("Orbit State", "Reflects the current orbit state as a bool variable (True=On/False=Off).")]
      out bool OrbitState
      )
   {
      m_CurrentSpeed = OrbitSpeed;
      m_Targets = Target;
      m_Location = Location;
      m_Axis = Axis;
      m_CurrentSpeed = OrbitSpeed;
      OrbitState = m_IsOrbitting;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
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
