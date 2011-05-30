// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc:  Cast a ray from the Camera out to the center of the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Cast a ray from the Camera out to the center of the screen.")]
[NodeDescription("Cast a ray from the Camera out to the center of the screen, determines if anything was hit along the way, and fires the associated output link.\n\nCamera: The Camera GameObject to cast the ray from. \nX Pixel Offset: The number of pixels (positive or negative value) to offset the ray from the center of the screen on X (width). Capped to the screen pixel width min/max. \nY Pixel Offset: The number of pixels (positive or negative value) to offset the ray from the center of the screen on Y (height). Capped to the screen pixel height min/max. \nDistance: How far out to cast the ray. \nLayer Mask: A Layer mask that is used to selectively ignore colliders when casting a ray.\nHit GameObject: The first GameObject that was hit by the raycast (if any).\nHit Distance: The distance along the ray that the hit occured (if any).\nHit Location: The position of the hit (if any).\nHit Normal: The surface normal of the hit (if any).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Raycast From Camera")]
public class uScriptAct_RaycastFromCamera : uScriptLogic
{
   private bool m_NotObstructed = false;
   private bool m_Obstructed = false;

   public bool NotObstructed { get { return m_NotObstructed; } }
   public bool Obstructed { get { return m_Obstructed; } }

   public void In(
      Camera Camera,
      [FriendlyName("X Pixel Offset"), SocketState(false, false)] int Offset_X,
      [FriendlyName("Y Pixel Offset"), SocketState(false, false)] int Offset_Y,
      [FriendlyName("Distance"), SocketState(false, false), DefaultValue(100f)] float Distance,
      [FriendlyName("Layer Mask"), SocketState(false, false)] int LayerMask,
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
      float finalWidth = (float)Offset_X + (Screen.width / 2);
      float finalHeight = (float)Offset_Y + (Screen.height / 2);

      if (finalWidth < 0) finalWidth = 0;
      if (finalWidth > Screen.width) finalWidth = Screen.width;
      if (finalHeight < 0) finalHeight = 0;
      if (finalHeight > Screen.height) finalHeight = Screen.height;

      Ray ray = Camera.ScreenPointToRay(new Vector3(finalWidth, finalHeight, 0));

      if (Distance <= 0) Distance = 1;
      float castDistance = Distance;
      RaycastHit hit;

      if (LayerMask <= 0)
      {
         if (Physics.Raycast(ray.origin, ray.direction, out hit, castDistance))
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
         if (Physics.Raycast(ray.origin, ray.direction, out hit, castDistance, LayerMask))
         {
            tmpHitDistance = hit.distance;
            tmpHitLocation = hit.point;
            tmpHitObject = hit.collider.gameObject;
            tmpHitNormal = hit.normal;
            hitTrue = true;
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