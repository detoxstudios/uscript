// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the current enabled state the GUI.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Set_Enabled_State")]

[FriendlyName("GUI Set Enabled State", "Sets the current enabled state the GUI.")]
public class uScriptAct_GUISetEnabledState : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Enabled", "Whether or not the current GUI should use the enabled state.")]
      bool Enabled
      )
   {
      GUI.enabled = Enabled;
   }
}
