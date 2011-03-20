// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Takes any non-zero target integer and outputs its inverse version. Example: -2 becomes 2

using UnityEngine;
using System.Collections;

public class uScriptAct_InvertInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int Target, out int Value)
   {
      if (Target != 0)
      {
         int newInt;

         if (Target > 0)
         {
            newInt = System.Math.Abs(Target) * (-1);
         }
         else
         {
            newInt = System.Math.Abs(Target);
         }

         Value = newInt;
      }
      else
      {
         Value = 0;
      }

   }
}