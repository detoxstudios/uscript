// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds two float variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Adds two float variables together and returns the result.")]
[NodeDescription("Adds two float variables together and returns the result.")]
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
         aTotals = aTotals + currentA;
      }
      foreach (float currentB in B)
      {
         bTotals = bTotals + currentB;
      }

      float m_Total = aTotals + bTotals;
      FloatResult = m_Total;
      IntResult = System.Convert.ToInt32(m_Total);

   }
}