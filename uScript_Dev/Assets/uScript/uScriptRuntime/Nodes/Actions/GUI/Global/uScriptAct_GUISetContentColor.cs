// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GUI/Global")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the current content tint color for the GUI.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("GUI Set Content Color", "Sets the current content tint color for the GUI.\n\nNOTE: This color selection only lasts for the current frame or until another color is set.")]
public class uScriptAct_GUISetContentColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Color", "The color to tint the GUI content objects with.")]
      Color color
      )
   {
      GUI.contentColor = color;
   }
}
