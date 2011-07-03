// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current size informaiton for the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current size informaiton for the screen.")]
[NodeDescription("Gets the current size informaiton for the screen.\n\n\tRect Center Width (In): Used to define a rect width size (in pixels) at the center of the screen. Will auto-cap to a minimum size of 2 and the maximum size of the screen width.\n\tRect Center Width (In): Used to define a rect height size (in pixels) at the center of the screen. Will auto-cap to a minimum size of 2 and the maximum size of the screen height.\n\tWidth (Out): The width of the screen size in pixels.\n\tHeight (Out): The height of the screen size in pixels.\n\tScreen Size (Out): The screen size as a Rect variable.\n\tScreen Center (Out): The center of the screen as a Vector2.\n\tRect Center (Out): A Rect variable with values that position it at the center of the screen. The width and height of the Rect variable are determined by the Rect Center Size inputs.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Get Screen Size")]
public class uScriptAct_GetScreenSize : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Rect Center Width"), SocketState(false, false), DefaultValue(32)] int RectCenterPixelWidthSize,
      [FriendlyName("Rect Center Height"), SocketState(false, false), DefaultValue(32)] int RectCenterPixelHeightSize,
      [FriendlyName("Width")] out int ScreenWidth,
      [FriendlyName("Height")] out int ScreenHeight,
      [FriendlyName("Screen Size")] out Rect ScreenSize,
      [FriendlyName("Screen Center"), SocketState(false, false)] out Vector2 ScreenCenter,
      [FriendlyName("Rect Center"), SocketState(false, false)] out Rect RectCenter
      )
   {
      int scrnWidth = Screen.width;
      int scrnHeight = Screen.height;
      float scrnWidthFloat = (float)scrnWidth;
      float scrnHeightFloat = (float)scrnHeight;
      Rect scrnSize = new Rect(0, 0, scrnWidthFloat, scrnHeightFloat);
      Vector2 scrnCenter = new Vector2(scrnWidthFloat / 2f, scrnHeightFloat / 2f);

      // Setup RectCenter Values
      if (RectCenterPixelWidthSize < 2) { RectCenterPixelWidthSize = 2; }
      if (RectCenterPixelWidthSize > scrnWidth) { RectCenterPixelWidthSize = scrnWidth; }
      if (RectCenterPixelHeightSize < 2) { RectCenterPixelHeightSize = 2; }
      if (RectCenterPixelHeightSize > scrnWidth) { RectCenterPixelHeightSize = scrnWidth; }

      float widthHalfSizeOffset = (float)RectCenterPixelWidthSize / 2f;
      float heightHalfSizeOffset = (float)RectCenterPixelHeightSize / 2f;
      float rectLeft = scrnCenter.x - widthHalfSizeOffset;
      float rectTop = scrnCenter.y - heightHalfSizeOffset;
      float rectWidth = (float)RectCenterPixelWidthSize;
      float rectHeight = (float)RectCenterPixelHeightSize;
      Rect finalRectCenter = new Rect(rectLeft, rectTop, rectWidth, rectHeight);

      ScreenWidth = scrnWidth;
      ScreenHeight = scrnHeight;
      ScreenSize = scrnSize;
      ScreenCenter = scrnCenter;
      RectCenter = finalRectCenter;
      
   }
}