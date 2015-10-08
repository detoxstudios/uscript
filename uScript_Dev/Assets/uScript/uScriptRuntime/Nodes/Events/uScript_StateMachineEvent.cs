// uScript uScript_Collision.cs
// (C) 2010 Detox Studios LLC

[NodePath("Events/State Machine")]

[NodeCopyright("Copyright 2011-2015 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when various state machine (animator) events happen.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("On State Machine Event", "Fires an event signal when various state machine (animator) events happen. IMPORTANT NOTE: For this event to fire, you must attach a uScript_StateMachineBehaviour to a state in an animator and put the name of the state it's on in the State Name variable.")]
public class uScript_StateMachineEvent : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, StateMachineEventArgs args);

   public class StateMachineEventArgs : System.EventArgs
   {
      private string m_StateName;

      [FriendlyName("State Name", "The name of the state that triggered this event.")]
      public string StateName { get { return m_StateName; } }

      public StateMachineEventArgs(string stateName)
      {
         m_StateName = stateName;
      }
   }

   [FriendlyName("On State Enter")]
   public event uScriptEventHandler OnStateEnter;

   [FriendlyName("On State Exit")]
   public event uScriptEventHandler OnStateExit;

   [FriendlyName("On State Update")]
   public event uScriptEventHandler OnStateUpdate;

   [FriendlyName("On State Move")]
   public event uScriptEventHandler OnStateMove;

   [FriendlyName("On State IK")]
   public event uScriptEventHandler OnStateIK;

   void OnSMBStateEnter(string stateName)
   {
      if (OnStateEnter != null) OnStateEnter(this, new StateMachineEventArgs(stateName));
   }

   void OnSMBStateExit(string stateName)
   {
      if (OnStateExit != null) OnStateExit(this, new StateMachineEventArgs(stateName));
   }

   void OnSMBStateUpdate(string stateName)
   {
      if (OnStateUpdate != null) OnStateUpdate(this, new StateMachineEventArgs(stateName));
   }

   void OnSMBStateMove(string stateName)
   {
      if (OnStateMove != null) OnStateMove(this, new StateMachineEventArgs(stateName));
   }

   void OnSMBStateIK(string stateName)
   {
      if (OnStateIK != null) OnStateIK(this, new StateMachineEventArgs(stateName));
   }
}
