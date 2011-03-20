// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Subtracts two Vector3 variables together and returns the result.

using UnityEngine;
using System.Collections;

public class uScriptAct_SubtractVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector3[] A, Vector3[] B, out Vector3 Result)
   {

      Vector3 aTotals = new Vector3(0, 0, 0);
      Vector3 bTotals = new Vector3(0, 0, 0);

      foreach (Vector3 currentA in A)
      {
         aTotals = aTotals - currentA;
      }
      foreach (Vector3 currentB in B)
      {
         bTotals = bTotals - currentB;
      }

      Result = aTotals - bTotals;

   }
}