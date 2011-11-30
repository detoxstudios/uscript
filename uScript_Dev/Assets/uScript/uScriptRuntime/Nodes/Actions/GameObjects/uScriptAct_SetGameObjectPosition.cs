// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the position (Vector3) of a GameObject as world coordinates.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Position")]

[FriendlyName("Set Position", "Sets the position (Vector3) of a GameObject as world coordinates.")]
public class uScriptAct_SetGameObjectPosition : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Target GameObject(s) to set the position of.")]
      GameObject[] Target,

      [FriendlyName("Position", "The position to set the Target GameObjects to. If \"As Offset\" is enabled, this value will be used as an offest from the target's current position.")]
      Vector3 Position,

      [FriendlyName("As Offset", "Whether or not to use Position as an offset from the Target GameObjects' position(s).")]
      [SocketState(false, false)]
      bool AsOffset
      )
   {
      foreach ( GameObject currentTarget in Target )
      {
         if ( currentTarget != null )
         {
            if (AsOffset)
            {
               currentTarget.transform.position += Position;
            }
            else
            {
               currentTarget.transform.position = Position;
            }
         }
      }

   }
}
