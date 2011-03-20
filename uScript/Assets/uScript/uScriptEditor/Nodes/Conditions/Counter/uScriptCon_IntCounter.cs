// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Increments the first attached integer variable and then performs a comparison with
//       the second attached integer variable and fires the appropriate output link based on
//       that comparison.

using UnityEngine;
using System.Collections;

public class uScriptCon_IntCounter : uScriptLogic
{

   private int intTotal;
   private bool initialPulse = true;

   private bool greaterThan = false;
   private bool greaterThanOrEqualTo = false;
   private bool equalTo = false;
   private bool lessThanOrEqualTo = false;
   private bool lessThan = false;

   public bool GreaterThan { get { return greaterThan; } }
   public bool GreaterThanOrEqualTo { get { return greaterThanOrEqualTo; } }
   public bool EqualTo { get { return equalTo; } }
   public bool LessThanOrEqualTo { get { return lessThanOrEqualTo; } }
   public bool LessThan { get { return lessThan; } }

   public void In(int A, int B, out int currentValue)
   {

      greaterThan = false;
      greaterThanOrEqualTo = false;
      equalTo = false;
      lessThanOrEqualTo = false;
      lessThan = false;

      if (initialPulse)
      {
         intTotal = A;
         initialPulse = false;
      }

      intTotal++;
      currentValue = intTotal;

      if (intTotal > B)
      {
         greaterThan = true;
      }

      if (intTotal >= B)
      {
         greaterThanOrEqualTo = true;
      }

      if (intTotal == B)
      {
         equalTo = true;
      }

      if (intTotal <= B)
      {
         lessThanOrEqualTo = true;
      }

      if (intTotal < B)
      {
         lessThan = true;
      }

   }
}