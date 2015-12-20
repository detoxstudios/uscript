// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Rewind all animations on the target GameObjects.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Rewind Animation", "Rewind all animations on the target GameObjects. You can specify an optional animation name to rewind just that animation on the target GameObjects.")]
public class uScriptAct_RewindAnimation : uScriptLogic
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target GameObject(s) you wish to rewind animations on."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Animation Name", "(optional) Provide an animation name to just rewind a specific animation.")]
      [SocketState(false, false)]
      string AnimationName)
   {

      foreach ( GameObject currentTarget in Target )
      {
         if (currentTarget != null)
         {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
				if ("" != AnimationName)
				{
					currentTarget.animation.Rewind(AnimationName);
				}
				else
				{
					currentTarget.animation.Rewind();
				}
#else
            if ("" != AnimationName)
				{
               currentTarget.GetComponent<Animation>().Rewind(AnimationName);
				}
				else
				{
               currentTarget.GetComponent<Animation>().Rewind();
				}
#endif

         }
      }
   }

   

}