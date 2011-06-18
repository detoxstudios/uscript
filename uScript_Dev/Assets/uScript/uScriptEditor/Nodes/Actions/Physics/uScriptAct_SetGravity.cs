// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the gravity applied to all rigid bodies.


using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the gravity applied to all rigid bodies.")]
[NodeDescription("Sets the gravity force and direction applied to all rigid bodies. Use a zero Vector3 to turn gravity off (0, 0, 0).\n\nGravity: Defines the force and direction of gravity.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Gravity")]
public class uScriptAct_SetGravity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Force")] Vector3 Gravity)
   {
		 Physics.gravity = Gravity;
      
   }
}