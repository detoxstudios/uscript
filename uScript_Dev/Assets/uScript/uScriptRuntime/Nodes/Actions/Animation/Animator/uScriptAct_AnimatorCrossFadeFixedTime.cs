// uScript Action Node
// (C) 2015 Detox Studios LLC
#if (UNITY_5_1 || UNITY_5_2 || UNITY_5_3 || UNITY_5_4 || UNITY_5_5 || UNITY_5_6 || UNITY_5_7 || UNITY_5_8 || UNITY_5_9)
using UnityEngine;
using System.Collections;

[NodePath("Actions/Animation/Animator")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Creates a dynamic transition between the current state and the destination state in fixed time (seconds).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Animator Cross Fade (Fixed Time)", "Creates a dynamic transition between the current state and the destination state in fixed time (seconds). Both states have to be on the same layer. You cannot change the current state on a synchronized layer, you need to change it on the referenced layer.")]
public class uScriptAct_AnimatorCrossFadeFixedTime : uScriptLogic
{

   public bool Out { get { return true; } }
   
   public void In(
      [FriendlyName("Target", "The target GameObject(s) that contain the Animator Controller component with the paremeter you wish to set."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("State Name", "The name of the destination state.")]
      string Name,

      [FriendlyName("Duration", "The duration of the transition. Value is in seconds.")]
      [DefaultValue(1f)]
      float  Duration,

      [FriendlyName("Fixed Time", "Start time of the current destination state. Value is in seconds. If no explicit fixedTime is specified or fixedTime value is float.NegativeInfinity, the state will either be played from the start if it's not already playing, or will continue playing from its current time and no transition will happen.")]
      [DefaultValue(-1f)]
      [SocketState(false, false)]
      float  FixedTime,

      [FriendlyName("Layer", "Layer index containing the destination state. If no layer is specified or layer is -1, the first state that is found with the given name or hash will be played.")]
      [DefaultValue(-1)]
      [SocketState(false, false)]
      int  Layer
      )
   {
      foreach (GameObject obj in Target)
      {
         Animator animController = obj.GetComponent<Animator>();
         if (null != animController)
         {
            float finalTime = FixedTime;
            if (finalTime == -1f) { finalTime = float.NegativeInfinity; }

            animController.CrossFadeInFixedTime(Name, Duration, Layer, finalTime);
         }
         else
         {
            uScriptDebug.Log("The specified Target (" + obj.ToString() + ") does not have an Animator Controller component and will be skipped.");
         }
      }
       
   }

  
}
#endif