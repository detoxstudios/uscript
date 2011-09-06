// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Shows a GUILabel on the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Ends a GUI control group with a local coordinate system.")]
[NodeDescription("NOTE: Each use of those node. must be matched with a prior call to \"GUI Begin Group\".\n\n" +
					"Ends a GUI control group with a local coordinate system.  The node can directly follow a \"GUI Begin Group\" node, although any GUI controls that follow the \"GUI End Group\" will not appear inside the group.  Controls that follow the \"GUI Begin Group\" in separate chains will appear in the group.  Single node chains are the easiest way to determine which GUI controls will appear within a given group.\n\n")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Label")]

[FriendlyName("GUI End Group")]
public class uScriptAct_GUIEndGroup : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In( )
   {
      GUI.EndGroup();
   }
}