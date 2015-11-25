// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Adds two Vector4 variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[NodeDeprecated(typeof(uScriptAct_AddVector4_v2))]
[FriendlyName("Add Vector4 (OLD)", "Adds Vector4 variables together and returns the result." +
 "\n\n[ A + B ]" +
 "\n\nIf more than one variable is connected to A, they will be added together before being added to B." +
 "\n\nIf more than one variable is connected to B, they will be added together before being added to A.")]
public class uScriptAct_AddVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable or variable list."), AutoLinkType(typeof(Vector4))]
      Vector4[] A,

      [FriendlyName("B", "The second variable or variable list."), AutoLinkType(typeof(Vector4))]
      Vector4[] B,

      [FriendlyName("Result", "The Vector4 result of the operation.")]
      out Vector4 Result
      )
   {
      Vector4 aTotals = new Vector4(0, 0, 0, 0);
      Vector4 bTotals = new Vector4(0, 0, 0, 0);

      foreach (Vector4 currentA in A)
      {
         aTotals += currentA;
      }
      foreach (Vector4 currentB in B)
      {
         bTotals += currentB;
      }

      Result = aTotals + bTotals;
   }
}
