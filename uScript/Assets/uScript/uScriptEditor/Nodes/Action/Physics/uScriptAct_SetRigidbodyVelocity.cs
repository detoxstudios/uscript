// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the velocity of a GameObject's Rigidbody as a Vector3.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetRigidbodyVelocity : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, Vector3 Velocity)
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null && currentTarget.GetComponent("rigidbody"))
         {
            currentTarget.rigidbody.velocity = Velocity;
         }
      }

   }
}