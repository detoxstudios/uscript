// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the velocity of a GameObject's Rigidbody as a Vector3.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the velocity of a GameObject's Rigidbody as a Vector3.")]
[NodeDescription("Sets the velocity of a GameObject's Rigidbody as a Vector3.\n \nTarget: GameObject(s) to set the velocity of.\nVelocity: The velocity to give to the rigidbody component attached to the Target GameObject(s).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Rigidbody Velocity")]
public class uScriptAct_SetRigidbodyVelocity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(GameObject[] Target, Vector3 Velocity)
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null && currentTarget.GetComponent("rigidbody"))
         {
            currentTarget.rigidbody.velocity = Velocity;
         }
      }
   }
}