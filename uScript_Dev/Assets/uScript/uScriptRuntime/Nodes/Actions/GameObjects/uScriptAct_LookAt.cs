// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Tells a GameObject to look at another GameObject transform or Vector3 position.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Look At", "Tells a GameObject (target) to look at another GameObject (focus) transform or Vector3 position in a specified amount of time (seconds).")]
public class uScriptAct_LookAt : uScriptLogic
{
   public enum LockAxis { None, X, Y, Z };
	
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
   private LockAxis     m_LockAxis;
   //private bool         m_RotateAroundVector;
   private bool         m_UseDegreesPerSecond;
   private float        m_DegreesPerSecond;

   public void In(
      [FriendlyName("Target", "The Target GameObject(s) whose look direction will be adjusted."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Focus", "The item to focus on - can be a Vector3 position or a GameObject.")]
      object Focus,

      [FriendlyName("Seconds", "The amount of time (in seconds) it takes to complete the look.  Use 0 for an instantaneous look.")]
      float time,

      [FriendlyName("Lock Axis", "Use this to lock rotation on the specified axis.")]
      [SocketState(false, false)]
      LockAxis lockAxis,

      [FriendlyName("Degrees Per Second", "If Use Degrees Per Second is true, this is the speed at which the rotation will take place. NOTE: this variable must have the same sign (i.e. positive or negative) as the Degrees variable.")]
      float DegreesPerSecond = 10.0f,

      [FriendlyName("Use Degrees Per Second", "If this is true, the rotation will happen at a constant rate, no matter how many degrees of rotation are needed.  If false, the rotation will take the number of seconds in the variable Seconds to complete.")]
      [SocketState(true, false)]
      bool UseDegreesPerSecond = false
   )
   {
      if (Focus != null)
      {
         m_Time      = 0.0f;
         m_TotalTime = time;
         m_Targets   = null;
         m_Focus     = null;
         m_LockAxis = lockAxis;
         //m_RotateAroundVector = rotateAroundVector;
         
#if !UNITY_FLASH
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
#endif
            m_FocusPosition = Vector3.forward;
#if !UNITY_FLASH
         }
#endif


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

      m_UseDegreesPerSecond = UseDegreesPerSecond;
      m_DegreesPerSecond = DegreesPerSecond;

      if (0 == m_TotalTime) Update();
   }

   public void Update()
   {
      if ( null == m_Targets ) return;

      //calculate new time and clamp at 1
      float t = (m_TotalTime != 0) ? m_Time / m_TotalTime : 1.0f;
      if (t > 1 && !m_UseDegreesPerSecond) t = 1;

      //update our focal position to the game object's latest position
      if (null != m_Focus) m_FocusPosition = m_Focus.transform.position;

      for (int i = 0; i < m_Targets.Length; i++)
      {
         if (null == m_Targets[i]) continue;

         //our targets might be moving too, so recalculate their desired lookat and slerp it
         Vector3 up = Vector3.up;
         Vector3 look = m_FocusPosition - m_StartPositions[i];

         if (m_LockAxis != LockAxis.None)
         {
            if (m_LockAxis == LockAxis.X)
            {
               up = Vector3.right;
               look.x = 0;
            }
            else if (m_LockAxis == LockAxis.Y)
            {
               up = Vector3.up;
               look.y = 0;
            }
            else if (m_LockAxis == LockAxis.Z)
            {
               up = Vector3.forward;
               look.z = 0;
            }
         }

         look.Normalize();

         if (m_UseDegreesPerSecond)
         {
            Vector3 right = Vector3.Cross(look, up);
            up = Vector3.Cross(right, look);
            float angle = Mathf.Acos(Vector3.Dot(look, m_Targets[i].transform.forward)) * Mathf.Rad2Deg;
            Vector3 rotationAxis = Vector3.Cross(look, m_Targets[i].transform.forward).normalized;
            float degrees = m_DegreesPerSecond * Mathf.Sign(rotationAxis.y) * Time.deltaTime;
            t = 0.0f;
            if (Mathf.Sign(rotationAxis.y) >= 0.0f)  // rotating in the positive direction
            {
               // rotation axis is inverted, fix it
               rotationAxis = -rotationAxis;

               // check if we've gone past
               if (degrees >= angle)
               {
                  degrees = angle;
                  t = 1.0f;
               }
            }
            else  // rotating in the negative direction
            {
               // check if we've gone past
               if (Mathf.Abs(degrees) >= angle)
               {
                  degrees = -angle;
                  t = 1.0f;
               }
            }

            m_Targets[i].transform.Rotate(rotationAxis, degrees, Space.World);
         }
         else
         {
            Quaternion q = Quaternion.LookRotation(look, up);
            m_Targets[i].transform.rotation = Quaternion.Slerp(m_StartRotations[i], q, t);
         }
      }

      //finish if we hit our max time
      if (1.0f == t)
      {
         if (null != Finished) Finished(this, System.EventArgs.Empty);
         m_Targets = null;
      }

      m_Time += Time.deltaTime;
   }
}
