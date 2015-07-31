// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Moves a GameObject to a Vector3 Location.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Move To Location", "Moves a GameObject to a Vector3 Location.")]
public class uScriptAct_MoveToLocation : uScriptLogic
{
   public bool Out { get { return true; } }
   public bool Cancelled { get { return m_Cancelled; } }

   public event System.EventHandler Finished;

   private GameObject[] m_TargetArray;
   private Vector3      m_EndingLocation;
   private Vector3[]    m_StartingLocations;
   private bool         m_TreatAsOffset;
   private float        m_TotalTime;
   private float        m_CurrentTime;
   private bool         m_Cancelled;

   public void In(
      [FriendlyName("Target", "The Target GameObject(s) to be moved."), AutoLinkType(typeof(GameObject))]
      GameObject[] targetArray,
      
      [FriendlyName("End Location", "The ending location to move the Targets to.")]
      Vector3 location,
      
      [FriendlyName("Use as Offset", "Whether or not to treat End Location as an offset, rather than an absolute position.")]
      [SocketState(false, false)]
      bool asOffset,

      [FriendlyName("Transition Time", "Time to take to move from current position to desired position.")]
      float totalTime
      )
   {
      m_Cancelled   = false;
      m_TotalTime   = totalTime;
      m_CurrentTime = 0;

      if ( 0 == m_TotalTime )
      {
         if ( true == asOffset )
         {
            foreach ( GameObject target in targetArray )
            {
               if ( null == target ) continue;

               target.transform.position = target.transform.position + location;
            }
         }
         else
         {
            foreach ( GameObject target in targetArray )
            {
               if ( null == target ) continue;

               target.transform.position = location;
            }
         }
      }
      else
      {
         m_TreatAsOffset     = asOffset;
         m_TargetArray       = targetArray;
         m_EndingLocation    = location;
         m_StartingLocations = new Vector3[ m_TargetArray.Length ];

         for ( int i = 0; i < m_TargetArray.Length; i++ )
         {
            GameObject target = m_TargetArray[ i ];
            if ( null == target ) continue;

            m_StartingLocations[ i ] = target.transform.position;
         }
      }
   }
	
	
   public void Cancel(
      [FriendlyName("Target", "The Target GameObject(s) to be moved."), AutoLinkType(typeof(GameObject))]
      GameObject[] targetArray,
	  [FriendlyName("End Location", "The ending location to move the Targets to.")]
      Vector3 location,
	  [FriendlyName("Use as Offset", "Whether or not to treat End Location as an offset, rather than an absolute position.")]
      bool asOffset,
	  [FriendlyName("Transition Time", "Time to take to move from current position to desired position.")]
      float totalTime
   )
   {
      if (m_CurrentTime != m_TotalTime)
      {
         m_Cancelled = true;
         m_CurrentTime = m_TotalTime;
      }
   }
	
	
   public void Update()
   {
      if ( m_CurrentTime == m_TotalTime ) return;

      m_CurrentTime += Time.deltaTime;
      
      if ( m_CurrentTime >= m_TotalTime )
      {
         m_CurrentTime = m_TotalTime;
      }

      float t = m_CurrentTime / m_TotalTime;

      if ( true == m_TreatAsOffset )
      {
         for ( int i = 0; i < m_TargetArray.Length; i++ )
         {
            GameObject target = m_TargetArray[ i ];
            if ( null == target ) continue;

            target.transform.position = Vector3.Lerp( m_StartingLocations[ i ], m_EndingLocation + m_StartingLocations[ i ], t );
         }
      }
      else
      {
         for ( int i = 0; i < m_TargetArray.Length; i++ )
         {
            GameObject target = m_TargetArray[ i ];
            if ( null == target ) continue;

            target.transform.position = Vector3.Lerp( m_StartingLocations[ i ], m_EndingLocation, t );
         }
      }
   

      if ( m_CurrentTime == m_TotalTime )
      {
         if (Finished != null) Finished(this, new System.EventArgs());
      }
   }

}