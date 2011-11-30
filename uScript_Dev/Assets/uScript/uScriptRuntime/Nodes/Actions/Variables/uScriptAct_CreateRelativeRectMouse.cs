// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Creates a Rect based off the current mouse cursor position.")]
[NodeDescription("Creates a Rect based off the current mouse cursor position. Useful for attaching GUI elements to the mouse.\n\nWidth: The width of the Rect in pixels you wish to make. Can not be less than 2 (will be automatically set to 2 if you specify a value less than 2).\nHeight (in): The height of the Rect in pixels you wish to make. Can not be less than 2 (will be automatically set to 2 if you specify a value less than 2).\nX Offset: An optional X (horizontal) offset in pixels you wish to use for the new Rect.\nY Offset: An optional Y (vertical) offset in pixels you wish to use for the new Rect.\nOutput Rect (out): The new Rect.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Create Relative Rect (Mouse)")]
public class uScriptAct_CreateRelativeRectMouse : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Width"), DefaultValue(32)] int RectWidth,
      [FriendlyName("Height"), DefaultValue(32)] int RectHeight,
	  [FriendlyName("X Offset"), SocketState(false, false), DefaultValue(0)] int xOffset,
	  [FriendlyName("Y Offset"), SocketState(false, false), DefaultValue(0)] int yOffset,
      [FriendlyName("Output Rect")] out Rect OutputRect
      )
   {

      // Get the mouse cursor position
	  Vector3 tmpPosition = Input.mousePosition;
	  float XPos = tmpPosition.x + xOffset;
	  // Y needs to be inverted
	  float YPos = (Screen.height - tmpPosition.y) + yOffset;

      // Set min/max values
      if (RectWidth < 2) { RectWidth = 2; }
      if (RectHeight < 2) { RectHeight = 2; }
		
	  // Output final Rect
      Rect finalRect = new Rect(XPos, YPos, RectWidth, RectHeight);
      OutputRect = finalRect;

   }
}