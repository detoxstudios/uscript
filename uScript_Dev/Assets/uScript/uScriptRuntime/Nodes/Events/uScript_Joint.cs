// uScript uScript_Joint.cs
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Events/Physics Events")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when one of Instance's joints breaks.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Joint Break", "Fires an event signal when one of Instance's joints breaks.")]
public class uScript_Joint : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, JointBreakEventArgs args);

   public class JointBreakEventArgs : System.EventArgs
   {
      private float m_BreakForce;
      
      [FriendlyName("Break Force", "The magnitude of the force that caused the joint break.")]
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
