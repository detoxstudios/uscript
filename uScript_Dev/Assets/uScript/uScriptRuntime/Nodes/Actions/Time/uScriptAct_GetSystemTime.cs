// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the system's current time.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Game_Time")]

[FriendlyName("Get System Time", "Returns the system's current time.")]
public class uScriptAct_GetSystemTime : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Time", "Outputs the current time as hh:mm:ss.")]
      out string FullTime,
      
      [FriendlyName("UTC Time", "Outputs the current time in UTC format.")]
      [SocketState(false, false)]
      out string FullTimeUTC,
      
      [FriendlyName("Hour", "Outputs the hour value.")]
      [SocketState(false, false)]
      out int Hour,
      
      [FriendlyName("Minute", "Outputs the minute value.")]
      [SocketState(false, false)]
      out int Minute,
      
      [FriendlyName("Second", "Outputs the second value.")]
      [SocketState(false, false)]
      out int Second,
      
      [FriendlyName("Millisecond", "Outputs the millisecond value.")]
      [SocketState(false, false)]
      out int Millisecond
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

#endif