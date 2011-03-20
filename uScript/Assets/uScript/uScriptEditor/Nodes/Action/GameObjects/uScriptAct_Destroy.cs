// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Destroys the target GameObject. Can optionally set a delay.

using UnityEngine;
using System.Collections;

public class uScriptAct_Destroy : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, float DelayTime)
   {

      if (DelayTime > 0F)
      {
         foreach (GameObject currentTarget in Target)
         {
            if (currentTarget != null)
            {
               Destroy(currentTarget, DelayTime);
            }
         }

      }
      else
      {
         foreach (GameObject currentTarget in Target)
         {
            if (currentTarget != null)
            {
               Destroy(currentTarget);
            }
         }
      }

   }
}