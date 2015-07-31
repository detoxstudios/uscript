// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Scales a Vector2.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Scale Vector2", "Scales a Vector2")]
public class uScriptAct_ScaleVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Vector", "Vector to scale.")]
      Vector2 v,

      [FriendlyName("Scale", "Amount to scale Vector by.")]
      float s,

      [FriendlyName("Vector Result", "Scaled vector.")]
      out Vector2 result
      )
   {
      result = v * s;
   }
}
