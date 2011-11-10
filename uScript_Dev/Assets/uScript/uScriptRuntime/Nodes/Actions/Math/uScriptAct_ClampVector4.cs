// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Clamps a Vector4 variable between a min and a max value for the desired components and returns the resulting Vector4.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Clamps a Vector4 variable between a min and a max value for the desired components and returns the resulting Vector4.")]
[NodeDescription(@"Clamps a Vector4 variable between a min and a max value for the desired components and returns the resulting Vector4.\n\nTarget: The Vector to be clamped.\nClamp X: Specifiy if the X component will be clamped.\nX Min: The minimun float value allowed for the X component of the Vector.\nX Max: The maximum float value allowed for the X component of the Vector.\nClamp Y: Specifiy if the Y component will be clamped.\nY Min: The minimun float value allowed for the Y component of the Vector.\nY Max: The maximum float value allowed for the Y component of the Vector.\nClamp Z: Specifiy if the Z component will be clamped.\nZ Min: The minimun float value allowed for the Z component of the Vector.\nZ Max: The maximum float value allowed for the Z component of the Vector.\nClamp W: Specifiy if the W component will be clamped.\nW Min: The minimun float value allowed for the W component of the Vector.\nW Max: The maximum float value allowed for the W component of the Vector.\nResult: The resulting Vector variable after clamping.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Clamp Vector4")]
public class uScriptAct_ClampVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Vector4 Target,
      [FriendlyName("Clamp X"), SocketState(false, false)] bool ClampX,
      [FriendlyName("X Min"), SocketState(false, false)] float XMin,
      [FriendlyName("X Max"), SocketState(false, false)] float XMax,
      [FriendlyName("Clamp Y"), SocketState(false, false)] bool ClampY,
      [FriendlyName("Y Min"), SocketState(false, false)] float YMin,
      [FriendlyName("Y Max"), SocketState(false, false)] float YMax,
      [FriendlyName("Clamp Z"), SocketState(false, false)] bool ClampZ,
      [FriendlyName("Z Min"), SocketState(false, false)] float ZMin,
      [FriendlyName("Z Max"), SocketState(false, false)] float ZMax,
      [FriendlyName("Clamp W"), SocketState(false, false)] bool ClampW,
      [FriendlyName("W Min"), SocketState(false, false)] float WMin,
      [FriendlyName("W Max"), SocketState(false, false)] float WMax,
      [FriendlyName("Result")] out Vector4 Result
      )
   {
      if (ClampX)
      {
         Target.x = Mathf.Clamp(Target.x, XMin, XMax);
      }
      if (ClampY)
      {
         Target.y = Mathf.Clamp(Target.y, YMin, YMax);
      }
      if (ClampZ)
      {
         Target.z = Mathf.Clamp(Target.z, ZMin, ZMax);
      }
      if (ClampW)
      {
         Target.w = Mathf.Clamp(Target.w, WMin, WMax);
      }

      Result = Target;
   }
}