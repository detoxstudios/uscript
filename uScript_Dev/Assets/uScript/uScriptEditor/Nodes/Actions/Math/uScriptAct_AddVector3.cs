// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds two Vector3 variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Adds two Vector3 variables together and returns the result.")]
[NodeDescription("Adds two Vector3 variables together and returns the result.\n \nA: The first Vector3 addend.  If more than one Vector3 variable is connected to A, they will be added together before being added to B.\nB: The second Vector3 addend.  If more than one Vector3 variable is connected to B, they will be added together before being added to A.\nResult (out): The Vector3 result of the addition operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Add Vector3")]
public class uScriptAct_AddVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector3[] A, Vector3[] B, out Vector3 Result)
   {
      Vector3 aTotals = new Vector3(0, 0, 0);
      Vector3 bTotals = new Vector3(0, 0, 0);

      foreach (Vector3 currentA in A)
      {
         aTotals += currentA;
      }
      foreach (Vector3 currentB in B)
      {
         bTotals += currentB;
      }

      Result = aTotals + bTotals;
   }
}