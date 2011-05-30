// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Multiplies two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Multiplies two integer variables together and returns the result.")]
[NodeDescription("Multiplies two integer variables together and returns the result.\n \nA: First integer to multiply. If more than one integer variable is connected to A, they will be multiplied together before being multiplied B.\nB: Second integer to multiply. If more than one integer variable is connected to B, they will be multiplied together before being multiplied A.\nResult (out): Integer result of the multiplication operation.\nFloat Result (out): Floating point result of the multiplication operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Multiply Int")]
public class uScriptAct_MultiplyInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int[] A, int[] B, [FriendlyName("Result")] out int IntResult, [FriendlyName("Float Result"), SocketState(false, false)] out float FloatResult)
   {
      int aTotals = 0;
      int bTotals = 0;

      foreach (int currentA in A)
      {
         aTotals *= currentA;
      }
      foreach (int currentB in B)
      {
         bTotals *= currentB;
      }

      IntResult = aTotals * bTotals;
      FloatResult = System.Convert.ToSingle(IntResult);
   }
}