// uScript Action Node
// (C) 2016 Detox Studios LLC
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/RectTransform")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Gets the normalized position in the parent RectTransform that the upper right corner is anchored to.")]
[FriendlyName("Get RectTransform Anchor Max", "Gets the normalized position in the parent RectTransform that the upper right corner is anchored to.")]
public class uScriptAct_GetRectTransformAnchorMax : uScriptLogic
{
   public bool Out { get { return true; } }

   [FriendlyName("In")]
   public void In(
      [FriendlyName("Target", "The GameObject with the RectTransform.")]
		GameObject Target,

      [FriendlyName("Position", "The position of the RectTransform's anchorMax as a Vector2.")]
		out Vector2 Position
      )
   {
      Position = Target.GetComponent<RectTransform>().anchorMax;
   }
}
#endif
