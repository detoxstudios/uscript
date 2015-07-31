// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Close a control group started with a \"GUILayout Begin Horizontal\" node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUILayout End Horizontal", "Close a control group started with a \"GUILayout Begin Horizontal\" node.")]
public class uScriptAct_GUILayoutEndHorizontal : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In()
   {
      GUILayout.EndHorizontal();
   }
}
