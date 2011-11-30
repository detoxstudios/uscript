// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the components of a JointDrive structure.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Joint_Drive")]

[FriendlyName("Set Joint Drive", "Sets the components of a JointDrive structure.")]
public class uScriptAct_SetJointDrive : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Mode", "The JointDriveMode.")]
      JointDriveMode mode,
      
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
      JointDrive j = new JointDrive( );
      
      j.mode = mode;
      j.positionSpring = positionSpring;
      j.positionDamper = positionDamper;
      j.maximumForce   = maximumForce;

      jointDrive = j;
   }
}