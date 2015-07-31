// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Color")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Clamps a Color variable between a min and a max value for the desired components and returns the resulting Color.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Clamp Color", "Clamps Color variable components between minimun and maximum values." +
 "\n\nValues must be within the normalized color range of 0 and 1. Values outside this range are themselves clamped.")]
public class uScriptAct_ClampColor : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Color to be clamped.")]
      Color Target,
      
      [FriendlyName("Clamp Red", "If True, the Red component will be clamped.")]
      [SocketState(false, false)]
      bool ClampX,
      
      [FriendlyName("Red Min", "The minimun value allowed for the Red component.")]
      [SocketState(false, false)]
      float XMin,
      
      [FriendlyName("Red Max", "The maximum value allowed for the Red component.")]
      [SocketState(false, false)]
      float XMax,
      
      [FriendlyName("Clamp Green", "If True, the Green component will be clamped.")]
      [SocketState(false, false)]
      bool ClampY,
      
      [FriendlyName("Green Min", "The minimun value allowed for the Green component.")]
      [SocketState(false, false)]
      float YMin,
      
      [FriendlyName("Green Max", "The maximum value allowed for the Green component.")]
      [SocketState(false, false)]
      float YMax,
      
      [FriendlyName("Clamp Blue", "If True, the Blue component will be clamped.")]
      [SocketState(false, false)]
      bool ClampZ,
      
      [FriendlyName("Blue Min", "The minimun value allowed for the Blue component.")]
      [SocketState(false, false)]
      float ZMin,
      
      [FriendlyName("Blue Max", "The maximum value allowed for the Blue component.")]
      [SocketState(false, false)]
      float ZMax,
      
      [FriendlyName("Clamp Alpha", "If True, the Alpha component will be clamped.")]
      [SocketState(false, false)]
      bool ClampW,
      
      [FriendlyName("Alpha Min", "The minimun value allowed for the Alpha component.")]
      [SocketState(false, false)]
      float WMin,
      
      [FriendlyName("Alpha Max", "The maximum value allowed for the Alpha component.")]
      [SocketState(false, false)]
      float WMax,
      
      [FriendlyName("Result", "The clamped Color variable.")]
      out Color Result
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