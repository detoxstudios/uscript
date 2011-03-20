// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the distance between two GameObjects as a float.

using UnityEngine;
using System.Collections;

public class uScriptAct_GetDistance : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject A, GameObject B, out float Distance)
   {

      if (A != null && B != null)
      {
         Distance = Vector3.Distance(A.transform.position, B.transform.position);
      }
      else
      {
         Distance = 0F;
      }

   }
}