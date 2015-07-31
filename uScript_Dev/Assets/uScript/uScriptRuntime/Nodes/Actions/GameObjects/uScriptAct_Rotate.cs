// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Rotates the target GameObject by a number of degrees over X seconds.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Rotate", "Rotates the target GameObject by a number of degrees over X seconds.")]
public class uScriptAct_Rotate : uScriptLogic
{
   GameObject[] m_Target;
   float m_Seconds;
   float m_Time;
   bool m_Loop;
   bool m_Done;
   float m_Degrees;
   Quaternion[] m_TargetTransforms;
   Vector3 m_VectorAxis;
   
   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The Target GameObject(s) to rotate."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Degrees", "The number of degrees to rotate.")]
      float Degrees,
      
      [FriendlyName("Axis", "The axis to rotate around.")]
      string Axis,
      
      [FriendlyName("Seconds", "The number of seconds to complete the full rotation.")]
      float Seconds,
      
      [FriendlyName("Loop", "Whether or not to loop the rotation.")]
      [SocketState(false, false)]
      bool Loop
      )
   {
      m_Target = new GameObject[Target.Length];
      m_TargetTransforms = new Quaternion[Target.Length];
      
      if ( "x" == Axis || "X" == Axis ) m_VectorAxis = Vector3.right;
      else if ( "y" == Axis || "Y" == Axis ) m_VectorAxis = Vector3.up;
      else m_VectorAxis = Vector3.forward;
      
      if ( Degrees < 0.0f ) 
      {
         m_VectorAxis = m_VectorAxis * -1.0f;
         Degrees *= -1.0f;
      }
      
      int i = 0;
      
      foreach ( GameObject obj in Target )
      {
         m_TargetTransforms[i] = obj.transform.rotation;         
         m_Target[i] = obj;
   
         i++;
      }
      
      m_Seconds = Seconds;
      m_Degrees = Degrees;
      m_Loop = Loop;
      m_Time = 0f;
      m_Done = false;
   }
   
   public void Update()
   {
      if ( null == m_Target ) return;
      if ( true == m_Done ) return;
      
      int i = 0;

      if ( m_Time > m_Seconds && m_Loop == true )
      {
         m_Time -= m_Seconds;         
      }
      else if ( m_Time > m_Seconds )
      {
         m_Time = m_Seconds;
         m_Done = true;
      }
      
      float t = 1.0f;
      
      // Prevent div by 0
      if (m_Seconds != 0.0f)
      {
         t = m_Time / m_Seconds;
      }      
      float degrees = m_Degrees * t;
      
      foreach (GameObject obj in m_Target)
      {        
         Quaternion finalRotation = Quaternion.AngleAxis( degrees, m_VectorAxis );         
         obj.transform.rotation = m_TargetTransforms[i] * finalRotation;
                                   
         i++;
      }
      
      m_Time += Time.deltaTime;
   }
}