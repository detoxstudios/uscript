// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Moves a GameObject to a Vector3 Location. Optionally can choose to Lerp to the location and use a local offset.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Moves a GameObject to a Vector3 Location.")]
[NodeDescription("Moves a GameObject to a Vector3 Location.\n \nTargets: The Target GameObject(s) to be moved.\nEnd Location: The ending location to move the Targets to.\nUse as Offset: Whether or not to treat End Location as an offset, rather than an absolute position.\nSpeed: The units per second you wish your object to move.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Move_To_Location")]

[FriendlyName("Move To Location Fixed")]
public class uScriptAct_MoveToLocationFixed : uScriptLogic
{
   public bool Out { get { return true; } }
   public event System.EventHandler Finished;

   private GameObject[] m_TargetArray;
   private Vector3      m_EndingLocation;
   private Vector3[]    m_StartingLocations;
   private bool         m_TreatAsOffset;
   private float        m_Speed;
   private bool         m_Complete = true;


   public void In(
      [FriendlyName("Target")] GameObject[] targetArray, 
      [FriendlyName("End Location")] Vector3 location, 
      [FriendlyName("Use as Offset"), SocketState(false, false)] bool asOffset, 
      [FriendlyName("Speed"), DefaultValue(1.0f)] float speed
   )
   {
      m_Speed = speed;

      m_TreatAsOffset     = asOffset;
      m_TargetArray       = targetArray;
      m_EndingLocation    = location;
      m_Complete          = false;
      m_StartingLocations = new Vector3[ m_TargetArray.Length ];

      for ( int i = 0; i < m_TargetArray.Length; i++ )
      {
         GameObject target = m_TargetArray[ i ];
         if ( null == target ) continue;

         m_StartingLocations[ i ] = target.transform.position;
      }
   }

   public void Update()
   {
      if ( true == m_Complete ) return;

      bool done = true;

      if ( true == m_TreatAsOffset )
      {
         for ( int i = 0; i < m_TargetArray.Length; i++ )
         {
            GameObject target = m_TargetArray[ i ];
            if ( null == target ) return;

            Vector3 delta = (m_EndingLocation + m_StartingLocations[ i ]) - target.transform.position;

            //if we've gotten as precise as the speed will allow, stay here
            if ( Vector3.Dot(delta, delta) < m_Speed * m_Speed ) 
            {
               target.transform.position = m_EndingLocation + m_StartingLocations[ i ];
            }
            else
            {
               done  = false;

               delta = Vector3.Normalize( delta );
               target.transform.position = target.transform.position + delta * m_Speed;
            }
         }
      }
      else
      {
         for ( int i = 0; i < m_TargetArray.Length; i++ )
         {
            GameObject target = m_TargetArray[ i ];
            if ( null == target ) return;

            Vector3 delta = m_EndingLocation - target.transform.position;

            //if we've gotten as precise as the speed will allow, stay here
            if ( Vector3.Dot(delta, delta) < m_Speed * m_Speed ) 
            {
               target.transform.position = m_EndingLocation;
            }
            else
            {
               done  = false;

               delta = Vector3.Normalize( delta );
               target.transform.position = target.transform.position + delta * m_Speed;
            }
         }
      }
   

      if ( true == done )
      {
         m_Complete = true;
         if (Finished != null) Finished(this, new System.EventArgs());
      }
   }

}