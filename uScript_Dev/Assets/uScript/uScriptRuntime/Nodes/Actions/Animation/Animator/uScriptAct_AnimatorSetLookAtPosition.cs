// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Sets the look at position.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Set Look At Position", "Sets the look at position on the Target's Animator Controller.")]
public class uScriptAct_AnimatorSetLookAtPosition : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject(s) that contains the Animator Controller component with the paremeter you wish to get."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Position", "The position that the Animator should look at (Vector 3).")]
      Vector3 Position
      )
   {

      foreach (GameObject obj in Target)
      {
         Animator animController = obj.GetComponent<Animator>();
         if (null != animController)
         {
            animController.SetLookAtPosition(Position);
         }
         else
         {
            uScriptDebug.Log("The specified Target does not have an Animator Controller component. Skipping.");
         }

      }
     
   }

}
#endif
