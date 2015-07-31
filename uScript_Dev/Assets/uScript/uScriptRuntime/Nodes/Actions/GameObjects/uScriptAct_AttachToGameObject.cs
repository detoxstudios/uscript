// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Attaches one GameObject to another, setting the Target as the parent of the Attachment.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Attach To GameObject", "Attaches one GameObject to another, setting the Target as the parent of the Attachment.")]
public class uScriptAct_AttachToGameObject : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject to attach to.")]
      GameObject Target,

      [FriendlyName("Attachment", "GameObject to attach to the Target.")]
      GameObject Attachment,
      
      [FriendlyName("Use Relative Offset", "Whether or not to use the relative offset.")]
      [SocketState(false, false)]
      bool UseRelativeOffset,
      
      [FriendlyName("Relative Offset", "The relative offset to use.")]
      [SocketState(false, false)]
      Vector3 RelativeOffset,

      [FriendlyName("Use Relative Rotation", "Whether or not to use the relative rotation.")]
      [SocketState(false, false)]
      bool UseRelativeRotation,

      [FriendlyName("Relative Rotation", "The relative rotation to use.")]
      [SocketState(false, false)]
      Vector3 RelativeRotation
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
