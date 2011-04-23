// uScript Example Action Node
// (C) 2011 Detox Studios LLC
// Desc: Template simple example node. It does nothing of value.

using UnityEngine;
using System.Collections;

// This section uses Attributes to tell uScript information it can us in the UI and other ways.
[NodePath("Action/YourFolder")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Template simple example node. It does nothing of value.")]
[NodeDescription("Template simple example node. It does nothing of value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net")]

[FriendlyName("Simple Example Node")]
public class uScriptAct_SimpleExampleNode : uScriptLogic
{

   // Without a friendly name, uScript will just use the method name-- 'Out' in this case. Uncomment the next line to use the Friendly Name attribute for this out socket.
   // [FriendlyName("Out")]
   public bool Out { get { return true; } }


   // This node has two variabel sockets (the ones on the bottom of a node). These are not required. You can have a node with
   // no variable sockets, one or more of either in or out variabel sockets, or one with any combination of both in and out variable sockets.
   [FriendlyName("In")]
   public void In([FriendlyName("String Input")] string StringInput, [FriendlyName("Vector3 Output")] out Vector3 Vector3Output)
   {

      // Do your node logic here.
      Vector3Output = new Vector3(0, 0, 0);

   }


}


