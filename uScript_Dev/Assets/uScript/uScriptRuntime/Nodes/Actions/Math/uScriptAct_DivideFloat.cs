// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Divides two float variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Divides two float variables and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Divide_Float")]

[FriendlyName("Divide Float", "Divides two float variables and returns the result." +
 "\n\n[ A / B ]")]
public class uScriptAct_DivideFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The numerator.")]
      float A,

      [FriendlyName("B", "The denominator.")]
      float B,

      [FriendlyName("Result", "The floating point result of the operation.")]
      out float FloatResult,

      [FriendlyName("Int Result", "The integer result of the operation.")]
      [SocketState(false, false)]
      out int IntResult
      )
   {
      float total = A / B;
      FloatResult = total;
      IntResult = System.Convert.ToInt32(total);
   }
}