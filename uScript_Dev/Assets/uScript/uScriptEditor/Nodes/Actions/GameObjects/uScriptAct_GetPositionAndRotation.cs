// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the position and rotation (in quaternion and euler angle formats) of a GameObject
//       and outputs them as Vector3 variables. Optionally can get local position and rotation
//       relative to a parent GameObject (if exists - otherwise returns World).

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the position and rotation of a GameObject and outputs them as a Vector3.")]
[NodeDescription("Gets the position and rotation (in quaternion and euler angle formats) of a GameObject and outputs them as Vector3 variables.\n \nTarget: GameObject to get position and rotation of.\nGet Local: Whether or not to get local position and rotation relative to a parent GameObject (if exists - otherwise returns world).\nPosition: The position of the Target GameObject.\nRotation: The rotation of the Target GameObject.\nEuler Angles: The rotation of the object in (Pitch, Yaw, Roll) format.\nForward: Gets the forward vector of the object.\nUp: Gets the up vector of the object.\nRight: Gets the right vector of the object.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Position and Rotation")]
public class uScriptAct_GetPositionAndRotation : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      GameObject Target,
      [FriendlyName("Get Local"), SocketState(false, false)] bool GetLocal,
      out Vector3 Position,
      out Quaternion Rotation,
      [FriendlyName("Euler Angles"), SocketState(false, false)] out Vector3 EulerAngles,
	  [SocketState(false, false)] out Vector3 Forward,
	  [SocketState(false, false)] out Vector3 Up,
	  [SocketState(false, false)] out Vector3 Right
      )
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
		
		Forward = Target.transform.forward;
		Up = Target.transform.up;
		Right = Target.transform.right;
   }
}