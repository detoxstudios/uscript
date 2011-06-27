// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current gravity as a Vector3.


using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current gravity as a Vector3.")]
[NodeDescription("Gets the current gravity as a Vector3.\n\nGravity: Returns the current gravity value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Gravity")]
public class uScriptAct_GetGravity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Gravity")] out Vector3 Gravity)
   {
		 Gravity = Physics.gravity;
      
   }
}