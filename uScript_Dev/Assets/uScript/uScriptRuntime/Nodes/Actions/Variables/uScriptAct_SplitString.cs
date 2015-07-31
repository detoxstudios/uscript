// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Splits a string variable into multiple strings divided by the Separator character.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Split String", "Splits a string variable into multiple strings divided by the Separator character. The Result is a String List containing each new sub-string.")]
public class uScriptAct_SplitString : uScriptLogic
{
	
   public bool Out { get { return true; } }

   public void In(
	               [FriendlyName("Target", "The string variable to be split into new sub-strings.")] string Target, 
	               [FriendlyName("Separator", "The character to use to split the string into sub-strings."), SocketState(false, false)] string Separator,
	               [FriendlyName("Split Options", "Determine if empty sub-strings should be added to the String List."), SocketState(false, false)] System.StringSplitOptions SplitOptions,
	               [FriendlyName("Result (List)", "The String List containing the sub-strings.")] out string[] Result,
	               [FriendlyName("Count", "The number of sub-strings created from the split."), SocketState(false, false)] out int Count
	               )
   {
		string[] tmpResult;
		
		// Determine what to split
		if (Separator != "" && Target.Contains(Separator))
		{
			tmpResult = Target.Split(new string[] { Separator }, SplitOptions);
		}
		else
		{
			tmpResult = new string[1] {Target};
		}
		
		Result = tmpResult;
		Count = tmpResult.Length;

   }
}
