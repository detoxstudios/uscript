// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Converts a quaternion into forward and up vectors.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Converts a quaternion into forward and up vectors.")]
[NodeDescription("Converts a quaternion into forward and up vectors.\n \nResult Quaternion: The quaternion to get the forward and up vectors from.\nForward Vector (out): The forward vector component of the quaternion.\nUp Vector (out): The up vector component of the quaternion.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Vectors_From_Quaternion")]

[FriendlyName("Vectors From Quaternion")]
public class uScriptAct_VectorsFromQuaternion : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Quaternion")] Quaternion quaternion,
      [FriendlyName("Forward Vector")] out Vector3 forward,
      [FriendlyName("Up Vector")] out Vector3 up
      )
   {
      Matrix4x4 mat = Matrix4x4.TRS(Vector3.zero, quaternion, Vector3.one);
      forward = (Vector3)mat.GetColumn(2);
      up = (Vector3)mat.GetColumn(1);
   }
}