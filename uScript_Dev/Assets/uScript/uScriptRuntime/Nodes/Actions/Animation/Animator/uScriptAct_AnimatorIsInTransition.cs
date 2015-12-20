// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Is the specified AnimatorController layer in a transition.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Is In Transition", "Returns true if the specified AnimatorController layer in a transition.")]
public class uScriptAct_AnimatorIsInTransition : uScriptLogic
{

   //public bool Out { get { return true; } }

   public bool Out { get; private set; }

   [FriendlyName("Is True", "Fired only if the AnimatorController layer is in a transition.")]
   public bool IsTrue { get; private set; }

   [FriendlyName("Is False", "Fired only if the AnimatorController layer is not in a transition.")]
   public bool IsFalse { get; private set; }

   
   public void In(
      [FriendlyName("Target", "The target GameObject that contains the Animator Controller component you wish to check the transition on."), AutoLinkType(typeof(GameObject))]
      GameObject Target,

      [FriendlyName("Layer Index", "The index of the layer you wish to check to see if it is in transition.")]
      [DefaultValue(0)]
      int Index
      )
   {
      this.Out = true;

      Animator animController = Target.GetComponent<Animator>();
      if (null != animController)
      {
         bool tmpValue = animController.IsInTransition(Index);
         this.IsTrue = tmpValue;
         this.IsFalse = !tmpValue;
      }
      else
      {
         uScriptDebug.Log("The specified Target does not have an Animator Controller component. Skipping and firing the Out socket ONLY.");
      }
 
   }

}
#endif
