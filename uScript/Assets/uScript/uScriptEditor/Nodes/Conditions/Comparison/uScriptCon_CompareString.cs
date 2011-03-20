// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Compares two string variables and outputs accordingly.

using UnityEngine;
using System.Collections;

public class uScriptCon_CompareString : uScriptLogic
{
   private bool compareSame = false;
   private bool compareDifferent = false;

   public bool Same { get { return compareSame; } }
   public bool Different { get { return compareDifferent; } }

   public void In(string A, string B)
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
