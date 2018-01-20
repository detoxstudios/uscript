// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;

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
   bool m_UseDegreesPerSecond;
   bool m_Done;
   float m_Degrees;
   float m_DegreesPerSecond;
   float m_DegreesRemaining;
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
      bool Loop,

      [FriendlyName("Degrees Per Second", "If Use Degrees Per Second is true, this is the speed at which the rotation will take place. NOTE: this variable must have the same sign (i.e. positive or negative) as the Degrees variable.")]
      float DegreesPerSecond = 10.0f,

      [FriendlyName("Use Degrees Per Second", "If this is true, the rotation will happen at a constant rate, no matter how many degrees of rotation are needed.  If false, the rotation will take the number of seconds in the variable Seconds to complete.")]
      [SocketState(true, false)]
      bool UseDegreesPerSecond = false
      )
   {
      m_Target = new GameObject[Target.Length];
      m_TargetTransforms = new Quaternion[Target.Length];

      if ("x" == Axis || "X" == Axis) m_VectorAxis = Vector3.right;
      else if ("y" == Axis || "Y" == Axis) m_VectorAxis = Vector3.up;
      else m_VectorAxis = Vector3.forward;

      if (Degrees < 0.0f)
      {
         m_VectorAxis = m_VectorAxis * -1.0f;
         Degrees *= -1.0f;
      }

      int i = 0;

      foreach (GameObject obj in Target)
      {
         m_TargetTransforms[i] = obj.transform.rotation;
         m_Target[i] = obj;

         i++;
      }

      m_Seconds = Seconds;
      m_Degrees = Degrees;
      m_DegreesPerSecond = DegreesPerSecond;
      m_Loop = Loop;
      m_UseDegreesPerSecond = UseDegreesPerSecond;
      m_Time = 0f;
      m_DegreesRemaining = m_Degrees;
      m_Done = false;
   }

   public void Update()
   {
      if (null == m_Target) return;
      if (true == m_Done) return;

      int i = 0;

      if (!m_UseDegreesPerSecond)
      {
         if (m_Time > m_Seconds && m_Loop == true)
         {
            m_Time -= m_Seconds;
         }
         else if (m_Time > m_Seconds)
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
            Quaternion finalRotation = Quaternion.AngleAxis(degrees, m_VectorAxis);
            obj.transform.rotation = m_TargetTransforms[i] * finalRotation;

            i++;
         }

         m_Time += Time.deltaTime;
      }
      else
      {
         float degrees = m_DegreesPerSecond * Time.deltaTime;
         if (m_Degrees >= 0.0f)  // rotating in the positive direction
         {
            // check if we've gone past
            if (degrees >= m_DegreesRemaining)
            {
               degrees = m_DegreesRemaining;
               m_Done = true;
            }
         }
         else  // rotating in the negative direction
         {
            // check if we've gone past
            if (degrees <= m_DegreesRemaining)
            {
               degrees = m_DegreesRemaining;
               m_Done = true;
            }
         }
         m_DegreesRemaining -= degrees;

         foreach (GameObject obj in m_Target)
         {
            obj.transform.Rotate(m_VectorAxis, degrees);

            i++;
         }
      }
   }
}
