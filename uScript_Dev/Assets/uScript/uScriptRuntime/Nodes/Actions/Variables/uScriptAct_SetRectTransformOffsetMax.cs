// uScript Action Node
// (C) 2016 Detox Studios LLC
#if !(UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/RectTransform")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Sets the offset of the upper right corner of the rectangle relative to the upper right anchor.")]
[FriendlyName("Set RectTransform Offset Max", "Sets the offset of the upper right corner of the rectangle relative to the upper right anchor.")]
public class uScriptAct_SetRectTransformOffsetMax : uScriptLogic
{
   public bool Out { get { return true; } }

   [FriendlyName("In")]
   public void In(
      [FriendlyName("Target", "The GameObject with the RectTransform.")]
		GameObject Target,

      [FriendlyName("Position", "The position to set on the RectTransform's offsetMax as a Vector2.")]
		Vector2 Position
      )
   {
      Target.GetComponent<RectTransform>().offsetMax = Position;
   }
}
#endif
