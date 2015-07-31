// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Float")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Get various math constants.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Math Constants", "Get various math constants.")]
public class uScriptAct_MathConstants : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Degrees To Radians", "The constant for calculating radians from degrees.")]
      out float deg2Rad,
      
      [FriendlyName("Radians To Degrees", "The constant for calculating degrees from radians.")]
      out float rad2Deg,
      
      [FriendlyName("Infinity", "The constant representing infinity.")]
      out float infinity,
      
      [FriendlyName("Negative Infinity", "The constant representing negative infinity.")]
      out float nInfinity,

      [FriendlyName("PI", "The constant PI.")]
      out float pi
      )
   {
      deg2Rad     = Mathf.Deg2Rad;
      infinity    = Mathf.Infinity;
      nInfinity   = Mathf.NegativeInfinity;
      pi          = Mathf.PI;
      rad2Deg     = Mathf.Rad2Deg;
   }
}