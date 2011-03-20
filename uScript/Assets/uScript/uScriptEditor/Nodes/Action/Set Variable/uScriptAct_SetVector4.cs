// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Vector4 variable using the value of another Vector4 variable.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetVector4 : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Vector4 Value, out Vector4 TargetVector4)
   {

      TargetVector4 = Value;

   }
}