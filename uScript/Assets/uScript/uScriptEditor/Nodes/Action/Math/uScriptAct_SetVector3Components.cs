// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a Vector3 to the defined X, Y, and Z float component values.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetVector3Components : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(float X, float Y, float Z, out Vector3 OutputVector3)
   {
      Vector3 tempVector3 = new Vector3(X, Y, Z);
      OutputVector3 = tempVector3;
   }
}