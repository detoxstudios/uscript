// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Divides two integer variables and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Divide_Int")]

[FriendlyName("Divide Int", "Divides two integer variables and returns the result." +
 "\n\n[ A / B ]")]
public class uScriptAct_DivideInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The numerator.")]
      int A,

      [FriendlyName("B", "The denominator.")]
      int B,
      
      [FriendlyName("Result", "The integer result of the operation.")]
      out int IntResult,

      [FriendlyName("Float Result", "The floating point result of the operation.")]
      [SocketState(false, false)]
      out float FloatResult
      )
   {
      if (B != 0)
      {
         int total = A / B;
         IntResult = total;
         FloatResult = (float)A / (float)B;
      }
      else
      {
         uScriptDebug.Log("[Divide Int] Your denominator (B) is set to zero. Dividing by zero is not possible. Returning 0 as the result.", uScriptDebug.Type.Error);
         FloatResult = 0f;
         IntResult = 0;
      }
   }
}