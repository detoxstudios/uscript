// uScript Action Node
// (C) 2013 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Get the name of named control that has keyboard focus.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Get_Focused_Control")]

[FriendlyName("GUI Get Focused Control", "Get the name of named control that has keyboard focus.\n"
   + "\n"
   + "Control names can be applied to various GUI controls. When a named control has focus, this node"
   + " will return its name. If no control has focus or the focused control has no name set, this node"
   + " returns an empty string.")]
public class uScriptAct_GUIGetFocusedControl : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Control Name", "The name of the control that has keyboard focus.")]
      [DefaultValue("")]
      out string ControlName
      )
   {
      ControlName = GUI.GetNameOfFocusedControl();
   }
}
