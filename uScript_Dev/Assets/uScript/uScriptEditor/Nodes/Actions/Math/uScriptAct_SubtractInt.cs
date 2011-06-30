// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Subtracts two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Subtracts two integer variables and returns the result.")]
[NodeDescription("Subtracts two integer variables and returns the result.\n \nA: The integer to subtract from.\nB: The integer to subtract from A.\nResult (out): The integer result of the subtraction operation.\nFloat Result (out): The floating point result of the subtraction operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Subtract_Int")]

[FriendlyName("Subtract Int")]
public class uScriptAct_SubtractInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int A, int B, [FriendlyName("Result")] out int IntResult, [FriendlyName("Float Result"), SocketState(false, false)] out float FloatResult)
   {
      IntResult = A - B;
      FloatResult = System.Convert.ToSingle(IntResult);
   }
}