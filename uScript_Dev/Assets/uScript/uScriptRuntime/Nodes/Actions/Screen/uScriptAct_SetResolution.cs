// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Switches the screen resolution.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Resolution", "Switches the screen resolution using Width and Height.  If no matching resolution is supported, the nearest will be used." +
 "\n\nIn the web player you may only switch resolutions after the user has clicked on the content. The recommended way of doing it is to switch resolutions only when the user clicks on a designated button." +
 "\n\nA resolution switch does not happen immediately; it will actually happen when the current frame is finished.")]
public class uScriptAct_SetResolution : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Width", "The desired width in pixels.")]
      int Width,

      [FriendlyName("Height", "The desired height in pixels.")]
      int Height,

      [FriendlyName("Fullscreen", "If True, fullscreen-mode will be enabled, otherwise windowed-mode will be used.")]
      [SocketState(false, false)]
      bool Fullscreen,

      [FriendlyName("Preferred Refresh Rate", "If set to a non-zero value, Unity will use it if the monitor supports it, otherwise will choose the highest supported refresh rate.")]
      [SocketState(false, false)]
      int PreferredRefreshRate
      )
   {
      Screen.SetResolution(Width, Height, Fullscreen, PreferredRefreshRate);
   }
}
