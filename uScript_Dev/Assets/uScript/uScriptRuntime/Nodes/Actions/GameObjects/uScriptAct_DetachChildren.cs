// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Detaches all children GameObjects from the target parent GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Detach Children", "Detaches all children GameObjects from the target parent GameObject.")]
public class uScriptAct_DetachChildren : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In (
      [FriendlyName("Target", "The target GameObject.")]
      GameObject[] Target
      )
   {
      
      foreach(GameObject tmpTarget in Target)
	  {
	     if (null != tmpTarget)
		 {
			   tmpTarget.transform.DetachChildren();
		 }
	  }

   }
}
