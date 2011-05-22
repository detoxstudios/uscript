// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Multiplies two float variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Scales a Vector3.")]
[NodeDescription("Scales a Vector3")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Scale Vector3")]
public class uScriptAct_ScaleVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Vector")] Vector3 v, [FriendlyName("Scale")] float s, [FriendlyName("Vector Resut")] out Vector3 result)
   {
      result = v * s;
   }
}