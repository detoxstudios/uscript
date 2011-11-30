// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Tells the collision detection system ignore all collisions between any GameObject in Layer A and any GameObject in Layer B.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Ignore_Layer_Collision")]

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
      if (LayerA != LayerB)
      {
         Physics.IgnoreLayerCollision(1 << LayerA, 1 << LayerB, Ignore);
      }
   }
}