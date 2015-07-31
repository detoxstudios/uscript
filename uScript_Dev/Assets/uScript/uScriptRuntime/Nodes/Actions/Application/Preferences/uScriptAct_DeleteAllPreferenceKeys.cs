// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application/Preferences")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Deletes all preference keys.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Delete All Preference Keys", "Deletes all preference keys.")]
public class uScriptAct_DeleteAllPreferenceKeys : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In()
   {
      PlayerPrefs.DeleteAll();
   }
}