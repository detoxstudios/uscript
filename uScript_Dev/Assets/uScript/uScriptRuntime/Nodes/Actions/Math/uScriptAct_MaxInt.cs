// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Returns the larger of two integer variables.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the larger of two integer variables.")]
[NodeDescription("Returns the larger of two integer variables.\n \nA: The first of two values to be compared. Can also have multiple float variables connected.\nB: The second of two values to be compared. Can also have multiple float variables connected.\nResult (out): Largest value passed in.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Max_Int")]

[FriendlyName("Max Int")]
public class uScriptAct_MaxInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int []A, int []B, out int Result)
   {
      if (A.Length + B.Length < 2)
      {
         Result = int.MinValue;
      }
      
      int maxA = int.MinValue;
      foreach(int a in A)
      {
         if (a > maxA) maxA = a;
      }
      
      int maxB = int.MinValue;
      foreach(int b in B)
      {
         if (b > maxB) maxB = b;
      }
      
      Result = Mathf.Max(maxA, maxB);
   }
}