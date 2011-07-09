// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the current enabled state the GUI.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the current enabled state the GUI.")]
[NodeDescription("Sets the current enabled state the GUI.\n \nEnabled: Whether or not the current GUI should use the enabled state.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Set_Enabled_State")]

[FriendlyName("GUI Set Enabled State")]
public class uScriptAct_GUISetEnabledState : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(bool Enabled)
   {
      GUI.enabled = Enabled;
   }
}
