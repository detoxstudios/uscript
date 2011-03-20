// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Fires the appropriate output link(s) depending on the comparison of the attached float variables.

using UnityEngine;
using System.Collections;

public class uScriptCon_CompareFloat : uScriptLogic
{

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
   
   public void In(float A, float B)
   {
      greaterThan = false;
      greaterThanOrEqualTo = false;
      equalTo = false;
      lessThanOrEqualTo = false;
      lessThan = false;

      if (A > B)
      {
         greaterThan = true;
      }

      if (A >= B)
      {
         greaterThanOrEqualTo = true;
      }

      if (A == B)
      {
         equalTo = true;
      }

      if (A <= B)
      {
         lessThanOrEqualTo = true;
      }

      if (A < B)
      {
         lessThan = true;
      }
           
   }
}
