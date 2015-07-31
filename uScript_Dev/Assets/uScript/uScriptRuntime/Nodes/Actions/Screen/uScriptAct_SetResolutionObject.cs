// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Switches the screen resolution.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Resolution Object", "Switches the screen resolution using Width and Height.  If no matching resolution is supported, the nearest will be used." +
 "\n\nIn the web player you may only switch resolutions after the user has clicked on the content. The recommended way of doing it is to switch resolutions only when the user clicks on a designated button." +
 "\n\nA resolution switch does not happen immediately; it will actually happen when the current frame is finished.")]
public class uScriptAct_SetResolutionObject : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Resolution", "The desired resolution.")]
      Resolution resolution,

      [FriendlyName("Fullscreen", "If True, fullscreen-mode will be enabled, otherwise windowed-mode will be used.")]
      [SocketState(false, false)]
      bool Fullscreen
      )
   {
      Screen.SetResolution(resolution.width, resolution.height, Fullscreen, resolution.refreshRate);
   }
}
