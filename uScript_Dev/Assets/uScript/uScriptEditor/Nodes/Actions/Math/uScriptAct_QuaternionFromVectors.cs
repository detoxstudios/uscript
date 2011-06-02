// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Converts a look and up vector into a quaternion.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Converts a look and up vector into a quaternion.")]
[NodeDescription("Converts a look and up vector into a quaternion.\n \nLook Vector: The look vector component of the quaternion.\nUp Vector: The up vector component of the quaternion.\nResult Quaternion (out): The quaternion calculated using the look and up vectors passed in.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Quaternion From Vectors")]
public class uScriptAct_QuaternionFromVectors : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Look Vector")] Vector3 look,
      [FriendlyName("Up Vector")] Vector3 up,
      [FriendlyName("Result Quaternion")] out Quaternion result
      )
   {
      if (look == Vector3.zero)
      {
         look = Vector3.forward;
         
         if (up != Vector3.zero)
         {
            // fix edge cases
            if (look == up || look == -up) look = Vector3.right;

            // need to re-calculate look and preserve up
            Vector3 right = Vector3.Cross(look, up);
            look = Vector3.Cross(up, right);
         }
      }

      if (up == Vector3.zero)
      {
         up = Vector3.up;
         
         if (look != Vector3.zero)
         {
            // fix edge cases
            if (look == up || look == -up) up = Vector3.forward;
            
            // need to re-calculate up and preserve look
            Vector3 right = Vector3.Cross(look, up);
            up = Vector3.Cross(right, look);
         }
      }
         
         
      result = Quaternion.LookRotation(look, up);
   }
}