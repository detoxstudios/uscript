// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the position (Vector3) of a GameObject as world coordinates.
//       Optionally can set position as offest from the target's current position.

using UnityEngine;
using System.Collections;

public class uScriptAct_SetGameObjectPosition : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, Vector3 Position, bool AsOffset)
   {
      foreach ( GameObject currentTarget in Target )
      {
         if ( currentTarget != null )
         {
            if (AsOffset)
            {
               currentTarget.transform.position += Position;
            }
            else
            {
               currentTarget.transform.position = Position;
            }
         }
      }

   }
}
