// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Camera")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Sets a Camera to the defined value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Camera", "Sets a Camera to the defined value.")]
public class uScriptAct_SetCamera : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      Camera Value,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out Camera Target
      )
   {
      Target = Value;
   }
}
