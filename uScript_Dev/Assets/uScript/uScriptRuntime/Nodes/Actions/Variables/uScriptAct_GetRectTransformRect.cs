// uScript Action Node
// (C) 2016 Detox Studios LLC
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/RectTransform")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Gets the calculated rectangle in the local space of the Transform.")]
[FriendlyName("Get RectTransform Rect", "Gets the calculated rectangle in the local space of the Transform.")]
public class uScriptAct_GetRectTransformRect : uScriptLogic
{
   public bool Out { get { return true; } }

   [FriendlyName("In")]
   public void In(
      [FriendlyName("Target", "The GameObject whose RectTransform Rect you wish to get.")]
		GameObject Target,

      [FriendlyName("Rect", "The Rect of the RectTransform's pivot as a Rect.")]
		out Rect RectValue
      )
   {
      RectValue = Target.GetComponent<RectTransform>().rect;
   }
}
#endif
