// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Attaches one GameObject to another, setting the Target as the parent of the Attachment.
//       Optionally, a relative offset and rotation can be set for the attachment.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Attaches one GameObject to another, setting the Target as the parent of the Attachment.")]
[NodeDescription("Attaches one GameObject to another, setting the Target as the parent of the Attachment.\n \nTarget: GameObject to attach to.\nAttachment: GameObject to attach to the Target.\nUse Relative Offset: Whether or not to use the relative offset.\nRelative Offset: The relative offset to use.\nUse Relative Rotation: Whether or not to use the relative rotation.\nRelative Rotation: The relative rotation to use.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Attach To GameObject")]
public class uScriptAct_AttachToGameObject : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      GameObject Target,
      GameObject Attachment, 
      [FriendlyName("Use Relative Offset"), SocketState(false, false)] bool UseRelativeOffset,
      [FriendlyName("Relative Offset"), SocketState(false, false)] Vector3 RelativeOffset,
      [FriendlyName("Use Relative Rotation"), SocketState(false, false)] bool UseRelativeRotation,
      [FriendlyName("Relative Rotation"), SocketState(false, false)] Vector3 RelativeRotation
      )
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
