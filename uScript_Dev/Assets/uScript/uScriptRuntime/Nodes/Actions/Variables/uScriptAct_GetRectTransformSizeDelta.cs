// uScript Action Node
// (C) 2016 Detox Studios LLC
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/RectTransform")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Gets the size of this RectTransform relative to the distances between the anchors.")]
[FriendlyName("Get RectTransform Size Delta", "Gets the size of this RectTransform relative to the distances between the anchors.")]
public class uScriptAct_GetRectTransformSizeDelta : uScriptLogic
{
   public bool Out { get { return true; } }

   [FriendlyName("In")]
   public void In(
      [FriendlyName("Target", "The GameObject whose RectTransform sizeDelta you wish to get.")]
		GameObject Target,

      [FriendlyName("Size Delta", "The sizeDelta of the RectTransform as a Vector2.")]
		out Vector2 SizeDelta
      )
   {
      SizeDelta = Target.GetComponent<RectTransform>().sizeDelta;
   }
}
#endif
