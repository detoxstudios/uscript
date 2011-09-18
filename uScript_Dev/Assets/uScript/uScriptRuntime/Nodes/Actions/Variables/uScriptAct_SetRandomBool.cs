// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a Bool variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Bool")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Bool variable.")]
[NodeDescription("Randomly sets the value of a Bool variable.\n \nSeed: Optional. Seed value for the random number generator. Using a specific seed value will generate the same random number each time. A value of zero (the default) will generate random numbers each time.\nTarget Bool (out): The bool value that gets set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Random_Bool")]

[FriendlyName("Set Random Bool")]
public class uScriptAct_SetRandomBool : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target Bool")] out bool TargetBool)
   {

      TargetBool = Random.Range(0, 2) > 0;
   }
}