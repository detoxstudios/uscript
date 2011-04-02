// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the position (Vector3) of a GameObject as world coordinates. Optionally can set position as offest from the target's current position.

using UnityEngine;
using System.Collections;

[NodePath("Action/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the position (Vector3) of a GameObject as world coordinates.")]
[NodeDescription("Sets the position (Vector3) of a GameObject as world coordinates. Optionally can set position as offest from the target's current position.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set Position")]
public class uScriptAct_SetGameObjectPosition : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject[] Target, Vector3 Position, [FriendlyName("As Offset")] bool AsOffset)
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
