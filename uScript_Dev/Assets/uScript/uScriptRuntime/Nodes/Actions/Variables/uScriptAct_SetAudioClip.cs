// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/AudioClip")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a AudioClip variable using the value of another AudioClip variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set AudioClip", "Sets the value of a AudioClip variable using the value of another AudioClip variable.")]
public class uScriptAct_SetAudioClip : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The variable you wish to use to set the target's value.")]
      AudioClip Value,

      [FriendlyName("Target", "The Target variable you wish to set.")]
      out AudioClip TargetGameObject
      )
   {
      TargetGameObject = Value;
   }
}
