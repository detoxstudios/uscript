// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a float to the defined value.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a float to the defined value.")]
[NodeDescription("Sets a float to the defined value.\n \nValue: The variable you wish to use to set the target's value.\nTarget (out): The Target variable you wish to set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Float")]

[FriendlyName("Set Float")]
public class uScriptAct_SetFloat : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(float Value, out float Target)
   {
      Target = Value;
   }
}