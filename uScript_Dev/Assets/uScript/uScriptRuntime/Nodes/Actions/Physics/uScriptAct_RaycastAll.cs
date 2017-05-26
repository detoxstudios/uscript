// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Performs a ray trace from the starting point to the end point. Returns any and all hit data.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Raycast All", "Performs a ray trace from the starting point to the end point, determines if anything was hit along the way, and fires the associated output link.")]
public class uScriptAct_RaycastAll : uScriptLogic
{
   private Vector3 m_StartVector = Vector3.zero;
   private Vector3 m_EndVector = Vector3.zero;

   private bool m_NotObstructed = false;
   private bool m_Obstructed = false;

   public bool NotObstructed { get { return m_NotObstructed; } }
   public bool Obstructed { get { return m_Obstructed; } }

   public void In(
      [FriendlyName("Start", "The start point of the ray cast. Must be a GameObject or Vector3.")]
      object Start,

      [FriendlyName("End", "The end point of the ray cast. Must be a GameObject or Vector3.")]
      object End,

      [FriendlyName("Layer Mask", "A Layer mask that is used to selectively ignore colliders when casting a ray.")]
      [SocketState(false, false)]
      LayerMask layerMask,

      [FriendlyName("Include Masked Layers", "If true, the ray will test against the masked layers, otherwise it will test against all layers excluding the masked layers.")]
      [DefaultValue(true), SocketState(false, false)]
      bool include,

      [FriendlyName("Show Ray", "If true, the ray will be displayed as a line in the Scene view.")]
      [SocketState(false, false)]
      bool showRay,

      [FriendlyName("Hit GameObjects", "All the GameObjects that were hit by the raycast (if any).")]
      out GameObject[] HitObjects,

      [FriendlyName("Hit Distances", "The distances along the ray that the hits occured (if any).")]
      out float[] HitDistances,

      [FriendlyName("Hit Locations", "The positions of the hits (if any).")]
      out Vector3[] HitLocations,

      [FriendlyName("Hit Normals", "The surface normals of the hits (if any).")]
      out Vector3[] HitNormals
      )
   {
      bool hitTrue = false;
      bool validInputs = true;
      List<float> tmpHitDistances = new List<float>();
      List<Vector3> tmpHitLocations = new List<Vector3>();
      List<Vector3> tmpHitNormals = new List<Vector3>();
      List<GameObject> tmpHitObjects = new List<GameObject>();

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
         uScriptDebug.Log("The Raycast node can only take a GameObject or Vector3 for the 'Start' input nub!", uScriptDebug.Type.Error);
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
         uScriptDebug.Log("The Raycast node can only take a GameObject or Vector3 for the 'End' input nub!", uScriptDebug.Type.Error);
         validInputs = false;
      }

      if (validInputs)
      {
         Vector3 finalDirection = (m_EndVector - m_StartVector).normalized;
         float castDistance = Vector3.Distance(m_StartVector, m_EndVector);

         if (!include) layerMask = ~layerMask;

         if (true == showRay)
         {
            Debug.DrawLine(m_StartVector, m_StartVector + (finalDirection * castDistance));
         }

         RaycastHit[] hits = Physics.RaycastAll(m_StartVector, finalDirection, castDistance, layerMask);
         for (int i = 0; i < hits.Length; i++)
         {
            tmpHitDistances.Add(hits[i].distance);
            tmpHitLocations.Add(hits[i].point);
            tmpHitObjects.Add(hits[i].collider.gameObject);
            tmpHitNormals.Add(hits[i].normal);
            hitTrue = true;
         }
      }

      HitDistances = tmpHitDistances.ToArray();
      HitLocations = tmpHitLocations.ToArray();
      HitObjects = tmpHitObjects.ToArray();
      HitNormals = tmpHitNormals.ToArray();

      m_Obstructed = hitTrue;
      m_NotObstructed = !m_Obstructed;
   }
}

#endif