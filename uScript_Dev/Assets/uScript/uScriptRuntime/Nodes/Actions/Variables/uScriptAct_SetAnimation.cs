// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Animation variable using the value of another Animation variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Animation", "Sets the value of a Animation variable using the value of another Animation variable.")]
public class uScriptAct_SetAnimation : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      Animation Value,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out Animation TargetAnim
      )
   {
      TargetAnim = Value;
   }
}
