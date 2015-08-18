// uScript Action Node
// (C) 2015 Detox Studios LLC
#if UNITY_5
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Returns true if the AnimatorState is present in the Animator's controller.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Has State", "Fires 'Is True' if the AnimatorState is present in the Animator's controller.")]
public class uScriptAct_AnimatorHasState : uScriptLogic
{

   //public bool Out { get { return true; } }

   public bool Out { get; private set; }

   [FriendlyName("Is True", "Fired only if the state is found.")]
   public bool IsTrue { get; private set; }

   [FriendlyName("Is False", "Fired only if the state was not found.")]
   public bool IsFalse { get; private set; }

   
   public void In(
      [FriendlyName("Target", "The target GameObject that contains the Animator Controller component you wish to check the state on."), AutoLinkType(typeof(GameObject))]
      GameObject Target,

      [FriendlyName("Layer Index", "The index of the layer that contains the state you wish to check.")]
      [DefaultValue(0)]
      int Index,

      [FriendlyName("State ID", "The state's fullPathHash, nameHash or shortNameHash id.")]
      [DefaultValue(0)]
      int StateID
      )
   {
      this.Out = true;

      Animator animController = Target.GetComponent<Animator>();
      if (null != animController)
      {
         bool tmpValue = animController.HasState(Index, StateID);
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