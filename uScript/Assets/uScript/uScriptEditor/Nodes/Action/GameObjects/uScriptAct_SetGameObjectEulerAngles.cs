// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the world coordinates euler angle rotation of a GameObject by specifing the X, Y, and Z axis in degrees (0-360 degrees).

using UnityEngine;
using System.Collections;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the world coordinates euler angle rotation of a GameObject.")]
[NodeDescription("Sets the world coordinates euler angle rotation of a GameObject by specifing the X, Y, and Z axis in degrees (0-360 degrees).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Rotation")]
public class uScriptAct_SetGameObjectEulerAngles : uScriptLogic
{
   // @TODO: This one needs work to handle not wanting to change one or more axis as well as Quaternion support.
   public bool Out { get { return true; } }

   public void In(GameObject[] Target, [FriendlyName("X Axis")] float X_Axis, [FriendlyName("Y Axis")] float Y_Axis, [FriendlyName("Z Axis")] float Z_Axis)
   {
      Vector3 m_RotationVector3;

      if (X_Axis > 360F || X_Axis < 0F)
      {
         X_Axis = 0F;
      }
      else
      if (Y_Axis > 360F || Y_Axis < 0F)
      {
         Y_Axis = 0F;
      }
      if (Z_Axis > 360F || Z_Axis < 0F)
      {
         Z_Axis = 0F;
      }

      m_RotationVector3 = new Vector3(X_Axis, Y_Axis, Z_Axis);

      foreach (GameObject currentTarget in Target)
      {
         currentTarget.transform.eulerAngles = m_RotationVector3;
      }

      

   }
}