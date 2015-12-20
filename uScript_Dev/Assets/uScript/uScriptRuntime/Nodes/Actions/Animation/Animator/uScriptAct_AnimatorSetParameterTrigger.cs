// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Activates a Trigger parameter of a Animator Controller on the target GameObject(s) by setting it to True.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Animator Parameter (Trigger)", "Activates a Trigger parameter of a Animator Controller on the target GameObject(s) by setting it to True.")]
public class uScriptAct_AnimatorSetParameterTrigger : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject(s) that contain the Animator Controller component with the paremeter you wish to set."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Name", "The name of the trigger parameter you wish to activate.")]
      string Name
      )
   {
      foreach (GameObject obj in Target)
      {
         Animator animController = obj.GetComponent<Animator>();
         if (null != animController)
         {
            animController.SetTrigger(Name);
         }
         else
         {
            uScriptDebug.Log("The specified Target (" + obj.ToString() + ") does not have an Animator Controller component and will be skipped.");
         }
      }
       
   }

  
}
#endif
