// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Locks and hides (or unocks and shows) the mouse cursor.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Lock Mouse Cursor", "Locks and hides (or unocks and shows) the mouse cursor.")]
public class uScriptAct_LockMouseCursor : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Lock", "If true, the mouse cursor is locked and hidden, otherwise the mouse cursor is unlocked and shown.")]
      [DefaultValue(false)]
      bool Lock
      )
   {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
      Screen.lockCursor = Lock;
#else
      if (Lock == true)
      {
         Cursor.lockState = CursorLockMode.Locked;
		 Cursor.visible = false;
      }
      else
      {
         Cursor.lockState = CursorLockMode.None;
		 Cursor.visible = true;
      }
#endif
   }
}