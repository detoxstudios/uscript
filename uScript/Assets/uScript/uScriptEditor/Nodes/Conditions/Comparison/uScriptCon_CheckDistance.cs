// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Checks the distance of two GameObjects and fires the appropriate output.

using UnityEngine;
using System.Collections;

public class uScriptCon_CheckDistance : uScriptLogic
{

   // @TODO: This node would really benifit by being able to check every tick as part of a master uScript Update() event.

   private bool m_Closer = false;
   private bool m_Further = false;

   public bool Closer { get { return m_Closer; } }
   public bool Further { get { return m_Further; } }

   public void In(GameObject A, GameObject B, float Distance)
   {
      m_Closer = false;
      m_Further = false;

      if (A != null && B != null)
      {

         float myDistance = Vector3.Distance(A.transform.position, B.transform.position);
         if (myDistance <= Distance)
         {
            m_Closer = true;
         }
         else
         {
            m_Further = true;
         }

      }
      
   }
}