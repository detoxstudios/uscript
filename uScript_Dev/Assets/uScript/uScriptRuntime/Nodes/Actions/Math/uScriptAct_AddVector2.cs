// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds two Vector2 variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Adds two or more Vector2 variables together and returns the result.")]
[NodeDescription("Adds two or more Vector2 variables together and returns the result.\n \nA: The first Vector2. If more than one Vector2 variable is connected to A, they will be added together before being added to B.\nB: The second Vector2. If more than one Vector2 variable is connected to B, they will be added together before being added to A.\nResult (out): The Vector2 result of the addition operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Add_Vector3")]

[FriendlyName("Add Vector2")]
public class uScriptAct_AddVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector2[] A, Vector2[] B, out Vector2 Result)
   {
      Vector2 aTotals = new Vector2(0, 0);
      Vector2 bTotals = new Vector2(0, 0);

      foreach (Vector2 currentA in A)
      {
         aTotals += currentA;
      }
      foreach (Vector2 currentB in B)
      {
         bTotals += currentB;
      }

      Result = aTotals + bTotals;
   }
}