// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Clamps a Rect variable between a min and a max value for the desired components and returns the resulting Rect.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Clamp Rect", "Clamps Rect variable components between minimun and maximum values.")]
public class uScriptAct_ClampRect : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Rect to be clamped.")]
      Rect Target,
      
      [FriendlyName("Clamp X", "If True, the X component will be clamped.")]
      [SocketState(false, false)]
      bool ClampX,
      
      [FriendlyName("X Min", "The minimum value allowed for the X component.")]
      [SocketState(false, false)]
      float XMin,
      
      [FriendlyName("X Max", "The maximum value allowed for the X component.")]
      [SocketState(false, false)]
      float XMax,
      
      [FriendlyName("Clamp Y", "If True, the Y component will be clamped.")]
      [SocketState(false, false)]
      bool ClampY,
      
      [FriendlyName("Y Min", "The minimum value allowed for the Y component.")]
      [SocketState(false, false)]
      float YMin,
      
      [FriendlyName("Y Max", "The maximum value allowed for the Y component.")]
      [SocketState(false, false)]
      float YMax,
      
      [FriendlyName("Clamp Height", "If True, the Height component will be clamped.")]
      [SocketState(false, false)]
      bool ClampZ,
      
      [FriendlyName("Height Min", "The minimum value allowed for the Height component.")]
      [SocketState(false, false)]
      float ZMin,
      
      [FriendlyName("Height Max", "The maximum value allowed for the Height component.")]
      [SocketState(false, false)]
      float ZMax,
      
      [FriendlyName("Clamp Width", "If True, the Width component will be clamped.")]
      [SocketState(false, false)]
      bool ClampW,
      
      [FriendlyName("Width Min", "The minimum value allowed for the Width component.")]
      [SocketState(false, false)]
      float WMin,
      
      [FriendlyName("Width Max", "The maximum value allowed for the Width component.")]
      [SocketState(false, false)]
      float WMax,
      
      [FriendlyName("Result", "The clamped Rect variable.")]
      out Rect Result
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