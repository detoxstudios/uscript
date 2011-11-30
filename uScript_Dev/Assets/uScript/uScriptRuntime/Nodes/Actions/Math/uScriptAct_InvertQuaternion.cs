// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Inverts a Quaternion.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Invert_Vector4")]

[FriendlyName("Invert Quaternion", "Returns the inverse value of a Quaternion variable." +
 "\n\nExample:" +
 "\n\t[x, y, z, w] -> [-x, -y, -z, -w]")]
public class uScriptAct_InvertQuaternion : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "Value to invert.")]
      Quaternion Target,

      [FriendlyName("Value", "The inverted value.")]
      out Quaternion Value
      )
   {
      Value = Quaternion.Inverse(Target);
   }
}