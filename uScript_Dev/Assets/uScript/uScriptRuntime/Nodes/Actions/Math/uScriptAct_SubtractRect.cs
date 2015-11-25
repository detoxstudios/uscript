// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Subtracts two Rect variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[NodeDeprecated(typeof(uScriptAct_SubtractRect_v2))]
[FriendlyName("Subtract Rect (OLD)", "Subtracts Rect variables and returns the result.")]
public class uScriptAct_SubtractRect : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first Rect.  If more than one Rect variable is connected to A, they will be subtracted from each other before B will be subtracted from them.")]
      Rect[] A,

      [FriendlyName("B", "The second Rect.  If more than one Rect variable is connected to B, they will be subtracted from each other before being subtracted from A.")]
      Rect[] B,
      
      [FriendlyName("Result", "The Rect result of the subtractition operation.")]
      out Rect Result
      )
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
