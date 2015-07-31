// uScript Action Node
// (C) 2013 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Moves keyboard focus to a named control.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Set Focused Control", "Move keyboard focus to a named control.")]
public class uScriptAct_GUISetFocusedControl : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Control Name", "The name of the control that should receive keyboard focus.")]
      [DefaultValue("")]
      string ControlName
      )
   {
      GUI.FocusControl(ControlName);
   }
}
