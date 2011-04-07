// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Adds two integer variables together and returns the result.")]
[NodeDescription("Adds two integer variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Add Int")]
public class uScriptAct_AddInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int[] A, int[] B, [FriendlyName("Result")] out int IntResult, [FriendlyName("Float Result")] out float FloatResult)
   {

      int aTotals = 0;
      int bTotals = 0;

      foreach (int currentA in A)
      {
         aTotals = aTotals + currentA;
      }
      foreach (int currentB in B)
      {
         bTotals = bTotals + currentB;
      }

      int m_Total = aTotals + bTotals;
      IntResult = m_Total;
      FloatResult = System.Convert.ToSingle(m_Total);

   }
}