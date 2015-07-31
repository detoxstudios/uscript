// uScript Action Node
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Performs a 2D line cast from the starting point to the end point.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Linecast (2D)", "Performs a 2D line cast from the starting point to the end point, determines if anything was hit along the way, and fires the associated output link. GameObjects being hit must have a 2D Collider component in order to be detected.")]
public class uScriptAct_Linecast2D : uScriptLogic
{
   private Vector3 m_StartVector = Vector3.zero;
   private Vector3 m_EndVector = Vector3.zero;

   private bool m_NotObstructed = false;
   private bool m_Obstructed = false;

   public bool NotObstructed { get { return m_NotObstructed; } }
   public bool Obstructed { get { return m_Obstructed; } }

   public void In(
      [FriendlyName("Start", "The start point of the line cast. Must be a GameObject, Transform, Vector2, or Vector3.")]
      object Start,

      [FriendlyName("End", "The end point of the line cast. Must be a GameObject, Transform, or Vector2, or Vector3.")]
      object End,
      
      [FriendlyName("Layer Mask", "A Layer mask that is used to selectively ignore colliders when casting a line.")]
      [SocketState(false, false)]
      LayerMask layerMask,

      [FriendlyName("Include Masked Layers", "If true, the line will test against the masked layers, otherwise it will test against all layers excluding the masked layers.")]
      [DefaultValue(true), SocketState(false, false)]
      bool include,

      [FriendlyName("Show Line", "If true, the line will be displayed in the Scene view.")]
      [SocketState(false, false)]
      bool showRay,

      [FriendlyName("Hit GameObject", "The first GameObject that was hit by the raycast (if any).")]
      out GameObject HitObject,

      [FriendlyName("Hit Location", "The position of the hit (if any).")]
      out Vector3 HitLocation,

      [FriendlyName("Hit Normal", "The surface normal of the hit (if any).")]
      out Vector3 HitNormal
      )
   {
      bool validInputs = true;
       
      if (typeof(GameObject) == Start.GetType() || typeof(Vector3) == Start.GetType())
      {
         if (typeof(GameObject) == Start.GetType())
         {
            GameObject tmpGameObjectStart = (GameObject)Start;
            m_StartVector = tmpGameObjectStart.transform.position;
         }
         if (typeof(Vector2) == Start.GetType())
         {
            Vector2 tmpVector3Start = (Vector2)Start;
            m_StartVector = tmpVector3Start;
         }
         if (typeof(Vector3) == Start.GetType())
         {
            Vector2 tmpVector3Start = (Vector3)Start;
            m_StartVector = tmpVector3Start;
         }
         if (typeof(Transform) == Start.GetType())
         {
            Transform tmpVector3Start = (Transform)Start;
            m_StartVector = tmpVector3Start.position;
         }
      }
      else
      {
         uScriptDebug.Log("The Linecast (2D) node can only take a GameObject, Transform, Vector2, or Vector3 for the 'Start' input nub!", uScriptDebug.Type.Error);
         validInputs = false;
      }

      if (typeof(GameObject) == End.GetType() || typeof(Vector3) == End.GetType())
      {
         if (typeof(GameObject) == End.GetType())
         {
            GameObject tmpGameObjectEnd = (GameObject)End;
            m_EndVector = tmpGameObjectEnd.transform.position;
         }
         if (typeof(Vector2) == End.GetType())
         {
            Vector2 tmpGameObjectEnd = (Vector2)End;
            m_EndVector = tmpGameObjectEnd;
         }
         if (typeof(Vector3) == End.GetType())
         {
            Vector2 tmpGameObjectEnd = (Vector3)End;
            m_EndVector = tmpGameObjectEnd;
         }
         if (typeof(Transform) == End.GetType())
         {
            Transform tmpGameObjectEnd = (Transform)End;
            m_EndVector = tmpGameObjectEnd.position;
         }
      }
      else
      {
         uScriptDebug.Log("The Linecast (2D) node can only take a GameObject, Transform, Vector2, or Vector3 for the 'End' input nub!", uScriptDebug.Type.Error);
         validInputs = false;
      }

      RaycastHit2D hit = default(RaycastHit2D);

      if (validInputs)
      {
         if (true == showRay)
         {
            Debug.DrawLine(m_StartVector, m_EndVector);
         }

         if (!include)
         {
            hit = Physics2D.Linecast(m_StartVector, m_EndVector);
         }
         else
         {
            hit = Physics2D.Linecast(m_StartVector, m_EndVector, layerMask);
         }
      }
      
      if (hit.collider != null)
      {
         HitLocation = hit.point;
         HitObject   = hit.collider.gameObject;
         HitNormal   = hit.normal;
      }
      else
      {
         HitObject   = null;
         HitLocation = Vector3.zero;
         HitNormal   = Vector3.zero;
      }

      m_Obstructed = hit.collider != null;
      m_NotObstructed = !m_Obstructed;
   }
}

#endif