// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Causes the targeted GameObject to be relocated to the destination GameObject. Optionally, can update the rotation to the destination's rotation as well.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Causes the targeted GameObject to be relocated to the destination GameObject.")]
[NodeDescription("Causes the targeted GameObject to be relocated to the destination GameObject.\n \nTarget: The Target GameObject(s) to teleport.\nDestination: The destination GameObject to teleport to.\nUpdate Rotation: Whether or not to also update the rotation of the teleported GameObject to match the Destination's rotation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Teleport")]
public class uScriptAct_Teleport : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      GameObject[] Target,
      GameObject Destination,
      [FriendlyName("Update Rotation"), SocketState(false, false)] bool UpdateRotation)
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