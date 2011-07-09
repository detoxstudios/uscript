// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Applies an Add Relative Torque to the specified GameObject


using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the position and rotation of a GameObject and outputs them as a Vector3.")]
[NodeDescription("Applies an Add Relative Torque to the specified GameObject. Target must have a Rigid Body Component in order to recieve a force\n \nTarget: GameObject to apply the force to.\nForce: The force to apply to the Target. The force is a Vector3, so it defines both the direction and magnitude of the force.\nScale: A scale to multiply to the force (force x scale).\nUse ForceMode: The force being applied will use the object's mass.\nForceMode Type: Specifies the ForceMode to use if Use ForceMode is set to true.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Add_Relative_Torque")]

[FriendlyName("Add Relative Torque")]
public class uScriptAct_AddRelativeTorque : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
	               [FriendlyName("Target")] GameObject Target,
	               [FriendlyName("Force")] Vector3 Force,
                  [FriendlyName("Scale"), DefaultValue(0f), SocketState(false, false)] float Scale,
	               [FriendlyName("Use ForceMode"), SocketState(false, false)] bool UseForceMode,
	               [FriendlyName("ForceMode Type"), SocketState(false, false)] ForceMode ForceModeType
      
      )
   {
		if  ( null != Target.rigidbody )
		{
         if (Scale != 0) { Force = Force * Scale; }

			if ( UseForceMode )
			{
				Target.rigidbody.AddRelativeTorque(Force, ForceModeType);
			}
			else
			{
				Target.rigidbody.AddRelativeTorque(Force);
			}
		}
		else
		{
			uScriptDebug.Log("(Node - Add Relative Torque) The specified Target GameObject does not have a Rigid Body Component, so no force could be added.", uScriptDebug.Type.Warning);
		}
		
      
   }
}