// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Cast a ray from the specified screen location (in pxiels) out into the scene.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Raycast From Screen Point", "Cast a ray from the specified screen location (in pxiels) out into the scene, determines if anything was hit along the way, and fires the associated output link.")]
public class uScriptAct_RaycastFromScreenPoint : uScriptLogic
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
      
      [FriendlyName("Hit Distance", "The distance along the ray that the hit occured (if any).")]
      [SocketState(false, false)]
      out float HitDistance,
      
      [FriendlyName("Hit Location", "The position of the hit (if any).")]
      out Vector3 HitLocation,
      
      [FriendlyName("Hit Normal", "The surface normal of the hit (if any).")]
      [SocketState(false, false)]
      out Vector3 HitNormal
      )
   {
      bool hitTrue = false;
      float tmpHitDistance = 0F;
      Vector3 tmpHitLocation = Vector3.zero;
      Vector3 tmpHitNormal = new Vector3(0, 1, 0);
      GameObject tmpHitObject = null;

      Ray ray = Camera.ScreenPointToRay(ScreenPosition);

      if (Distance <= 0) Distance = Mathf.Infinity;
      float castDistance = Distance;
      RaycastHit hit;

      if (!include) layerMask = ~layerMask;

      if (true == showRay)
      {
         Debug.DrawLine(ray.origin, ray.origin + (ray.direction * castDistance));
      }
      if (Physics.Raycast(ray.origin, ray.direction, out hit, castDistance, layerMask))
      {
         tmpHitDistance = hit.distance;
         tmpHitLocation = hit.point;
         tmpHitObject = hit.collider.gameObject;
         tmpHitNormal = hit.normal;
         hitTrue = true;
      }

      HitDistance = tmpHitDistance;
      HitLocation = tmpHitLocation;
      HitObject = tmpHitObject;
      HitNormal = tmpHitNormal;

      m_Obstructed = hitTrue;
      m_NotObstructed = !m_Obstructed;
   }
}