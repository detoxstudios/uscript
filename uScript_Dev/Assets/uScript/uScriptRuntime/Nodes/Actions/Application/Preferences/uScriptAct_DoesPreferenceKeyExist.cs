// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Fires the appropriate signal depending on if the specified key exists in the PlayerPrefs file.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires the appropriate signal depending on if the specified key exists in the PlayerPrefs file.")]
[NodeDescription("Fires the appropriate signal depending on if the specified key exists in the PlayerPrefs file.\n\nKey Name: The name of the preference key you wish to check.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Log")]

[FriendlyName("Does Preference Key Exist")]
public class uScriptAct_DoesPreferenceKeyExist : uScriptLogic
{
   private bool m_FoundKey = false;
   
   [FriendlyName("Found")]
   public bool True { get { return m_FoundKey; } }
	
   [FriendlyName("Not Found")]
   public bool False { get { return !m_FoundKey; } }

   public void In(
      [FriendlyName("Key Name")] string KeyName
	  )
   {
      m_FoundKey = PlayerPrefs.HasKey(KeyName);
   }
}