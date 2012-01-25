// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the velocity of a GameObject's Rigidbody as a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Rigidbody_Velocity")]

[FriendlyName("Set Rigidbody Velocity", "Sets the velocity of a GameObject's Rigidbody as a Vector3.")]
public class uScriptAct_SetRigidbodyVelocity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject(s) to set the velocity of.")]
      GameObject[] Target,
      
      [FriendlyName("Velocity", "The velocity to give to the rigidbody component attached to the Target GameObject(s).")]
      Vector3 Velocity
      )
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null && currentTarget.rigidbody != null)
         {
            currentTarget.rigidbody.velocity = Velocity;
         }
      }
   }
}