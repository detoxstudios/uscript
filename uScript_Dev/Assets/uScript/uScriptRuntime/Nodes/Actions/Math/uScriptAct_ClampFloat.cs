// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Clamps a float variable between a min and a max value and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Clamp Float", "Clamps a float variable between a min and a max value and returns the result.")]
public class uScriptAct_ClampFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The value to be clamped.")]
      float Target,
      
      [FriendlyName("Min", "The minimum value to clamp to.")]
      float Min,
      
      [FriendlyName("Max", "The maximum value to clamp to.")]
      float Max,
      
      [FriendlyName("Result", "Floating-point result of the clamp operation.")]
      out float FloatResult,

      [FriendlyName("Int Result", "Integer result of the clamp operation.")]
      [SocketState(false, false)]
      out int IntResult
      )
   {
      FloatResult = Mathf.Clamp(Target, Min, Max);
      IntResult = System.Convert.ToInt32(FloatResult);
   }
}