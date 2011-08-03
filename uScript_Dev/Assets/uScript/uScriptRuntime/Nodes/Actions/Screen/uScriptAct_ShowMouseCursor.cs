// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current size informaiton for the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows or hides the mouse cursor.")]
[NodeDescription("Shows or hides the mouse cursor.\n\nShow: If true the mouse cursor is shown, if false the mouse cursor is hidden.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Show_Mouse_Cursor")]

[FriendlyName("Show Mouse Cursor")]
public class uScriptAct_ShowMouseCursor : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Show")] bool show
   )
   {
      Screen.showCursor = show;
   }
}