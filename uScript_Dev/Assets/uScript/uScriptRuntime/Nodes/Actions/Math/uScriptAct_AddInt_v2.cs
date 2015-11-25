// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Int")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip( "Adds two integer variables together and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Add Int", "Adds integer variables together and returns the result." +
 "\n\n[ A + B ]")]
public class uScriptAct_AddInt_v2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable or variable list."), AutoLinkType(typeof(int))]
      int A,

      [FriendlyName("B", "The second variable or variable list."), AutoLinkType(typeof(int))]
      int B,

      [FriendlyName("Result", "The integer result of the operation.")]
      out int IntResult,

      [FriendlyName("Float Result", "The floating-point result of the operation.")]
      [SocketState(false, false)]
      out float FloatResult
      )
   {
      IntResult = A + B;
      FloatResult = System.Convert.ToSingle(IntResult);
   }
}
