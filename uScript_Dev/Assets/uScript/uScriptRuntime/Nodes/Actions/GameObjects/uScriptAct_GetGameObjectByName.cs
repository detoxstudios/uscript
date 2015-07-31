// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the GameObject in the scene with the specified name.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get GameObject By Name",
              "Returns the GameObject in the scene with the specified name." +
              "\n\nThe \"Found\" output socket will be triggered if a GameObject matching the name is found, otherwise the \"Not Found\" output socket will be triggered." +
              "\n\nWARNING: For performance reasons, this should not be executed every frame.")]
public class uScriptAct_GetGameObjectByName : uScriptLogic
{
   private bool m_Out = false;
   public bool Out { get { return m_Out; } }
   private bool m_True = false;

   [FriendlyName("Found")]
   public bool GameObjectFound { get { return m_True; } }

   [FriendlyName("Not Found")]
   public bool GameObjectNotFound { get { return !m_True; } }

   public void In(
      [FriendlyName("Name", "The name of the GameObject you are looking for.")]
      string Name,

      [FriendlyName("GameObject", "Assigns found GameObject to the attached variable.")]
      out GameObject gameObject
      )
   {
      m_Out = false;

      gameObject = GameObject.Find(Name);

      // Fire out the correct out socket
      m_True = gameObject != null;

      m_Out = true;
   }
}
