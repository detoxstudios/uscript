// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Subtracts two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Subtracts two integer variables and returns the result.")]
[NodeDescription("Subtracts two integer variables and returns the result.\n \nA: The integer to subtract from. If more than one integer variable is connected to A, they will be subtracted from 0 before B is subtracted from them.\nB: The integer to subtract from A. If more than one integer variable is connected to B, they will be subtracted from 0 before being subtracted from A.\nResult (out): The integer result of the subtraction operation.\nFloat Result (out): The floating point result of the subtraction operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Subtract Int")]
public class uScriptAct_SubtractInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int[] A, int[] B, [FriendlyName("Result")] out int IntResult, [FriendlyName("Float Result")] out float FloatResult)
   {
      int aTotals = 0;
      int bTotals = 0;

      foreach (int currentA in A)
      {
         aTotals = aTotals - currentA;
      }
      foreach (int currentB in B)
      {
         bTotals = bTotals - currentB;
      }

      int m_Total = aTotals - bTotals;
      IntResult = m_Total;
      FloatResult = System.Convert.ToSingle(m_Total);
   }
}