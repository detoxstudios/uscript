// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Subtracts two integer variables and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Subtract Int", "Subtracts two integer variables and returns the result." +
 "\n\n[ A - B ]")]
public class uScriptAct_SubtractInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable.")]
      int A,

      [FriendlyName("B", "The second variable.")]
      int B,

      [FriendlyName("Result", "The integer result of the operation.")]
      out int IntResult,

      [FriendlyName("Float Result", "The floating-point result of the operation.")]
      [SocketState(false, false)]
      out float FloatResult
      )
   {
      IntResult = A - B;
      FloatResult = System.Convert.ToSingle(IntResult);
   }
}