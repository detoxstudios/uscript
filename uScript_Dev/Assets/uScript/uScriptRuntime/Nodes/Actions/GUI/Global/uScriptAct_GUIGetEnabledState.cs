// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current enabled state of the GUI.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current enabled state of the GUI.")]
[NodeDescription("Gets the current enabled state of the GUI.\n \nEnabled (out): The current enabled state of the GUI.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Get_Enabled_State")]

[FriendlyName("GUI Get Enabled State")]
public class uScriptAct_GUIGetEnabledState : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(out bool Enabled)
   {
      Enabled = GUI.enabled;
   }
}
