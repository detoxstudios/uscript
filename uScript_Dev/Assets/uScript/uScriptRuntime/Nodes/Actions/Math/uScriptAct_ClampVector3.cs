// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Clamps a Vector3 variable between a min and a max value for the desired components and returns the resulting Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Clamp Vector3", "Clamps Vector3 variable components between minimun and maximum values.")]
public class uScriptAct_ClampVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Vector3 to be clamped.")]
      Vector3 Target,
      
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
      
      [FriendlyName("Result", "The clamped Vector3 variable.")]
      out Vector3 Result
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

      Result = Target;
   }
}