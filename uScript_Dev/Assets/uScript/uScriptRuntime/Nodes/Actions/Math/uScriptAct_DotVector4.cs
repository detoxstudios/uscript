// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Dot product of two Vector4 variables.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Dot (Vector4)", "Dot Product of two Vector4 variables." +
 "\n\n[ Dot(A,B) ]")]
public class uScriptAct_DotVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable.")]
      Vector4 A,

      [FriendlyName("B", "The second variable.")]
      Vector4 B,

      [FriendlyName("Result", "The float result of the operation.")]
      out float Result
      )
   {
      Result = Vector4.Dot(A, B);
   }
}