// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/KeyCode")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets an KeyCode to the defined value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set KeyCode", "Sets an KeyCode to the defined value.")]
public class uScriptAct_SetKeyCode : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      KeyCode Value,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out KeyCode Target
      )
   {
      Target = Value;
   }
}
