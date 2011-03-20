// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Subtracts two float variables together and returns the result.

using UnityEngine;
using System.Collections;

public class uScriptAct_SubtractFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float[] A, float[] B, out float FloatResult, out int IntResult)
   {
      float aTotals = 0F;
      float bTotals = 0F;

      foreach (float currentA in A)
      {
         aTotals = aTotals - currentA;
      }
      foreach (float currentB in B)
      {
         bTotals = bTotals - currentB;
      }

      float m_Total = aTotals - bTotals;
      FloatResult = m_Total;
      IntResult = System.Convert.ToInt32(m_Total);

   }
}