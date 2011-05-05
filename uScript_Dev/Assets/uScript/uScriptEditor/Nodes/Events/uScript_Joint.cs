// uScript uScript_Global.cs
// (C) 2010 Detox Studios LLC
// Desc: uScript Global contains all project global related events. Assign this component to
//       your master uScript GameObject (_uScripts by default).

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Joint))]

[NodePath("Events/Physics Events")]

[FriendlyName("Joint Break")]
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
}
