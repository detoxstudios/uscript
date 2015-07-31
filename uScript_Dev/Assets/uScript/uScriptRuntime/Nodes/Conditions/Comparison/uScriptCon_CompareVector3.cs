// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Compares two Vector3 variables and outputs accordingly.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Compare Vector3", "Compares two Vector3 variables and outputs accordingly.")]
public class uScriptCon_CompareVector3 : uScriptLogic
{
   private bool m_CompareValue = false;

   public bool Same { get { return m_CompareValue; } }
   public bool Different { get { return !m_CompareValue; } }

   public void In(
      [FriendlyName("A", "First value to compare.")]
      Vector3 A,

      [FriendlyName("B", "Second value to compare.")]
      Vector3 B
      )
   {
      m_CompareValue = A == B;
   }
}