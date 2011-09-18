// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the value of a Vector2 variable using the value of another Vector2 variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector2")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Vector2 variable using the value of another Vector2 variable.")]
[NodeDescription("Sets the value of a Vector2 variable using the value of another Vector2 variable.\n \nValue: The variable you wish to use to set the target's value.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Vector2")]

[FriendlyName("Set Vector2")]
public class uScriptAct_SetVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector2 Value, [FriendlyName("Target")] out Vector2 TargetVector2)
   {
      TargetVector2 = Value;
   }
}