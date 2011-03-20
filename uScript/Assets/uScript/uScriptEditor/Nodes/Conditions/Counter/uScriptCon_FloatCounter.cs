// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Increments the first attached float variable and then performs a comparison with
//       the second attached float variable and fires the appropriate output link based on
//       that comparison.

using UnityEngine;
using System.Collections;

public class uScriptCon_FloatCounter : uScriptLogic
{

   private float floatTotal;
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

   public void In(float A, float B, out float currentValue)
   {

      greaterThan = false;
      greaterThanOrEqualTo = false;
      equalTo = false;
      lessThanOrEqualTo = false;
      lessThan = false;

      if (initialPulse)
      {
         floatTotal = A;
         initialPulse = false;
      }

      floatTotal++;
      currentValue = floatTotal;

      if (floatTotal > B)
      {
         greaterThan = true;
      }

      if (floatTotal >= B)
      {
         greaterThanOrEqualTo = true;
      }

      if (floatTotal == B)
      {
         equalTo = true;
      }

      if (floatTotal <= B)
      {
         lessThanOrEqualTo = true;
      }

      if (floatTotal < B)
      {
         lessThan = true;
      }

   }
}