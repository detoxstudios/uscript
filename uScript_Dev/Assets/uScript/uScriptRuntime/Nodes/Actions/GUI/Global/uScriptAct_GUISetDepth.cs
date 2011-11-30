// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the current layering depth of the GUI.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("GUI Set Layer Depth", "Sets the current layering depth of the GUI.")]
public class uScriptAct_GUISetDepth : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Depth", "The integer depth to use when rendering subsequent controls. Lower numbers are farther into the screen.")]
      int Depth
      )
   {
      GUI.depth = Depth;
   }
}
