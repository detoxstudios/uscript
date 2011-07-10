// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Converts a Rect variable to a Vector4 variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Converts a Rect variable to a Vector4 variable.")]
[NodeDescription("Converts a Rect variable to a Vector4 variable.\n \nRect: The Rect variable to be converted.\nVector4 (out): The new Vector4 variable created from the Rect.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Convert Rect To Vector4")]
public class uScriptAct_ConvertRectToVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Rect")] Rect TargetRect,
      [FriendlyName("Vector4")] out Vector4 NewVector4
      )
   {
      float xMin = TargetRect.xMin;
      float yMin = TargetRect.yMin;
      float Width = TargetRect.width;
      float Height = TargetRect.height;

      NewVector4 = new Vector4(xMin, yMin, Width, Height);

   }
}