// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Compares two Vector4 variables and outputs accordingly.

using UnityEngine;
using System.Collections;

public class uScriptCon_CompareVector4 : uScriptLogic
{
   private bool compareSame = false;
   private bool compareDifferent = false;

   public bool Same { get { return compareSame; } }
   public bool Different { get { return compareDifferent; } }

   public void In(Vector4 A, Vector4 B)
   {
      compareSame = false;
      compareDifferent = false;

      if (A == B)
      {
         compareSame = true;
      }
      else
      {
         compareDifferent = true;
      }

   }

}