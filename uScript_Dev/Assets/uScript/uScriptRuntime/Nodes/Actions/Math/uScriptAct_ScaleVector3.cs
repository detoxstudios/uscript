// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Scales a Vector3.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Scales a Vector3.")]
[NodeDescription("Scales a Vector3.\n \nVector: Vector to scale.\nScale: Amount to scale Vector by.\nVector Result: Scaled vector.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Scale_Vector3")]

[FriendlyName("Scale Vector3")]
public class uScriptAct_ScaleVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Vector")] Vector3 v, [FriendlyName("Scale")] float s, [FriendlyName("Vector Result")] out Vector3 result)
   {
      result = v * s;
   }
}