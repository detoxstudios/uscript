// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Converts a forward and up vector into a quaternion.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Converts a forward and up vector into a quaternion.")]
[NodeDescription("Converts a forward and up vector into a quaternion.\n \nForward Vector: The forward vector component of the quaternion.\nUp Vector: The up vector component of the quaternion.\nResult Quaternion (out): The quaternion calculated using the forward and up vectors passed in.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Quaternion_From_Vectors")]

[FriendlyName("Quaternion From Vectors")]
public class uScriptAct_QuaternionFromVectors : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Foward Vector")] Vector3 forward,
      [FriendlyName("Up Vector")] Vector3 up,
      [FriendlyName("Result Quaternion")] out Quaternion result
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