// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip( "Adds two or more Vector2 variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Add Vector2", "Adds Vector2 variables together and returns the result." +
 "\n\n[ A + B ]")]
public class uScriptAct_AddVector2_v2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable or variable list."), AutoLinkType(typeof(Vector2))]
      Vector2 A,

      [FriendlyName("B", "The second variable or variable list."), AutoLinkType(typeof(Vector2))]
      Vector2 B,

      [FriendlyName("Result", "The Vector2 result of the operation.")]
      out Vector2 Result
      )
   {

      Result = A + B;
   }
}
