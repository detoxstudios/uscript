// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Clamps a Rect variable between a min and a max value for the desired components and returns the resulting Rect.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Clamps a Rect variable between a min and a max value for the desired components and returns the resulting Rect.")]
[NodeDescription("Clamps a Rect variable between a min and a max value for the desired components and returns the resulting Rect.\n\nTarget: The Rect to be clamped.\nClamp X: Specifiy if the X component will be clamped.\nX Min: The minimun float value allowed for the X component of the Rect.\nX Max: The maximum float value allowed for the X component of the Rect.\nClamp Y: Specifiy if the Y component will be clamped.\nY Min: The minimun float value allowed for the Y component of the Rect.\nY Max: The maximum float value allowed for the Y component of the Rect.\nClamp Height: Specifiy if the height component will be clamped.\nHeight Min: The minimun float value allowed for the height component of the Rect.\nHeight Max: The maximum float value allowed for the height component of the Rect.\nClamp Width: Specifiy if the width component will be clamped.\nWidth Min: The minimun float value allowed for the width component of the Rect.\nWidth Max: The maximum float value allowed for the width component of the Rect.\nResult: The resulting Rect variable after clamping.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Clamp Rect")]
public class uScriptAct_ClampRect : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Rect Target,
      [FriendlyName("Clamp X"), SocketState(false, false)] bool ClampX,
      [FriendlyName("X Min"), SocketState(false, false)] float XMin,
      [FriendlyName("X Max"), SocketState(false, false)] float XMax,
      [FriendlyName("Clamp Y"), SocketState(false, false)] bool ClampY,
      [FriendlyName("Y Min"), SocketState(false, false)] float YMin,
      [FriendlyName("Y Max"), SocketState(false, false)] float YMax,
      [FriendlyName("Clamp Height"), SocketState(false, false)] bool ClampZ,
      [FriendlyName("Height Min"), SocketState(false, false)] float ZMin,
      [FriendlyName("Height Max"), SocketState(false, false)] float ZMax,
      [FriendlyName("Clamp Width"), SocketState(false, false)] bool ClampW,
      [FriendlyName("Width Min"), SocketState(false, false)] float WMin,
      [FriendlyName("Width Max"), SocketState(false, false)] float WMax,
      [FriendlyName("Result")] out Rect Result
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
         Target.height = Mathf.Clamp(Target.height, ZMin, ZMax);
      }
      if (ClampW)
      {
         Target.width = Mathf.Clamp(Target.width, WMin, WMax);
      }

      Result = Target;
   }
}