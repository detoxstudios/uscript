// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a Float variable. Min/Max ovverrides allow you to set the range of the random number.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Float variable.")]
[NodeDescription("Randomly sets the value of a Float variable.\n \nMin: Minimum allowable float value.\nMax: Maximum allowable float value.\nSeed: Seed value for the random number generator.\nTarget Float (out): The float value that gets set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Random Float")]
public class uScriptAct_SetRandomFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Min")] float Min,
      [FriendlyName("Max")] float Max,
      [FriendlyName("Seed"), DefaultValue(0)] int Seed,
      [FriendlyName("Target Float")] out float TargetFloat)
   {
      // Make sure we don't have min > max (or other way around)
      if (Min > Max) { Min = Max; }
      if (Max < Min) { Max = Min; }

      if (Seed > 0) { Random.seed = Seed; }
      
      TargetFloat = Random.Range(Min, Max);
   }
}