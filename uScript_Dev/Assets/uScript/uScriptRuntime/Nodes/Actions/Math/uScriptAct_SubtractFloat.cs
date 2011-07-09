// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Subtracts two float variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Subtracts two float variables and returns the result.")]
[NodeDescription("Subtracts two float variables and returns the result.\n \nA: The floating point number to subtract from.\nB: The floating point number to subtract from A.\nResult (out): The floating point result of the subtraction operation.\nInt Result (out): The integer result of the subtraction operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Subtract_Float")]

[FriendlyName("Subtract Float")]
public class uScriptAct_SubtractFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float A, float B, [FriendlyName("Result")] out float FloatResult, [FriendlyName("Int Result"), SocketState(false, false)] out int IntResult)
   {
      FloatResult = A - B;
      IntResult = System.Convert.ToInt32(FloatResult);
   }
}