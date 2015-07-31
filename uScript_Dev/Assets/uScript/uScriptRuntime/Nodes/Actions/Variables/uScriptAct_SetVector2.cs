// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector2")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Vector2 variable using the value of another Vector2 variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Vector2", "Sets the value of a Vector2 variable using the value of another Vector2 variable.")]
public class uScriptAct_SetVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      Vector2 Value,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out Vector2 TargetVector2
      )
   {
      TargetVector2 = Value;
   }
}
