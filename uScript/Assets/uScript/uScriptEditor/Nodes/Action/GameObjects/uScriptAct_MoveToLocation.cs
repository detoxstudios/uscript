// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Moves a GameObject to a Vector3 Location. Optionally can choose to Lerp to
//       the location and use a local offset.

using UnityEngine;
using System.Collections;

public class uScriptAct_MoveToLocation : uScriptLogic
{

   private GameObject m_TargetObj = null;
   private GameObject[] m_TargetArray;
   private bool m_ShouldUseLocal = false;
   private Vector3 m_DestinationVector = new Vector3(0, 0, 0);
   private Vector3 m_DestinationVectorLocal = new Vector3(0, 0, 0);
   private bool m_UseLerp = false;
   private float m_LerpSpeedModifier = 0.0F;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);
   public event uScriptEventHandler Out;


   public void In(GameObject[] Target, Vector3 Location, bool AsOffset, bool UseLerp, float LerpSpeedModifier)
   {
      if ( Out != null ) Out(this, new System.EventArgs() );

      m_TargetArray = Target;

      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null)
         {
            m_TargetObj = currentTarget;
            m_ShouldUseLocal = AsOffset;
            m_DestinationVector = Location;
            m_DestinationVectorLocal = (currentTarget.transform.position + m_DestinationVector);
            m_UseLerp = UseLerp;
            m_LerpSpeedModifier = LerpSpeedModifier;

            if (!m_UseLerp)
            {
               if (m_ShouldUseLocal)
               {
                  m_TargetObj.transform.position = m_DestinationVectorLocal;
               }
               else
               {
                  m_TargetObj.transform.position = m_DestinationVector;
               }
            }

         }
      }

   }

   public override void _InternalUpdate()
   {
      if (m_UseLerp)
      {
         foreach (GameObject currentTarget in m_TargetArray)
         {
            if (currentTarget != null)
            {

               if (m_ShouldUseLocal)
               {
                  currentTarget.transform.position = Vector3.Lerp(currentTarget.transform.position, m_DestinationVectorLocal, Time.deltaTime * m_LerpSpeedModifier);
               }
               else
               {
                  currentTarget.transform.position = Vector3.Lerp(currentTarget.transform.position, m_DestinationVector, Time.deltaTime * m_LerpSpeedModifier);
               }
            }
         }

      }
   }

}