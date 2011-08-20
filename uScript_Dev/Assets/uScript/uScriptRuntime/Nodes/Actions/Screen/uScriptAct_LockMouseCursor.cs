// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Locks and hides (or unocks and shows) the mouse cursor.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Locks and hides (or unocks and shows) the mouse cursor.")]
[NodeDescription("Locks and hides (or unocks and shows) the mouse cursor.\n\nLock: If true the mouse cursor is locked and hidden, if false the mouse cursor unlocked and shown.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Show_Mouse_Cursor")]

[FriendlyName("Lock Mouse Cursor")]
public class uScriptAct_LockMouseCursor : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Lock"), DefaultValue(false)] bool Lock
   )
   {
      Screen.lockCursor = Lock;
   }
}