// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Int")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets an integer to the defined value.")]
[NodeDescription("Sets an integer to the defined value.\n \nValue: The variable you wish to use to set the target's value.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Int")]

[FriendlyName("Set Int")]
public class uScriptAct_SetInt : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(int Value, out int Target)
   {
      Target = Value;
   }
}