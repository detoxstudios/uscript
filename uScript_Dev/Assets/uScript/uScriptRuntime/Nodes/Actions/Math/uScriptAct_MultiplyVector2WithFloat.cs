// uScript Action Node
// (C) 2014 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Multiplies a Vector2 with a Float.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Multiply Vector2 With Float", "Multiplies a Vector2 with a Float. This is useful for multiplying things like Delta Time with a Vector2 velocity for example.")]
public class uScriptAct_MultiplyVector2WithFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Vector2", "The Vector2 you wish to multiple with.")]
      Vector2 targetVector2,

      [FriendlyName("Float", "The Float you wish to multiple with.")]
      float targetFloat,

      [FriendlyName("Result", "The Vector2 result of the operation.")]
      out Vector2 Result
      )
   {
      Result = targetVector2 * targetFloat;
   }
}