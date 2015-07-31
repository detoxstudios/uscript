// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Transform")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Gets the topmost Transform in the hierarchy.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Root Transform", "Gets the topmost Transform in the hierarchy. If the target Transform is the root transofrm, it will return itself.")]
public class uScriptAct_GetRootTransform : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
                  [FriendlyName("Target", "The Transform you wish to get the rotation information of.")]
                  Transform target,

                  [FriendlyName("Root", "The root Transform of the target Transform.")]
                  out Transform rootTransform,

                  [FriendlyName("Root GameObject", "The root GameObject of the target Transform.")]
                  [SocketStateAttribute(false, false)]
                  out GameObject rootGameObject
                  )
   {

      rootTransform = target.root;
      rootGameObject = target.root.gameObject;

   }
}
