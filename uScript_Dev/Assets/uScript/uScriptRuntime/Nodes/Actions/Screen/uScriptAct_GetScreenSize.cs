// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current size informaiton for the screen.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Screen Size", "Gets the current size informaiton for the screen.")]
public class uScriptAct_GetScreenSize : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Width", "Returns the width of the screen size in pixels as an integer.")]
      out int ScreenWidth,
      
      [FriendlyName("Height", "Returns the height of the screen size in pixels as an integer.")]
      out int ScreenHeight,
      
      [FriendlyName("Float Width", "Returns the width of the screen size in pixels as a float.")]
      out float fScreenWidth,
      
      [FriendlyName("Float Height", "Returns the height of the screen size in pixels as a float.")]
      out float fScreenHeight,
      
      [FriendlyName("Screen Rect", "Returns the screen size as a Rect variable.")]
      [SocketState(false, false)]
      out Rect ScreenRect,
      
      [FriendlyName("Screen Center", "The center of the screen as a Vector2.")]
      [SocketState(false, false)]
      out Vector2 ScreenCenter
      )
   {
      Rect scrnSize = new Rect(0, 0, (float)Screen.width, (float)Screen.height);
      Vector2 scrnCenter = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);

      ScreenWidth = Screen.width;
      ScreenHeight = Screen.height;
      fScreenWidth = (float)Screen.width;
      fScreenHeight = (float)Screen.height;
      ScreenRect = scrnSize;
      ScreenCenter = scrnCenter;
      
   }
}