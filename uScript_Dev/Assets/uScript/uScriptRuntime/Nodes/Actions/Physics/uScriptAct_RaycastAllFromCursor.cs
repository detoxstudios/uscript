// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections.Generic;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Cast a ray from the Mouse Cursor into the scene.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Raycast (All) From Mouse Cursor", "Cast a ray from the Mouse Cursor into the scene, determines if anything was hit along the way, and fires the associated output link.")]
public class uScriptAct_RaycastAllFromCursor : uScriptLogic
{
   private bool m_NotObstructed = false;
   private bool m_Obstructed = false;

   public bool NotObstructed { get { return m_NotObstructed; } }
   public bool Obstructed { get { return m_Obstructed; } }

   public void In(
      [FriendlyName("Camera", "The Camera GameObject to cast the ray from.")]
      Camera Camera,

      [FriendlyName("Distance", "How far out to cast the ray.")]
      [DefaultValue(100f)]
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

      [FriendlyName("Hit Distances", "The distances along the ray that the hits occured (if any).")]
      [SocketState(false, false)]
      out float[] HitDistances,

      [FriendlyName("Hit Locations", "The positions of the hits (if any).")]
      out Vector3[] HitLocations,

      [FriendlyName("Hit Normals", "The surface normals of the hits (if any).")]
      [SocketState(false, false)]
      out Vector3[] HitNormals
      )
   {
      bool hitTrue = false;
      List<float> tmpHitDistances = new List<float>();
      List<Vector3> tmpHitLocations = new List<Vector3>();
      List<Vector3> tmpHitNormals = new List<Vector3>();
      List<GameObject> tmpHitObjects = new List<GameObject>();

      Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

      if (Distance <= 0) Distance = Mathf.Infinity;
      float castDistance = Distance;

      if (!include) layerMask = ~layerMask;

      if (true == showRay)
      {
         Debug.DrawLine(ray.origin, ray.origin + (ray.direction * castDistance));
      }

      RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction, castDistance, layerMask);
      for (int i = 0; i < hits.Length; i++)
      {
         tmpHitDistances.Add(hits[i].distance);
         tmpHitLocations.Add(hits[i].point);
         tmpHitObjects.Add(hits[i].collider.gameObject);
         tmpHitNormals.Add(hits[i].normal);
         hitTrue = true;
      }

      HitDistances = tmpHitDistances.ToArray();
      HitLocations = tmpHitLocations.ToArray();
      HitObjects = tmpHitObjects.ToArray();
      HitNormals = tmpHitNormals.ToArray();

      m_Obstructed = hitTrue;
      m_NotObstructed = !m_Obstructed;
   }
}