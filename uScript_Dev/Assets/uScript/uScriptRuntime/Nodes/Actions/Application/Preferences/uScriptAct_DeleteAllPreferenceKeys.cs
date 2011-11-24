// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Deletes all preference keys.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Deletes all preference keys.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Log")]

[FriendlyName("Delete All Preference Keys", "Deletes all preference keys.")]
public class uScriptAct_DeleteAllPreferenceKeys : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In()
   {
      PlayerPrefs.DeleteAll();
   }
}