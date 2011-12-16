// uScript Action Node
// (C) 2010 Detox Studios LLC

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
      [FriendlyName("A", "The dividend.")]
      float A,

      [FriendlyName("B", "The divisor.  Must be a non-zero value.")]
      float B,

      [FriendlyName("Result", "The floating-point quotient or result of the operation.")]
      out float FloatResult,

      [FriendlyName("Int Result", "The integer quotient or result of the operation.")]
      [SocketState(false, false)]
      out int IntResult
      )
   {
      if (B == 0)
      {
         uScriptDebug.Log("[Divide Float] You cannot divide by 0.  Returning 0 as the result.", uScriptDebug.Type.Error);
         FloatResult = 0f;
         IntResult = 0;
      }
      else
      {
         float total = A / B;
         FloatResult = total;
         IntResult = System.Convert.ToInt32(total);
      }
   }
}