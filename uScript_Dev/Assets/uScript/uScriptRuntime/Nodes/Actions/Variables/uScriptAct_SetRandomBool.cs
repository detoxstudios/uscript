// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Bool")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Bool variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Random_Bool")]

[FriendlyName("Set Random Bool", "Randomly sets the value of a Bool variable to True or False.")]
public class uScriptAct_SetRandomBool : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target Bool", "The random bool value that gets set.")]
      out bool TargetBool
      )
   {
      TargetBool = Random.Range(0, 2) > 0;
   }
}
