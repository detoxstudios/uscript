// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the system's current time.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the system's current time.")]
[NodeDescription("Returns the system's current time.\n \nFull Time (out): Outputs the current time as hh:mm:ss.\nFull Time UTC (out): Outputs the current time in UTC format.\nHour (out): Outputs the hour value.\nMinute (out): Outputs the minute value.\nSecond (out): Outputs the second value.\nMillisecond (out): Outputs the millisecond value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Game_Time")]

[FriendlyName("Get System Time")]
public class uScriptAct_GetSystemTime : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Time")] out string FullTime,
	  [FriendlyName("UTC Time"), SocketState(false, false)] out string FullTimeUTC,
	  [FriendlyName("Hour"), SocketState(false, false)] out int Hour,
	  [FriendlyName("Minute"), SocketState(false, false)] out int Minute,
	  [FriendlyName("Second"), SocketState(false, false)] out int Second,
	  [FriendlyName("Millisecond"), SocketState(false, false)] out int Millisecond
      )
   {
      FullTime = System.DateTime.Now.ToString("hh:mm:ss");
	  FullTimeUTC = System.DateTime.UtcNow.ToString("hh:mm:ss");
	  Hour = System.DateTime.Now.Hour;
	  Minute = System.DateTime.Now.Minute;
	  Second = System.DateTime.Now.Second;
	  Millisecond = System.DateTime.Now.Millisecond;
   }
}

