// uScript Action Node

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the Root GameObject of a hierarchy of GameObjects.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Root", "Returns the Root GameObject of a hierarchy of GameObjects.")]
public class uScriptAct_GetRoot : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In (
      [FriendlyName("Target", "The child GameObject.")]
      GameObject Target,
      
      [FriendlyName("Root", "The Root GameObject of Target.")]
      out GameObject objRoot
      )
   {
      
      if ( null != Target.transform.root )
      {
         objRoot = Target.transform.root.gameObject;
      }
      else
      {
         uScriptDebug.Log ("(Node - Get Root): The specified Target GameObject does not have a root (was null).", uScriptDebug.Type.Warning);
         objRoot = null;
      }
   }
}
