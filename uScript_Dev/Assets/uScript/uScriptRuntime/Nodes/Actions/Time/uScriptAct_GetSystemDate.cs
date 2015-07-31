// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the system's current date information.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get System Date", "Returns the system's current date information.")]
public class uScriptAct_GetSystemDate : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Date", "Outputs the current date.")]
      out string FullDate,
      
      [FriendlyName("Day", "Outputs the current day of the week.")]
      [SocketState(false, false)]
      out string Day,
      
      [FriendlyName("Day of Month", "Outputs the current day value.")]
      [SocketState(false, false)]
      out int DayOfMonth,
      
      [FriendlyName("Month", "Outputs the current month value.")]
      [SocketState(false, false)]
      out int Month,
      
      [FriendlyName("Year", "Outputs the current year value.")]
      [SocketState(false, false)]
      out int Year
      )
   {
      FullDate = System.DateTime.Today.ToString("d");
	  Day = System.DateTime.Today.DayOfWeek.ToString();
	  DayOfMonth = System.DateTime.Today.Day;
	  Month = System.DateTime.Today.Month;
	  Year = System.DateTime.Today.Year;

   }
}

#endif