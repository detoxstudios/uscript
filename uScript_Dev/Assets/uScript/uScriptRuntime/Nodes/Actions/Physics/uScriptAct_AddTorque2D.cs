// uScript Action Node
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Applies an Add Torque 2D to the specified GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Add Torque (2D)", "Applies an Add Torque 2D to the specified GameObject. Target must have a rigidbody2D component in order to recieve a force.")]
public class uScriptAct_AddTorque2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject to apply the force to.")]
      GameObject Target,

      [FriendlyName("Force", "The force to apply to the Target.")]
      float Force,
      
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
		if  ( null != Target.rigidbody2D )
		{
         if (Scale != 0) { Force = Force * Scale; }

         Target.rigidbody2D.AddTorque(Force);
		}
#else
      if (null != Target.GetComponent<Rigidbody2D>())
      {
         if (Scale != 0) { Force = Force * Scale; }

         Target.GetComponent<Rigidbody2D>().AddTorque(Force);
      }
#endif
		else
		{
         uScriptDebug.Log("(Node - Add Torque (2D)) The specified Target GameObject does not have a rigidbody2D component, so no force could be added.", uScriptDebug.Type.Warning);
		}
		
      
   }
}

#endif