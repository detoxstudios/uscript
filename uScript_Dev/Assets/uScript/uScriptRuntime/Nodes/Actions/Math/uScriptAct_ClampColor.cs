// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Clamps a Color variable between a min and a max value for the desired components and returns the resulting Color.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Clamps a Color variable between a min and a max value for the desired components and returns the resulting Color.")]
[NodeDescription("Clamps a Color variable between a min and a max value for the desired components and returns the resulting Color. Values must be between Unity's color range of 0 and 1. Values outside this range are clamped to either 0 or 1.\n\nTarget: The Color to be clamped.\nClamp Red: Specifiy if the red component will be clamped.\nRed Min: The minimun float value allowed for the red component of the Color.\nRed Max: The maximum float value allowed for the red component of the Color.\nClamp Green: Specifiy if the Green component will be clamped.\nGreen Min: The minimun float value allowed for the green component of the Color.\nGreen Max: The maximum float value allowed for the green component of the Color.\nClamp Blue: Specifiy if the height component will be clamped.\nBlue Min: The minimun float value allowed for the blue component of the Color.\nBlue Max: The maximum float value allowed for the blue component of the Color.\nClamp Alpha: Specifiy if the alpha component will be clamped.\nAlpha Min: The minimun float value allowed for the alpha component of the Color.\nAlpha Max: The maximum float value allowed for the alpha component of the Color.\nResult: The resulting Color variable after clamping.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Clamp Color")]
public class uScriptAct_ClampColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Color Target,
      [FriendlyName("Clamp Red"), SocketState(false, false)] bool ClampX,
      [FriendlyName("Red Min"), SocketState(false, false)] float XMin,
      [FriendlyName("Red Max"), SocketState(false, false)] float XMax,
      [FriendlyName("Clamp Green"), SocketState(false, false)] bool ClampY,
      [FriendlyName("Green Min"), SocketState(false, false)] float YMin,
      [FriendlyName("Green Max"), SocketState(false, false)] float YMax,
      [FriendlyName("Clamp Blue"), SocketState(false, false)] bool ClampZ,
      [FriendlyName("Blue Min"), SocketState(false, false)] float ZMin,
      [FriendlyName("Blue Max"), SocketState(false, false)] float ZMax,
      [FriendlyName("Clamp Alpha"), SocketState(false, false)] bool ClampW,
      [FriendlyName("Alpha Min"), SocketState(false, false)] float WMin,
      [FriendlyName("Alpha Max"), SocketState(false, false)] float WMax,
      [FriendlyName("Result")] out Color Result
      )
   {

      if (ClampX)
      {
         if (XMin < 0) { XMin = 0f; }
         if (XMin > 1) { XMin = 1f; }
         if (XMax < 0) { XMax = 0f; }
         if (XMax > 1) { XMax = 1f; }
         Target.r = Mathf.Clamp(Target.r, XMin, XMax);
      }
      if (ClampY)
      {
         if (YMin < 0) { YMin = 0f; }
         if (YMin > 1) { YMin = 1f; }
         if (YMax < 0) { YMax = 0f; }
         if (YMax > 1) { YMax = 1f; }
         Target.g = Mathf.Clamp(Target.g, YMin, YMax);
      }
      if (ClampZ)
      {
         if (ZMin < 0) { ZMin = 0f; }
         if (ZMin > 1) { ZMin = 1f; }
         if (ZMax < 0) { ZMax = 0f; }
         if (ZMax > 1) { ZMax = 1f; }
         Target.b = Mathf.Clamp(Target.b, ZMin, ZMax);
      }
      if (ClampW)
      {
         if (WMin < 0) { WMin = 0f; }
         if (WMin > 1) { WMin = 1f; }
         if (WMax < 0) { WMax = 0f; }
         if (WMax > 1) { WMax = 1f; }
         Target.a = Mathf.Clamp(Target.a, WMin, WMax);
      }

      Result = Target;
   }
}