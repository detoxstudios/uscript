// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Is the specified parameter controlled by an additional curve on an animation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Is Parameter Controlled By Curve", "Fires 'Is True' if a parameter is controlled by an additional curve on an animation.")]
public class uScriptAct_AnimatorIsParameterControledByCurve : uScriptLogic
{

   //public bool Out { get { return true; } }

   public bool Out { get; private set; }

   [FriendlyName("Is True", "Fired only if a parameter is controlled by an additional curve on an animation.")]
   public bool IsTrue { get; private set; }

   [FriendlyName("Is False", "Fired only if if a parameter is not controlled by an additional curve on an animation.")]
   public bool IsFalse { get; private set; }

   
   public void In(
      [FriendlyName("Target", "The target GameObject that contains the Animator Controller component that contains the parameter you wish to check."), AutoLinkType(typeof(GameObject))]
      GameObject Target,

      [FriendlyName("Name", "The name of the parameter you wish to check to see if it is in transition.")]
      string Name
      )
   {
      this.Out = true;

      Animator animController = Target.GetComponent<Animator>();
      if (null != animController)
      {
         bool tmpValue = animController.IsParameterControlledByCurve(Name);
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
