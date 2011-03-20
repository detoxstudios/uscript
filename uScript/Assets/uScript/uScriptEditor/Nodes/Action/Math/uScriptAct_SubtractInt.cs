// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Subtracts two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

public class uScriptAct_SubtractInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int[] A, int[] B, out int IntResult, out float FloatResult)
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