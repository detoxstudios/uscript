// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Sets an AvatarTarget and a targetNormalizedTime for the current state.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Set Target", "Sets an AvatarTarget and a targetNormalizedTime for the current state.")]
public class uScriptAct_AnimatorSetTarget : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject(s) that contain the Animator Controller component with the target you wish to set."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Avatar Target", " The avatar body part that is queried.")]
      AvatarTarget BodyPart,

      [FriendlyName("Normalized Time", "The current state Time that is queried.")]
      [DefaultValue(0f)]
      float NormalizedTime
      )
   {
      foreach (GameObject obj in Target)
      {
         Animator animController = obj.GetComponent<Animator>();
         if (null != animController)
         {
            animController.SetTarget(BodyPart, NormalizedTime);
         }
         else
         {
            uScriptDebug.Log("The specified Target (" + obj.ToString() + ") does not have an Animator Controller component and will be skipped.");
         }
      }
       
   }

  
}
#endif
