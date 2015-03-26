// uScript Action Node
// (C) 2015 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Makes a copy of the Target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]

[FriendlyName("Clone GameObject", "Makes a copy of the Target GameObject if it's not null. Use the 'Finished Cloning' output socket for anything that relies on the cloned GameObject to be fully instantiated (created).")]
public class uScriptAct_CloneGameObject : uScriptLogic
{
	public delegate void uScriptEventHandler(object sender, System.EventArgs args);
	private bool m_FinishedCloning = false;

   public bool Immediate { get { return true; } }

   [FriendlyName("Finished Cloning")]
   public event uScriptEventHandler FinishedCloning;


   public void In (
      [FriendlyName("Target", "The GameObject you wish to clone.")]
      GameObject Target,

	  [FriendlyName("Don't Rename", "Checking this will make the new clone have the same exact name as the Target (it will remove the '(Clone)' part that Unity adds to the end be default.")]
	  [SocketState(false, false)]
	  bool DoNotRename,

	  [FriendlyName("GameObject", "The newly cloned GameObject.")]
	  out GameObject Clone,
      
      [FriendlyName("Transform", "The transform component of the newly cloned GameObject.")]
	  [SocketState(false, false)]
      out Transform CloneTransform,

	  [FriendlyName("InstanceID", "The unique id of the newly cloned GameObject. Returns '0' if Target was null.")]
	  [SocketState(false, false)]
	  out int InstanceID


      )
   {
      
      if ( null != Target )
		{
			 GameObject go = ScriptableObject.Instantiate(Target, Target.transform.position, Target.transform.rotation) as GameObject; //CloneTransform.gameObject;

			if (!DoNotRename)
			{
				Clone = go;
				CloneTransform = Clone.transform;
			}
			else
			{
				go.name = Target.name;
				Clone = go;
				CloneTransform = Clone.transform;
			}

			InstanceID = go.GetInstanceID();
			m_FinishedCloning = true;

		}
      else
		{
			Clone = null;
			CloneTransform = null;
			InstanceID = 0;
		}
   }

	public void Update()
	{
		if (m_FinishedCloning)
		{
			m_FinishedCloning = false;
			if ( FinishedCloning != null ) FinishedCloning(this, new System.EventArgs());
		}
	}
}
