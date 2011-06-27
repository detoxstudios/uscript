// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Adds two integer variables together and returns the result.")]
[NodeDescription("Adds two integer variables together and returns the result.\n \nA: The first integer addend. If more than one integer variable is connected to A, they will be added together before being added to B.\nB: The second integer addend.  If more than one integer variable is connected to B, they will be added together before being added to A.\nResult (out): The integer result of the addition operation.\nFloat Result (out): The floating point result of the addition operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Add Int")]
public class uScriptAct_AddInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int[] A, int[] B, [FriendlyName("Result")] out int IntResult, [FriendlyName("Float Result"), SocketState(false, false)] out float FloatResult)
   {
      int aTotals = 0;
      int bTotals = 0;

      foreach (int currentA in A)
      {
         aTotals += currentA;
      }
      foreach (int currentB in B)
      {
         bTotals += currentB;
      }

      IntResult = aTotals + bTotals;
      FloatResult = System.Convert.ToSingle(IntResult);
   }
}