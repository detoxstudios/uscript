// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a Vector3 to the defined X, Y, and Z float component values.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Vector3 to the defined X, Y, and Z float component values.")]
[NodeDescription("Sets a Vector3 to the defined X, Y, and Z float component values.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Vector3 Components")]
public class uScriptAct_SetVector3Components : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(float X, float Y, float Z, [FriendlyName("Output Vector3")] out Vector3 OutputVector3)
   {
      Vector3 tempVector3 = new Vector3(X, Y, Z);
      OutputVector3 = tempVector3;
   }
}