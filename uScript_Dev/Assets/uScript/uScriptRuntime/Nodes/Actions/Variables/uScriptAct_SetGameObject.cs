// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a GameObject variable using the value of another GameOject variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/GameObject")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a GameObject variable using the value of another GameOject variable.")]
[NodeDescription("Sets the value of a GameObject variable using the value of another GameOject variable.\n \nValue: The variable you wish to use to set the target's value.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_GameObject")]

[FriendlyName("Set GameObject")]
public class uScriptAct_SetGameObject : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(GameObject Value, [FriendlyName("Target")] out GameObject TargetGameObject)
   {
      // @TODO: I'm worried this won't assign the correct object.
      // uScript might need to be using InstanceIDs instead of by the name?

      TargetGameObject = Value;
   }

}