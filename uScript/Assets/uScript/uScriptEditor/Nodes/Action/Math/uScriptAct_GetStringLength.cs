// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Returns the number of characters in a string as a float, integer, and string.

using UnityEngine;
using System.Collections;

public class uScriptAct_GetStringLength : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(string Target, out int IntValue, out float FloatValue, out string StringValue)
   {

      int m_CountInt;
      float m_CountFloat;
      string m_CountString;

      if (Target != "")
      {
         m_CountInt = Target.Length;
         m_CountFloat = System.Convert.ToSingle(Target.Length);
         m_CountString = Target.Length.ToString();
      }
      else
      {
         m_CountInt = 0;
         m_CountFloat = 0F;
         m_CountString = "0";  
      }

      IntValue = m_CountInt;
      FloatValue = m_CountFloat;
      StringValue = m_CountString;
      
   }
}