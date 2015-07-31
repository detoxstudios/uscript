// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Mirrors the X, Y, Z and W of a Vector4.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Invert Vector4", "Returns the inverse value of a Vector4 variable. Individual components can optionally be ignored by this operation." +
 "\n\nExample:" +
 "\n\t[x, y, z, w] -> [-x, -y, -z, -w]")]
public class uScriptAct_InvertVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "Value to invert.")]
      Vector4 Target,

      [FriendlyName("Ignore X", "If True, the X component will be ignored.")]
      [SocketState(false, false)]
      bool IgnoreX,

      [FriendlyName("Ignore Y", "If True, the Y component will be ignored.")]
      [SocketState(false, false)]
      bool IgnoreY,

      [FriendlyName("Ignore Z", "If True, the Z component will be ignored.")]
      [SocketState(false, false)]
      bool IgnoreZ,

      [FriendlyName("Ignore W", "If True, the W component will be ignored.")]
      [SocketState(false, false)]
      bool IgnoreW,

      [FriendlyName("Value", "The inverted value.")]
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