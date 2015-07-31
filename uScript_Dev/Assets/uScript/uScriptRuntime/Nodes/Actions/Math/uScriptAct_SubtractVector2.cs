// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Subtracts two Vector2 variables and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Subtract Vector2", "Subtracts two Vector2 variables and returns the result.")]
public class uScriptAct_SubtractVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The Vector2 to subtract from.")]
      Vector2 A,
      
      [FriendlyName("B", "The Vector2 to subtract from A.")]
      Vector2 B,
      
      [FriendlyName("Result", "The Vector2 result of the subtraction operation.")]
      out Vector2 Result
      )
   {
      Result = A - B;
   }
}