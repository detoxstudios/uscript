// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets an int to the defined value.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets an integer to the defined value.")]
[NodeDescription("Sets an integer to the defined value.\n \nValue: The integer variable to be set.\nTarget (out): The value that has been set for this variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Int")]
public class uScriptAct_SetInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int Value, out int Target)
   {
      Target = Value;
   }
}