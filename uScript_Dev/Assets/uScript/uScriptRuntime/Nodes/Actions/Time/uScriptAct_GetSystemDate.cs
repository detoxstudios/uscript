// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the system's current date information.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Time")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the system's current date information.")]
[NodeDescription("Returns the system's current date information.\n \nDate (out): Outputs the current date.\nDay (out): Outputs the current day of the week.\nDay Of Month (out): Outputs the current day value.\nMonth (out): Outputs the current month value.\nYear (out): Outputs the current year value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Game_Time")]

[FriendlyName("Get System Date")]
public class uScriptAct_GetSystemDate : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Date")] out string FullDate,
	  [FriendlyName("Day"), SocketState(false, false)] out string Day,
	  [FriendlyName("Day of Month"), SocketState(false, false)] out int DayOfMonth,
	  [FriendlyName("Month"), SocketState(false, false)] out int Month,
	  [FriendlyName("Year"), SocketState(false, false)] out int Year
      )
   {
      FullDate = System.DateTime.Today.ToString("d");
	  Day = System.DateTime.Today.DayOfWeek.ToString();
	  DayOfMonth = System.DateTime.Today.Day;
	  Month = System.DateTime.Today.Month;
	  Year = System.DateTime.Today.Year;

   }
}

