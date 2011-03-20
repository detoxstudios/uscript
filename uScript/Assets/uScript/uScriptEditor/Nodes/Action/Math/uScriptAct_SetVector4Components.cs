// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a Vector4 to the defined X, Y, Z and W float component values.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetVector4Components : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(float X, float Y, float Z, float W, out Vector4 OutputVector4)
   {
      Vector4 tempVector4 = new Vector4(X, Y, Z, W);
      OutputVector4 = tempVector4;
   }
}