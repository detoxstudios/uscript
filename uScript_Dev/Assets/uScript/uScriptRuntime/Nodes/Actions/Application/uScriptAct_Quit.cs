// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Quit the application on supported devices.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Quit", "Quit the application on supported devices. This has no effect in the editor or web player.")]
public class uScriptAct_Quit : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In()
   {
      Application.Quit();
   }
}
