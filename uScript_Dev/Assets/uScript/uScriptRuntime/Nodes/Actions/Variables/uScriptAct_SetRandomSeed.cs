// uScript Action Node
// (C) 2011-2016 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables")]

[NodeCopyright("Copyright 2011-2016 by Detox Studios LLC")]
[NodeToolTip("Sets the seed for the random function.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random Seed", "Sets the seed for the random function.")]
public class uScriptAct_SetRandomSeed : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Seed", "The seed value you wish to use.")]
      int Seed
      )
   {
#if (UNITY_3_5 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3)
      Random.seed = Seed;
#else
      Random.InitState(Seed);
#endif

   }

}
