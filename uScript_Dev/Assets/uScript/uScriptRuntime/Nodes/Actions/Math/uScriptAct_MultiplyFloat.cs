// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Multiplies two float variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Multiplies two float variables together and returns the result.")]
[NodeDescription("Multiplies two float variables together and returns the result.\n \nA: First floating point number to multiply. If more than one floating point variable is connected to A, they will be multiplied together before being multiplied by B.\nB: Second floating point number to multiply. If more than one floating point variable is connected to B, they will be multiplied together before being multiplied by A.\nResult (out): Floating point result of the multiplication operation.\nInt Result (out): Integer result of the multiplication operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Multiply_Float")]

[FriendlyName("Multiply Float")]
public class uScriptAct_MultiplyFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float[] A, float[] B, [FriendlyName("Result")] out float FloatResult, [FriendlyName("Int Result"), SocketState(false, false)] out int IntResult)
   {
      float aTotals = 1;
      float bTotals = 1;

      foreach (float currentA in A)
      {
         aTotals *= currentA;
      }
      foreach (float currentB in B)
      {
         bTotals *= currentB;
      }

      FloatResult = aTotals * bTotals;
      IntResult = System.Convert.ToInt32(FloatResult);
   }
}