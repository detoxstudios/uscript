// uScript Action Node
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Performs a 2D ray trace from the starting point to the end point.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Raycast (2D)", "Performs a 2D ray trace from the starting point to the end point, determines if anything was hit along the way, and fires the associated output link. GameObjects being hit must have a 2D Collider component in order to be detected.")]
public class uScriptAct_RaycastAll2D : uScriptLogic
{
   private Vector2 m_StartVector = Vector3.zero;

   private bool m_NotObstructed = false;
   private bool m_Obstructed = false;

   public bool NotObstructed { get { return m_NotObstructed; } }
   public bool Obstructed { get { return m_Obstructed; } }

   public void In(
      [FriendlyName("Start", "The start point of the ray cast. Must be a GameObject, Transform, or Vector2, or Vector3.")]
      object Start,

      [FriendlyName("Direction", "The direction of the ray cast. Must be a Vector2.")]
      Vector2 Direction,

     [FriendlyName("Distance", "How far out the ray cast will travel from its Start position. If the default value of zero is used, the ray will cast an infinite distance. Must be a float.")]
     [DefaultValue(0f)]
     float Distance,

      [FriendlyName("Layer Mask", "A Layer mask that is used to selectively ignore colliders when casting a ray.")]
      [SocketState(false, false)]
      LayerMask layerMask,

      [FriendlyName("Include Masked Layers", "If true, the ray will test against the masked layers, otherwise it will test against all layers excluding the masked layers.")]
      [DefaultValue(true), SocketState(false, false)]
      bool include,

      [FriendlyName("Show Ray", "If true, the ray will be displayed as a line in the Scene view.")]
      [SocketState(false, false)]
      bool showRay,

      [FriendlyName("Hit GameObjects", "The GameObjects that were hit by the raycast (if any).")]
      out GameObject[] HitObjects,

      [FriendlyName("Hit Locations", "The positions of the hits (if any).")]
      out Vector3[] HitLocations,

      [FriendlyName("Hit Normals", "The surface normals of the hits (if any).")]
      out Vector3[] HitNormals
      )
   {
      bool validInputs = true;
      bool hitTrue = false;

      if (typeof(GameObject) == Start.GetType())
      {
         GameObject tmpGameObjectStart = (GameObject)Start;
         m_StartVector = tmpGameObjectStart.transform.position;
      }
      else if (typeof(Vector2) == Start.GetType())
      {
         Vector2 tmpVector3Start = (Vector2)Start;
         m_StartVector = tmpVector3Start;
      }
      else if (typeof(Vector3) == Start.GetType())
      {
         Vector2 tmpVector3Start = (Vector3)Start;
         m_StartVector = tmpVector3Start;
      }
      else if (typeof(Transform) == Start.GetType())
      {
         Transform tmpVector3Start = (Transform)Start;
         m_StartVector = tmpVector3Start.position;
      }
      else
      {
         uScriptDebug.Log("The Raycast node can only take a GameObject, Transform, Vector2, or Vector3 for the 'Start' input nub!", uScriptDebug.Type.Error);
         validInputs = false;
      }

      // Figure out if distance should be used.
      bool useDistance = false;
      if (Distance > 0)
      {
         useDistance = true;
      }

      RaycastHit2D[] hits = null;

      if (validInputs)
      {

         if (true == showRay)
         {
            Debug.DrawLine(m_StartVector, m_StartVector + (Direction * Distance));
         }

         if (!include)
         {
            if (!useDistance)
            {
               hits = Physics2D.RaycastAll(m_StartVector, Direction);
            }
            else
            {
               hits = Physics2D.RaycastAll(m_StartVector, Direction, Distance);
            }
         }
         else
         {
            if (!useDistance)
            {
               hits = Physics2D.RaycastAll(m_StartVector, Direction, float.MaxValue, layerMask);
            }
            else
            {
               hits = Physics2D.RaycastAll(m_StartVector, Direction, Distance, layerMask);
            }
         }
      }

      List<Vector3> tmpHitLocations = new List<Vector3>();
      List<Vector3> tmpHitNormals = new List<Vector3>();
      List<GameObject> tmpHitObjects = new List<GameObject>();
      for (int i = 0; i < hits.Length; i++)
      {
         tmpHitLocations.Add(hits[i].point);
         tmpHitObjects.Add(hits[i].collider.gameObject);
         tmpHitNormals.Add(hits[i].normal);
         hitTrue = true;
      }

      HitLocations = tmpHitLocations.ToArray();
      HitObjects = tmpHitObjects.ToArray();
      HitNormals = tmpHitNormals.ToArray();

      m_Obstructed = hitTrue;
      m_NotObstructed = !m_Obstructed;
   }
}

#endif