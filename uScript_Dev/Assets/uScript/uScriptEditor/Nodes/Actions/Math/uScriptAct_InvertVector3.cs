// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Mirrors the X, Y, and Z of a Vector3.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Mirrors the X, Y, and Z of a Vector3.")]
[NodeDescription("Mirrors the X, Y, and Z of a Vector3.\n \nTarget: Value to invert.\nIgnore X: Whether or not to mirror the X component of the Target.\nIgnore Y: Whether or not to mirror the Y component of the Target.\nIgnore Z: Whether or not to mirror the Z component of the Target.\nValue (out): Inverted value ([x, y, z] -> [-x, -y, -z]).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Invert Vector3")]
public class uScriptAct_InvertVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Vector3 Target,
      [FriendlyName("Ignore X"), SocketState(false, false)] bool IgnoreX,
      [FriendlyName("Ignore Y"), SocketState(false, false)] bool IgnoreY,
      [FriendlyName("Ignore Z"), SocketState(false, false)]bool IgnoreZ,
      out Vector3 Value
      )
   {
      Value = new Vector3(Target.x, Target.y, Target.z);

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
   }
}