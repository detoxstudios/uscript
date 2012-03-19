// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the velocity of a GameObject's Rigidbody as a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Rigidbody_Velocity")]

[FriendlyName("Get Rigidbody Velocity", "Gets the velocity of a GameObject's Rigidbody as a Vector3. If Target does not have a rigidbody component, will return Vector3.zero.")]
public class uScriptAct_GetRigidbodyVelocity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject to get the velocity of.")]
      GameObject Target,
      
      [FriendlyName("Velocity", "The velocity of the rigidbody component attached to Target.")]
      out Vector3 Velocity,
 
      [FriendlyName("Magnitude", "The magnitude of the rigidbody component attached to Target.")]
       out float Magnitude
   )
   {
      if (Target != null && Target.GetComponent<Rigidbody>( ))
      {
         Velocity = Target.rigidbody.velocity;
         Magnitude = Velocity.magnitude;
      }
      else
      {
         Velocity = Vector3.zero;
         Magnitude = 0;      
      }
   }
}
