// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Scales a Vector4.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Scales a Vector4.")]
[NodeDescription("Scales a Vector4.\n \nVector: Vector to scale.\nScale: Amount to scale Vector by.\nVector Result: Scaled vector.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Scale_Vector4")]

[FriendlyName("Scale Vector4")]
public class uScriptAct_ScaleVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Vector")] Vector4 v, [FriendlyName("Scale")] float s, [FriendlyName("Vector Result")] out Vector4 result)
   {
      result = v * s;
   }
}