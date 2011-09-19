// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns part of the Target string as specified.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Returns part of the Target string as specified.")]
[NodeDescription("Returns part of the Target string as specified. Note, if you supply values outside of a valid range, nothing will be returned in th new string.\n \nTarget: The target string.\nStart Position: The character position to start from. This value is zero-based, so the first character in the string is at position 0 (zero).\nLength: Optional. The number of characters to include in the sub-string. If no length is given, the sub-string will return all characters from the Start Position to the end of the Target string.\nResult (out): Resulting sub-string based on the Target string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Sub-String")]
public class uScriptAct_GetSubString : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
	               string Target,
	               [FriendlyName("Start Position")] int StartPos,
	               [FriendlyName("Length"), SocketState(false, false), DefaultValue(0)] int StringLength,
	               out string Result
	               )
   {
		if("" != Target)
		{
			bool skip = false;
			bool useLength = false;
			int indexMax = Target.Length - 1;
			
			// Make sure everything is within bounds of the Target string
			if(StartPos < 0) { StartPos = 0; }
			if(StartPos > indexMax) { StartPos = indexMax; }
			if(StringLength > 0) { useLength = true; }
			
			if(StringLength > Target.Length) { skip = true; }
			
			if(StartPos + StringLength > Target.Length) { skip = true; }
			
			
			if(!skip)
			{
				if(useLength)
				{
					Result = Target.Substring(StartPos, StringLength);
				}
				else
				{
					Result = Target.Substring(StartPos);
				}
				
			}
			else
			{
				Result = "";
			}
			
		}
		else
		{
			Result = "";
		}
		
		
		
   }
	

}
