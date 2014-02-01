// uScript Action Node
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Gets the Rigidbody2D component of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Rigidbody (2D)", "Gets the Rigidbody2D component of a GameObject.")]
public class uScriptAct_GetRigidBody2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject which contains a Rigidbody.")]
      GameObject Target,
      
      [FriendlyName("Rigidbody", "The Rigidbody of the GameObject.")]
      out Rigidbody2D rigidBody
      )
   {
      rigidBody = Target.rigidbody2D;
   }
}

#endif