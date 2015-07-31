// uScript Action Node
// (C) 2014 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Returns the child GameObject of a parent GameObject with the specified name.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Find Child Transform",
              "Searches the target GameObject for a child using the specified name.\n\n" +
              "\"Child Found\" will fire if the child GameObject is found matching " +
              "the search criteria, otherwise \"Child Not Found\" will fire.\n\n" + 
			  "(Paths are supported - ex. 'path/to/my/gameobject")]
public class uScriptAct_FindChildTransform : uScriptLogic
{
	private bool m_Out = false;
	public bool Out { get { return m_Out; } }

	private bool m_True = false;
	[FriendlyName("Child Found")]
	public bool ChildFound { get { return m_True; } }

	[FriendlyName("Child Not Found")]
	public bool ChildNotFound { get { return !m_True; } }

	public void In (
      [FriendlyName("Target", "The parent GameObject you wish to search for the child GameObject on.")]
      GameObject Target,
      
      [FriendlyName("Name", "The name of the child GameObject you are looking for.")]
      string Name,

      [FriendlyName("Child", "The found child GameObject.")]
      out GameObject Child
      )
	{
		m_Out = false;
		m_True = false;
		
		Transform t = Target.transform.FindChild(Name);
		
		if ( t != null )
		{
			m_True = true;
			Child = t.gameObject;
		}
		else
		{
			Child = null;
		}

		m_Out = true;
	}
}
