// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Mirrors the X and Y of a Vector2.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Mirrors the X and Y of a Vector2.")]
[NodeDescription("Mirrors the X and Y of a Vector2.\n \nTarget: Value to invert.\nIgnore X: Whether or not to mirror the X component of the Target.\nIgnore Y: Whether or not to mirror the Y component of the Target.\nValue (out): Inverted value ([x, y] -> [-x, -y]).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Invert_Vector2")]

[FriendlyName("Invert Vector2")]
public class uScriptAct_InvertVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Vector2 Target,
      [FriendlyName("Ignore X"), SocketState(false, false)] bool IgnoreX,
      [FriendlyName("Ignore Y"), SocketState(false, false)] bool IgnoreY,
      out Vector2 Value
      )
   {
      Value = new Vector2(Target.x, Target.y);

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

   }
}