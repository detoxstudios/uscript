// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Rewind all animations on the target GameObjects.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Rewind all animations on the target GameObjects.")]
[NodeDescription("Rewind all animations on the target GameObjects. Optionaly you can specify an animation name to rewind just that animation on the target GameObjects.\n \nTarget: The Target GameObject(s) you wish to rewind animations on.\nAnimation Name: Optionally provide an animation name to just rewind a specific animation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Rewind Animation")]
public class uScriptAct_RewindAnimation : uScriptLogic
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, [FriendlyName("Animation Name"), SocketState(false, false)] string AnimationName)
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