// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Quaternion")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Quaternion variable using the value of another Vector4 variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Quaternion", "Sets the value of a Quaternion variable using the value of another Quaternion variable.")]
public class uScriptAct_SetQuaternion : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      Quaternion Value,

      [FriendlyName("Target", "The Target variable you wish to set.")]
      out Quaternion TargetQuaternion
      )
   {
      TargetQuaternion = Value;
   }
}
