// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector3")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Wrapper around the Vector3.RotateTowards function.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Rotate Towards", "Rotate a Vector3 towards another Vector3.")]
public class uScriptAct_RotateTowardsVector3 : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("Current", "The current Vector3.")]
      Vector3 current,
      
      [FriendlyName("Target", "The target Vector3.")]
      Vector3 target,

      [FriendlyName("Max Radian Delta", "The maximum rotation allowed in radians.")]
      float maxRadiansDelta,
      
      [FriendlyName("Max Magnitude Delta", "The maximum magnitude in radians.")]
      float maxMagnitudeDelta,

      [FriendlyName("Result", "The resulting Vector3.")]
      out Vector3 result
      )
   {
      result = Vector3.RotateTowards(current, target, maxRadiansDelta, maxMagnitudeDelta);
   }
}
