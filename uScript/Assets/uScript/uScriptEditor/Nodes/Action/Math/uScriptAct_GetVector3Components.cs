// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Gets the components of a Vector3 as floats.

using UnityEngine;
using System.Collections;

public class uScriptAct_GetVector3Components : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(Vector3 InputVector3, out float X, out float Y, out float Z)
   {

      X = InputVector3.x;
      Y = InputVector3.y;
      Z = InputVector3.z;

   }
}