// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Attaches one GameObject to another, setting the Target as the parent of the Attachment.
//       Optionally, a relative offset and rotation can be set for the attachment.

using UnityEngine;
using System.Collections;

public class uScriptAct_AttachToGameObject : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject Target, GameObject Attachment, bool UseRelativeOffset, Vector3 RelativeOffset, bool UseRelativeRotation, Vector3 RelativeRotation)
   {
      if (Attachment != null)
      {
         if (Target != null)
         {
            Attachment.transform.parent = Target.transform;

            if (UseRelativeOffset)
            {
               Attachment.transform.localPosition = RelativeOffset;
            }

            if (UseRelativeRotation)
            {
               Attachment.transform.Rotate(RelativeRotation, Space.Self);
            }

         }
      }

   }
}
