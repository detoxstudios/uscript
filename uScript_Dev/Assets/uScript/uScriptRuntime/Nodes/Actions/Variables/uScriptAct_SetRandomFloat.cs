// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Float variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Random_Float")]

[FriendlyName("Set Random Float", "Randomly sets the value of a Float variable.")]
public class uScriptAct_SetRandomFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Min", "Minimum allowable float value.")]
      [SocketState(false, false)]
      float Min,
      
      [FriendlyName("Max", "Maximum allowable float value.")]
      [SocketState(false, false)]
      float Max,
      
      [FriendlyName("Target Float", "The random float value that gets set.")]
      out float TargetFloat
      )
   {
      // Make sure we don't have min > max (or other way around)
      if (Min > Max) { Min = Max; }

      TargetFloat = Random.Range(Min, Max);
   }
}
