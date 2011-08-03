// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Tells the collision detection system ignore all collisions between any GameObject in Layer A and any GameObject in Layer B.


using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Tells the collision detection system ignore all collisions between any GameObject in Layer A and any GameObject in Layer B.")]
[NodeDescription("Tells the collision detection system ignore all collisions between any GameObject in Layer A and any GameObject in Layer B.\n\nLayer A: The first layer.\nLayer B: The second layer.\nIgnore: True = Ignore collisions between the layers, False = Enable collisions between the layers.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Ignore_Layer_Collision")]

[FriendlyName("Ignore Layer Collision")]
public class uScriptAct_IgnoreLayerCollision : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Layer A")] LayerMask LayerA, [FriendlyName("Layer B")] LayerMask LayerB, [DefaultValue(true), SocketState(false, false)] bool Ignore)
   {
      if (LayerA != LayerB)
      {
         Physics.IgnoreLayerCollision(1 << LayerA, 1 << LayerB, Ignore);
      }
   }
}