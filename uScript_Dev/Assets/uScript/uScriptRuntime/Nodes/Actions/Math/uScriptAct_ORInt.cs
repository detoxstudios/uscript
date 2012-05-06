// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: ORs two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "ORs two integer variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#OR_Int")]

[FriendlyName("OR Int", "ORs integer variables together and returns the result." +
 "\n\n[ A | B ]")]
public class uScriptAct_ORInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable or variable list.")]
      int[] A,

      [FriendlyName("B", "The second variable or variable list.")]
      int[] B,

      [FriendlyName("Result", "The integer result of the operation.")]
      out int IntResult
      )
   {
      int aTotals = 0;
      int bTotals = 0;

      foreach (int currentA in A)
      {
         aTotals |= currentA;
      }
      foreach (int currentB in B)
      {
         bTotals |= currentB;
      }

      IntResult = aTotals | bTotals;
   }
}