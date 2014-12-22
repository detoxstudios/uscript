// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the machine's IP address as a string")]
[NodeAuthor("Detox Studios LLC. Original node by xzlashed on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Animation Speed", "Sets the animation speed of the specified animation.")]
public class uScriptAct_SetAnimationSpeed : uScriptLogic {
	
	public delegate void uScriptEventHandler(object sender, System.EventArgs args);
	public event uScriptEventHandler Out;

   public void In(
      [FriendlyName("Target", "The GameObject containing the animtion clip.")]GameObject target,
      [FriendlyName("Animation", "The animation clip name you wish to use.")]string animationName,
      [FriendlyName("Speed Factor", "The speed of the animation.")][DefaultValue(1.0f)]float speed
      )
	{
#if (UNITY_3_0 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6)
		target.animation[animationName].speed = speed;
#else
      target.GetComponent<Animation>()[animationName].speed = speed;
#endif
		if (Out != null) Out(this, new System.EventArgs());
	}
}
