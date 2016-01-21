// uScript Action Node
// (C) 2016 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Gets the angular velocity of a GameObject's Rigidbody as a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Rigidbody Angular Velocity", "Gets the angular velocity of a GameObject's Rigidbody as a Vector3. If Target does not have a rigidbody component, will return Vector3.zero.")]
public class uScriptAct_GetRigidbodyAngularVelocity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject to get the angular velocity of.")]
      GameObject Target,
      
      [FriendlyName("Velocity", "The angular velocity of the rigidbody component attached to Target.")]
      out Vector3 Velocity,
 
      [FriendlyName("Magnitude", "The magnitude of the rigidbody component attached to Target.")]
       out float Magnitude
   )
   {
      if (Target != null && Target.GetComponent<Rigidbody>( ))
      {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
         Velocity = Target.rigidbody.angularVelocity;
#else
         Velocity = Target.GetComponent<Rigidbody>().angularVelocity;
#endif
         Magnitude = Velocity.magnitude;
      }
      else
      {
         Velocity = Vector3.zero;
         Magnitude = 0;      
      }
   }
}
