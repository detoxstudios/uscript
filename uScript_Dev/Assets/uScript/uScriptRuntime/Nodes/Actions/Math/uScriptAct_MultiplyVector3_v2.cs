// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip( "Multiplies two Vector3 variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Multiply Vector3", "Multiplies Vector3 variables together and returns the result." +
 "\n\n[ A + B ]")]
public class uScriptAct_MultiplyVector3_v2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable."), AutoLinkType(typeof(Vector3))]
      Vector3 A,
      
      [FriendlyName("B", "The second variable."), AutoLinkType(typeof(Vector3))]
      Vector3 B,

      [FriendlyName("Result", "The Vector3 result of the operation.")]
      out Vector3 Result
      )
   {

      Result = new Vector3( (A.x * B.x), (A.y * B.y), (A.z * B.z) );

   }
}
