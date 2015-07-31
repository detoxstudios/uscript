// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the gravity applied to all rigid bodies.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Gravity", "Sets the gravity force and direction applied to all rigid bodies. Use a zero Vector3 to turn gravity off (0, 0, 0).")]
public class uScriptAct_SetGravity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Gravity", "Defines the force and direction of gravity.")]
      Vector3 Gravity
      )
   {
		 Physics.gravity = Gravity;
      
   }
}