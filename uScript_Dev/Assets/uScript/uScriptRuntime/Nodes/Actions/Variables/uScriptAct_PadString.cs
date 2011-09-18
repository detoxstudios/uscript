// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Pads a string to reach the specified width.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Pads a string to reach the specified width.")]
[NodeDescription("Pads a string to reach the specified width.\n \nTarget: The target string to be padded.\nSide: Which side of the string to pad.\nWidth: Specifies the total width of the Result string after padding. If the width specified is smaller thatn the Target string's current width, the original string is returned instead.\nPad Character: Optional. Specify the character to use for padding. If none is provided, whitespace will be used by default. Note: If more than one character is provided in the string, only the first character will be used for padding.\nResult (out): Resulting padded string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Pad String")]
public class uScriptAct_PadString : uScriptLogic
{
   public enum PadSide {Left, Right};
	
   public bool Out { get { return true; } }

   public void In(
	               string Target,
	               [FriendlyName("Side"), SocketState(false, false)] PadSide padSide,
	               [FriendlyName("Width"), SocketState(false, false)] int TotalWidth,
	               [FriendlyName("Pad Character"), SocketState(false, false)] string padCharString,
	               out string Result
	               )
   {
		
		// Convert the string into a char variable
		System.Char padChar;
		char[] padCharTemp;
		if(padCharString == "")
		{
			string whitespace = " ";
			padCharTemp = whitespace.ToCharArray();
			padChar = padCharTemp[0];
		}
		else
		{
			padCharTemp = padCharString.ToCharArray();
			padChar = padCharTemp[0];
		}
		
		// Preform padding
		if(padSide == PadSide.Left)
		{
			Result = Target.PadLeft(TotalWidth, padChar);
		}
		else
		{
			Result = Target.PadRight(TotalWidth, padChar);
		}
		
   }
}
