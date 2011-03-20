// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Divides two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

public class uScriptAct_DivideInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int A, int B, out int IntResult, out float FloatResult)
   {

      int m_Total = A / B;
      IntResult = m_Total;
      FloatResult = System.Convert.ToSingle(m_Total);

   }
}