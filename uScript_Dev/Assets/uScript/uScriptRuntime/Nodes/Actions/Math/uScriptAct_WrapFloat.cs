// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Keeps a float variable between a min and a max value while allowing it to wrap back around and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Wrap Float", "Keeps a float variable between a min and a max value while allowing it to wrap back around and returns the result.")]
public class uScriptAct_WrapFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The value to be wrapped.")]
      float Target,
      
      [FriendlyName("Min", "The minimum value to wrap to.")]
      float Min,
      
      [FriendlyName("Max", "The maximum value to wrap to.")]
      float Max,
      
      [FriendlyName("Result", "Floating-point result of the wrap operation.")]
      out float FloatResult,

      [FriendlyName("Int Result", "Integer result of the wrap operation.")]
      [SocketState(false, false)]
      out int IntResult
      )
   {
      float range = Max - Min;
      FloatResult = Target;
      while ( FloatResult > Max )
      {
         FloatResult -= range;
      }
      while ( FloatResult < Min )
      {
         FloatResult += range;
      }
      IntResult = System.Convert.ToInt32(FloatResult);
   }
}