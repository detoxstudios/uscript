// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Transform")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a Transform variable using the value of another Transform variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Transform", "Sets the value of a Transform variable using the value of another Transform variable.")]
public class uScriptAct_SetTransform : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      Transform Value,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out Transform TargetTransform
      )
   {
      // TODO: I'm worried this won't assign the correct object.
      // uScript might need to be using InstanceIDs instead of by the name?

      TargetTransform = Value;
   }
}
