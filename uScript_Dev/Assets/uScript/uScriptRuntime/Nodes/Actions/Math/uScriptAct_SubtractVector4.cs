// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Subtracts two Vector4 variables and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[NodeDeprecated(typeof(uScriptAct_SubtractVector4_v2))]
[FriendlyName("Subtract Vector4 (OLD)", "Subtracts two Vector4 variables and returns the result.")]
public class uScriptAct_SubtractVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The Vector4 to subtract from. If more than one Vector4 variable is connected to A, they will be subtracted from (0, 0, 0, 0) before B is subtracted from them."), AutoLinkType(typeof(Vector4))]
      Vector4[] A,

      [FriendlyName("B", "The Vector4 to subtract from A. If more than one Vector4 variable is connected to B, they will be subtracted from (0, 0, 0, 0) before being subtracted from A."), AutoLinkType(typeof(Vector4))]
      Vector4[] B,

      [FriendlyName("Result", "The Vector4 result of the subtraction operation.")]
      out Vector4 Result
      )
   {
      Vector4 aTotals = new Vector4(0, 0, 0, 0);
      Vector4 bTotals = new Vector4(0, 0, 0, 0);

      foreach (Vector4 currentA in A)
      {
         aTotals = aTotals - currentA;
      }
      foreach (Vector4 currentB in B)
      {
         bTotals = bTotals - currentB;
      }

      Result = aTotals - bTotals;
   }
}
