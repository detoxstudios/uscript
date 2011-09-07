// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Applies an Add Relative Force to the specified GameObject


using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the components of a JointDrive structure.")]
[NodeDescription("Sets the components of a JointDrive structure.\n \nMode: The JointDriveMode.\nPosition Spring: The JointDrive PositionSpring.\nPosition Damper: The PositionDamper of the JointDrive.\nMaximum Force: The MaximumForce of the JointDrive.\n(out) Joint Drive: The newly created JointDrive.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Joint_Drive")]

[FriendlyName("Set Joint Drive")]
public class uScriptAct_SetJointDrive : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
	               [FriendlyName("Mode")] JointDriveMode mode,
	               [FriendlyName("Position Spring")] float positionSpring,
	               [FriendlyName("Position Damper")] float positionDamper,
	               [FriendlyName("Maximum Force")] float maximumForce,
                  [FriendlyName("Joint Drive")] out JointDrive jointDrive
      
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