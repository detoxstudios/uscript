// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: ORs two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/LayerMasks")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Removes LayerMasks from a layer mask combination and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Remove LayerMasks", "Removes multiple LayerMasks.\n\n[ A & ~B ]")]
public class uScriptAct_RemoveLayerMasks : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Existing Masks", "The existing layer masks.")]
      UnityEngine.LayerMask A,

      [FriendlyName("Masks to Remove", "The masks you want removed from the Existing Mask.")]
      UnityEngine.LayerMask B,

      [FriendlyName("Result", "The LayerMask result of the operation.")]
      out UnityEngine.LayerMask LayerMask
      )
   {      
      LayerMask = A & ~B;   
   }
}