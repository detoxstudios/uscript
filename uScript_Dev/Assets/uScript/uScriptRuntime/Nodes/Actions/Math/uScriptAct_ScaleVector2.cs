// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Scales a Vector2.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Scales a Vector2.")]
[NodeDescription("Scales a Vector2.\n \nVector: Vector to scale.\nScale: Amount to scale Vector by.\nVector Result: Scaled vector.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Scale_Vector2")]

[FriendlyName("Scale Vector2")]
public class uScriptAct_ScaleVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Vector")] Vector2 v, [FriendlyName("Scale")] float s, [FriendlyName("Vector Result")] out Vector2 result)
   {
      result = v * s;
   }
}