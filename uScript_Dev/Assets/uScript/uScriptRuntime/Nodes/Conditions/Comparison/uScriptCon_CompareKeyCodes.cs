// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires the appropriate output link depending on the comparison of the attached KeyCode variables.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Compare KeyCodes", "Fires the appropriate output link depending on the comparison of the attached KeyCode variables.")]
public class uScriptCon_CompareKeyCodes : uScriptLogic
{

   private bool m_EqualTo = false;

   [FriendlyName("(Equal To)   =")]
   public bool EqualTo { get { return m_EqualTo; } }

   [FriendlyName("(Not Equal To)  !=")]
   public bool NotEqualTo { get { return !m_EqualTo; } }
   
   public void In(
      [FriendlyName("A", "First value to compare.")]
      KeyCode A,
      
      [FriendlyName("B", "Second value to compare.")]
      KeyCode B
      )
   {

      m_EqualTo = false;

      if (A == B)
      {
         m_EqualTo = true;
      }
           
   }
}
