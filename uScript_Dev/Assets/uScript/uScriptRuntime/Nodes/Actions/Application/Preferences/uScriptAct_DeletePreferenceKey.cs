// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Deletes the specified preference key if found.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Deletes the specified preference key if found.")]
[NodeDescription("Deletes the specified preference key if found.\n\nKey Name: The name of the preference key you wish to delete.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Log")]

[FriendlyName("Delete Preference Key")]
public class uScriptAct_DeletePreferenceKey : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key Name")] string KeyName
	  )
   {
      PlayerPrefs.DeleteKey(KeyName);
   }
}