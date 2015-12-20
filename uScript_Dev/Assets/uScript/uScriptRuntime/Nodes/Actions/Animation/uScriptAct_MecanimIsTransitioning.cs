// uScript Action Node
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Mecanim")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Check if mecanim is transitioning between two specified states.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Mecanim Is Transitioning", "Check if mecanim is transitioning between two specified states.")]
public class uScriptAct_MecanimIsTransitioning : uScriptLogic
{
   private Animator m_Animator;
   private int m_OldState = -1;
   private int m_NewState = -1;
   private int m_LayerIndex = -1;
   private bool m_CheckForTransitions = false;
   private bool m_SentFirst = false;
   private bool m_CheckOld = false;
   private bool m_CheckNew = false;

   public delegate void uScriptEventHandler(object sender, System.EventArgs args);

   public bool Out { get { return true; } }
   public bool Transitioning { get { return m_SentFirst; } }
   
   [FriendlyName("Started Transitioning")]
   public event uScriptEventHandler StartedTransitioning;

   [FriendlyName("Finished Transitioning")]
   public event uScriptEventHandler FinishedTransitioning;

   public void In(
      [FriendlyName("Target", "The target GameObject to check for transitions on.")]
      GameObject Target,

      [FriendlyName("Old State", "The name of the mecanim state that the game object is transitioning out of.")]
      string oldState,

      [FriendlyName("New State", "The name of the mecanim state that the game object is transitioning into.")]
      string newState,

      [FriendlyName("Layer", "The index of the mecanim layer that the states are on (usually 0)."),
       DefaultValue(0), 
       SocketState(false, false)]
      int layer)
   {
      m_Animator = Target.GetComponent<Animator>();
      m_CheckOld = !string.IsNullOrEmpty(oldState);
      m_CheckNew = !string.IsNullOrEmpty(newState);
      if ( m_CheckOld ) m_OldState = Animator.StringToHash(oldState);
      if ( m_CheckNew ) m_NewState = Animator.StringToHash(newState);
      m_LayerIndex = layer;
      m_CheckForTransitions = true;
   }

   public void Start()
   {
      m_SentFirst = false;
   }
   
   private void StartTransitioning()
   {
      if ( null != StartedTransitioning ) StartedTransitioning( this, new System.EventArgs() );
      m_SentFirst = true;
   }

   private void FinishTransitioning()
   {
      if ( null != FinishedTransitioning ) FinishedTransitioning( this, new System.EventArgs() );
      m_SentFirst = false;
   }
    
   public void Update()
   {
      if ( m_CheckForTransitions && null != m_Animator )
      {
         if ( m_Animator.IsInTransition(m_LayerIndex) )
         {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
            if ( (!m_CheckOld || m_Animator.GetCurrentAnimatorStateInfo(m_LayerIndex).nameHash == m_OldState) && (!m_CheckNew || m_Animator.GetNextAnimatorStateInfo(m_LayerIndex).nameHash == m_NewState) )
#else
            if ((!m_CheckOld || m_Animator.GetCurrentAnimatorStateInfo(m_LayerIndex).fullPathHash == m_OldState) && (!m_CheckNew || m_Animator.GetNextAnimatorStateInfo(m_LayerIndex).fullPathHash == m_NewState))
#endif
            {
               if ( !m_SentFirst )
               {
                  // m_SentFirst is false, so we must just be starting to transition
                  StartTransitioning();
               }
            }
            else if ( m_SentFirst )
            {
               // if we were doing the specified transition last frame, we need to finish it because we're doing a different one now
               FinishTransitioning();
            }
         }
         else
         {
            if ( m_SentFirst )
            {
               // we were transitioning because m_SentFirst is true, so we must have just stopped
               FinishTransitioning();
            }
         }
      }
   }

}
#endif