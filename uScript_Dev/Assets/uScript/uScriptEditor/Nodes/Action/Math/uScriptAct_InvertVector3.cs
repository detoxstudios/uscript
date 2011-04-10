// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Mirrors the X, Y, and Z of a Vector3.

using UnityEngine;
using System.Collections;

[NodePath("Action/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Mirrors the X, Y, and Z of a Vector3.")]
[NodeDescription("Mirrors the X, Y, and Z of a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Invert Vector3")]
public class uScriptAct_InvertVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      Vector3 Target,
      [FriendlyName("Ignore X")] bool IgnoreX,
      [FriendlyName("Ignore Y")] bool IgnoreY,
      [FriendlyName("Ignore Z")]bool IgnoreZ,
      out Vector3 Value
      )
   {
      float newX = Target.x;
      float newY = Target.y;
      float newZ = Target.z;

      // Mirror X axis
      if (!IgnoreX)
      {
         if (newX > 0F)
         {
            newX = System.Math.Abs(newX) * (-1F);
         }
         else
         {
            newX = System.Math.Abs(newX);
         }
      }

      // Mirror Y axis
      if (!IgnoreY)
      {
         if (newY > 0F)
         {
            newY = System.Math.Abs(newY) * (-1F);
         }
         else
         {
            newY = System.Math.Abs(newY);
         }
      }
      
      // Mirror Z axis
      if (!IgnoreZ)
      {
         if (newZ > 0F)
         {
            newZ = System.Math.Abs(newZ) * (-1F);
         }
         else
         {
            newZ = System.Math.Abs(newZ);
         }
      }

      // Output the mirrored axis values into a new Vector3
      Value = new Vector3(newX, newY, newZ);

   }
}