// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Causes the targeted GameObject to be relocated to the destination GameObject.

using UnityEngine;
using System.Collections;

public class uScriptAct_Teleport : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, GameObject Destination, bool UpdateRotation)
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null && Destination != null)
         {

            currentTarget.transform.position = Destination.transform.position;

            if (UpdateRotation)
            {
               currentTarget.transform.rotation = Destination.transform.rotation;
            }
         }
      }

   }
}