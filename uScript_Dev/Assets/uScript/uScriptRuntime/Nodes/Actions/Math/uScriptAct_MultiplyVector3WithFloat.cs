// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Multiplies a Vector3 with a Float.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Multiply Vector3 With Float", "Multiplies a Vector3 with a Float. This is useful for multiplying things like Delta Time with a Vector3 velocity for example.")]
public class uScriptAct_MultiplyVector3WithFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Vector3", "The Vector3 you wish to multiple with.")]
      Vector3 targetVector3,

      [FriendlyName("Float", "The Float you wish to multiple with.")]
      float targetFloat,

      [FriendlyName("Result", "The Vector3 result of the operation.")]
      out Vector3 Result
      )
   {
      Result = targetVector3 * targetFloat;
   }
}