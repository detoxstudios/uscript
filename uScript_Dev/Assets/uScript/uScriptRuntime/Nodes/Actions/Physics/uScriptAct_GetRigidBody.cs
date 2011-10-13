// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the velocity of a GameObject's Rigidbody as a Vector3.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the Rigidbody component of a GameObject.")]
[NodeDescription("Gets the Rigidbody component of a GameObject..\n \nTarget: GameObject which contains a Rigidbody.\n(out) Rigidbody: The Rigidbody of the GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Rigidbody")]

[FriendlyName("Get Rigidbody")]
public class uScriptAct_GetRigidBody : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(GameObject Target, [FriendlyName("Rigidbody")] out Rigidbody rigidBody)
   {
      rigidBody = Target.rigidbody;
   }
}