// uScript Action Node
// (C) 2016 Detox Studios LLC
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/RectTransform")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Gets the pivot for the attached GameObject's RectTransform.")]
[FriendlyName("Get RectTransform Pivot", "Gets the pivot for the attached GameObject's RectTransform.")]
public class uScriptAct_GetRectTransformPivot : uScriptLogic
{
   public bool Out { get { return true; } }

   [FriendlyName("In")]
   public void In(
      [FriendlyName("Target", "The GameObject whose RectTransform pivot you wish to get.")]
		GameObject Target,

      [FriendlyName("Pivot", "The pivot position of the RectTransform's pivot as a Vector2.")]
		out Vector2 Pivot
      )
   {
      Pivot = Target.GetComponent<RectTransform>().pivot;
   }
}
#endif
