// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Get various math constants.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Get various math constants.")]
[NodeDescription("Get various math constants.\n \nDegrees To Radians: The constant for calculating radians from degrees.\nRadians To Degrees: The constant for calculating degrees from radians.\nInfinity: The constant representing infinity.\nNegative Infinity: The constant representing negative infinity.\nPI: The constant PI.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#MathConstants")]

[FriendlyName("Get Math Constants")]
public class uScriptAct_MathConstants : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("Degrees To Radians")]out float deg2Rad, [FriendlyName("Radians To Degrees")]out float rad2Deg, [FriendlyName("Infinity")]out float infinity, [FriendlyName("Negative Infinity")]out float nInfinity, [FriendlyName("PI")]out float pi)
   {
      deg2Rad     = Mathf.Deg2Rad;
      infinity    = Mathf.Infinity;
      nInfinity   = Mathf.NegativeInfinity;
      pi          = Mathf.PI;
      rad2Deg     = Mathf.Rad2Deg;
   }
}