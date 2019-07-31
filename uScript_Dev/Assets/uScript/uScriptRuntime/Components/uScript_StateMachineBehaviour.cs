using UnityEngine;

public class uScript_StateMachineBehaviour : StateMachineBehaviour {
   public string StateName;

   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      animator.gameObject.SendMessage("OnSMBStateEnter", StateName);
   }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      animator.gameObject.SendMessage("OnSMBStateUpdate", StateName);
   }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      animator.gameObject.SendMessage("OnSMBStateExit", StateName);
   }

   // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
   override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      animator.gameObject.SendMessage("OnSMBStateMove", StateName);
   }

   // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
   override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
      animator.gameObject.SendMessage("OnSMBStateIK", StateName);
   }
}
