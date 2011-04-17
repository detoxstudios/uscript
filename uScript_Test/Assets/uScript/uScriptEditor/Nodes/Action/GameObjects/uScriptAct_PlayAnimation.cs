// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Play the specified animation on the target object. Animation must
//       exist in the GameObject's AnimationClip.

using UnityEngine;
using System.Collections;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Play the specified animation on the target object.")]
[NodeDescription("Play the specified animation on the target object. Animation must exist in the GameObject's AnimationClip.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Play Animation")]
public class uScriptAct_PlayAnimation : uScriptLogic
{

   public bool Out { get { return true; } }
   //TODO: Have another output that fired when the animation is done.

   public void In(GameObject[] Target, string Animation, [FriendlyName("Speed Factor")] float SpeedFactor, [FriendlyName("Stop Other Animation")] bool StopOtherAnimations)
   {
      foreach ( GameObject currentTarget in Target )
      {
         if (currentTarget != null)
         {

            if (SpeedFactor == 0F)
            {
               currentTarget.animation[Animation].speed = 1.0F;
            }
            else
            {
               
               currentTarget.animation[Animation].speed = SpeedFactor;
            }

            if (StopOtherAnimations)
            {
               currentTarget.animation.Play(PlayMode.StopAll);
            }

            if (SpeedFactor < 0)
            {
               // Needed to play in reverse with a negative speed
               currentTarget.animation[Animation].time = currentTarget.animation[Animation].length;
            }
            currentTarget.animation.Play(Animation);
         }
      }
   }
}