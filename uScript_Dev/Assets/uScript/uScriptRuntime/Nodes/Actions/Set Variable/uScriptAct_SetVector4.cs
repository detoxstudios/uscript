// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Vector4 variable using the value of another Vector4 variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Vector4 variable using the value of another Vector4 variable.")]
[NodeDescription("Sets the value of a Vector4 variable using the value of another Vector4 variable.\n \nValue: The variable you wish to use to set the target's value.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Vector4")]

[FriendlyName("Set Vector4")]
public class uScriptAct_SetVector4 : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Vector4 Value, [FriendlyName("Target")] out Vector4 TargetVector4)
   {

      TargetVector4 = Value;

   }
}