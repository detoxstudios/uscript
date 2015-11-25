// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Rect")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip( "Subtracts two Rect variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Subtract Rect", "Subtracts Rect variables and returns the result.")]
public class uScriptAct_SubtractRect_v2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first Rect.")]
      Rect A,

      [FriendlyName("B", "The second Rect.")]
      Rect B,
      
      [FriendlyName("Result", "The Rect result of the subtractition operation.")]
      out Rect Result
      )
   {

      Result = new Rect( (A.xMin - B.xMin), (A.yMin - B.yMin), (A.width - B.width), (A.height - B.height));

   }
}
