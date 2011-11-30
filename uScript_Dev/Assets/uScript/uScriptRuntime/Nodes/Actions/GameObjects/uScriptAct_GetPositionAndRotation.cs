// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the position and rotation of a GameObject and outputs them as a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Position_and_Rotation")]

[FriendlyName("Get Position and Rotation", "Gets the position and rotation (in quaternion and euler angle formats) of a GameObject and outputs them as Vector3 variables.")]
public class uScriptAct_GetPositionAndRotation : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject to get position and rotation of.")]
      GameObject Target,

      [FriendlyName("Get Local", "If TRUE, the return value will be relative to a its parent GameObject, otherwise it will be world-relative.")]
      [SocketState(false, false)]
      bool GetLocal,

      [FriendlyName("Position", "The position of the Target GameObject.")]
      out Vector3 Position,

      [FriendlyName("Rotation", "The rotation of the Target GameObject.")]
      out Quaternion Rotation,

      [FriendlyName("Euler Angles", "The rotation of the object in (Pitch, Yaw, Roll) format.")]
      [SocketState(false, false)]
      out Vector3 EulerAngles,
      
      [FriendlyName("Forward", "Gets the forward vector of the object.")]
      [SocketState(false, false)]
      out Vector3 Forward,

      [FriendlyName("Up", "Gets the up vector of the object.")]
      [SocketState(false, false)]
      out Vector3 Up,
      
      [FriendlyName("Right", "Gets the right vector of the object.")]
      [SocketState(false, false)]
      out Vector3 Right
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