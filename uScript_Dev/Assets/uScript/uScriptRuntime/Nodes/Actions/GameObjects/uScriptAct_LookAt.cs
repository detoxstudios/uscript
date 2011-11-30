// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Tells a GameObject to look at another GameObject transform or Vector3 position.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Look_At")]

[FriendlyName("Look At", "Tells a GameObject (target) to look at another GameObject (focus) transform or Vector3 position in a specified amount of time (seconds).")]
public class uScriptAct_LookAt : uScriptLogic
{
   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public event uScriptEventHandler Finished;

   public bool Out { get { return true; } }

   private float m_Time      = 0.0f;
   private float m_TotalTime = 0.0f;

   private GameObject[] m_Targets;
   private Quaternion[] m_StartRotations;
   private Vector3   [] m_StartPositions;
   private GameObject   m_Focus;
   private Vector3      m_FocusPosition;

   public void In(
      [FriendlyName("Target", "The Target GameObject(s) whose look direction will be adjusted.")]
      GameObject[] Target,
      
      [FriendlyName("Focus", "The item to focus on - can be a Vector3 position or a GameObject.")]
      object Focus,

      [FriendlyName("Seconds", "The amount of time (in seconds) it takes to complete the look.  Use 0 for an instantaneous look.")]
      float time
      )
   {
      if (Focus != null)
      {
         m_Time      = 0.0f;
         m_TotalTime = time;
         m_Targets   = null;
         m_Focus     = null;
         
         if (typeof(GameObject) == Focus.GetType())
         {
            m_Focus = (GameObject) Focus;
            m_FocusPosition = ((GameObject)Focus).transform.position;
         }
         else if (typeof(Vector3) == Focus.GetType())
         {
            m_FocusPosition = (Vector3)Focus;
         }
         else
         {
            m_FocusPosition = Vector3.forward;
         }

         if ( m_TotalTime <= 0.0f )
         {
            foreach (GameObject currentTarget in Target)
            {
               if (currentTarget == null) continue;
               currentTarget.transform.LookAt( m_FocusPosition );
            }
         }
         else
         {
            m_Targets = Target;

            m_StartRotations = new Quaternion[ m_Targets.Length ];
            m_StartPositions = new Vector3   [ m_Targets.Length ];

            for (int i = 0; i < m_Targets.Length; i++)
            {
               if ( null == m_Targets[i] ) continue;

               m_StartRotations[ i ] = m_Targets[ i ].transform.rotation;
               m_StartPositions[ i ] = m_Targets[ i ].transform.position;
            }
         }
      }
   }

   public void Update()
   {
      if ( null == m_Targets ) return;

      //calculate new time and clamp at 1
      float t = m_Time / m_TotalTime;
      if ( t > 1 ) t = 1;

      //update our focal position to the game object's latest position
      if ( null != m_Focus ) m_FocusPosition = m_Focus.transform.position;

      if ( t < 1.0f )
      {
         for (int i = 0; i < m_Targets.Length; i++)
         {
            if ( null == m_Targets[i] ) continue;
         
            //our targets might be moving too, so recalculate their desired lookat and slerp it
            Quaternion q = Quaternion.LookRotation( m_FocusPosition - m_StartPositions[ i ] );
            m_Targets[ i ].transform.rotation = Quaternion.Slerp( m_StartRotations[ i ], q, t );
         }
      }
      else
      {
         for (int i = 0; i < m_Targets.Length; i++)
         {
            if ( null == m_Targets[i] ) continue;
         
            m_Targets[ i ].transform.LookAt( m_FocusPosition );
         }
      }


      //finish if we hit our max time
      if ( 1 == t )
      {
         if ( null != Finished ) Finished( this, System.EventArgs.Empty );
         m_Targets = null;
      }

      m_Time += Time.deltaTime;
   }
}
