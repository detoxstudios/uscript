// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Clamps a Vector4 variable between a min and a max value for the desired components and returns the resulting Vector4.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Clamp Vector4", "Clamps Vector4 variable components between minimun and maximum values.")]
public class uScriptAct_ClampVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Vector4 to be clamped.")]
      Vector4 Target,
      
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
      
      [FriendlyName("Clamp Z", "If True, the Z component will be clamped.")]
      [SocketState(false, false)]
      bool ClampZ,
      
      [FriendlyName("Z Min", "The minimum value allowed for the Z component.")]
      [SocketState(false, false)]
      float ZMin,
      
      [FriendlyName("Z Max", "The maximum value allowed for the Z component.")]
      [SocketState(false, false)]
      float ZMax,
      
      [FriendlyName("Clamp W", "If True, the W component will be clamped.")]
      [SocketState(false, false)]
      bool ClampW,
      
      [FriendlyName("W Min", "The minimum value allowed for the W component.")]
      [SocketState(false, false)]
      float WMin,
      
      [FriendlyName("W Max", "The maximum value allowed for the W component.")]
      [SocketState(false, false)]
      float WMax,
      
      [FriendlyName("Result", "The clamped Vector4 variable.")]
      out Vector4 Result
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