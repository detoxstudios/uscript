// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Determines if the target string contains the specified text.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Determines if the target string contains the specified text.")]
[NodeDescription("Determines if the target string contains the specified text.\n \nTarget: The target string you wish to check.\nValue: The text you want to search for in the Target string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Game_Time")]

[FriendlyName("String Contains")]
public class uScriptCon_StringContains : uScriptLogic
{
   private bool m_ContainsValue = false;

   [FriendlyName("True")]
   public bool True { get { return m_ContainsValue; } }

   [FriendlyName("False")]
   public bool False { get { return !m_ContainsValue; } }

   public void In([FriendlyName("Target")] string Target, [FriendlyName("Value")] string Value)
   {
		m_ContainsValue = Target.Contains(Value);
   }
}