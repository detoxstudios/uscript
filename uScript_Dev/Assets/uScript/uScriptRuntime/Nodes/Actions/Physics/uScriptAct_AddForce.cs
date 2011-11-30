// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Applies an Add Force to the specified GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Add_Force")]

[FriendlyName("Add Force", "Applies an Add Force to the specified GameObject. Target must have a Rigid Body Component in order to recieve a force.")]
public class uScriptAct_AddForce : uScriptLogic
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
		if  ( null != Target.rigidbody )
		{
         if (Scale != 0) { Force = Force * Scale; }

			if ( UseForceMode )
			{
				Target.rigidbody.AddForce(Force, ForceModeType);
			}
			else
			{
				Target.rigidbody.AddForce(Force);
			}
		}
		else
		{
			uScriptDebug.Log("(Node - Add Force) The specified Target GameObject does not have a Rigid Body Component, so no force could be added.", uScriptDebug.Type.Warning);
		}
		
      
   }
}