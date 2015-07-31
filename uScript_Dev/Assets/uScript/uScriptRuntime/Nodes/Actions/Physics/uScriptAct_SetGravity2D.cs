// uScript Action Node
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Sets the 2D gravity force and direction applied to all rigidbody2D components.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Gravity (2D)", "Sets the 2D gravity force and direction applied to all rigidbody2D components. Use a zero Vector2 to turn gravity off (0, 0).")]
public class uScriptAct_SetGravity2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Gravity", "Defines the 2D force and direction of the gravity.")]
      Vector2 Gravity
      )
   {
		 Physics2D.gravity = Gravity;
      
   }
}

#endif