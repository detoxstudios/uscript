// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Normalizes the vector.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Normalize Vector3", "Normalizes the vector. A normalized vector keeps the same direction but its length is 1.0. If the vector is too small to be normalized, a zero vector will be returned instead.")]
public class uScriptAct_NormalizeVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The vector to normalize.")]
      Vector3 Target,

      [FriendlyName("Normalized", "The result.")]
      out Vector3 NormalizedVector
      )
   {
      NormalizedVector = Target.normalized;
   }
}
