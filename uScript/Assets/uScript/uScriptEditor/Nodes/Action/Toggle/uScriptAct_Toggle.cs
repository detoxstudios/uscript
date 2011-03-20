// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Toggles the active state of a GameObject.

using UnityEngine;
using System.Collections;

public class uScriptAct_Toggle : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, bool IgnoreChildren)
   {

      foreach ( GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            if (IgnoreChildren)
            {

               if (currentTarget.active)
               {
                  currentTarget.active = false;
               }
               else
               {
                  currentTarget.active = true;
               }
            }
            else
            {
               if (currentTarget.active)
               {
                  currentTarget.SetActiveRecursively(false);
               }
               else
               {
                  currentTarget.SetActiveRecursively(true);
               }
            }
         }
      }

   }
}
