// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Divides two float variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Divides two float variables and returns the result.")]
[NodeDescription("Divides two float variables and returns the result.\n \nA: The floating point numerator.\nB: The floating point denominator.\nResult (out): The floating point result of the division operation.\nInt Result (out): The integer result of the division operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Divide_Float")]

[FriendlyName("Divide Float")]
public class uScriptAct_DivideFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float A, float B, [FriendlyName("Result")] out float FloatResult, [FriendlyName("Int Result"), SocketState(false, false)] out int IntResult)
   {
      float total = A / B;
      FloatResult = total;
      IntResult = System.Convert.ToInt32(total);
   }
}