// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the GameObject in the scene with the specified name.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the GameObject in the scene with the specified name.")]
[NodeDescription("Returns the GameObject in the scene with the specified name. WARNING: For performance reasons, this should not be executed every frame. The \"GameObject Found\" output socket will be triggered if a GameObject matching the name is found, otherwise the \"GameObject Not Found\" output socket will be triggered.\n\nVariable Sockets:\nName (In): The name of the GameObject you are looking for.\nGameObject (Out): Assigns found GameObject to the attached variable\n\nOutput Sockets:\nOut: The standard output socket (always fired).\nGameObject Found: Fired once if a GameObject is found.\nGameObject Not Found: Fired once if no child GameObject is found.\n")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Find GameObject By Name")]
public class uScriptAct_FindGameObjectByName : uScriptLogic
{
	private bool m_Out = false;
	public bool Out { get { return m_Out; } }

	private bool m_True = false;
	[FriendlyName("GameObject Found")]
	public bool ChildrenFound { get { return m_True; } }

	[FriendlyName("GameObject Not Found")]
	public bool ChildrenNotFound { get { return !m_True; } }

	public void In (
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
