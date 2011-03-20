// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a float to the defined value.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetFloat : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(float Value, out float Target)
   {
      Target = Value;
   }
}