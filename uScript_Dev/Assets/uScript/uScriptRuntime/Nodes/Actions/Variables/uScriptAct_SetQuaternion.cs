// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Quaternion variable using the value of another Quaternion variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Quaternion")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Quaternion variable using the value of another Vector4 variable.")]
[NodeDescription("Sets the value of a Quaternion variable using the value of another Quaternion variable.\n \nValue: The variable you wish to use to set the target's value.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Quaternion")]
public class uScriptAct_SetQuaternion : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Quaternion Value, [FriendlyName("Target")] out Quaternion TargetQuaternion)
   {

      TargetQuaternion = Value;

   }
}