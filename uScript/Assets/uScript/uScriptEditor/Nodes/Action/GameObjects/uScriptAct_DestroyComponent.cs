// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Removes the specified Component from then target GameObject. Can optionally set a delay.

using UnityEngine;
using System.Collections;

public class uScriptAct_DestroyComponent : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, string[] ComponentName, float DelayTime)
   {
      foreach ( GameObject currentTarget in Target )
      {
         if (currentTarget != null)
         {
            foreach (string currentComponentName in ComponentName)
            {
               if (currentTarget.GetComponent(currentComponentName))
               {
                  if (DelayTime > 0F)
                  {
                     Destroy(currentTarget.GetComponent(currentComponentName), DelayTime);
                  }
                  else
                  {
                     Destroy(currentTarget.GetComponent(currentComponentName));
                  }
               }
               else
               {
                  uScriptDebug.Log("Component '" + currentComponentName + "' not found on GameObject '" + currentTarget.name + "'.", uScriptDebug.Type.Warning);
               }
            }
         }
      }

   }
}