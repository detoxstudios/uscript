// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Multiplies two float variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Multiply Float", "Multiplies float variables together and returns the result." +
 "\n\n[ A * B ]")]
public class uScriptAct_MultiplyFloat_v2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable or variable list."), AutoLinkType(typeof(float))]
      float A,

      [FriendlyName("B", "The second variable or variable list."), AutoLinkType(typeof(float))]
      float B,

      [FriendlyName("Result", "The floating-point result of the operation.")]
      out float FloatResult,

      [FriendlyName("Int Result", "The integer result of the operation.")]
      [SocketState(false, false)]
      out int IntResult
      )
   {
      FloatResult = A * B;
      IntResult = System.Convert.ToInt32(FloatResult);
   }
}
