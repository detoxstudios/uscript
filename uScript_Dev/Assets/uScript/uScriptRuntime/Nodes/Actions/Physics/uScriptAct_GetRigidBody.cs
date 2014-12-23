// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the Rigidbody component of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Rigidbody")]

[FriendlyName("Get Rigidbody", "Gets the Rigidbody component of a GameObject.")]
public class uScriptAct_GetRigidBody : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject which contains a Rigidbody.")]
      GameObject Target,
      
      [FriendlyName("Rigidbody", "The Rigidbody of the GameObject.")]
      out Rigidbody rigidBody
      )
   {
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6)
      rigidBody = Target.rigidbody;
#else
      rigidBody = Target.GetComponent<Rigidbody>();
#endif
   }
}