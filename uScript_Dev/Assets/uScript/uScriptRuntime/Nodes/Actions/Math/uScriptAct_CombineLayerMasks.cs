// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: ORs two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/LayerMasks")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Combines LayerMask variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Combine_LayerMasks")]

[FriendlyName("Combine LayerMasks", "Combines multiple LayerMasks.\n\n[ A | B ]")]
public class uScriptAct_CombineLayerMasks : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first layer mask.")]
      UnityEngine.LayerMask A,

      [FriendlyName("B", "The second layer mask.")]
      UnityEngine.LayerMask B,

      [FriendlyName("Result", "The LayerMask result of the operation.")]
      out UnityEngine.LayerMask LayerMask
      )
   {
      LayerMask = A | B;
   }
}