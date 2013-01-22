// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("The time in seconds since the start of the game.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Game_Time")]

[FriendlyName("Get Run Time", "The time in seconds since the start of the game.")]
public class uScriptAct_GetRunTime : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Run Time", "Outputs the total number of seconds the game has been running.")]
      out float RunTime,

      [FriendlyName("Fixed Run Time", "Outputs the fixed total number of seconds the game has been running.")]
      [SocketState(false, false)]
      out float FixedRunTime
      )
   {
      RunTime = Time.time;
      FixedRunTime = Time.fixedTime;

   }
}


