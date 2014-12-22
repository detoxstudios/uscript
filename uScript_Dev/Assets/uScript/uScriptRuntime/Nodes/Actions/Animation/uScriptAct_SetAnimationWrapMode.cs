// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the machine's IP address as a string")]
[NodeAuthor("Detox Studios LLC. Original node by xzlashed on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Animation Wrap Mode", "Sets the wrap mode of the specified animation.")]
public class uScriptAct_SetAnimationWrapMode : uScriptLogic
{

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   public event uScriptEventHandler Out;

   public void In(
      [FriendlyName("Target", "The GameObject containing the animtion clip.")]GameObject target,
      [FriendlyName("Animation", "The animation clip name you wish to use.")]string animationName,
      [FriendlyName("Wrap Mode", "The wrap mode you wish to set.")][DefaultValue(WrapMode.Once)]WrapMode wrapMode
      )
   {
#if (UNITY_3 || UNITY_4)
      target.animation[animationName].wrapMode = wrapMode;
#else
      target.GetComponent<Animation>()[animationName].wrapMode = wrapMode;
#endif

      if (Out != null) Out(this, new System.EventArgs());
   }

}
