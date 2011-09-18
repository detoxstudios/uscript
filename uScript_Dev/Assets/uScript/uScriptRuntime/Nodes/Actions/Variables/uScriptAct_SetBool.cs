// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a boolean to the defined value.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Bool")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a boolean to the defined value.")]
[NodeDescription("Sets a boolean to the defined value.\n \nTarget (out): The value that has been set for this variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Bool")]

[FriendlyName("Set Bool")]
public class uScriptAct_SetBool : uScriptLogic
{
   public bool Out { get { return true; } }

   public void True(out bool Target)
   {
      Target = true;
   }

   public void False(out bool Target)
   {
      Target = false;
   }

}
