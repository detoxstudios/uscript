// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Increments the first attached float variable and then performs a comparison with
//       the second attached float variable and fires the appropriate output link based on
//       that comparison.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Counter")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Increments the first attached float variable and then performs a comparison with the second attached float variable and fires the appropriate output link based on that comparison.")]
[NodeDescription("Increments the first attached float variable and then performs a comparison with the second attached float variable and fires the appropriate output link based on that comparison.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Float Counter")]
public class uScriptCon_FloatCounter : uScriptLogic
{

   private float floatTotal;
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

   public void In(float A, float B, [FriendlyName("Current Value")] out float currentValue)
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