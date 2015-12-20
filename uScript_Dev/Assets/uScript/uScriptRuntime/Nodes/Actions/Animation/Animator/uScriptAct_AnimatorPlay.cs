// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_4_6 || UNITY_4_7 || UNITY_5)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Playes an Animator State.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Play", "Playes an Animator State. This could be used to synchronize your animation with audio or synchronize an Animator over the network.")]
public class uScriptAct_AnimatorPlay : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject(s) that contain the Animator Controller component with the paremeter you wish to set."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("State Name", "The name of the state to play.")]
      string Name,

      [FriendlyName("Layer", "The layer where the state is. If no layer is specified or layer is -1, the first state that is found with the given name or hash will be played.")]
      [DefaultValue(-1)]
      int Layer,

      [FriendlyName("Normalized Time", "The normalized time at which the state will play. If no explicit normalizedTime is specified or normalizedTime value is float.NegativeInfinity, the state will either be played from the start if it's not already playing, or will continue playing from its current time.")]
      [DefaultValue(-1f)]
      [SocketState(false, false)]
      float NormalizedTime
      )
   {
      foreach (GameObject obj in Target)
      {
         Animator animController = obj.GetComponent<Animator>();
         if (null != animController)
         {
            float finalTime = NormalizedTime;
            if (finalTime == -1f) { finalTime = float.NegativeInfinity; }

            animController.Play(Name, Layer, finalTime);
         }
         else
         {
            uScriptDebug.Log("The specified Target (" + obj.ToString() + ") does not have an Animator Controller component and will be skipped.");
         }
      }
       
   }

  
}
#endif
