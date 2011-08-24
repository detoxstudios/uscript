// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Returns the larger of two float variables.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the larger of two float variables.")]
[NodeDescription("Returns the larger of two float variables.\n \nA: The first of two values to be compared. Can also have multiple float variables connected.\nB: The second of two values to be compared. Can also have multiple float variables connected.\nResult (out): Largest value passed in.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Max_Float")]

[FriendlyName("Max Float")]
public class uScriptAct_MaxFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float []A, float []B, out float Result)
   {
      if (A.Length + B.Length < 2)
      {
         Result = float.MinValue;
      }
      
      float maxA = float.MinValue;
      foreach(float a in A)
      {
         if (a > maxA) maxA = a;
      }
      
      float maxB = float.MinValue;
      foreach(float b in B)
      {
         if (b > maxB) maxB = b;
      }
      
      Result = Mathf.Max(maxA, maxB);
   }
}