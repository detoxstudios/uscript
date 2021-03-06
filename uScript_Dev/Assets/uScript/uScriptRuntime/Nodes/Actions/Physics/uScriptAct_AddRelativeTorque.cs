// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the position and rotation of a GameObject and outputs them as a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Add Relative Torque", "Applies an Add Relative Torque to the specified GameObject. Target must have a Rigid Body Component in order to recieve a force.")]
public class uScriptAct_AddRelativeTorque : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject to apply the force to.")]
      GameObject Target,
      
      [FriendlyName("Force", "The force to apply to the Target. The force is a Vector3, so it defines both the direction and magnitude of the force.")]
      Vector3 Force,
      
      [FriendlyName("Scale", "A scale to multiply to the force (force x scale).")]
      [DefaultValue(0f), SocketState(false, false)]
      float Scale,
      
      [FriendlyName("Use ForceMode", "The force being applied will use the object's mass.")]
      [SocketState(false, false)]
      bool UseForceMode,
      
      [FriendlyName("ForceMode Type", "Specifies the ForceMode to use if Use ForceMode is set to true.")]
      [SocketState(false, false)]
      ForceMode ForceModeType
      )
   {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
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
#else
      if (null != Target.GetComponent<Rigidbody>())
		{
         if (Scale != 0) { Force = Force * Scale; }

			if ( UseForceMode )
			{
            Target.GetComponent<Rigidbody>().AddRelativeTorque(Force, ForceModeType);
			}
			else
			{
            Target.GetComponent<Rigidbody>().AddRelativeTorque(Force);
			}
		}
#endif
		else
		{
			uScriptDebug.Log("(Node - Add Relative Torque) The specified Target GameObject does not have a Rigid Body Component, so no force could be added.", uScriptDebug.Type.Warning);
		}
		
      
   }
}