// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Keeps an integer variable between a min and a max value while allowing it to wrap back around and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Wrap Int", "Keeps an integer variable between a min and a max value and while allowing it to wrap back around returns the result.")]
public class uScriptAct_WrapInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The value to be wrapped.")]
      int Target,
      
      [FriendlyName("Min", "The minimum value to wrap to.")]
      int Min,
      
      [FriendlyName("Max", "The maximum value to wrap to.")]
      int Max,
      
      [FriendlyName("Result", "Integer result of the wrap operation.")]
      out int IntResult,

      [FriendlyName("Float Result", "Floating-point result of the wrap operation.")]
      [SocketState(false, false)]
      out float FloatResult
      )
   {
      int range = Max - Min;
      IntResult = Target;
      while ( IntResult > Max )
      {
         IntResult -= range;
      }
      while ( IntResult < Min )
      {
         IntResult += range;
      }
      FloatResult = (float)IntResult;
   }
}