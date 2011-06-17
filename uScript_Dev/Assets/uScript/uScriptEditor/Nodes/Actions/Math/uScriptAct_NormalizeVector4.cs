// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Normalizes the vector.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Normalizes the vector.")]
[NodeDescription("Normalizes the vector. A normalized vector keeps the same direction but its length is 1.0. If the vector is too small to be normalized a zero vector will be returned instead.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Normalize Vector4")]
public class uScriptAct_NormalizeVector4 : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Vector4 Target, [FriendlyName("Normalized")] out Vector4 NormalizedVector)
   {
      NormalizedVector = Target.normalized;
   }
}