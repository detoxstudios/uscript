// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the machine's IP address as a string")]
[NodeAuthor("Detox Studios LLC. Original node by xzlashed on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Animation Blend Weight", "Sets the blend weight of the specified animation.")]
public class uScriptAct_SetAnimationWeight : uScriptLogic {

	public delegate void uScriptEventHandler(object sender, System.EventArgs args);
	public event uScriptEventHandler Out;

   public void In(
      [FriendlyName("Target", "The GameObject containing the animtion clip.")]GameObject target,
      [FriendlyName("Animation", "The animation clip name you wish to use.")]string animationName, 
      [FriendlyName("Blend Weight", "The blend weight you wish to set (0.0 - 1.0).")][DefaultValue(1)]float weight
      )
	{
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
		if (weight >= 0 && weight <= 1)
			target.animation[animationName].weight = weight;
		else if (weight < 0)
			target.animation[animationName].weight = 0;
		else if (weight > 1)
			target.animation[animationName].weight = 1;
		if (Out != null) Out(this, new System.EventArgs());
#else
      if (weight >= 0 && weight <= 1)
         target.GetComponent<Animation>()[animationName].weight = weight;
		else if (weight < 0)
         target.GetComponent<Animation>()[animationName].weight = 0;
		else if (weight > 1)
         target.GetComponent<Animation>()[animationName].weight = 1;
		if (Out != null) Out(this, new System.EventArgs());
#endif
	}
	
}
