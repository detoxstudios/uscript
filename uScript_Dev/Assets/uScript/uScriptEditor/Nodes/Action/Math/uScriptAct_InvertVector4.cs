// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Mirrors the X, Y, Z and W of a Vector4.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Mirrors the X, Y, Z and W of a Vector4.")]
[NodeDescription("Mirrors the X, Y, Z and W of a Vector4.\n \nTarget: Value to invert.\nIgnore X: Whether or not to mirror the X component of the Target.\nIgnore Y: Whether or not to mirror the Y component of the Target.\nIgnore Z: Whether or not to mirror the Z component of the Target.\nIgnore W: Whether or not to mirror the W component of the Target.\nValue (out): Inverted value ([x, y, z, w] -> [-x, -y, -z, -w]).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Invert Vector4")]
public class uScriptAct_InvertVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Vector4 Target,
      [FriendlyName("Ignore X")] bool IgnoreX,
      [FriendlyName("Ignore Y")] bool IgnoreY,
      [FriendlyName("Ignore Z")] bool IgnoreZ,
      [FriendlyName("Ignore W")] bool IgnoreW,
      out Vector4 Value
      )
   {
      Value = new Vector4(Target.x, Target.y, Target.z, Target.w);

      // Mirror X axis
      if (!IgnoreX)
      {
         Value.x = -Value.x;
      }

      // Mirror Y axis
      if (!IgnoreY)
      {
         Value.y = -Value.y;
      }

      // Mirror Z axis
      if (!IgnoreZ)
      {
         Value.z = -Value.z;
      }

      // Mirror W
      if (!IgnoreW)
      {
         Value.w = -Value.w;
      }
   }
}