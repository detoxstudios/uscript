// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Fires the appropriate output link(s) depending on the comparison of the attached bool variables.

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires the appropriate output link(s) depending on the comparison of the attached bool variables.")]
[NodeDescription("Fires the appropriate output link(s) depending on the comparison of the attached bool variables.\n \nA: First bool value to compare.\nB: Second bool value to compare.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Compare_Bool_Equality")]

[FriendlyName("Compare Bool Equality")]
public class uScriptCon_CompareBoolEquality : uScriptLogic
{
   private bool m_EqualTo = false;

   [FriendlyName("(Equal To)   =")]
   public bool EqualTo { get { return m_EqualTo; } }

   [FriendlyName("(Not Equal To)  !=")]
   public bool NotEqualTo { get { return !m_EqualTo; } }

   public void In(bool A, bool B)
   {
      m_EqualTo = false;

      if (A == B)
      {
         m_EqualTo = true;
      }
   }
}
