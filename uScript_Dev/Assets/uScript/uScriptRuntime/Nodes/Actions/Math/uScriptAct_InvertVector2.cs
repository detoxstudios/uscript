// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Mirrors the X and Y of a Vector2.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Invert_Vector2")]

[FriendlyName("Invert Vector2", "Returns the inverse value of a Vector2 variable. Individual components can optionally be ignored by this operation." +
 "\n\nExample:" +
 "\n\t[x, y] -> [-x, -y]")]
public class uScriptAct_InvertVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "Value to invert.")]
      Vector2 Target,

      [FriendlyName("Ignore X", "If True, the X component will be ignored.")]
      [SocketState(false, false)]
      bool IgnoreX,

      [FriendlyName("Ignore Y", "If True, the Y component will be ignored.")]
      [SocketState(false, false)]
      bool IgnoreY,

      [FriendlyName("Value", "The inverted value.")]
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