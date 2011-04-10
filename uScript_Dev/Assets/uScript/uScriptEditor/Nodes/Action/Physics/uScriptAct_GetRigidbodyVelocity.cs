// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Gets the velocity of a GameObject's Rigidbody as a Vector3.

using UnityEngine;
using System.Collections;

[NodePath("Action/Physics")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the velocity of a GameObject's Rigidbody as a Vector3.")]
[NodeDescription("Gets the velocity of a GameObject's Rigidbody as a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Raycast")]
public class uScriptAct_GetRigidbodyVelocity : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject Target, out Vector3 Velocity)
   {

      if (Target != null && Target.GetComponent("rigidbody"))
      {
         Velocity = Target.rigidbody.velocity;
      }
      else
      {
         Velocity = Vector3.zero;
      }

   }
}