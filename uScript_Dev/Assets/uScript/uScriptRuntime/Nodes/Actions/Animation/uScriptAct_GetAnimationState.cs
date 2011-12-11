// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the machine's IP address as a string")]
[NodeAuthor("Detox Studios LLC. Original node by xzlashed on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Animation State", "Returns AnimationState properties of the specified animation attached to the target GameObject.")]
public class uScriptAct_GetAnimationState : uScriptLogic {
	
	public bool Out {get{return true;}}
	
	public void In (
	   [FriendlyName("Target", "The GameObject containing the animtion clip.")]GameObject target, 
	   [FriendlyName("Animation", "The animation clip name you wish to get information on.")]string animationName,
      [FriendlyName("Blend Weight", "Weight of the animation for blending (0.0 to 1.0).")][SocketState(false, false)]out float weight,
      [FriendlyName("Normalized Position", "The current frame of the animation as a percentage (0.0 to 1.0).")][SocketState(false, false)]out float normalizedPosition,
      [FriendlyName("Length", "The length of the animation in seconds.")] out float animLength,
	   [FriendlyName("Speed Factor", "The current animation speed (default is 1).")] out float speed,
      [FriendlyName("Layer", "The current layer of the animation (default is 0).")] out int layer,
      [FriendlyName("Wrap Mode", "The current wrap mode of the animation.")][SocketState(false, false)]out WrapMode wrapMode
	   )
	{
		weight = target.animation[animationName].weight;
		normalizedPosition = target.animation[animationName].normalizedTime;
		speed = target.animation[animationName].speed;
		layer = target.animation[animationName].layer;
		wrapMode = target.animation[animationName].wrapMode;
      animLength = target.animation[animationName].length;
	}
	
}
