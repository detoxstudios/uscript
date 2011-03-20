// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Subtracts two Vector4 variables together and returns the result.

using UnityEngine;
using System.Collections;

public class uScriptAct_SubtractVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector4[] A, Vector4[] B, out Vector4 Result)
   {

      Vector4 aTotals = new Vector4(0, 0, 0, 0);
      Vector4 bTotals = new Vector4(0, 0, 0, 0);

      foreach (Vector4 currentA in A)
      {
         aTotals = aTotals - currentA;
      }
      foreach (Vector4 currentB in B)
      {
         bTotals = bTotals - currentB;
      }

      Result = aTotals - bTotals;

   }
}