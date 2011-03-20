// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Compares the unique InstanceID of the attached GameObject variables and outputs accordingly.
//       Optionally you can compare by a GameObject's tag.

using UnityEngine;
using System.Collections;

public class uScriptCon_CompareGameObjects : uScriptLogic
{
   private bool compareSame = false;
   private bool compareDifferent = false;

   public bool Same { get { return compareSame; } }
   public bool Different { get { return compareDifferent; } }

   public void In(GameObject A, GameObject B, bool CompareByTag)
   {

      compareSame = false;
      compareDifferent = false;

      if (!CompareByTag)
      {
         int GameObjectA = A.GetInstanceID();
         int GameObjectB = B.GetInstanceID();

         if (GameObjectA == GameObjectB)
         {
            compareSame = true;
         }
         else
         {
            compareDifferent = true;
         }

      }
      else
      {

         string GameObjectA = A.tag;
         string GameObjectB = B.tag;

         if (GameObjectA == GameObjectB)
         {
            compareSame = true;
         }
         else
         {
            compareDifferent = true;
         }

      }

   }
}