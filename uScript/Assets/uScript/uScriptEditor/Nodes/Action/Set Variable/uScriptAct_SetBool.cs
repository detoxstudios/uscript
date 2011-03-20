// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a boolean to the defined value.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetBool : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(bool Value, out bool Target)
   {
      Target = Value;
   }
}
