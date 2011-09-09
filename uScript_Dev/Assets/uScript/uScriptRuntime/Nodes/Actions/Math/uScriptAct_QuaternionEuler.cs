// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Converts a forward and up vector into a quaternion.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Converts a forward and up vector into a quaternion.")]
[NodeDescription("Converts a forward and up vector into a quaternion.\n \nForward Vector: The forward vector component of the quaternion.\nUp Vector: The up vector component of the quaternion.\nResult Quaternion (out): The quaternion calculated using the forward and up vectors passed in.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Quaternion_From_Vectors")]

[FriendlyName("Quaternion Euler")]
public class uScriptAct_QuaternionEuler : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      float x,
      float y,
      float z,
      [FriendlyName("Result Quaternion")] out Quaternion result
      )
   {
      result = Quaternion.Euler(x, y, z);
   }
}