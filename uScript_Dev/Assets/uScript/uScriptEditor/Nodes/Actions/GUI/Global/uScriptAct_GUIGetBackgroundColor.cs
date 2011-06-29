// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current background tint color for the GUI.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current background tint color for the GUI.")]
[NodeDescription("Gets the current background tint color for the GUI.\n \nColor (out): The current color that the GUI background objects are tinted with.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("GUI Get Background Color")]
public class uScriptAct_GUIGetBackgroundColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Color")] out Color color)
   {
      color = GUI.backgroundColor;
   }
}
