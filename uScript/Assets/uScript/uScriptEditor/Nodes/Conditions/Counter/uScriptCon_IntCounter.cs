// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Increments the first attached integer variable and then performs a comparison with
//       the second attached integer variable and fires the appropriate output link based on
//       that comparison.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Counter")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Increments the first attached integer variable and then performs a comparison with the second attached integer variable and fires the appropriate output link based on that comparison.")]
[NodeDescription("Increments the first attached integer variable and then performs a comparison with the second attached integer variable and fires the appropriate output link based on that comparison.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Int Counter")]
public class uScriptCon_IntCounter : uScriptLogic
{

   private int intTotal;
   private bool initialPulse = true;

   private bool greaterThan = false;
   private bool greaterThanOrEqualTo = false;
   private bool equalTo = false;
   private bool lessThanOrEqualTo = false;
   private bool lessThan = false;

   [FriendlyName("(Greater Than)   >")]
   public bool GreaterThan { get { return greaterThan; } }

   [FriendlyName("(Greater Than or Equal To) >=")]
   public bool GreaterThanOrEqualTo { get { return greaterThanOrEqualTo; } }

   [FriendlyName("(Equal To)   =")]
   public bool EqualTo { get { return equalTo; } }

   [FriendlyName("(Less Than or Equal To) <=")]
   public bool LessThanOrEqualTo { get { return lessThanOrEqualTo; } }

   [FriendlyName("(Less Than)   <")]
   public bool LessThan { get { return lessThan; } }

   public void In(int A, int B, [FriendlyName("Current Value")] out int currentValue)
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