// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Joint))]

[NodePath("Events")]

[FriendlyName("Joint Events")]
public class uScript_Joint : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, JointBreakEventArgs args);

   public class JointBreakEventArgs : System.EventArgs
   {
      private float m_BreakForce;
      
      [FriendlyName("Break Force")]
      public float BreakForce { get { return m_BreakForce; } }

      public JointBreakEventArgs(float force)
      {
         m_BreakForce = force;
      }
   }

   [FriendlyName("On Joint Break")]
   public event uScriptEventHandler JointBreak;

   void OnJointBreak(float force)
   {
      if ( JointBreak != null ) JointBreak(this, new JointBreakEventArgs(force));
   }
   
   // uScript GUI Options
   void OnDrawGizmos()
   {
      // @TODO: would be nice if this would only show up if "UseGizmos" was true in uScriptConfig.
      if ( this.name != uScriptConfig.MasterObjectName )
      {
         Gizmos.DrawIcon(transform.position, "uscript_gizmo_events.png");
      }
   }

}
