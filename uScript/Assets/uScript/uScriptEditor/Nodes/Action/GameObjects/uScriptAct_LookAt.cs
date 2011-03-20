// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Tells a GameObject to look at another GameObject transform or Vector3 position.

using UnityEngine;
using System.Collections;

public class uScriptAct_LookAt : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, object Focus)
   {

      if (Focus != null)
      {
         foreach (GameObject currentTarget in Target)
         {
            if (currentTarget != null)
            {

               if (typeof(GameObject) == Focus.GetType())
               {
                  GameObject tempGameObject = (GameObject)Focus;
                  currentTarget.transform.LookAt(tempGameObject.transform);
               }
               else if (typeof(Vector3) == Focus.GetType())
               {
                  Vector3 tempVector3 = (Vector3)Focus;
                  currentTarget.transform.LookAt(tempVector3);
               }

            }
         }
      }

   }
}
