// uScript Action Node
// (C) 2014 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip( "Multiplies two Vector2 variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[NodeDeprecated(typeof(uScriptAct_MultiplyVector2_v2))]
[FriendlyName("Multiply Vector2 (OLD)", "Multiplies Vector2 variables together and returns the result." +
 "\n\n[ A + B ]" +
 "\n\nIf more than one variable is connected to A, they will be multiplied together before being multiplied to B." +
 "\n\nIf more than one variable is connected to B, they will be multiplied together before being multiplied to A.")]
public class uScriptAct_MultiplyVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable or variable list."), AutoLinkType(typeof(Vector2))]
      Vector2[] A,
      
      [FriendlyName("B", "The second variable or variable list."), AutoLinkType(typeof(Vector2))]
      Vector2[] B,

      [FriendlyName("Result", "The Vector2 result of the operation.")]
      out Vector2 Result
      )
   {
      Vector2 a = A[0];
      Vector2 b = B[0];

      for ( int i = 1; i < A.Length; i++ )
      {
         a.x = a.x * A[i].x;
         a.y = a.y * A[i].y;
      }

      for ( int i = 1; i < B.Length; i++ )
      {
         b.x = b.x * B[i].x;
         b.y = b.y * B[i].y;
      }

      Result.x = a.x * b.x;
      Result.y = a.y * b.y;
   }
}
