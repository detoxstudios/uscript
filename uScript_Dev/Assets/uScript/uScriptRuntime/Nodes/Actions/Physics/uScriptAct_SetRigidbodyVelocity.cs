// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the velocity of a GameObject's Rigidbody as a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Rigidbody Velocity", "Sets the velocity of a GameObject's Rigidbody as a Vector3.")]
public class uScriptAct_SetRigidbodyVelocity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject(s) to set the velocity of."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Velocity", "The velocity to give to the rigidbody component attached to the Target GameObject(s).")]
      Vector3 Velocity
      )
   {
      foreach (GameObject currentTarget in Target)
      {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
         if (currentTarget != null && currentTarget.rigidbody != null)
         {
            currentTarget.rigidbody.velocity = Velocity;
         }
#else
         if (currentTarget != null && currentTarget.GetComponent<Rigidbody>() != null)
         {
            currentTarget.GetComponent<Rigidbody>().velocity = Velocity;
         }
#endif
      }
   }
}