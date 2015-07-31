// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Determines if the target string contains the specified text.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("String Contains", "Determines if the target string contains the specified text.")]
public class uScriptCon_StringContains : uScriptLogic
{
   private bool m_ContainsValue = false;

   [FriendlyName("True")]
   public bool True { get { return m_ContainsValue; } }

   [FriendlyName("False")]
   public bool False { get { return !m_ContainsValue; } }

   public void In(
      [FriendlyName("Target", "The target string you wish to check.")]
      string Target,
      
      [FriendlyName("Value", "The text you want to search for in the Target string.")]
      string Value
      )
   {
		m_ContainsValue = Target.Contains(Value);
   }
}