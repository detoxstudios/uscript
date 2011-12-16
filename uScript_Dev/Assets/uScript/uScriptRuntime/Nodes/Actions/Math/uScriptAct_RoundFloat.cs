// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Rounds the Target float and returns the result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Round Float", "Rounds the Target float to the nearest whole number and returns the result.")]
public class uScriptAct_RoundFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The float to round.")]
      float Target,

      [FriendlyName("Result", "The floating-point result of the rounding operation.")]
      out float FloatResult,

      [FriendlyName("Int Result", "The integer result of the rounding operation.")]
      [SocketState(false, false)]
      out int IntResult
      )
   {
      FloatResult = UnityEngine.Mathf.Round(Target);
      IntResult = UnityEngine.Mathf.RoundToInt(Target);
   }
}