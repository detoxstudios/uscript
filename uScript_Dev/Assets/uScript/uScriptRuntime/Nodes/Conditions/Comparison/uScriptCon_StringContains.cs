// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Determines if the target string contains the specified text.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Game_Time")]

[FriendlyName("String Contains", "Determines if the target string contains the specified text. If multiple targets and/or values are used, the True socket will fire if ANY one of the targets contain ANY one of the values.")]
public class uScriptCon_StringContains : uScriptLogic
{
   private bool m_ContainsValue = false;

   [FriendlyName("True")]
   public bool True { get { return m_ContainsValue; } }

   [FriendlyName("False")]
   public bool False { get { return !m_ContainsValue; } }

   public void In(
      [FriendlyName("Target", "The target string you wish to check.")]
      string[] Target,
      
      [FriendlyName("Value", "The text you want to search for in the Target string.")]
      string[] Value
      )
   {
		bool matchFound = false;
		
		foreach (string tmpTarget in Target)
		{
			foreach (string tmpValue in Value)
			{
				if (tmpTarget.Contains(tmpValue))
				{
					matchFound = true;
				}
			}
		}
		
		m_ContainsValue = matchFound;
   }
}