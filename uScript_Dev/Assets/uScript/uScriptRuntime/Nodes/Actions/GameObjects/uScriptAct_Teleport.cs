// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Causes the targeted GameObject to be relocated to the destination GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Teleport", "Causes the targeted GameObject to be relocated to the destination GameObject.")]
public class uScriptAct_Teleport : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Target GameObject(s) to teleport."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Destination", "The destination GameObject to teleport to.")]
      GameObject Destination,

      [FriendlyName("Update Rotation", "Whether or not to also update the rotation of the teleported GameObject to match the Destination's rotation.")]
      [SocketState(false, false)]
      bool UpdateRotation
      )
   {
      foreach (GameObject currentTarget in Target)
      {
         if (currentTarget != null && Destination != null)
         {
            currentTarget.transform.position = Destination.transform.position;

            if (UpdateRotation)
            {
               currentTarget.transform.rotation = Destination.transform.rotation;
            }
         }
      }
   }
}
