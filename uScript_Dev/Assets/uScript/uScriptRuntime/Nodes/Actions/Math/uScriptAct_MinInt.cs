// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Returns the smaller of two integer variables.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the smaller of two integer variables.")]
[NodeDescription("Returns the smaller of two integer variables.\n \nA: The first of two values to be compared. Can also have multiple float variables connected.\nB: The second of two values to be compared. Can also have multiple float variables connected.\nResult (out): Smallest value passed in.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Min_Int")]

[FriendlyName("Min Int")]
public class uScriptAct_MinInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int []A, int []B, out int Result)
   {
      if (A.Length + B.Length < 2)
      {
         Result = int.MaxValue;
      }
      
      int minA = int.MaxValue;
      foreach(int a in A)
      {
         if (a < minA) minA = a;
      }
      
      int minB = int.MaxValue;
      foreach(int b in B)
      {
         if (b < minB) minB = b;
      }
      
      Result = Mathf.Min(minA, minB);
   }
}