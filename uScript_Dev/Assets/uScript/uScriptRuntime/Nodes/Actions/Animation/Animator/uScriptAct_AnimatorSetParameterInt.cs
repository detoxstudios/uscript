// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Sets the specified parameter of a Animator Controller on the target GameObject(s).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Animator Parameter (Int)", "Sets the specified parameter of a Animator Controller on the target GameObject(s).")]
public class uScriptAct_AnimatorSetParameterInt : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject(s) that contain the Animator Controller component with the paremeter you wish to set."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Name", "The name of the parameter you wish to set.")]
      string Name,

      [FriendlyName("Value", "The value you wish to set the specified parameter to.")]
      [DefaultValue(0)]
      int Value
      )
   {
      foreach (GameObject obj in Target)
      {
         Animator animController = obj.GetComponent<Animator>();
         if (null != animController)
         {
            animController.SetInteger(Name, Value);
         }
         else
         {
            uScriptDebug.Log("The specified Target (" + obj.ToString() + ") does not have an Animator Controller component and will be skipped.");
         }
      }
       
   }

  
}
#endif
