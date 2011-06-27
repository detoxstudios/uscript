// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Moves a GameObject to a Vector3 Location. Optionally can choose to Lerp to the location and use a local offset.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Moves a GameObject to a Vector3 Location.")]
[NodeDescription("Moves a GameObject to a Vector3 Location.\n \nTargets: The Target GameObject(s) to be moved.\nEnd Location: The ending location to move the Targets to.\nUse as Offset: Whether or not to treat End Location as an offset, rather than an absolute position.\nTransition Time: Time to take to move from current position to desired position.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Move To Location")]
public class uScriptAct_MoveToLocation : uScriptLogic
{
   public bool Out { get { return true; } }
   public event System.EventHandler Finished;

   private GameObject[] m_TargetArray;
   private Vector3      m_EndingLocation;
   private Vector3[]    m_StartingLocations;
   private bool         m_TreatAsOffset;
   private float        m_TotalTime;
   private float        m_CurrentTime;

   public void In(
      [FriendlyName("Target")] GameObject[] targetArray, 
      [FriendlyName("End Location")] Vector3 location, 
      [FriendlyName("Use as Offset"), SocketState(false, false)] bool asOffset, 
      [FriendlyName("Transition Time")] float totalTime
   )
   {
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

   public override void Update()
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
            if ( null == target ) return;

            target.transform.position = Vector3.Lerp( m_StartingLocations[ i ], m_EndingLocation + m_StartingLocations[ i ], t );
         }
      }
      else
      {
         for ( int i = 0; i < m_TargetArray.Length; i++ )
         {
            GameObject target = m_TargetArray[ i ];
            if ( null == target ) return;

            target.transform.position = Vector3.Lerp( m_StartingLocations[ i ], m_EndingLocation, t );
         }
      }
   

      if ( m_CurrentTime == m_TotalTime )
      {
         if (Finished != null) Finished(this, new System.EventArgs());
      }
   }

}