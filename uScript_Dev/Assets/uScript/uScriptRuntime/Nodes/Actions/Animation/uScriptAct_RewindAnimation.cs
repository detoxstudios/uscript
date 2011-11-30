// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Rewind all animations on the target GameObjects.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Rewind Animation", "Rewind all animations on the target GameObjects. You can specify an optional animation name to rewind just that animation on the target GameObjects.")]
public class uScriptAct_RewindAnimation : uScriptLogic
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target GameObject(s) you wish to rewind animations on.")]
      GameObject[] Target,

      [FriendlyName("Animation Name", "(optional) Provide an animation name to just rewind a specific animation.")]
      [SocketState(false, false)]
      string AnimationName)
   {

      foreach ( GameObject currentTarget in Target )
      {
         if (currentTarget != null)
         {
				if ("" != AnimationName)
				{
					currentTarget.animation.Rewind(AnimationName);
				}
				else
				{
					currentTarget.animation.Rewind();
				}

         }
      }
   }

   

}