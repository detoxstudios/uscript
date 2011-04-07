// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a Vector4 to the defined X, Y, Z and W float component values.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Vector4 to the defined X, Y, Z and W float component values.")]
[NodeDescription("Sets a Vector4 to the defined X, Y, Z and W float component values.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Vector4 Components")]
public class uScriptAct_SetVector4Components : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(float X, float Y, float Z, float W, [FriendlyName("Output Vector4")] out Vector4 OutputVector4)
   {
      Vector4 tempVector4 = new Vector4(X, Y, Z, W);
      OutputVector4 = tempVector4;
   }
}