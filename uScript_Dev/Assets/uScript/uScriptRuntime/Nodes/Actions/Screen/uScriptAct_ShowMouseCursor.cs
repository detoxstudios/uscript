// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Shows or hides the mouse cursor.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Show Mouse Cursor", "Shows or hides the mouse cursor.")]
public class uScriptAct_ShowMouseCursor : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Show", "If true, the mouse cursor is shown, otherwise the mouse cursor is hidden.")]
      bool show
      )
   {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
      Screen.showCursor = show;
#else
      Cursor.visible = show;
#endif
   }
}