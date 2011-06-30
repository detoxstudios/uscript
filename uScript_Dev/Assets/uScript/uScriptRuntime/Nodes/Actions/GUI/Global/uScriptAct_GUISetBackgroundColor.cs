// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the current background tint color for the GUI.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the current background tint color for the GUI.")]
[NodeDescription("Sets the current background tint color for the GUI. NOTE: This color selection only lasts for the current frame or until another color is set.\n \nColor: The color to tint the GUI background objects with.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Set_Background_Color")]

[FriendlyName("GUI Set Background Color")]
public class uScriptAct_GUISetBackgroundColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Color")] Color color)
   {
      GUI.backgroundColor = color;
   }
}
