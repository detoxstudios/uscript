// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Conversions")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Converts a Rect variable to a Vector4 variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Convert Rect To Vector4", "Converts a Rect variable to a Vector4 variable.")]
public class uScriptAct_ConvertRectToVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Rect", "The Rect variable to be converted.")]
      Rect TargetRect,
      
      [FriendlyName("Vector4", "The new Vector4 variable created from the Rect.")]
      out Vector4 NewVector4
      )
   {
      float xMin = TargetRect.xMin;
      float yMin = TargetRect.yMin;
      float Width = TargetRect.width;
      float Height = TargetRect.height;

      NewVector4 = new Vector4(xMin, yMin, Width, Height);
   }
}