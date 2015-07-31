// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System;
using System.Collections;

[NodePath("Actions/Variables/KeyCode")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Converts a string into a KeyCode.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("String To KeyCode", "Converts a string into a KeyCode. If a match is not found, the specified default is returned.")]
public class uScriptAct_StringToKeyCode : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Value", "The string you wish to use to convert to a KeyCode. Note: casing of the dtring must match that of the KeyCode!")]
      string Value,
	               
	  [FriendlyName("Default", "The default KeyCode to return if a match is not found.")]
	  [DefaultValue(KeyCode.None)]
	  [SocketState(false, false)]
      KeyCode Default,
      
      [FriendlyName("Target", "The Target variable you wish to set.")]
      out KeyCode Target
      )
   {
		String[] codeNames = Enum.GetNames( typeof( KeyCode ) );
		KeyCode tmpCode = Default;
		
		foreach( string code in codeNames)
		{
			if (code == Value)
			{
				tmpCode = (KeyCode)Enum.Parse(typeof(KeyCode), code, false);
			}
		}
		
		Target = tmpCode;
   }
}
