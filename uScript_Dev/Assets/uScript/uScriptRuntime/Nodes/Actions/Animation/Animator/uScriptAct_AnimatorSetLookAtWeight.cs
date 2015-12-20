// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Sets the look at weights.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Set Look At Weights", "Sets the Look At weights on the Target's Animator.")]
public class uScriptAct_AnimatorSetLookAtWeight : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject(s) that contains the Animator Controller component with the paremeter you wish to get."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Weight", "The global weight of the LookAt, multiplier for other parameters. (0.0 - 1.0)")]
      [DefaultValue(1f)]
      float Weight,

      [FriendlyName("Body", "Determines how much the body is involved in the LookAt. (0.0 - 1.0)")]
      [DefaultValue(0f)]
      float BodyWeight,

      [FriendlyName("Head", "Determines how much the head is involved in the LookAt. (0.0 - 1.0)")]
      [DefaultValue(1f)]
      float HeadWeight,

      [FriendlyName("Eyes", "Determines how much the eyes are involved in the LookAt. (0.0 - 1.0)")]
      [DefaultValue(0f)]
      float EyesWeight,

      [FriendlyName("Clamp Weight", "0.0 means the character is completely unrestrained in motion, 1.0 means he's completely clamped (look at becomes impossible), and 0.5 means he'll be able to move on half of the possible range (180 degrees). (0.0 - 1.0)")]
      [DefaultValue(0.5f)]
      float ClampWeight
      )
   {

      foreach (GameObject obj in Target)
      {
         Animator animController = obj.GetComponent<Animator>();
         if (null != animController)
         {
            animController.SetLookAtWeight(Weight, BodyWeight, HeadWeight, EyesWeight, ClampWeight);
         }
         else
         {
            uScriptDebug.Log("The specified Target does not have an Animator Controller component. Skipping.");
         }

      }
     
   }

}
#endif
