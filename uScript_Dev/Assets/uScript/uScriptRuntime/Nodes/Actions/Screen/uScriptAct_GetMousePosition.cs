// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current size informaiton for the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the position of the mouse.")]
[NodeDescription("Gets the position of the mouse.\n\nPosition(Out): Returns the position of the mouse.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Mouse_Position")]

[FriendlyName("Get Mouse Position")]
public class uScriptAct_GetMousePosition : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Position")] out Vector3 position
   )
   {
      position = Input.mousePosition;
   }
}