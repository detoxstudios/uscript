// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns all the children GameObjects of a parent GameObject.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the parent of a GameObject.")]
[NodeDescription("Returns the parent of a GameObject.\nTarget (In): The child GameObject.\nParent (out): The parent GameObject of Target.\n")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_All_Children")]

[FriendlyName("Get Parent")]
public class uScriptAct_GetParent : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In (
                   [FriendlyName("Target")] GameObject Target,
                   [FriendlyName("Parent")] out GameObject Parent)
   {
      
      if ( null != Target.transform.parent )
      {
         Parent = Target.transform.parent.gameObject;
      }
      else
      {
         uScriptDebug.Log ("(Node - Get Parent): The specified Target GameObject does not have a parent (was null).", uScriptDebug.Type.Warning);
         Parent = null;
      }
   }
}
