// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Replaces characters in a string with the new ones specified.")]
[NodeDescription("Replaces characters in a string with the new ones specified.\n \nTarget: The target string.\nOld: The current characters in the string you wish to replace.\nNew: The new characters you wish to use. If you leave this property empty/blank, the old characters will be deleted from the string.\nResult (out): Resulting string with replaced characters.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Replace Characters")]
public class uScriptAct_ReplaceCharacters : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
	               string Target,
	               [FriendlyName("Old"), SocketState(false, false)] string OldChars,
	               [FriendlyName("New"), SocketState(false, false)] string NewChars,
	               out string Result
	               )
   {
		if(OldChars.Length > 0)
		{
			Result = Target.Replace(OldChars, NewChars);
		}
		else
		{
			Result = Target;
		}
		
		
   }
}
