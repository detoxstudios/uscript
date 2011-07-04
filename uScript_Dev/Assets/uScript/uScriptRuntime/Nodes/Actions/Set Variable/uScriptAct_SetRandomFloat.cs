// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a Float variable. Min/Max ovverrides allow you to set the range of the random number.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Float variable.")]
[NodeDescription("Randomly sets the value of a Float variable.\n \nMin: Minimum allowable float value.\nMax: Maximum allowable float value.\nSeed: Optional. Seed value for the random number generator. Using a specific seed value will generate the same random number each time. A value of zero (the default) will generate random numbers each time.\nTarget Float (out): The float value that gets set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Random_Float")]

[FriendlyName("Set Random Float")]
public class uScriptAct_SetRandomFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Min")] float Min,
      [FriendlyName("Max")] float Max,
      [FriendlyName("Seed"), DefaultValue(0), SocketState(false, false)] int Seed,
      [FriendlyName("Target Float")] out float TargetFloat)
   {
      // Make sure we don't have min > max (or other way around)
      if (Min > Max) { Min = Max; }
      if (Max < Min) { Max = Min; }

      if ( 0 != Seed )
	  {
	     Random.seed = Seed;
	  }
	  else if ( Seed == 0 )
	  {
	     Random.seed = System.Environment.TickCount;
	  }
      
      TargetFloat = Random.Range(Min, Max);
   }
}