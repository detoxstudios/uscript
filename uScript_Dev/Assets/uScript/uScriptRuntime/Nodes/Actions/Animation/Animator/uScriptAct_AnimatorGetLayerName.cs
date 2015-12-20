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

[FriendlyName("Animator Get Layer Name", "Gets the name of the layer with specified index.")]
public class uScriptAct_AnimatorGetLayerName : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject that contains the Animator Controller component with the paremeter you wish to get."), AutoLinkType(typeof(GameObject))]
      GameObject Target,

      [FriendlyName("Index", "The index of the layer you wish to get the name for.")]
      int Index,

      [FriendlyName("Name", "The name returned for the specified layer index.")]
      out string Name
      )
   {
      string tmpValue = "NOT FOUND!";

      Animator animController = Target.GetComponent<Animator>();
      if (null != animController)
      {
         tmpValue = animController.GetLayerName(Index);
      }
      else
      {
         uScriptDebug.Log("The specified Target does not have an Animator Controller component. Returning 'NOT FOUND!'.");
      }

      Name = tmpValue;       
   }

}
#endif
