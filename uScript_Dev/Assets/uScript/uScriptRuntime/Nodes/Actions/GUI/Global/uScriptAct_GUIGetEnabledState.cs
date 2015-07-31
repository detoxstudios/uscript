// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current enabled state of the GUI.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Get Enabled State", "Gets the current enabled state of the GUI.")]
public class uScriptAct_GUIGetEnabledState : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Enabled", "The current enabled state of the GUI.")]
      out bool Enabled
      )
   {
      Enabled = GUI.enabled;
   }
}
