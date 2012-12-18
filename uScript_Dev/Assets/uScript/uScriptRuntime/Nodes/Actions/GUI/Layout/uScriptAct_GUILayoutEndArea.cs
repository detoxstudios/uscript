// uScript Action Node
// (C) 2012 Detox Studios LLC
using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Close a control group started with a \"GUILayout Begin Area\" node.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUILayout_EndArea")]

[FriendlyName("GUILayout End Area", "Close a control group started with a \"GUILayout Begin Area\" node.")]
public class uScriptAct_GUILayoutEndArea : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In()
   {
      GUILayout.EndArea();
   }
}
