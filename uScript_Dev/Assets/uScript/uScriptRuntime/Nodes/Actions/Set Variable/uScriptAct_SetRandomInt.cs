// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a Int variable. Min/Max ovverrides allow you to set the range of the random number.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Int variable.")]
[NodeDescription("Randomly sets the value of a Int variable.\n \nMin: Minimum allowable integer value.\nMax: Maximum allowable integer value. This value is exclusive - that means if you want it to show up in random results, you will need to add 1 to it.\nSeed: Optional. Seed value for the random number generator. Using a specific seed value will generate the same random number each time. A value of zero (the default) will generate random numbers each time.\nTarget Integer (out): The integer value that gets set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Random_Int")]

[FriendlyName("Set Random Int")]
public class uScriptAct_SetRandomInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Min")] int Min,
      [FriendlyName("Max")] int Max,
      [FriendlyName("Seed"), DefaultValue(0), SocketState(false, false)] int Seed,
      [FriendlyName("Target Int")] out int TargetInt)
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

      TargetInt = Random.Range(Min, Max);
   }
}