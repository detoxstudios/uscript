// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the current skin for the GUI.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Set Skin", "Sets the current skin for the GUI.\n\nNOTE: This skin selection only lasts for the current frame or until another skin is set.")]
public class uScriptAct_GUISetSkin : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Skin", "The skin to render the GUI with.")]
      [RequiresLink]
      GUISkin skin
      )
   {
      GUI.skin = skin;
   }
}
