// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Subtracts two Rect variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Subtracts two Rect variables together and returns the result.")]
[NodeDescription("Subtracts two Rect variables together and returns the result.\n \nA: The first Rect.  If more than one Rect variable is connected to A, they will be subtracted from each other before B will be subtracted from them.\nB: The second Rect.  If more than one Rect variable is connected to B, they will be subtracted from each other before being subtracted from A.\nResult (out): The Rect result of the subtractition operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Subtract_Rect")]

[FriendlyName("Subtract Rect")]
public class uScriptAct_SubtractRect : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Rect[] A, Rect[] B, out Rect Result)
   {
      Rect totalA = A.Length > 0 ? A[0] : new Rect(0,0,0,0);
      Rect totalB = B.Length > 0 ? B[0] : new Rect(0,0,0,0);

      for ( int i = 1; i < A.Length; i++ )
      {
         totalA.xMin -= A[i].xMin;
         totalA.xMax -= A[i].xMax;
         totalA.yMin -= A[i].yMin;
         totalA.yMax -= A[i].yMax;
      }

      for ( int i = 1; i < B.Length; i++ )
      {
         totalB.xMin -= B[i].xMin;
         totalB.xMax -= B[i].xMax;
         totalB.yMin -= B[i].yMin;
         totalB.yMax -= B[i].yMax;
      }

      Result = totalA;

      Result.xMin -= totalB.xMin;
      Result.xMax -= totalB.xMax;
      Result.yMin -= totalB.yMin;
      Result.yMax -= totalB.yMax;
   }
}