// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Subtracts two Vector3 variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Subtracts two Vector3 variables and returns the result.")]
[NodeDescription("Subtracts two Vector3 variables and returns the result.\n \nA: The Vector3 to subtract from. If more than one Vector3 variable is connected to A, they will be subtracted from (0, 0, 0) before B is subtracted from them.\nB: The Vector3 to subtract from A. If more than one Vector3 variable is connected to B, they will be subtracted from (0, 0, 0) before being subtracted from A.\nResult (out): The Vector3 result of the subtraction operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Subtract Vector3")]
public class uScriptAct_SubtractVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector3[] A, Vector3[] B, out Vector3 Result)
   {
      Vector3 aTotals = new Vector3(0, 0, 0);
      Vector3 bTotals = new Vector3(0, 0, 0);

      foreach (Vector3 currentA in A)
      {
         aTotals = aTotals - currentA;
      }
      foreach (Vector3 currentB in B)
      {
         bTotals = bTotals - currentB;
      }

      Result = aTotals - bTotals;
   }
}