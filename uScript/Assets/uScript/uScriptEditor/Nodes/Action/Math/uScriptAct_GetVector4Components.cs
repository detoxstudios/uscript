// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Gets the components of a Vector4 as floats.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Vector4 as floats.")]
[NodeDescription("Gets the components of a Vector4 as floats.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get Vector4 Components")]
public class uScriptAct_GetVector4Components : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In([FriendlyName("Input Vector4")] Vector4 InputVector4, out float X, out float Y, out float Z, out float W)
   {

      X = InputVector4.x;
      Y = InputVector4.y;
      Z = InputVector4.z;
      W = InputVector4.w;

   }
}