// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds two float variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Adds two float variables together and returns the result.")]
[NodeDescription("Adds two float variables together and returns the result.\n \nA: The first floating point addend. If more than one floating point variable is connected to A, they will be added together before being added to B.\nB: The second floating point addend.  If more than one floating point variable is connected to B, they will be added together before being added to A.\nResult (out): The floating point result of the addition operation.\nInt Result (out): The integer result of the addition operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Add Float")]
public class uScriptAct_AddFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float[] A, float[] B, [FriendlyName("Result")] out float FloatResult, [FriendlyName("Int Result")] out int IntResult)
   {
      float aTotals = 0F;
      float bTotals = 0F;

      foreach (float currentA in A)
      {
         aTotals += currentA;
      }
      foreach (float currentB in B)
      {
         bTotals += currentB;
      }

      FloatResult = aTotals + bTotals;
      IntResult = System.Convert.ToInt32(FloatResult);
   }
}