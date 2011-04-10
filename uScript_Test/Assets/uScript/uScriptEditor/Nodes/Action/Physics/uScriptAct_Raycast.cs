// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc:  Performs a ray trace from the starting point to the end point, determines if
//        anything was hit along the way, and fires the associated output link.

using UnityEngine;
using System.Collections;

[NodePath("Action/Physics")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Performs a ray trace from the starting point to the end point. Returns any hit data.")]
[NodeDescription("Performs a ray trace from the starting point to the end point, determines if anything was hit along the way, and fires the associated output link.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Raycast")]
public class uScriptAct_Raycast : uScriptLogic
{
   // @TODO: I wish I could return the GameObject hit, but it looks like Unity (RaycastHit) doesn't provide that functionality (at least for static GOs).

   private Vector3 m_StartVector = Vector3.zero;
   private Vector3 m_EndVector = Vector3.zero;
   private bool m_ValidInputs = true;

   private bool m_NotObstructed = false;
   private bool m_Obstructed = false;

   public bool NotObstructed { get { return m_NotObstructed; } }
   public bool Obstructed { get { return m_Obstructed; } }

   public void In(object Start, object End, [FriendlyName("Layer Mask")] int LayerMask, [FriendlyName("Hit Distance")] out float HitDistance, [FriendlyName("Hit Location")] out Vector3 HitLocation)
   {
      m_NotObstructed = false;
      m_Obstructed = false;
      
      bool m_HitTrue = false;

      float tmpHitDistance = 0F;
      Vector3 tmpHitLocation = Vector3.zero;
 
      if (typeof(GameObject) == Start.GetType() || typeof(Vector3) == Start.GetType())
      {
         if (typeof(GameObject) == Start.GetType())
         {
            GameObject tmpGameObjectStart = (GameObject)Start;
            m_StartVector = tmpGameObjectStart.transform.position;
         }
         if (typeof(Vector3) == Start.GetType())
         {
            Vector3 tmpVector3Start = (Vector3)Start;
            m_StartVector = tmpVector3Start;
         }
      }
      else
      {
         uScriptDebug.Log("The Raycast node can only take a GameObject or Vector3 for the 'Start' input nub!", uScriptDebug.Type.Error);
         m_ValidInputs = false;
      }

      if (typeof(GameObject) == End.GetType() || typeof(Vector3) == End.GetType())
      {
         if (typeof(GameObject) == End.GetType())
         {
            GameObject tmpGameObjectEnd = (GameObject)End;
            m_EndVector = tmpGameObjectEnd.transform.position;
         }
         if (typeof(Vector3) == End.GetType())
         {
            Vector3 tmpGameObjectEnd = (Vector3)End;
            m_EndVector = tmpGameObjectEnd;
         }
      }
      else
      {
         uScriptDebug.Log("The Raycast node can only take a GameObject or Vector3 for the 'End' input nub!", uScriptDebug.Type.Error);
         m_ValidInputs = false;
      }

      if (m_ValidInputs)
      {
         Vector3 finalDirection = (m_EndVector - m_StartVector).normalized;

         float castDistance = Vector3.Distance(m_StartVector, m_EndVector);
         RaycastHit hit;

         if (LayerMask <= 0)
         {
            if (Physics.Raycast(m_StartVector, finalDirection, out hit, castDistance))
            {
               tmpHitDistance = hit.distance;
               tmpHitLocation = hit.point;
               m_HitTrue = true;
            }
         }
         else
         {
            if (Physics.Raycast(m_StartVector, finalDirection, out hit, castDistance, LayerMask))
            {
               tmpHitDistance = hit.distance;
               tmpHitLocation = hit.point;
               m_HitTrue = true;
            }
         }
      }

      if (m_HitTrue)
      {
         HitDistance = tmpHitDistance;
         HitLocation = tmpHitLocation;

         m_Obstructed = true;
      }
      else
      {
         HitDistance = tmpHitDistance;
         HitLocation = tmpHitLocation;

         m_NotObstructed = true;
      }

   }
}