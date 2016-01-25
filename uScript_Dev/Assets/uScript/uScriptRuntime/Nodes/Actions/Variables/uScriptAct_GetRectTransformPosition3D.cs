// uScript Action Node
// (C) 2016 Detox Studios LLC
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/RectTransform")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Gets the position for the attached GameObject's RectTransform.")]
[FriendlyName("Get RectTransform Position (3D)", "Gets the 3D position for the attached GameObject's RectTransform.")]
public class uScriptAct_GetRectTransformPosition3D : uScriptLogic
{
   public bool Out { get { return true; } }

   [FriendlyName("In")]
   public void In(
      [FriendlyName("Target", "The GameObject whose RectTransform position you wish to get.")]
		GameObject Target,

      [FriendlyName("Position", "The position of the RectTransform's anchoredPosition as a Vector3.")]
		out Vector3 Position
      )
   {
      Position = Target.GetComponent<RectTransform>().anchoredPosition3D;
   }
}
#endif
