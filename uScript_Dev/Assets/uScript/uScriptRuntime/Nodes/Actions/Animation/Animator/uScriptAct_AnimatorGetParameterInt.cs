// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5 || UNITY_2017 || UNITY_2017_1_OR_NEWER)
using UnityEngine;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Gets the specified parameter of a Animator Controller on the target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Animator Parameter (Int)", "Gets the specified parameter of a Animator Controller on the target GameObject.")]
public class uScriptAct_AnimatorGetParameterInt : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject that contains the Animator Controller component with the paremeter you wish to get."), AutoLinkType(typeof(GameObject))]
      GameObject Target,

      [FriendlyName("Name", "The name of the parameter you wish to get.")]
      string Name,

      [FriendlyName("Value", "The value of the specified paramater.")]
      out int Value
      )
   {
      int tmpValue = 0;

      Animator animController = Target.GetComponent<Animator>();
      if (null != animController)
      {
         tmpValue = animController.GetInteger(Name);
      }
      else
      {
         uScriptDebug.Log("The specified Target does not have an Animator Controller component. Returning 0.");
      }

      Value = tmpValue;       
   }

}
#endif
