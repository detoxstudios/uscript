// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Cast a ray from the Mouse Cursor into the scene.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Cast a ray from the Mouse Cursor into the scene.")]
[NodeDescription("Cast a ray from the Mouse Cursor into the scene, determines if anything was hit along the way, and fires the associated output link.\n\nCamera: The Camera GameObject to cast the ray from. \nDistance: How far out to cast the ray. \nLayer Mask: A Layer mask that is used to selectively ignore colliders when casting a ray.\nHit GameObject: The first GameObject that was hit by the raycast (if any).\nHit Distance: The distance along the ray that the hit occured (if any).\nHit Location: The position of the hit (if any).\nHit Normal: The surface normal of the hit (if any).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Raycast_From_Mouse_Cursor")]

[FriendlyName("Raycast From Mouse Cursor")]
public class uScriptAct_RaycastFromCursor : uScriptLogic
{
   private bool m_NotObstructed = false;
   private bool m_Obstructed = false;

   public bool NotObstructed { get { return m_NotObstructed; } }
   public bool Obstructed { get { return m_Obstructed; } }

   public void In(
      Camera Camera,
      [FriendlyName("Distance"), SocketState(false, false), DefaultValue(100f)] float Distance,
      [FriendlyName("Layer Mask"), SocketState(false, false)] LayerMask layerMask,
// TODO: Uncomment when array support is added
//      [FriendlyName("Layer Masks"), SocketState(false, false)] LayerMask[] layerMasks,
      [FriendlyName("Include Masked Layers"), DefaultValue(true), SocketState(false, false)] bool include,
      [FriendlyName("Hit GameObject")] out GameObject HitObject,
      [FriendlyName("Hit Distance"), SocketState(false, false)] out float HitDistance,
      [FriendlyName("Hit Location")] out Vector3 HitLocation,
      [FriendlyName("Hit Normal"), SocketState(false, false)] out Vector3 HitNormal
      )
   {
      bool hitTrue = false;
      float tmpHitDistance = 0F;
      Vector3 tmpHitLocation = Vector3.zero;
      Vector3 tmpHitNormal = new Vector3(0, 1, 0);
      GameObject tmpHitObject = null;
      // TODO: Remove the following line when array support is added
      LayerMask[] layerMasks = new LayerMask[] { layerMask };

      Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

      if (Distance <= 0) Distance = Mathf.Infinity;
      float castDistance = Distance;
      RaycastHit hit;
      int bitmask = 0;
      
      foreach (LayerMask mask in layerMasks)
      {
         bitmask |= 1 << mask;
      }
      if (!include) bitmask = ~bitmask;

      if (Physics.Raycast(ray.origin, ray.direction, out hit, castDistance, bitmask))
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