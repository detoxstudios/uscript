// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Gets the weight of the layer.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Get Layer Weight", "Gets the weight of the specified layer.")]
public class uScriptAct_AnimatorGetLayerWeight : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject that contains the Animator Controller component with the paremeter you wish to get."), AutoLinkType(typeof(GameObject))]
      GameObject Target,

      [FriendlyName("Index", "The index of the layer you wish to get the weight value for.")]
      int Index,

      [FriendlyName("Weight", "The weight value returned for the specified layer.")]
      out float Weight
      )
   {
      float tmpValue = 0f;

      Animator animController = Target.GetComponent<Animator>();
      if (null != animController)
      {
         tmpValue = animController.GetLayerWeight(Index);
      }
      else
      {
         uScriptDebug.Log("The specified Target does not have an Animator Controller component. Returning 0.");
      }

      Weight = tmpValue;       
   }

}
#endif
