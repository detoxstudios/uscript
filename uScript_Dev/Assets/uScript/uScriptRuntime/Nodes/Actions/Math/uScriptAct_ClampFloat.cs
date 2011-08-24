// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Clamps a float variable between a min and a max value and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Clamps a float variable between a min and a max value and returns the result.")]
[NodeDescription("Clamps a float variable between a min and a max value and returns the result.\n \nTarget: The value to be clamped.\nMin: The minimum value to clamp to.\nMax: The maximum value to clamp to.\nResult (out): Floating point result of the clamp operation.\nInt Result (out): Integer result of the clamp operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Clamp_Float")]

[FriendlyName("Clamp Float")]
public class uScriptAct_ClampFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float Target, float Min, float Max, [FriendlyName("Result")] out float FloatResult, [FriendlyName("Int Result"), SocketState(false, false)] out int IntResult)
   {
      FloatResult = Mathf.Clamp(Target, Min, Max);
      IntResult = System.Convert.ToInt32(FloatResult);
   }
}