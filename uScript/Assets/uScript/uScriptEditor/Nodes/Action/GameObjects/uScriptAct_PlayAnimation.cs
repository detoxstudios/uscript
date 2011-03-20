// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Play the specified animation on the target object. Animation must
//       exist in the GameObject's AnimationClip.

using UnityEngine;
using System.Collections;

public class uScriptAct_PlayAnimation : uScriptLogic
{

   public bool Out { get { return true; } }
   //TODO: Have another output that fired when the animation is done.

   public void In(GameObject[] Target, string Animation, float SpeedFactor, bool StopOtherAnimations)
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

            currentTarget.animation.Play(Animation);
         }
      }
   }
}