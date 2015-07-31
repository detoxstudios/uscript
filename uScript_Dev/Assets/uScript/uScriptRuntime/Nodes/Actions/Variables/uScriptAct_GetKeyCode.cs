// uScript Action Node
// (C) 2014 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/KeyCode")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip( "Gets the first key pressed from the current frame.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Pressed KeyCode", "Returns the KeyCode of the first key pressed in the current frame (KeyCode.None if there wasn't one pressed).  Warning - this is very slow and should not run on every tick!")]
public class uScriptAct_GetKeyCode : uScriptLogic


{
	private KeyCode firstKey;
   public bool Out { get { return true; } }

   public void In(

      [FriendlyName("KeyCode", "The first key pressed (KeyCode.None if none was pressed).")]
		out KeyCode result,

      [FriendlyName("Key Name", "The name of the key pressed as a string.")]
      [SocketState(false, false)]
		out string resultString
      )
   {
		
		firstKey=KeyCode.None;

		foreach (KeyCode type in System.Enum.GetValues(typeof(KeyCode))){
			if(Input.GetKey(type))
			{
				firstKey = type;
				break;
			}
		}

	  result = firstKey;
      resultString = firstKey.ToString();
   }
}