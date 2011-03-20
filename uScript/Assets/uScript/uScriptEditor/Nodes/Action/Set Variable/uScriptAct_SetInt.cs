// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets an int to the defined value.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int Value, out float Target)
   {
      Target = Value;
   }
}