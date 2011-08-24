// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Returns the smaller of two float variables.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the smaller of two float variables.")]
[NodeDescription("Returns the smaller of two float variables.\n \nA: The first of two values to be compared. Can also have multiple float variables connected.\nB: The second of two values to be compared. Can also have multiple float variables connected.\nResult (out): Smallest value passed in.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Min_Float")]

[FriendlyName("Min Float")]
public class uScriptAct_MinFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float []A, float []B, out float Result)
   {
      if (A.Length + B.Length < 2)
      {
         Result = float.MaxValue;
      }
      
      float minA = float.MaxValue;
      foreach(float a in A)
      {
         if (a < minA) minA = a;
      }
      
      float minB = float.MaxValue;
      foreach(float b in B)
      {
         if (b < minB) minB = b;
      }
      
      Result = Mathf.Min(minA, minB);
   }
}