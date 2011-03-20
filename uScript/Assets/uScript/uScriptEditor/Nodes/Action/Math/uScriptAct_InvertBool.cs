// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Inverse a boolean variable to its opposite value. Example: true becomes false

using UnityEngine;
using System.Collections;

public class uScriptAct_InvertBool : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(bool Target, out bool Value)
   {

      if (Target)
      {
         Value = false;
      }
      else
      {
         Value = true;
      }

   }
}