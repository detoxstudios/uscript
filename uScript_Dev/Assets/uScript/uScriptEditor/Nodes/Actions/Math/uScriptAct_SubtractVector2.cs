// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Subtracts two Vector2 variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Subtracts two Vector2 variables and returns the result.")]
[NodeDescription("Subtracts two Vector2 variables and returns the result.\n \nA: The Vector2 to subtract from.\nB: The Vector2 to subtract from A.\nResult (out): The Vector2 result of the subtraction operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Subtract_Vector2")]

[FriendlyName("Subtract Vector2")]
public class uScriptAct_SubtractVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector2 A, Vector2 B, out Vector2 Result)
   {
      Result = A - B;
   }
}