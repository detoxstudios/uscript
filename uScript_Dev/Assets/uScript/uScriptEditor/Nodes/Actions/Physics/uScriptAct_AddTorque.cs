// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Applies an Add Torque to the specified GameObject


using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Applies an Add Torque to the specified GameObject.")]
[NodeDescription("Applies an Add Torque to the specified GameObject. Target must have a Rigid Body Component in order to recieve a force\n \nTarget: GameObject to apply the force to.\nForce: The force to apply to the Target. The force is a Vector3, so it defines both the direction and magnitude of the force.\nScale: A scale to multiply to the force (force x scale).\nUse ForceMode: The force being applied will use the object's mass.\nForceMode Type: Specifies the ForceMode to use if Use ForceMode is set to true.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Add Torque")]
public class uScriptAct_AddTorque : uScriptLogic
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
				Target.rigidbody.AddTorque(Force, ForceModeType);
			}
			else
			{
				Target.rigidbody.AddTorque(Force);
			}
		}
		else
		{
			uScriptDebug.Log("(Node - Add Torque) The specified Target GameObject does not have a Rigid Body Component, so no force could be added.", uScriptDebug.Type.Warning);
		}
		
      
   }
}