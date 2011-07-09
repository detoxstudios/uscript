// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the GameObject in the scene with the specified name.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the GameObject in the scene with the specified name.")]
[NodeDescription("Returns the GameObject in the scene with the specified name. WARNING: For performance reasons, this should not be executed every frame. The \"Found\" output socket will be triggered if a GameObject matching the name is found, otherwise the \"Not Found\" output socket will be triggered.\n\nVariable Sockets:\n\tName (In): The name of the GameObject you are looking for.\n\tGameObject (Out): Assigns found GameObject to the attached variable\n\nOutput Sockets:\n\tOut: The standard output socket (always fired).\n\tFound: Fired once if a GameObject is found.\n\tNot Found: Fired once if no child GameObject is found.\n")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_GameObject_By_Name")]

[FriendlyName("Get GameObject By Name")]
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
                   [FriendlyName("Name")] string Name,
                   [FriendlyName("GameObject")] out GameObject gameObject
                   )
   {
      m_Out = false;

      gameObject = GameObject.Find(Name);

      // Fire out the correct out socket
      m_True = gameObject != null;

      m_Out = true;
   }
}
