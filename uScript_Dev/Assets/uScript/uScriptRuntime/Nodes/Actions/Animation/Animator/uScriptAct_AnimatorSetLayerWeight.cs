// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Sets the layer's current weight.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Set Layer Weight", "Sets the specified layer's current weight on the Target's Animator Controller.")]
public class uScriptAct_AnimatorSetLayerWeight : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject(s) that contains the Animator Controller component with the paremeter you wish to get."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Index", "The index of the layer you wish to set the weight value for.")]
      int Index,

      [FriendlyName("Weight", "The weight value you wish to set for the specified layer.")]
      float Weight
      )
   {

      foreach (GameObject obj in Target)
      {
         Animator animController = obj.GetComponent<Animator>();
         if (null != animController)
         {
            animController.SetLayerWeight(Index, Weight);
         }
         else
         {
            uScriptDebug.Log("The specified Target does not have an Animator Controller component. Skipping.");
         }

      }
     
   }

}
#endif
