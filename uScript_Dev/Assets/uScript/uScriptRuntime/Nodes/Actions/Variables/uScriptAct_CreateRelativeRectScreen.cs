// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Creates a Rect based off the current screen resolution.")]
[NodeDescription("Creates a Rect based off the current screen resolution. Useful for quickly laying out GUI elements based on the screen.\n\nWidth: The width of the Rect in pixels you wish to make. Can not be less than 2 or greater than the screen width (will be automatically capped if you specify a value outside this range).\nHeight (in): The height of the Rect in pixels you wish to make. Can not be less than 2 or greater than the screen height (will be automatically capped if you specify a value outside this range).\nPosition: The position on the screen you wish to locate the new Rect.\nX Offset: An optional X (horizontal) offset in pixels you wish to use for the new Rect.\nY Offset: An optional Y (vertical) offset in pixels you wish to use for the new Rect.\nOutput Rect (out): The new Rect.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Create Relative Rect (Screen)")]
public class uScriptAct_CreateRelativeRectScreen : uScriptLogic
{
   public enum Position { TopLeft, TopCenter, TopRight, MiddleLeft, MiddleCenter, MiddleRight, BottomLeft, BottomCenter, BottomRight }

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Width"), DefaultValue(32)] int RectWidth,
      [FriendlyName("Height"), DefaultValue(32)] int RectHeight,
	  [FriendlyName("Position"), SocketState(false, false), DefaultValue(0)] Position RectPosition,
	  [FriendlyName("X Offset"), SocketState(false, false), DefaultValue(0)] int xOffset,
	  [FriendlyName("Y Offset"), SocketState(false, false), DefaultValue(0)] int yOffset,
      [FriendlyName("Output Rect")] out Rect OutputRect
      )
   {

      // Get the screen size
      int ScreenWidth = Screen.width;
      int ScreenHeight = Screen.height;

      // Set min/max values
      if (RectWidth < 2) { RectWidth = 2; }
      if (RectWidth + xOffset > ScreenWidth) { RectWidth = ScreenWidth; }
      if (RectHeight < 2) { RectHeight = 2; }
      if (RectHeight + yOffset > ScreenHeight) { RectHeight = ScreenHeight; }

      int RectLeft = 0;
      int RectTop = 0;
		
	  // Generate Top/Left position
	  if(RectPosition == Position.TopLeft)
		{
			RectLeft = (0 + xOffset);
			
			RectTop = (0 + yOffset);
		}
		else if(RectPosition == Position.TopCenter)
		{
			RectLeft = ((Screen.width / 2) - (RectWidth / 2)) + xOffset;
			
			RectTop = (0 + yOffset);
		}
		else if(RectPosition == Position.TopRight)
		{
			RectLeft = Screen.width - (RectWidth - xOffset);
			
			RectTop = (0 + yOffset);
		}
		else if(RectPosition == Position.MiddleLeft)
		{
			RectLeft = (0 + xOffset);
			
			RectTop = ((Screen.height / 2) - (RectHeight / 2)) + yOffset;
		}
		else if(RectPosition == Position.MiddleCenter)
		{
      		RectLeft = ((Screen.width / 2) - (RectWidth / 2)) + xOffset;
			
      		RectTop = ((Screen.height / 2) - (RectHeight / 2)) + yOffset;
		}
		else if(RectPosition == Position.MiddleRight)
		{
			RectLeft = Screen.width - (RectWidth - xOffset);
			
			RectTop = ((Screen.height / 2) - (RectHeight / 2)) + yOffset;
		}
		else if(RectPosition == Position.BottomLeft)
		{
			RectLeft = (0 + xOffset);
			
			RectTop = Screen.height - (RectHeight - yOffset);
		}
		else if(RectPosition == Position.BottomCenter)
		{
			RectLeft = ((Screen.width / 2) - (RectWidth / 2)) + xOffset;
			
			RectTop = Screen.height - (RectHeight - yOffset);
		}
		else if(RectPosition == Position.BottomRight)
		{
			RectLeft = Screen.width - (RectWidth - xOffset);
			
			RectTop = Screen.height - (RectHeight - yOffset);
		}
		else
		{
			// Do center
			RectLeft = ((Screen.width / 2) - (RectWidth / 2)) + xOffset;
			
      		RectTop = ((Screen.height / 2) - (RectHeight / 2)) + yOffset;
		}
		
	  // Output final Rect
      Rect finalRect = new Rect(RectLeft, RectTop, RectWidth, RectHeight);
      OutputRect = finalRect;

   }
}