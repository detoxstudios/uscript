// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/AudioClip")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a AudioClip variable using the value of another AudioClip variable.")]
[NodeDescription("Sets the value of a AudioClip variable using the value of another AudioClip variable.\n \nValue: The variable you wish to use to set the target's value.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_GameObject")]

[FriendlyName("Set AudioClip")]
public class uScriptAct_SetAudioClip : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(AudioClip Value, [FriendlyName("Target")] out AudioClip TargetGameObject)
   {
      TargetGameObject = Value;
   }

}