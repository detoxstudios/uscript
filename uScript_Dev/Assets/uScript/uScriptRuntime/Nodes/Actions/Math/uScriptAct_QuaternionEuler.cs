// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Converts a forward and up vector into a quaternion.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Quaternion_From_Vectors")]

[FriendlyName("Quaternion Euler", "Returns a rotation that rotates Z degrees around the Z axis, X degrees around the X axis, and Y degrees around the Y axis (in that order).")]
public class uScriptAct_QuaternionEuler : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("X", "Degrees around the X axis.")]
      float x,
      
      [FriendlyName("Y", "Degrees around the Y axis.")]
      float y,
      
      [FriendlyName("Z", "Degrees around the Z axis.")]
      float z,
      
      [FriendlyName("Result Quaternion", "The result rotation.")]
      out Quaternion result
      )
   {
      result = Quaternion.Euler(x, y, z);
   }
}