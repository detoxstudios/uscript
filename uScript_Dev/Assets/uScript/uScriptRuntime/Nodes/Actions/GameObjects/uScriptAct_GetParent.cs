// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the parent of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Parent", "Returns the parent of a GameObject.")]
public class uScriptAct_GetParent : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In (
      [FriendlyName("Target", "The child GameObject.")]
      GameObject Target,
      
      [FriendlyName("Parent", "The parent GameObject of Target.")]
      out GameObject Parent
      )
   {
      
      if ( null != Target.transform.parent )
         Parent = Target.transform.parent.gameObject;
      else
         Parent = null;
   }
}
