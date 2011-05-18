// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the world coordinates euler angle rotation of a GameObject by specifing the X, Y, and Z axis in degrees. Any of the current euler angles can be preserved.

using UnityEngine;
using System.Collections;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the world coordinates euler angle rotation of a GameObject.")]
[NodeDescription("Sets the world coordinates euler angle rotation of a GameObject by specifing the X, Y, and Z axis in degrees. Any of the current euler angles can be preserved.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Rotation")]
public class uScriptAct_SetGameObjectEulerAngles : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, [FriendlyName("X Axis")] float X_Axis, [FriendlyName("Preserve X Axis")] bool PreserveX_Axis, [FriendlyName("Y Axis")] float Y_Axis, [FriendlyName("Preserve Y Axis")] bool PreserveY_Axis, [FriendlyName("Z Axis")] float Z_Axis, [FriendlyName("Preserve Z Axis")] bool PreserveZ_Axis)
   {
      if (!PreserveX_Axis)
      {
         // clamp x to 0-360
         while (X_Axis > 360F)
         {
            X_Axis -= 360F;
         }
         while (X_Axis < 0F)
         {
            X_Axis += 360F;
         }
      }
  
      if (!PreserveY_Axis)
      {
         // clamp y to 0-360
         while (Y_Axis > 360F)
         {
            Y_Axis -= 360F;
         }
         while (Y_Axis < 0F)
         {
            Y_Axis += 360F;
         }
      }
  
      if (!PreserveZ_Axis)
      {
         // clamp z to 0-360
         while (Z_Axis > 360F)
         {
            Z_Axis -= 360F;
         }
         while (Z_Axis < 0F)
         {
            Z_Axis += 360F;
         }
      }

      foreach (GameObject currentTarget in Target)
      {
         Vector3 angles = currentTarget.transform.eulerAngles;
         Vector3 rotationVector = new Vector3(angles.x, angles.y, angles.z);
         if (!PreserveX_Axis) rotationVector.x = X_Axis;
         if (!PreserveY_Axis) rotationVector.y = Y_Axis;
         if (!PreserveZ_Axis) rotationVector.z = Z_Axis;
         currentTarget.transform.eulerAngles = rotationVector;
      }
   }
}