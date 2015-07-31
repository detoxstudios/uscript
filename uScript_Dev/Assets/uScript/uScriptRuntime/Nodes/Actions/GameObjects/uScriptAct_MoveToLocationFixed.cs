// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Moves a GameObject to a Vector3 Location.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Move To Location Fixed", "Moves a GameObject to a Vector3 Location.")]
public class uScriptAct_MoveToLocationFixed : uScriptLogic
{
   public bool Out       { get { return true; } }
   public bool Cancelled { get { return m_Cancelled; } }

   public event System.EventHandler Finished;

   private GameObject[] m_TargetArray;
   private Vector3      m_EndingLocation;
   private Vector3[]    m_StartingLocations;
   private bool         m_TreatAsOffset;
   private float        m_Speed;
   private bool         m_Complete = true;
   private bool         m_Cancelled;


   public void In(
      [FriendlyName("Target", "The Target GameObject(s) to be moved."), AutoLinkType(typeof(GameObject))]
      GameObject[] targetArray,
      
      [FriendlyName("End Location", "The ending location to move the Targets to.")]
      Vector3 location,
      
      [FriendlyName("Use as Offset", "Whether or not to treat End Location as an offset, rather than an absolute position.")]
      [SocketState(false, false)]
      bool asOffset,
      
      [FriendlyName("Speed", "The units per second you wish your object to move.")]
      [DefaultValue(1.0f)]
      float speed
      )
   {
      m_Speed             = speed;
      m_TreatAsOffset     = asOffset;
      m_TargetArray       = targetArray;
      m_EndingLocation    = location;
      m_Complete          = false;
      m_Cancelled         = false;
      m_StartingLocations = new Vector3[ m_TargetArray.Length ];

      for ( int i = 0; i < m_TargetArray.Length; i++ )
      {
         GameObject target = m_TargetArray[ i ];
         if ( null == target ) continue;

         m_StartingLocations[ i ] = target.transform.position;
      }
   }
	
	
   public void Cancel(
      [FriendlyName("Target", "The Target GameObject(s) to be moved."), AutoLinkType(typeof(GameObject))]
      GameObject[] targetArray,
      
      [FriendlyName("End Location", "The ending location to move the Targets to.")]
      Vector3 location,
      
      [FriendlyName("Use as Offset", "Whether or not to treat End Location as an offset, rather than an absolute position.")]
      [SocketState(false, false)]
      bool asOffset,
      
      [FriendlyName("Speed", "The units per second you wish your object to move.")]
      [DefaultValue(1.0f)]
      float speed
   )
   {
      if (false == m_Complete)
      {
         m_Complete  = true;
         m_Cancelled = true;
      }
   }
	

   public void Update()
   {
      if ( true == m_Complete ) return;

      float speed = m_Speed * Time.deltaTime;

      bool done = true;

      if ( true == m_TreatAsOffset )
      {
         for ( int i = 0; i < m_TargetArray.Length; i++ )
         {
            GameObject target = m_TargetArray[ i ];
            if ( null == target ) continue;

            Vector3 delta = (m_EndingLocation + m_StartingLocations[ i ]) - target.transform.position;

            //if we've gotten as precise as the speed will allow, stay here
            if ( Vector3.Dot(delta, delta) < speed * speed ) 
            {
               target.transform.position = m_EndingLocation + m_StartingLocations[ i ];
            }
            else
            {
               done  = false;

               delta = Vector3.Normalize( delta );
               target.transform.position = target.transform.position + delta * speed;
            }
         }
      }
      else
      {
         for ( int i = 0; i < m_TargetArray.Length; i++ )
         {
            GameObject target = m_TargetArray[ i ];
            if ( null == target ) continue;

            Vector3 delta = m_EndingLocation - target.transform.position;

            //if we've gotten as precise as the speed will allow, stay here
            if ( Vector3.Dot(delta, delta) < speed * speed ) 
            {
               target.transform.position = m_EndingLocation;
            }
            else
            {
               done  = false;

               delta = Vector3.Normalize( delta );
               target.transform.position = target.transform.position + delta * speed;
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