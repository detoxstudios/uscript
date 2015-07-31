// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/GameObject")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a GameObject variable using the value of another GameOject variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set GameObject", "Sets the value of a GameObject variable using the value of another GameOject variable.")]
public class uScriptAct_SetGameObject : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      GameObject Value,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out GameObject TargetGameObject
      )
   {
      // TODO: I'm worried this won't assign the correct object.
      // uScript might need to be using InstanceIDs instead of by the name?

      TargetGameObject = Value;
   }
}
