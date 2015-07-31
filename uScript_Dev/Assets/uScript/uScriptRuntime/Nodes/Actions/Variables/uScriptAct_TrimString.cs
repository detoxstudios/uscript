// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Trims characters from the begining and end of a string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Trim String", "Trims characters from the begining and/or end of a string.  If no characters are provided, the node will trim whitespace by default.")]
public class uScriptAct_TrimString : uScriptLogic
{
   public enum TrimType {Both, Left, Right};
	
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target string to be trimmed.")]
      string Target,

      [FriendlyName("Trim Type", "Specify the side of the string that will be trimmed.")]
      [SocketState(false, false)]
      TrimType trimType,

      [FriendlyName("Characters", "(optional) Specify the characters to trim. If none are provided, whitespace will be trimmed by default.")]
      [SocketState(false, false)]
      string trimChars,

      [FriendlyName("Result", "Resulting trimmed string.")]
      out string Result
      )
   {
		char[] myChar;
		
		// Determine what to trim
		if (trimChars == "")
		{
			string whitespace = " ";
			myChar = whitespace.ToCharArray();
		}
		else
		{
			myChar = trimChars.ToCharArray();
		}
		
		// Trim string based on TrimType
		if(trimType == TrimType.Both)
		{
			Result = Target.Trim(myChar);
		}
		else if(trimType == TrimType.Left)
		{
			Result = Target.TrimStart(myChar);
		}
		else
		{
			Result = Target.TrimEnd(myChar);
		}
   }
}
