// uScript Action Node
// (C) 2016 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2016 by Detox Studios LLC")]
[NodeToolTip("Sets the angular velocity of a GameObject's Rigidbody as a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Rigidbody Angular Velocity", "Sets the angular velocity of a GameObject's Rigidbody as a Vector3.")]
public class uScriptAct_SetRigidbodyAngularVelocity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject(s) to set the angular velocity of."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Angular Velocity", "The angular velocity to give to the rigidbody component attached to the Target GameObject(s).")]
      Vector3 Velocity
      )
   {
      foreach (GameObject currentTarget in Target)
      {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
         if (currentTarget != null && currentTarget.rigidbody != null)
         {
            currentTarget.rigidbody.angularVelocity = Velocity;
         }
#else
         if (currentTarget != null && currentTarget.GetComponent<Rigidbody>() != null)
         {
            currentTarget.GetComponent<Rigidbody>().angularVelocity = Velocity;
         }
#endif
      }
   }
}
