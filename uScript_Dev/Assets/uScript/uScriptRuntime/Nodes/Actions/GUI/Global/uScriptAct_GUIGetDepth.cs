// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current layering depth of the GUI.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current layering depth of the GUI.")]
[NodeDescription("Gets the current layering depth of the GUI.\n \nDepth (out): The current layering depth of the GUI.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("GUI Get Layer Depth")]
public class uScriptAct_GUIGetDepth : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(out int Depth)
   {
      Depth = GUI.depth;
   }
}
