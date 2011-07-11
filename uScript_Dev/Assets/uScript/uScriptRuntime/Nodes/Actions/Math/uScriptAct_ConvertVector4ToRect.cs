// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Converts a Vector4 variable to a Rect variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Converts a Vector4 variable to a Rect variable.")]
[NodeDescription("Converts a Vector4 variable to a Rect variable.\n \nVector4: The Vector4 variable to be converted.\nRect (out): The new Rect variable created from the Vector4.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Convert Vector4 To Rect")]
public class uScriptAct_ConvertVector4ToRect : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Vector4")] Vector4 TargetVector4,
      [FriendlyName("Rect")] out Rect NewRect
      )
   {
      float X = TargetVector4.x;
      float Y = TargetVector4.y;
      float Z = TargetVector4.z;
      float W = TargetVector4.w;

      NewRect = new Rect(X, Y, Z, W);

   }
}