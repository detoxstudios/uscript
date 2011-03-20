// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Takes any non-zero target float and outputs its inverse version. Example: 3.25 becomes -3.25

using UnityEngine;
using System.Collections;

public class uScriptAct_InvertFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float Target, out float Value)
   {
      if (Target != 0F)
      {
         float newFloat;

         if (Target > 0)
         {
            newFloat = System.Math.Abs(Target) * (-1F);
         }
         else
         {
            newFloat = System.Math.Abs(Target);
         }
         
         Value = newFloat;
      }
      else
      {
         Value = 0F;
      }

   }
}