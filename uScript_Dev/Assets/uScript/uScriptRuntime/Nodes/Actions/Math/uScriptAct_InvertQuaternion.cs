// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Inverts a Quaternion.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Inverts a Quaternion.")]
[NodeDescription("Inverts a Quaternion.\n \nTarget: Value to invert.\nValue (out): Inverted value ([x, y, z, w] -> [-x, -y, -z, -w]).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Invert_Vector4")]

[FriendlyName("Invert Quaternion")]
public class uScriptAct_InvertQuaternion : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Quaternion Target,
      out Quaternion Value
      )
   {
      Value = Quaternion.Inverse(Target);
   }
}