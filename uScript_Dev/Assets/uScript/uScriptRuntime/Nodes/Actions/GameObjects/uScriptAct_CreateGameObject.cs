// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Creates a new GameObject at the specified location.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Create GameObject", "Creates a new GameObject at the specified location.")]
public class uScriptAct_CreateGameObject: uScriptLogic
{
	public bool Out { get { return true; } }
	
	public void In (
	                [FriendlyName("Name", "The name given to the new GameObject."), DefaultValue("GameObject")] string Name,
	                [FriendlyName("Location", "The world location where to place the new GameObject."), SocketState(false, false)] Vector3 Location,
	                [FriendlyName("GameObject", "The new GameObject.")] out GameObject newGameObject
	                )
	{
		newGameObject = new GameObject(Name);
		newGameObject.transform.position = Location;
	}
}