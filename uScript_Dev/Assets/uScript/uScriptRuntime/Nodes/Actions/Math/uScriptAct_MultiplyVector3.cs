// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Multiplies two Vector3 variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Multiplies two Vector3 variables together and returns the result.")]
[NodeDescription("Multiplies two Vector3 variables together and returns the result.\n \nA: The first Vector3.  If more than one Vector3 variable is connected to A, they will be multiplied together before being multiplied to B.\nB: The second Vector3.  If more than one Vector3 variable is connected to B, they will be multiplied together before being multiplied to A.\nResult (out): The Vector3 result of the multiplication operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Multiply_Vector3")]

[FriendlyName("Multiply Vector3")]
public class uScriptAct_MultiplyVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector3[] A, Vector3[] B, out Vector3 Result)
   {
      Vector3 a = A[0];
      Vector3 b = B[0];

      for ( int i = 1; i < A.Length; i++ )
      {
         a.x = a.x * A[i].x;
         a.y = a.y * A[i].y;
         a.z = a.z * A[i].z;
      }

      for ( int i = 1; i < B.Length; i++ )
      {
         b.x = b.x * B[i].x;
         b.y = b.y * B[i].y;
         b.z = b.z * B[i].z;
      }

      Result.x = a.x * b.x;
      Result.y = a.y * b.y;
      Result.z = a.z * b.z;
   }
}