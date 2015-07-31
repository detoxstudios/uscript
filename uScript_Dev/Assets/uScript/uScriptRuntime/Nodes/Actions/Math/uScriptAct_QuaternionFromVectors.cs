// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Conversions")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Converts a forward and up vector into a quaternion.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Quaternion From Vectors", "Converts a forward and up vector into a quaternion.")]
public class uScriptAct_QuaternionFromVectors : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Foward Vector", "The forward vector component of the quaternion.")]
      Vector3 forward,
      
      [FriendlyName("Up Vector", "The up vector component of the quaternion.")]
      Vector3 up,
      
      [FriendlyName("Result Quaternion", "The quaternion calculated using the forward and up vectors passed in.")]
      out Quaternion result
      )
   {
      if (forward == Vector3.zero)
      {
         forward = Vector3.forward;
         
         if (up != Vector3.zero)
         {
            // fix edge cases
            if (forward == up || forward == -up) forward = Vector3.right;

            // need to re-calculate forward and preserve up
            Vector3 right = Vector3.Cross(forward, up);
            forward = Vector3.Cross(up, right);
         }
      }

      if (up == Vector3.zero)
      {
         up = Vector3.up;
         
         if (forward != Vector3.zero)
         {
            // fix edge cases
            if (forward == up || forward == -up) up = Vector3.forward;
            
            // need to re-calculate up and preserve look
            Vector3 right = Vector3.Cross(forward, up);
            up = Vector3.Cross(right, forward);
         }
      }
         
         
      result = Quaternion.LookRotation(forward, up);
   }
}
