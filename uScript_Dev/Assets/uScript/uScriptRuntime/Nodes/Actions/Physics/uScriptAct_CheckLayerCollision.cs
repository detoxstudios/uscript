// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns True or False if collisions are being ignored between Layer A and Layer B.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Check Layer Collision", "Returns True or False if collisions are being ignored between Layer A and Layer B.")]
public class uScriptAct_CheckLayerCollision : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Layer A", "The first layer.")]
      LayerMask LayerA,

      [FriendlyName("Layer B", "The second layer.")]
      LayerMask LayerB,

      [FriendlyName("Result", "True = collisions are being ignored between the layers, False = collisions are NOT being ignored between the layers.")]
      out bool Result
      )
   {
      if (LayerA != LayerB)
      {
         Result = Physics.GetIgnoreLayerCollision(1 >> LayerA, 1 >> LayerB);
      }
      else
      {
         Result = false;
      }
   }
}