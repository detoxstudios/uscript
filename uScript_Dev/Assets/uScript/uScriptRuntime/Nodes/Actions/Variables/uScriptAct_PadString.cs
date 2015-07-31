// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Pads a string to reach the specified width.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Pad String", "Pads a string to reach the specified width.")]
public class uScriptAct_PadString : uScriptLogic
{
   public enum PadSide {Left, Right};
	
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target string to be padded.")]
      string Target,

      [FriendlyName("Side", "Which side of the string to pad.")]
      [SocketState(false, false)]
      PadSide padSide,

      [FriendlyName("Width", "Specifies the total width of the Result string after padding. If the width specified is smaller thatn the Target string's current width, the original string is returned instead.")]
      [SocketState(false, false)]
      int TotalWidth,

      [FriendlyName("Pad Character", "(optional) Specify the character to use for padding. If none is provided, whitespace will be used by default. Note: If more than one character is provided in the string, only the first character will be used for padding.")]
      [SocketState(false, false)]
      string padCharString,
      
      [FriendlyName("Result", "Resulting padded string.")]
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
