// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Camera")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Takes a Camera and an analog control x/y pair and computes the world rotation relative to the current camera view.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Camera Relative Rotation", "Takes a Camera and an analog control x/y pair and computes the world rotation relative to the current camera view.")]
public class uScriptAct_GetCameraRelativeRotation : uScriptLogic
{
   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Camera", "The Camera to use for calculations.")]
      Camera camera,
      
      [FriendlyName("X Axis Value", "The X value of the control stick. 1.0 is full right, -1.0 is full left.")]
      float stickX,
      
      [FriendlyName("Y Axis Value", "The Y value of the control stick. 1.0 is full up, -1.0 is full down.")]
      float stickY,
      
      [FriendlyName("Constrain to XZ Plane", "Whether or not to constrain the calculations to keep the resulting up perpendicular to the x/z plane.")]
      bool constrainToXZ,
      
      [FriendlyName("World Rotation", "")]
      out Quaternion worldRotation
   )
   {
      Vector3 worldLook = new Vector3(stickX, 0.0f, stickY);
      Vector3 worldUp = new Vector3(0.0f, 1.0f, 0.0f);
      worldRotation = camera.transform.rotation;
      Transform t = camera.transform;
      Matrix4x4 m = t.localToWorldMatrix;
      Vector3 cameraUp = new Vector3(m[1, 0], m[1, 1], m[1, 2]);
      
      worldLook = m.MultiplyVector(worldLook);
   
      if (constrainToXZ)
      {
         worldLook.y = 0.0f;
      }
      
      worldLook.Normalize();

      if (!constrainToXZ)
      {
         worldUp = Vector3.Cross(worldLook, cameraUp);
      }
   
      worldRotation.SetLookRotation(worldLook, worldUp);
   }
}
