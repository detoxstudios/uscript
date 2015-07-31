// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/String")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Replaces characters in a string with the new ones specified.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Replace Characters", "Replaces characters in a string with the new ones specified.")]
public class uScriptAct_ReplaceCharacters : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target string.")]
      string Target,

      [FriendlyName("Old Chars", "The current characters in the string you wish to replace.")]
      [SocketState(false, false)]
      string OldChars,

      [FriendlyName("New Chars", "The new characters you wish to use. If you leave this property empty/blank, the old characters will be deleted from the string.")]
      [SocketState(false, false)]
      string NewChars,

      [FriendlyName("Result", "Resulting string with replaced characters.")]
      out string Result
      )
   {
		if (OldChars.Length > 0)
		{
			Result = Target.Replace(OldChars, NewChars);
		}
		else
		{
			Result = Target;
		}
   }
}
