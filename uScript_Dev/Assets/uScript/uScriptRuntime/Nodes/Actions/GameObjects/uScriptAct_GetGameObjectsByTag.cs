// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the GameObjects in the scene with the specified tag.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get GameObjects By Tag", "Returns the GameObjects in the scene with the specified tag.\n\nThe \"Found\" output socket will be triggered if at least one child GameObject matching the tag is found, otherwise the \"Not Found\" output socket will be triggered.")]
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
      [FriendlyName("Tag", "The tag name of the GameObjects you are looking for.")]
      string Tag,
      
      [FriendlyName("First GameObject", "The first GameObject in the list of GameObjects.")]
      out GameObject FirstGameObject,
      
      [FriendlyName("GameObjects", "Assigns found GameObjects to the attached variable.")]
      out GameObject[] GameObjects,
      
      [FriendlyName("GameObject Count", "Sets the total number of GameObjects found to the attached variable.")]
      [SocketState(false, false)]
      out int GameObjectCount
      )
   {
      m_Out = false;

      GameObjects = GameObject.FindGameObjectsWithTag(Tag);
      GameObjectCount = GameObjects.Length;

      // Fire out the correct true/false out socket
      m_True = GameObjectCount > 0;

      if (m_True) FirstGameObject = GameObjects[0]; else FirstGameObject = null;
      m_Out = true;
   }
}
