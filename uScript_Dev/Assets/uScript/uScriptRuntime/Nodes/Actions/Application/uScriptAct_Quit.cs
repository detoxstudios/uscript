// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Quit the application on supported devices.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Application")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Quit the application on supported devices.")]
[NodeDescription("Quit the application on supported devices. This has no effect in the editor or web player.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Log")]

[FriendlyName("Quit")]
public class uScriptAct_Quit : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In()
   {
      Application.Quit();
   }
}