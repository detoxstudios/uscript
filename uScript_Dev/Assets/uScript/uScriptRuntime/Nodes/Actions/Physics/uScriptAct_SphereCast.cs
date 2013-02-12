// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Casts a sphere against all colliders in the scene and returns information on what was hit.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Raycast")]

[FriendlyName("Sphere Cast", "Casts a sphere against all colliders in the scene and returns information on what was hit. Please note that the sphere cast does not work against colliders configured as triggers.")]
public class uScriptAct_SphereCast : uScriptLogic
{

   private Vector3 m_StartVector = Vector3.zero;
   private Vector3 m_EndVector = Vector3.zero;

   private bool m_NotObstructed = false;
   private bool m_Obstructed = false;

   public bool NotObstructed { get { return m_NotObstructed; } }
   public bool Obstructed { get { return m_Obstructed; } }

   public void In(
      [FriendlyName("Start", "The center of the sphere at the start of the sweep. Must be a GameObject or Vector3.")] object Start,
      [FriendlyName("End", "The center of the sphere at the end of the sweep. Must be a GameObject or Vector3.")] object End,
      [FriendlyName("Radius", "The radius of the sphere.")] float Radius,
      [FriendlyName("Use Layer Mask", "If true, the ray will test against the selected layer mask, otherwise it will test against all GameObjects in the scene.")] [DefaultValue(true), SocketState(false, false)] bool useLayers,
      [FriendlyName("Layer Mask", "A Layer mask that is used to selectively ignore colliders when casting a ray.")] [SocketState(false, false)] LayerMask layerMask,
      [FriendlyName("Show Ray", "If true, the ray will be displayed as a line in the Scene view.")] [SocketState(false, false)] bool showRay,
      [FriendlyName("Hit GameObject", "The first GameObject that was hit by the raycast (if any).")] out GameObject HitObject,
      [FriendlyName("Hit Distance", "The distance along the ray that the hit occured (if any).")] out float HitDistance,
      [FriendlyName("Hit Location", "The position of the hit (if any).")] out Vector3 HitLocation,
      [FriendlyName("Hit Normal", "The surface normal of the hit (if any).")] out Vector3 HitNormal
   )
   {
      // Debug.Log(layerMask.value);
      bool hitTrue = false;
      bool validInputs = true;
      float tmpHitDistance = 0F;
      Vector3 tmpHitLocation = Vector3.zero;
      Vector3 tmpHitNormal = new Vector3(0, 1, 0);
      GameObject tmpHitObject = null;

      if (typeof(GameObject) == Start.GetType() || typeof(Vector3) == Start.GetType())
      {
         if (typeof(GameObject) == Start.GetType())
         {
            GameObject tmpGameObjectStart = (GameObject)Start;
            m_StartVector = tmpGameObjectStart.transform.position;
         }
         if (typeof(Vector3) == Start.GetType())
         {
            Vector3 tmpVector3Start = (Vector3)Start;
            m_StartVector = tmpVector3Start;
         }
      }
      else
      {
         uScriptDebug.Log("[Sphere Cast] The Sphere Cast node can only take a GameObject or Vector3 for the 'Start' input socket.", uScriptDebug.Type.Error);
         validInputs = false;
      }

      if (typeof(GameObject) == End.GetType() || typeof(Vector3) == End.GetType())
      {
         if (typeof(GameObject) == End.GetType())
         {
            GameObject tmpGameObjectEnd = (GameObject)End;
            m_EndVector = tmpGameObjectEnd.transform.position;
         }
         if (typeof(Vector3) == End.GetType())
         {
            Vector3 tmpGameObjectEnd = (Vector3)End;
            m_EndVector = tmpGameObjectEnd;
         }
      }
      else
      {
         uScriptDebug.Log("[Sphere Cast] The Sphere Cast node can only take a GameObject or Vector3 for the 'End' input socket.", uScriptDebug.Type.Error);
         validInputs = false;
      }

      if (validInputs)
      {
         Vector3 finalDirection = (m_EndVector - m_StartVector).normalized;
         float castDistance = Vector3.Distance(m_StartVector, m_EndVector);
         RaycastHit hit;

         if (true == showRay)
         {
            Debug.DrawLine(m_StartVector, m_StartVector + (finalDirection * castDistance));
         }

         if (useLayers)
         {
            if (Physics.SphereCast(m_StartVector, Radius, finalDirection, out hit, castDistance, layerMask.value))
            {
               tmpHitDistance = hit.distance;
               tmpHitLocation = hit.point;
               tmpHitObject = hit.collider.gameObject;
               tmpHitNormal = hit.normal;
               hitTrue = true;
            }
         }
         else
         {
            if (Physics.SphereCast(m_StartVector, Radius, finalDirection, out hit, castDistance))
            {
               tmpHitDistance = hit.distance;
               tmpHitLocation = hit.point;
               tmpHitObject = hit.collider.gameObject;
               tmpHitNormal = hit.normal;
               hitTrue = true;
            }
         }
      }
         
      HitDistance = tmpHitDistance;
      HitLocation = tmpHitLocation;
      HitObject = tmpHitObject;
      HitNormal = tmpHitNormal;

      m_Obstructed = hitTrue;
      m_NotObstructed = !m_Obstructed;

   }
}

#endif