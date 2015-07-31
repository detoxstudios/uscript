// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the tooltip of the control that is currently being hovered over with the cursor.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Get Tooltip", "Gets the tooltip of the control that is currently being hovered over with the cursor.")]
public class uScriptAct_GUIGetToolTip : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Tooltip", "The tooltip of the control that is currently being hovered over with the cursor.")]
      out string tooltip
      )
   {
      tooltip = GUI.tooltip;
   }
}
