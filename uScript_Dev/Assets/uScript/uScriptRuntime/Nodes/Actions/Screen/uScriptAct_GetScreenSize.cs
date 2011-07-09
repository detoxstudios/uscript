// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current size informaiton for the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current size informaiton for the screen.")]
[NodeDescription("Gets the current size informaiton for the screen.\n\nWidth (Out): Returns the width of the screen size in pixels.\nHeight (Out): Returns the height of the screen size in pixels.\nScreen Rect (Out): Returns the screen size as a Rect variable.\nScreen Center (Out): The center of the screen as a Vector2.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Screen Size")]
public class uScriptAct_GetScreenSize : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Width")] out int ScreenWidth,
      [FriendlyName("Height")] out int ScreenHeight,
      [FriendlyName("Screen Rect"), SocketState(false, false)] out Rect ScreenRect,
      [FriendlyName("Screen Center"), SocketState(false, false)] out Vector2 ScreenCenter
      )
   {
      Rect scrnSize = new Rect(0, 0, (float)Screen.width, (float)Screen.height);
      Vector2 scrnCenter = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);

      ScreenWidth = Screen.width;
      ScreenHeight = Screen.height;
      ScreenRect = scrnSize;
      ScreenCenter = scrnCenter;
      
   }
}