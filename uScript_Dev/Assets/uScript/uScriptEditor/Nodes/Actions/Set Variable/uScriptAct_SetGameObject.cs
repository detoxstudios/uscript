// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets the value of a GameObject variable using the value of another GameOject variable.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the value of a GameObject variable using the value of another GameOject variable.")]
[NodeDescription("Sets the value of a GameObject variable using the value of another GameOject variable.\n \nValue: The GameObject variable to be set.\nTarget GameObject (out): The value that has been set for this variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Set GameObject")]
public class uScriptAct_SetGameObject : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(GameObject Value, [FriendlyName("Target GameObject")] out GameObject TargetGameObject)
   {
      // @TODO: I'm worried this won't assign the correct object.
      // uScript might need to be using InstanceIDs instead of by the name?

      TargetGameObject = Value;
   }

}