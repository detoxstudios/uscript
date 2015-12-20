// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the machine's IP address as a string")]
[NodeAuthor("Detox Studios LLC. Original node by xzlashed on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Animation Layer", "Sets the animation layer of the specified animation.")]
public class uScriptAct_SetAnimationLayer : uScriptLogic {
	
	public delegate void uScriptEventHandler(object sender, System.EventArgs args);
	public event uScriptEventHandler Out;

   public void In(
      [FriendlyName("Target", "The GameObject containing the animtion clip.")]GameObject target,
      [FriendlyName("Animation", "The animation clip name you wish to use.")]string animationName,
      [FriendlyName("Layer", "The animation layer value you wish to set.")][DefaultValue(0)]int layer
      )
	{
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
		target.animation[animationName].layer = layer;
#else
      target.GetComponent<Animation>()[animationName].layer = layer;
#endif
		if (Out != null) Out(this, new System.EventArgs());
	}
}
