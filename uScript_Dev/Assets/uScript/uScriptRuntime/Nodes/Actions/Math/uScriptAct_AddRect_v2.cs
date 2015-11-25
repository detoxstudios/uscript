// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Rect")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip( "Adds two Rect variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Add Rect", "Adds Rect variables together and returns the result." +
 "\n\n[ A + B ]")]
public class uScriptAct_AddRect_v2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable or variable list.")]
      Rect A,

      [FriendlyName("B", "The second variable or variable list.")]
      Rect B,

      [FriendlyName("Result", "The Rect result of the operation.")]
      out Rect Result
      )
   {
      Result = new Rect( (A.xMin + B.xMin), (A.yMin + B.yMin), (A.width + B.width), (A.height + B.height) );
   }
}
