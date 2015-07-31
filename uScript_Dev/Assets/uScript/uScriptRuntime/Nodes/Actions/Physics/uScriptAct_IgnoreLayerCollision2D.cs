// uScript Action Node
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Tells the collision detection system ignore all 2D collisions between any GameObject in Layer A and any GameObject in Layer B.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Ignore Layer Collision (2D)", "Tells the collision detection system ignore all 2D collisions between any GameObject in Layer A and any GameObject in Layer B.")]
public class uScriptAct_IgnoreLayerCollision2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Layer A", "The first layer.")]
      LayerMask LayerA,
      
      [FriendlyName("Layer B", "The second layer.")]
      LayerMask LayerB,
      
      [FriendlyName("Ignore", "True = Ignore collisions between the layers, False = Enable collisions between the layers.")]
      [DefaultValue(true), SocketState(false, false)]
      bool Ignore
      )
   {
      if (LayerA != LayerB)
      {
         Physics2D.IgnoreLayerCollision(1 << LayerA, 1 << LayerB, Ignore);
      }
   }
}

#endif