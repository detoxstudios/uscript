// uScript Action Node
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Sets the angular velocity of a GameObject's rigidbody2D component as a float.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Rigidbody2D Angular Velocity (2D)", "Sets the angular velocity of a GameObject's rigidbody2D component as a float.")]
public class uScriptAct_SetRigidbodyAngularVelocity2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject(s) to set the velocity of.")]
      GameObject[] Target,

      [FriendlyName("Velocity", "The velocity to give to the rigidbody2D component attached to the Target GameObject(s).")]
      float Velocity
      )
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null && currentTarget.rigidbody2D != null)
         {
            currentTarget.rigidbody2D.angularVelocity = Velocity;
         }
      }
   }
}

#endif