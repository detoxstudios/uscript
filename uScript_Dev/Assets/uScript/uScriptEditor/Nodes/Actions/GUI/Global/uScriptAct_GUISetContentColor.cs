// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the current content tint color for the GUI.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the current content tint color for the GUI.")]
[NodeDescription("Sets the current content tint color for the GUI. NOTE: This color selection only lasts for the current frame or until another color is set.\n \nColor: The color to tint the GUI content objects with.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("GUI Set Content Color")]
public class uScriptAct_GUISetContentColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Color")] Color color)
   {
      GUI.contentColor = color;
   }
}
