// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Attaches one GameObject to another, setting the Target as the parent of the Attachment.
//       Optionally, a relative offset and rotation can be set for the attachment.

using UnityEngine;
using System.Collections;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Attaches one GameObject to another, setting the Target as the parent of the Attachment.")]
[NodeDescription("Attaches one GameObject to another, setting the Target as the parent of the Attachment. Optionally, a relative offset and rotation can be set for the attachment.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Attach To GameObject")]
public class uScriptAct_AttachToGameObject : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject Target, GameObject Attachment, [FriendlyName("Use Relative Offset")] bool UseRelativeOffset, [FriendlyName("Relative Offset")] Vector3 RelativeOffset, [FriendlyName("Use Relative Rotation")] bool UseRelativeRotation, [FriendlyName("Relative Rotation")] Vector3 RelativeRotation)
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
