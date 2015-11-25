// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip( "Adds two Vector4 variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Add Vector4", "Adds Vector4 variables together and returns the result." +
 "\n\n[ A + B ]")]
public class uScriptAct_AddVector4_v2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable or variable list."), AutoLinkType(typeof(Vector4))]
      Vector4 A,

      [FriendlyName("B", "The second variable or variable list."), AutoLinkType(typeof(Vector4))]
      Vector4 B,

      [FriendlyName("Result", "The Vector4 result of the operation.")]
      out Vector4 Result
      )
   {

      Result = A + B;
   }
}
