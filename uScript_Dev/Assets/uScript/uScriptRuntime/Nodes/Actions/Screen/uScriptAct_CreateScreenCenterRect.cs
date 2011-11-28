// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Creates a Rect in the center of the screen based on screen size information.

using UnityEngine;
using System.Collections;

[NodeDeprecated(typeof(uScriptAct_CreateRelativeRectScreen))]

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Creates a Rect in the center of the screen based on screen size information.")]
/* D */[NodeDescription("Creates a Rect in the center of the screen based on screen size information.\n\nRect Width (in): The width of the Rect in pixels you wish to make. Can not be less than 2 or greater than the screen width (will be automatically capped if you specify a value outside this range).\nRect Height (in): The height of the Rect in pixels you wish to make. Can not be less than 2 or greater than the screen height (will be automatically capped if you specify a value outside this range).\nOutput Rect (out): The new Rect.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Create Screen Center Rect")]
public class uScriptAct_CreateScreenCenterRect : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Rect Width"), DefaultValue(32)] int RectWidth,
      [FriendlyName("Rect Height"), DefaultValue(32)] int RectHeight,
      [FriendlyName("Output Rect")] out Rect OutputRect
      )
   {

      // Get the screen size
      int ScreenWidth = Screen.width;
      int ScreenHeight = Screen.height;

      // Set min/max values
      if (RectWidth < 2) { RectWidth = 2; }
      if (RectWidth > ScreenWidth) { RectWidth = ScreenWidth; }
      if (RectHeight < 2) { RectHeight = 2; }
      if (RectHeight > ScreenHeight) { RectHeight = ScreenHeight; }

      int RectLeft = 0;
      int RectTop = 0;

      // Find Center Left and Top
      RectLeft = ((Screen.width / 2) - (RectWidth / 2));
      RectTop = ((Screen.height / 2) - (RectHeight / 2));

      Rect finalRect = new Rect(RectLeft, RectTop, RectWidth, RectHeight);
      OutputRect = finalRect;

   }
}