// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Multiplies two float variables together and returns the result.

using UnityEngine;
using System.Collections;

public class uScriptAct_MultiplyFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float A, float B, out float FloatResult, out int IntResult)
   {

      float m_Total = A * B;
      FloatResult = m_Total;
      IntResult = System.Convert.ToInt32(m_Total);

   }
}