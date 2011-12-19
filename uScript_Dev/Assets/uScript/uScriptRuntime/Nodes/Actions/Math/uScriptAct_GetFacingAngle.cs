// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the 2D facing angle in degrees between the direction of Target A and the position of Target B.")]
[NodeAuthor("Detox Studios LLC. Original node by SvdV on the uScript Community Forum", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Facing Angle", "Returns the 2D angle in degrees between the direction of Target A and the position of Target B. The resulting 2D angle is how many degress must Target A turn to face Target B.")]
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
         Vector3 finalPos = A.transform.InverseTransformDirection(bPos);

         float Result = Mathf.Atan2(finalPos.x, finalPos.z) * Mathf.Rad2Deg;
         Angle = Result;

      }
      else
      {
         Angle = 0f;
      }

   }
}