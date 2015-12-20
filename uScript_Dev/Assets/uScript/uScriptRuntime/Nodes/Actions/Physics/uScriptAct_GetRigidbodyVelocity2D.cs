// uScript Action Node
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Gets the velocity of a GameObject's Rigidbody as a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Rigidbody Velocity (2D)", "Gets the velocity of a GameObject's Rigidbody2D component as a Vector2. If Target does not have a Rigidbody2D component, will return Vector2.zero.")]
public class uScriptAct_GetRigidbodyVelocity2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject to get the velocity of.")]
      GameObject Target,
      
      [FriendlyName("Velocity", "The velocity of the rigidbody component attached to Target.")]
      out Vector2 Velocity,

      [FriendlyName("AngularVelocity", "The velocity of the rigidbody component attached to Target.")]
      [SocketStateAttribute(false, false)]
	  out float AngularVelocity,
 
      [FriendlyName("Magnitude", "The magnitude of the rigidbody component attached to Target.")]
       out float Magnitude
   )
   {
      if (Target != null && Target.GetComponent<Rigidbody2D>( ))
      {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
         Velocity = Target.rigidbody2D.velocity;
         AngularVelocity = Target.rigidbody2D.angularVelocity;
#else
         Velocity = Target.GetComponent<Rigidbody2D>().velocity;
         AngularVelocity = Target.GetComponent<Rigidbody2D>().angularVelocity;
#endif
         Magnitude = Velocity.magnitude;
      }
      else
      {
         Velocity = Vector2.zero;
         AngularVelocity = 0;
         Magnitude = 0;
      }
   }
}

#endif
