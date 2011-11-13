// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Normalizes the vector.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Normalizes the vector.")]
[NodeDescription("Normalizes the vector. A normalized vector keeps the same direction but its length is 1.0. If the vector is too small to be normalized a zero vector will be returned instead.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Normalize_Vector2")]

[FriendlyName("Normalize Vector2")]
public class uScriptAct_NormalizeVector2 : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Vector2 Target, [FriendlyName("Normalized")] out Vector2 NormalizedVector)
   {
      NormalizedVector = Target.normalized;
   }
}