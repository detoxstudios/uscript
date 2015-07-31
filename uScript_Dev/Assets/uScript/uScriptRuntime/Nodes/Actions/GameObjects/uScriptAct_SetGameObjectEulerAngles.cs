// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the world or local coordinates euler angle rotation of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Euler Angles", "Sets the world or local coordinates euler angle rotation of a GameObject by specifing the X, Y, and Z axis in degrees.")]
public class uScriptAct_SetGameObjectEulerAngles : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Target GameObject(s) to set Euler Angles for."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("X Axis", "The X Axis Euler angle to set.")]
      float X_Axis,

      [FriendlyName("Preserve X Axis", "Whether or not to preserve the current X Axis Euler angle.")]
      [SocketState(false, false)]
      bool PreserveX_Axis,

      [FriendlyName("Y Axis", "The Y Axis Euler angle to set.")]
      float Y_Axis,

      [FriendlyName("Preserve Y Axis", "Whether or not to preserve the current Y Axis Euler angle.")]
      [SocketState(false, false)]
      bool PreserveY_Axis,

      [FriendlyName("Z Axis", "The Z Axis Euler angle to set.")]
      float Z_Axis,

      [FriendlyName("Preserve Z Axis", "Whether or not to preserve the current Z Axis Euler angle.")]
      [SocketState(false, false)]
      bool PreserveZ_Axis,

      [FriendlyName("As Local", "Whether or not to set the local (instead of world) Euler angles of the Target GameObjects'.")]
      [SocketState(false, false)]
      [DefaultValue(false)]
      bool AsLocal
      )
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
         Vector3 angles;
         if (AsLocal)
         {
            angles = currentTarget.transform.localEulerAngles;
         }
         else
         {
            angles = currentTarget.transform.eulerAngles;
         }
         Vector3 rotationVector = new Vector3(angles.x, angles.y, angles.z);
         if (!PreserveX_Axis) rotationVector.x = X_Axis;
         if (!PreserveY_Axis) rotationVector.y = Y_Axis;
         if (!PreserveZ_Axis) rotationVector.z = Z_Axis;
         if (AsLocal)
         {
            currentTarget.transform.localEulerAngles = rotationVector;
         }
         else
         {
            currentTarget.transform.eulerAngles = rotationVector;
         }
      }
   }
}