// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Clamps an integer variable between a min and a max value and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Clamp Int", "Clamps an integer variable between a min and a max value and returns the result.")]
public class uScriptAct_ClampInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The value to be clamped.")]
      int Target,
      
      [FriendlyName("Min", "The minimum value to clamp to.")]
      int Min,
      
      [FriendlyName("Max", "The maximum value to clamp to.")]
      int Max,
      
      [FriendlyName("Result", "Integer result of the clamp operation.")]
      out int IntResult,

      [FriendlyName("Float Result", "Floating-point result of the clamp operation.")]
      [SocketState(false, false)]
      out float FloatResult
      )
   {
      IntResult = Mathf.Clamp(Target, Min, Max);
      FloatResult = (float)IntResult;
   }
}