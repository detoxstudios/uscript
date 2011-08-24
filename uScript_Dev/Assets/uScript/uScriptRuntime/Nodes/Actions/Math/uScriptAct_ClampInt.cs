// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Clamps an integer variable between a min and a max value and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Clamps an integer variable between a min and a max value and returns the result.")]
[NodeDescription("Clamps an integer variable between a min and a max value and returns the result.\n \nTarget: The value to be clamped.\nMin: The minimum value to clamp to.\nMax: The maximum value to clamp to.\nResult (out): Integer result of the clamp operation.\nFloat Result (out): Floating point result of the clamp operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Clamp_Int")]

[FriendlyName("Clamp Int")]
public class uScriptAct_ClampInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int Target, int Min, int Max, [FriendlyName("Result")] out int IntResult, [FriendlyName("Float Result"), SocketState(false, false)] out float FloatResult)
   {
      IntResult = Mathf.Clamp(Target, Min, Max);
      FloatResult = (float)IntResult;
   }
}