// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Mirrors the X, Y, Z and W of a Vector4.

using UnityEngine;
using System.Collections;

public class uScriptAct_InvertVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(Vector4 Target, bool IgnoreX, bool IgnoreY, bool IgnoreZ, bool IgnoreW, out Vector4 Value)
   {
      float newX = Target.x;
      float newY = Target.y;
      float newZ = Target.z;
      float newW = Target.w;

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

      // Mirror W axis
      if (!IgnoreW)
      {
         if (newW > 0F)
         {
            newW = System.Math.Abs(newW) * (-1F);
         }
         else
         {
            newW = System.Math.Abs(newW);
         }
      }

      // Output the mirrored axis values into a new Vector3
      Value = new Vector4(newX, newY, newZ, newW);

   }
}