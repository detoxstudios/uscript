// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Rebind all the animated properties and mesh data with the specified Animator.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Rebind", "Rebind all the animated properties and mesh data with the specified Animator. This can be used when you manually change your GameObject hierarchy by script/graph, like combining meshes or swap a complete transform hierarchy.")]
public class uScriptAct_AnimatorRebind : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject(s) that contains the Animator Controller you wish to perform a rebind on."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target
      )
   {
      foreach (GameObject obj in Target)
      {
         Animator animController = obj.GetComponent<Animator>();
         if (null != animController)
         {
            animController.Rebind();
         }
         else
         {
            uScriptDebug.Log("The specified Target does not have an Animator Controller component. Skipping.");
         }
      }
      
  
   }

}
#endif
