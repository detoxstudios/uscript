// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Sets the components of a JointDrive structure.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Joint Drive", "Sets the components of a JointDrive structure.")]
public class uScriptAct_SetJointDrive : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
#if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
      [FriendlyName("Mode", "The JointDriveMode.")]
      JointDriveMode mode,
#endif
      [FriendlyName("Position Spring", "The JointDrive PositionSpring.")]
      float positionSpring,

      [FriendlyName("Position Damper", "The PositionDamper of the JointDrive.")]
      float positionDamper,

      [FriendlyName("Maximum Force", "The MaximumForce of the JointDrive.")]
      float maximumForce,

      [FriendlyName("Joint Drive", "The newly created JointDrive.")]
      out JointDrive jointDrive
      )
   {
      JointDrive j = new JointDrive();
#if (UNITY_3_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
      j.mode = mode;
#endif
      j.positionSpring = positionSpring;
      j.positionDamper = positionDamper;
      j.maximumForce = maximumForce;

      jointDrive = j;
   }
}
