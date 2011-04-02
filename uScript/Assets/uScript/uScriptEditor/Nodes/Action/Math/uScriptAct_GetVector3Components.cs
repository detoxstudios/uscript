// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Gets the components of a Vector3 as floats.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Vector3 as floats.")]
[NodeDescription("Gets the components of a Vector3 as floats.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get Vector3 Components")]
public class uScriptAct_GetVector3Components : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(Vector3 InputVector3, out float X, out float Y, out float Z)
   {

      X = InputVector3.x;
      Y = InputVector3.y;
      Z = InputVector3.z;

   }
}