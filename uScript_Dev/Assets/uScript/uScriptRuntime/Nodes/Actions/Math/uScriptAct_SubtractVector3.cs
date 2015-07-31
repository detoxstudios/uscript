// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Subtracts two Vector3 variables and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Subtract Vector3", "Subtracts two Vector3 variables and returns the result.")]
public class uScriptAct_SubtractVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The Vector3 to subtract from.")]
      Vector3 A,
      
      [FriendlyName("B", "The Vector3 to subtract from A.")]
      Vector3 B,
      
      [FriendlyName("Result", "The Vector3 result of the subtraction operation.")]
      out Vector3 Result
      )
   {
      Result = A - B;
   }
}