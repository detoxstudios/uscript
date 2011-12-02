// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the seed for the random function.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Random Seed", "Sets the seed for the random function.")]
public class uScriptAct_SetRandomSeed : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Seed", "The seed value you wish to use.")]
      int Seed
      )
   {
      Random.seed = Seed;
   }
}
