// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a Vector3 variable using the value of another Vector3 variable.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetVector3 : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Vector3 Value, out Vector4 TargetVector3)
   {

      TargetVector3 = Value;

   }
}