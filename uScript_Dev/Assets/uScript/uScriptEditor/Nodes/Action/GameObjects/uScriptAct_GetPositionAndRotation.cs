// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the position and rotation (in quaternion and euler angle formats) of a GameObject
//       and outputs them as Vector3 variables. Optionally can get local position and rotation
//       relative to a parent GameObject (if exists - otherwise returns World).

using UnityEngine;
using System.Collections;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the position and rotation of a GameObject and outputs them as a Vector3.")]
[NodeDescription("Gets the position and rotation (in quaternion and euler angle formats) of a GameObject and outputs them as Vector3 variables. Optionally can get local position and rotation relative to a parent GameObject (if exists - otherwise returns World).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get Position and Rotation")]
public class uScriptAct_GetPositionAndRotation : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(GameObject Target, [FriendlyName("Get Local")] bool GetLocal, out Vector3 Position, out Quaternion Rotation, [FriendlyName("Euler Angles")] out Vector3 EulerAngles)
   {
      if (GetLocal)
      {
         Position = Target.transform.localPosition;
         Rotation = Target.transform.localRotation;
         EulerAngles = Target.transform.localEulerAngles;
      }
      else
      {
         Position = Target.transform.position;
         Rotation = Target.transform.rotation;
         EulerAngles = Target.transform.eulerAngles;
      }
   }
}