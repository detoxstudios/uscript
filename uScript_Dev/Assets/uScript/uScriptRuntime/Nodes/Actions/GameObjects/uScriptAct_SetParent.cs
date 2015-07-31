// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the parent of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Parent", "Sets the parent of a GameObject.")]
public class uScriptAct_SetParent : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In (
      [FriendlyName("Target", "The GameObject you wish to be the child."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Parent", "The GameObject you wish to set as the Target's parent.")]
      GameObject Parent
      )
   {
      
      foreach(GameObject tmpTarget in Target)
	  {
	     if (null != tmpTarget)
		 {
		    if (null != Parent)
			{
			   tmpTarget.transform.parent = Parent.transform;
			}
			else
			{
			   tmpTarget.transform.parent = null;
			}
		    
		 }
	  }

   }
}
