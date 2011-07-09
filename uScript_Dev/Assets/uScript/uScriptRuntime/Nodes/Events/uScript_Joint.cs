// uScript uScript_Joint.cs
// (C) 2010 Detox Studios LLC
// Desc: Fires an event signal when one of Instance's joints breaks.

using UnityEngine;
using System.Collections;

[NodeComponentType(typeof(Joint))]

[NodePath("Events/Physics Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when one of Instance's joints breaks.")]
[NodeDescription("Fires an event signal when one of Instance's joints breaks.\n \nBreak Force: The magnitude of the force that caused the joint break.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Joint_Break")]

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
