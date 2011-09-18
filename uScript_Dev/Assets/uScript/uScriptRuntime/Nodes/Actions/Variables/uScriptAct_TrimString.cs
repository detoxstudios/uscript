// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Trims characters from the begining and end of a string.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Trims characters from the begining and end of a string.")]
[NodeDescription("Trims characters from the begining and end of a string. If no characters are provided, the node will trim whitespace by default.\n \nTarget: The target string to be trimmed.\nCharacters: Optional. Specify the characters to trim. If none are provided, whitespace will be trimmed by default.\nResult (out): Resulting trimmed string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Trim String")]
public class uScriptAct_TrimString : uScriptLogic
{
   public enum TrimType {Both, Left, Right};
	
   public bool Out { get { return true; } }

   public void In(string Target, [FriendlyName("Trim Type"), SocketState(false, false)] TrimType trimType, [FriendlyName("Characters"), SocketState(false, false)] string trimChars, out string Result)
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
