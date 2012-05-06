// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Multiplies two integer variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Multiply_Int")]

[FriendlyName("Multiply Int", "Multiplies integer variables together and returns the result." +
 "\n\n[ A * B ]" +
 "\n\nIf more than one variable is connected to A, they will be multiplied together before being multiplied by B." +
 "\n\nIf more than one variable is connected to B, they will be multiplied together before being multiplied by A.")]
public class uScriptAct_MultiplyInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable or variable list.")]
      int[] A,

      [FriendlyName("B", "The second variable or variable list.")]
      int[] B,

      [FriendlyName("Result", "The integer result of the operation.")]
      out int IntResult,

      [FriendlyName("Float Result", "The floating-point result of the operation.")]
      [SocketState(false, false)]
      out float FloatResult
      )
   {
      int aTotals = 1;
      int bTotals = 1;

      foreach (int currentA in A)
      {
         aTotals *= currentA;
      }
      foreach (int currentB in B)
      {
         bTotals *= currentB;
      }

      IntResult = aTotals * bTotals;
      FloatResult = System.Convert.ToSingle(IntResult);
   }
}