// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the seed for the random function.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the seed for the random function.")]
[NodeDescription("Sets the seed for the random function.\n \nVSeed: The seed value you wish to use.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Random Seed")]
public class uScriptAct_SetRandomSeed : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int Seed)
   {
      Random.seed = Seed;
   }
}