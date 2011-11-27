// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the current focused control.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the current focused control.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Set_Focused_Control")]

[FriendlyName("GUI Set Focused Control", "Sets the current focused control.")]
public class uScriptAct_GUISetFocusedControl : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Control Name", "The name of the control to give focus to.")]
      [DefaultValue("")]
      string ControlName
      )
   {
      GUI.FocusControl(ControlName);
   }
}
