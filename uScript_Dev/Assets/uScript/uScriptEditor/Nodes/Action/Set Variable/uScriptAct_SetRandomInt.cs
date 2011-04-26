// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a Int variable. Min/Max ovverrides allow you to set the range of the random number.

using UnityEngine;
using System.Collections;

[NodePath("Action/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Int variable.")]
[NodeDescription("Randomly sets the value of a Int variable. Min/Max ovverrides allow you to set the range of the random number.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Random Int")]
public class uScriptAct_SetRandomInt : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Min")] int Min,
      [FriendlyName("Max")] int Max,
      [FriendlyName("Seed")] int Seed,
      [FriendlyName("Target Int")] out int TargetInt)
   {

      int RndValue;

      // Make sure we don't have min > max (or other way around)
      if (Min > Max) { Min = Max; }
      if (Max < Min) { Max = Min; }

      if (Seed > 0) { Random.seed = Seed; }

      RndValue = Random.Range(Min, Max);

      TargetInt = RndValue;

   }

}