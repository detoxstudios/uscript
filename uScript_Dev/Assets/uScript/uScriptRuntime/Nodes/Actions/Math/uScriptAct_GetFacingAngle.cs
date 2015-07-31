// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Angles")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the 2D facing angle in degrees between the direction of target A and the position of target B.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Facing Angle", "Returns the 2D angle in degrees between the direction of target A and the position of target B. The resulting 2D angle is how many degress must target A turn to face target B.")]
public class uScriptAct_GetFacingAngle : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first target.")] GameObject A,
      [FriendlyName("B", "The second target.")] GameObject B,
      [FriendlyName("Angle", "The angle result in degrees.")] out float Angle)
   {
      if (null != A && null != B)
      {
         Vector3 bPos = B.transform.position;
         Vector3 finalPos = A.transform.InverseTransformPoint(bPos);

         float Result = Mathf.Atan2(finalPos.x, finalPos.z) * Mathf.Rad2Deg;
         Angle = Result;

      }
      else
      {
         Angle = 0f;
      }

   }
}