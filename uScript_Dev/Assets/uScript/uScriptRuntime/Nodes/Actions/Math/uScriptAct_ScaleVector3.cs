// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Scales a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Scale Vector3", "Scales a Vector3.")]
public class uScriptAct_ScaleVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Vector", "Vector to scale.")]
      Vector3 v,
      
      [FriendlyName("Scale", "Amount to scale Vector by.")]
      float s,
      
      [FriendlyName("Vector Result", "Scaled vector.")]
      out Vector3 result
      )
   {
      result = v * s;
   }
}