// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Subtracts two Vector4 variables and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Subtract Vector4", "Subtracts two Vector4 variables and returns the result.")]
public class uScriptAct_SubtractVector4_v2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The Vector4 to subtract from."), AutoLinkType(typeof(Vector4))]
      Vector4 A,

      [FriendlyName("B", "The Vector4 to subtract from A."), AutoLinkType(typeof(Vector4))]
      Vector4 B,

      [FriendlyName("Result", "The Vector4 result of the subtraction operation.")]
      out Vector4 Result
      )
   {
      Result = A - B;
   }
}
