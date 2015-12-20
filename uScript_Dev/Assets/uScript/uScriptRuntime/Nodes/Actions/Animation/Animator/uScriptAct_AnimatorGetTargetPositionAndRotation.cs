// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Gets the name of the layer with specified index.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Get Target Position and Rotation", "Gets the position and rotation of an Animator's target.")]
public class uScriptAct_AnimatorGetTargetPositionAndRotation : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject that contains the Animator's target you wish to get informaiton for."), AutoLinkType(typeof(GameObject))]
      GameObject Target,

      [FriendlyName("Position", "Returns the position of the target specified by the Animator Set Target node.")]
      out Vector3 Position,

      [FriendlyName("Rotation", "Returns the rotation of the target specified by the Animator Set Target node.")]
      out Quaternion Rotation
      )
   {
      Vector3 tmpPosition = new Vector3(0, 0, 0);
      Quaternion tmpRotation = new Quaternion(0, 0, 0, 0);

      Animator animController = Target.GetComponent<Animator>();
      if (null != animController)
      {
         tmpPosition = animController.targetPosition;
         tmpRotation = animController.targetRotation;
      }
      else
      {
         uScriptDebug.Log("The specified Target does not have an Animator Controller component. Returning default '0' values'.");
      }

      Position = tmpPosition;
      Rotation = tmpRotation;
   }

}
#endif
