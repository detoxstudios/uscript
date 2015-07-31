// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Controls")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Ends a GUI control scrollview with a local coordinate system.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI End ScrollView", "Ends a GUI control scrollview with a local coordinate system. Each use of this node must be matched with a prior call to \"GUI Begin ScrollView\".\n\nNOTE: The node can directly follow a \"GUI Begin ScrollView\" node, although any GUI controls that follow the \"GUI End ScrollView\" will not appear inside the scrollview.  Controls that follow the \"GUI Begin ScrollView\" in separate chains will appear in the scrollview.  Single node chains are the easiest way to determine which GUI controls will appear within a given scrollview.")]
public class uScriptAct_GUIEndScrollView : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In( )
   {
      GUI.EndScrollView();
   }
}
