// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Returns part of the Target string as specified.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Sub-String", "Returns part of the Target string as specified. Note, if you supply values outside of a valid range, nothing will be returned in the new string.")]
public class uScriptAct_GetSubString : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target string.")]
      string Target,
      
      [FriendlyName("Start Position", "The character position to start from. This value is zero-based, so the first character in the string is at position 0 (zero).")]
      int StartPos,

      [FriendlyName("Length", "(optional) The number of characters to include in the sub-string. If no length is given, the sub-string will return all characters from the Start Position to the end of the Target string.")]
      [SocketState(false, false), DefaultValue(0)]
      int StringLength,
      
      [FriendlyName("Result", "Resulting sub-string based on the Target string.")]
      out string Result
      )
   {
		if (string.Empty != Target)
		{
			bool skip = false;
			bool useLength = false;
			int indexMax = Target.Length - 1;
			
			// Make sure everything is within bounds of the Target string
			if (StartPos < 0) { StartPos = 0; }
			if (StartPos > indexMax) { skip = true; }
			if (StringLength > 0) { useLength = true; }
			
			if (StringLength > Target.Length) { skip = true; }
			
			if (StartPos + StringLength > Target.Length) { skip = true; }
			
			if (!skip)
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
				Result = string.Empty;
			}
		}
		else
		{
			Result = string.Empty;
		}
   }
}
