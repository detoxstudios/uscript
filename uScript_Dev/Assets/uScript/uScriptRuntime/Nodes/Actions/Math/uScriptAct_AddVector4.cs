// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds two Vector4 variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Adds two Vector4 variables together and returns the result.")]
[NodeDescription("Adds two Vector4 variables together and returns the result.\n \nA: The first Vector4 addend.  If more than one Vector4 variable is connected to A, they will be added together before being added to B.\nB: The second Vector4 addend.  If more than one Vector4 variable is connected to B, they will be added together before being added to A.\nResult (out): The Vector4 result of the addition operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Add_Vector4")]

[FriendlyName("Add Vector4")]
public class uScriptAct_AddVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector4[] A, Vector4[] B, out Vector4 Result)
   {
      Vector4 aTotals = new Vector4(0, 0, 0, 0);
      Vector4 bTotals = new Vector4(0, 0, 0, 0);

      foreach (Vector4 currentA in A)
      {
         aTotals += currentA;
      }
      foreach (Vector4 currentB in B)
      {
         bTotals += currentB;
      }

      Result = aTotals + bTotals;
   }
}