// uScript Action Node
// (C) 2013 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Cast a ray from the Mouse Cursor into the scene.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Raycast (All) From Mouse Cursor (2D)", "Cast a 2D ray from the Mouse Cursor into the scene, determines if anything was hit along the way, and fires the associated output link. Used with Unity's 2D Physics system.")]
public class uScriptAct_RaycastAllFromCursor_2D : uScriptLogic
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

      [FriendlyName("Hit Locations", "The positions of the hits (if any).")]
      out Vector2[] HitLocations

      )
   {
      bool hitTrue = false;
      List<Vector2> tmpHitLocations = new List<Vector2>();
      List<GameObject> tmpHitObjects = new List<GameObject>();

      Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

      if (Distance <= 0) Distance = Mathf.Infinity;
      float castDistance = Distance;
      RaycastHit2D[] hits;

      if (!include) layerMask = ~layerMask;

      if (true == showRay)
      {
         Debug.DrawLine(ray.origin, ray.origin + (ray.direction * castDistance));
      }

      hits = Physics2D.GetRayIntersectionAll(ray, castDistance, layerMask);
      for (int i = 0; i < hits.Length; i++)
      {
         tmpHitLocations.Add(hits[i].point);
         tmpHitObjects.Add(hits[i].collider.gameObject);
         hitTrue = true;
      }

      HitLocations = tmpHitLocations.ToArray();
      HitObjects = tmpHitObjects.ToArray();

      m_Obstructed = hitTrue;
      m_NotObstructed = !m_Obstructed;
   }
}
#endif