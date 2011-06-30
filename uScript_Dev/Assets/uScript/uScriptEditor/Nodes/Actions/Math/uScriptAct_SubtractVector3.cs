// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Subtracts two Vector3 variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Subtracts two Vector3 variables and returns the result.")]
[NodeDescription("Subtracts two Vector3 variables and returns the result.\n \nA: The Vector3 to subtract from.\nB: The Vector3 to subtract from A.\nResult (out): The Vector3 result of the subtraction operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Subtract_Vector3")]

[FriendlyName("Subtract Vector3")]
public class uScriptAct_SubtractVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector3 A, Vector3 B, out Vector3 Result)
   {
      Result = A - B;
   }
}