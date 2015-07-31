// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Camera")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Places the specified camera in orbit around the a world vector.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Update Camera Orbit",
              "Places the specified camera in orbit around a world vector."
              + "\n\nInternally, the rotation uses the speed, offset, and camera distance to determine"
              + " rotation behavior.  The smaller the distance, the slower the camera rotates."
              + "\n\nCamera systems and behaviors are often quite complex and game-specific. This node"
              + " can be used as a template for creating a custom camera orbiting node.")]
public class uScriptAct_UpdateCameraOrbit : uScriptLogic
{
   float x = 0f;
   float y = 0f;

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Camera", "The camera that will orbit around the target.")]
      Camera Camera,
      
      [FriendlyName("Target", "The vector in world space. To target a GameObject, pass its position property.")]
      Vector3 Target,

      [FriendlyName("Distance", "The camera's distance from the target.")]
      [DefaultValue(5), SocketState(false, false)]
      float Distance,
      
      [FriendlyName("Movement", "Horizontal and vertical rotation movement.")]
      Vector2 Movement,
      
      [FriendlyName("Speed", "Horizontal and Vertical rotation speed.")]
#if !(UNITY_FLASH)
      [DefaultValue(typeof(Vector2), new float[]{ 2f, 2f })]
#endif
      Vector2 Speed,
      
      [FriendlyName("Constrain Angles", "Should the rotation be constrained to a range of angles?")]
      [SocketState(false, false)]
      bool ConstrainAngles,
      
      [FriendlyName("Horizontal Range", "The horizontal rotation range where X must be less than or equal to Y.")]
      [SocketState(false, false)]
      Vector2 HorizontalRange,
      
      [FriendlyName("Vertical Range", "The vertical rotation range where X must be less than or equal to Y.")]
      [SocketState(false, false)]
      Vector2 VerticalRange
      )
   {
      x += Movement.x * Speed.x * Distance;
      y -= Movement.y * Speed.y * Distance;

      if (ConstrainAngles)
      {
         if (HorizontalRange.x <= HorizontalRange.y) x = Mathf.Max(x, HorizontalRange.x);
         if (HorizontalRange.y >= HorizontalRange.x) x = Mathf.Min(x, HorizontalRange.y);

         if (VerticalRange.x <= VerticalRange.y) y = Mathf.Max(y, VerticalRange.x);
         if (VerticalRange.y >= VerticalRange.x) y = Mathf.Min(y, VerticalRange.y);
      }

      Quaternion rotation = Quaternion.Euler(y, x, 0);

      Vector3 position = rotation * new Vector3(0f, 0f, -Distance) + Target;

      Camera.transform.rotation = rotation;
      Camera.transform.position = position;
   }
}