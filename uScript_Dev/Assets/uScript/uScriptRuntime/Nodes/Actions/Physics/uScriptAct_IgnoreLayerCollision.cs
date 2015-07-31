// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Tells the collision detection system ignore all collisions between any GameObject in Layer A and any GameObject in Layer B.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Ignore Layer Collision", "Tells the collision detection system ignore all collisions between any GameObject in Layer A and any GameObject in Layer B.")]
public class uScriptAct_IgnoreLayerCollision : uScriptLogic
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

      int a = 0, b = 0;

      for (int i = 0; i < 32; i++)
      {
         if (0 != (LayerA.value & (1 << i)))
         {
            a = i;
            break;
         }
      }

      for (int i = 0; i < 32; i++)
      {
         if (0 != (LayerB.value & (1 << i)))
         {
            b = i;
            break;
         }
      }

      Physics.IgnoreLayerCollision(a, b, Ignore);
   }
}