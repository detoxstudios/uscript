// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Compares two Vector3 variables and outputs accordingly.

using UnityEngine;
using System.Collections;

public class uScriptCon_CompareVector3 : uScriptLogic
{
   private bool compareSame = false;
   private bool compareDifferent = false;

   public bool Same { get { return compareSame; } }
   public bool Different { get { return compareDifferent; } }

   public void In(Vector3 A, Vector3 B)
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