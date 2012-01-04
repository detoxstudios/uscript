// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/Level")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets DontDestroyOnLoad on an object so it will not be destroyed automatically when loading a new scene.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Don't Destroy On Load", "Sets DontDestroyOnLoad on an object so it will not be destroyed automatically when loading a new scene. If the object is a component or GameObject then its entire transform hierarchy will not be destroyed either.")]
public class uScriptAct_DontDestroyOnLoad : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In (
      [FriendlyName("Target", "The GameObject(s) or other object types you wish to set DontDestroyOnLoad on.")]
      UnityEngine.Object[] Target
      )
   {
		foreach( UnityEngine.Object obj in Target)
		{
			if (null != obj)
			{
				UnityEngine.Object.DontDestroyOnLoad(obj);
			}
		}

      
   }
}
