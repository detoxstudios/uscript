// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Rounds the Target float and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Rounds the Target float and returns the result.")]
[NodeDescription("Rounds the Target float to the nearest whole number and returns the result.\n \nTarget: The float to round.\nResult (out): The floating point result of the rounding operation.\nInt Result (out): The integer result of the rounding operation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Round Float")]
public class uScriptAct_RoundFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      float Target, 
      [FriendlyName("Result")] out float FloatResult,
      [FriendlyName("Int Result"), SocketState(false, false)] out int IntResult)
   {
      FloatResult = UnityEngine.Mathf.Round(Target);
      IntResult = UnityEngine.Mathf.RoundToInt(Target);
   }
}