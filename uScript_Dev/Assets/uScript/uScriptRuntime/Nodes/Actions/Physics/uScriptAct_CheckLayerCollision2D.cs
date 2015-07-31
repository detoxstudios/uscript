// uScript Action Node
// (C) 2014 Detox Studios LLC

#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2
using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics (2D)")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Returns True or False if 2D collisions are being ignored between Layer A and Layer B.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Check Layer Collision (2D)", "Returns True or False if 2D collisions are being ignored between Layer A and Layer B.")]
public class uScriptAct_CheckLayerCollision2D : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Layer A", "The first layer.")]
      LayerMask LayerA,

      [FriendlyName("Layer B", "The second layer.")]
      LayerMask LayerB,

      [FriendlyName("Result", "True = 2D collisions are being ignored between the layers, False = 2D collisions are NOT being ignored between the layers.")]
      out bool Result
      )
   {
      if (LayerA != LayerB)
      {
         Result = Physics2D.GetIgnoreLayerCollision(1 >> LayerA, 1 >> LayerB);
         
      }
      else
      {
         Result = false;
      }
   }
}

#endif