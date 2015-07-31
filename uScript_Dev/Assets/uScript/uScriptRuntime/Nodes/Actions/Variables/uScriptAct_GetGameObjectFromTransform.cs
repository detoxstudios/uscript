// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Transform")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Gets the GameObject of a Transform variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get GameObject From Transform", "Gets the GameObject of a Transform variable.")]
public class uScriptAct_GetGameObjectFromTransform : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
                  [FriendlyName("Input Transform", "The Transform you wish to get the GameObject of.")]
                  Transform InputTransform,

                  [FriendlyName("GameObject", "The GameObject of the Transform.")]
                  out GameObject transGameObject
                  )
   {

      transGameObject = InputTransform.gameObject;
   }
}
