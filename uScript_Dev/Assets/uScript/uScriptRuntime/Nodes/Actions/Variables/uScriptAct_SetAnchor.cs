// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/TextMesh")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets an Anchor for a TextMesh component.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Anchor", "Sets an Anchor for a TextMesh component.")]
public class uScriptAct_SetAnchor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      TextAnchor Value,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out TextAnchor Target
      )
   {
      Target = Value;
   }
}
