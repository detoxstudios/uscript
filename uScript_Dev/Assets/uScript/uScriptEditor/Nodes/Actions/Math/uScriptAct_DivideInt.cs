// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Divides two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Divides two integer variables and returns the result.")]
[NodeDescription("Divides two integer variables and returns the result.\n \nA: The integer numerator.\nB: The integer denominator.\nResult (out): The integer result of the division operation.\nFloat Result (out): The floating point result of the division operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Divide Int")]
public class uScriptAct_DivideInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int A, int B, [FriendlyName("Result")] out int IntResult, [FriendlyName("Float Result"), SocketState(false, false)] out float FloatResult)
   {
      int total = A / B;
      IntResult = total;
      FloatResult = System.Convert.ToSingle(total);
   }
}