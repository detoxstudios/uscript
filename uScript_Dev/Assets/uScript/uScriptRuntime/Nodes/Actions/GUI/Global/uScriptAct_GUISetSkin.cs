// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the current skin for the GUI.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the current skin for the GUI.")]
[NodeDescription("Sets the current skin for the GUI. NOTE: This skin selection only lasts for the current frame or until another skin is set.\n \nSkin: The skin to render the GUI with.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#GUI_Set_Skin")]

[FriendlyName("GUI Set Skin")]
public class uScriptAct_GUISetSkin : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([RequiresLink][FriendlyName("Skin")] GUISkin skin)
   {
      GUI.skin = skin;
   }
}