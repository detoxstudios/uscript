// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Ends a GUI control group with a local coordinate system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI End Group", "Ends a GUI control group.  Each use of this node must be matched with a prior call to \"GUI Begin Group\".\n\nNOTE: The node can directly follow a \"GUI Begin Group\" node, although any GUI controls that follow the \"GUI End Group\" will not appear inside the group.  Controls that follow the \"GUI Begin Group\" in separate chains will appear in the group.  Single node chains are the easiest way to determine which GUI controls will appear within a given group.")]
public class uScriptAct_GUIEndGroup : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In( )
   {
      GUI.EndGroup();
   }
}
