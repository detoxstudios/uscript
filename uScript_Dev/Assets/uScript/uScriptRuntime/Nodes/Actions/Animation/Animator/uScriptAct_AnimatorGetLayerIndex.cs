// uScript Action Node
// (C) 2015 Detox Studios LLC
#if UNITY_5
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Gets the index of the layer with specified name.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Get Layer Index", "Gets the index of the layer with specified name.")]
public class uScriptAct_AnimatorGetLayerIndex : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject that contains the Animator Controller component with the paremeter you wish to get."), AutoLinkType(typeof(GameObject))]
      GameObject Target,

      [FriendlyName("Name", "The name of the layer you wish to get the index for.")]
      string Name,

      [FriendlyName("Index", "The index value returned from the specified layer.")]
      out int Index
      )
   {
      int tmpValue = 0;

      Animator animController = Target.GetComponent<Animator>();
      if (null != animController)
      {
         tmpValue = animController.GetLayerIndex(Name);
      }
      else
      {
         uScriptDebug.Log("The specified Target does not have an Animator Controller component. Returning 0.");
      }

      Index = tmpValue;       
   }

}
#endif