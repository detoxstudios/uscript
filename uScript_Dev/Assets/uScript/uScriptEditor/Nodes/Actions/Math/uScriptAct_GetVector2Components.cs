// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the components of a Vector2 as floats.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Vector2 as floats.")]
[NodeDescription("Gets the components of a Vector2 as floats.\n \nInput Vector2: The input vector to get components of.\nX: The x value of the Input Vector2.\nY: The y value of the Input Vector2.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get Vector2 Components")]
public class uScriptAct_GetVector2Components : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In([FriendlyName("Input Vector2")]Vector2 InputVector2, out float X, out float Y)
   {
      X = InputVector2.x;
      Y = InputVector2.y;
   }
}