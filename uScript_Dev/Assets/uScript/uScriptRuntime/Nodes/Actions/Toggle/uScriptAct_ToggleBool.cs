// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Toggles a boolean variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Toggle")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Toggles a boolean variable.")]
[NodeDescription("Toggles a boolean variable.\n \nTarget: The Target bool(s) to toggle.\nResult: The toggled result.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Toggle_Bool")]

[FriendlyName("Toggle Bool")]
public class uScriptAct_ToggleBool : uScriptLogic
{
   public bool Out { get { return true; } }

   [FriendlyName("Toggle")]
   public void Toggle(bool Target, out bool Result)
   {
      Result = ! Target;
   }
}
