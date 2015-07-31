// uScript Action Node
// (C) 2013 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Cast a 2D ray from the specified screen location (in pixels) out into the scene.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Raycast From Screen Point (2D)", "Cast a 2D ray from the specified screen location (in pixels) out into the scene, determines if anything was hit along the way, and fires the associated output link. Used with Unity's 2D Physics system.")]
public class uScriptAct_RaycastFromScreenPoint_2D : uScriptLogic
{
   private bool m_NotObstructed = false;
   private bool m_Obstructed = false;

   public bool NotObstructed { get { return m_NotObstructed; } }
   public bool Obstructed { get { return m_Obstructed; } }

   public void In(
      [FriendlyName("Camera", "The Camera GameObject to cast the ray from.")]
      Camera Camera,

      [FriendlyName("Screen Position", "The X and Y position (in pixels) to raycast from. Acceptable values are from the screen's minimum X and Y (0,0) to the maximum current X and Y screen resolution values (values outside this range will be capped).")]
      Vector2 ScreenPosition,
      
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
      
      [FriendlyName("Hit GameObject", "The first GameObject that was hit by the raycast (if any).")]
      out GameObject HitObject,
      
      [FriendlyName("Hit Location", "The position of the hit (if any).")]
      out Vector2 HitLocation
      
      )
   {
      bool hitTrue = false;
      //float tmpHitDistance = 0F;
      Vector2 tmpHitLocation = Vector3.zero;
      GameObject tmpHitObject = null;

      Ray ray = Camera.ScreenPointToRay(ScreenPosition);
      if (Distance <= 0) Distance = Mathf.Infinity;
      float castDistance = Distance;
      RaycastHit2D hit;

      if (!include) layerMask = ~layerMask;

      if (true == showRay)
      {
         Debug.DrawLine(ray.origin, ray.origin + (ray.direction * castDistance));
      }
		hit = Physics2D.GetRayIntersection(ray, castDistance, layerMask);
      if(hit)
	{
         tmpHitLocation = hit.point;
         tmpHitObject = hit.collider.gameObject;
         hitTrue = true;
      }

      HitLocation = tmpHitLocation;
      HitObject = tmpHitObject;

      m_Obstructed = hitTrue;
      m_NotObstructed = !m_Obstructed;
   }
}

#endif