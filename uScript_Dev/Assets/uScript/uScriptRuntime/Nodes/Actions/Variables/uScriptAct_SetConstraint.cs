// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Constraint variable using the value of another Constraint variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Constraint")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Constraint variable using the value of another Constraint variable.")]
[NodeDescription("Sets the value of a Constraint variable using the value of another Constraint variable.n \nValue: The variable you wish to use to set the target's value.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Constraint")]
public class uScriptAct_SetConstraint : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(UnityEngine.RigidbodyConstraints Value, [FriendlyName("Target")] out UnityEngine.RigidbodyConstraints Target)
   {
      Target = Value;
   }
}