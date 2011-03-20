// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Gets the velocity of a GameObject's Rigidbody as a Vector3.

using UnityEngine;
using System.Collections;

public class uScriptAct_GetRigidbodyVelocity : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject Target, out Vector3 Velocity)
   {

      if (Target != null && Target.GetComponent("rigidbody"))
      {
         Velocity = Target.rigidbody.velocity;
      }
      else
      {
         Velocity = Vector3.zero;
      }

   }
}