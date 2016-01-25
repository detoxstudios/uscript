// uScript Action Node
// (C) 2016 Detox Studios LLC
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/RectTransform")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Gets the offset of the lower left corner of the rectangle relative to the lower left anchor.")]
[FriendlyName("Get RectTransform Offset Min", "Gets the offset of the lower left corner of the rectangle relative to the lower left anchor.")]
public class uScriptAct_GetRectTransformOffsetMin : uScriptLogic
{
   public bool Out { get { return true; } }

   [FriendlyName("In")]
   public void In(
      [FriendlyName("Target", "The GameObject with the RectTransform.")]
		GameObject Target,

      [FriendlyName("Position", "The position of the RectTransform's offsetMin as a Vector2.")]
		out Vector2 Position
      )
   {
      Position = Target.GetComponent<RectTransform>().offsetMin;
   }
}
#endif
