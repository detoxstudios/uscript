// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Fires the appropriate output link(s) depending on the comparison of the attached float variables.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires the appropriate output link(s) depending on the comparison of the attached float variables.")]
[NodeDescription("Fires the appropriate output link(s) depending on the comparison of the attached float variables.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Compare Float")]
public class uScriptCon_CompareFloat : uScriptLogic
{

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
