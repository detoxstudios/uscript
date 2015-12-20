// uScript uScript_Collision2D.cs
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Applies a 2D Add Force to the specified GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]


[FriendlyName("Add Force (2D)", "Applies a 2D Add Force to the specified GameObject. Target must have a RigidBody2D Component in order to recieve a force.")]
public class uScriptAct_AddForce2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(

        [FriendlyName("Target", "GameObject to apply the force to.")]
        GameObject Target,

        [FriendlyName("Force", "The force to apply to the Target. The force is a Vector2, so it defines both the direction and magnitude of the force.")]
        Vector2 force,

        [FriendlyName("Scale", "A scale to multiply to the force (force x scale).")]
        float scale
   )
   {
      if (null != Target)
      {
         if (scale != 0)
         {
            force = force * scale;
         }
#if (UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7)
         if (null != Target.rigidbody2D)
         {
            Target.rigidbody2D.AddForce(force);
         }
#else
         if (null != Target.GetComponent<Rigidbody2D>())
         {
            Target.GetComponent<Rigidbody2D>().AddForce(force);
         }

#endif
      }
   }
}

#endif
