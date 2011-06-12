// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the GameObjects in the scene with the specified tag.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the GameObjects in the scene with the specified tag.")]
[NodeDescription("Returns the GameObjects in the scene with the specified tag. The \"Found\" output socket will be triggered if at least one child GameObject matching the tag is found, otherwise the \"Not Found\" output socket will be triggered.\n\nVariable Sockets:\n\tTag (In): The tag name of the GameObjects you are looking for.\n\tFirst GameObject (Out): The first GameObject in the list of GameObjects.\n\tGameObjects (Out): Assigns found GameObjects to the attached variable\n\tGameObject Count (Out): Sets the total number of GameObjects found to the attached variable\n\nOutput Sockets:\n\tOut: The standard output socket (always fired).\n\tFound: Fired once if at least one GameObject is found.\n\tNot Found: Fired once if no GameObject is found.\n")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get GameObjects By Tag")]
public class uScriptAct_GetGameObjectsByTag : uScriptLogic
{
   private bool m_Out = false;
   public bool Out { get { return m_Out; } }

   private bool m_True = false;
   [FriendlyName("Found")]
   public bool GameObjectsFound { get { return m_True; } }

   [FriendlyName("Not Found")]
   public bool GameObjectsNotFound { get { return !m_True; } }

   public void In(
                   [FriendlyName("Tag")] string Tag,
                   [FriendlyName("First GameObject")] out GameObject FirstGameObject,
                   [FriendlyName("GameObjects")] out GameObject[] GameObjects,
                   [FriendlyName("GameObject Count"), SocketState(false, false)] out int GameObjectCount
                   )
   {
      m_Out = false;

      GameObjects = GameObject.FindGameObjectsWithTag(Tag);
      FirstGameObject = GameObjects[0];
      GameObjectCount = GameObjects.Length;

      // Fire out the correct true/false out socket
      m_True = GameObjectCount > 0;

      m_Out = true;
   }
}
