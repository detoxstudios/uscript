// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Creates a Rect based off the current mouse cursor position.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Create Relative Rect (Mouse)", "Creates a Rect based off the current mouse cursor position. Useful for attaching GUI elements to the mouse.")]
public class uScriptAct_CreateRelativeRectMouse : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Width", "The width of the Rect in pixels you wish to make. Can not be less than 2 (will be automatically set to 2 if you specify a value less than 2).")]
      [DefaultValue(32)]
      int RectWidth,

      [FriendlyName("Height", "The height of the Rect in pixels you wish to make. Can not be less than 2 (will be automatically set to 2 if you specify a value less than 2).")]
      [DefaultValue(32)]
      int RectHeight,

      [FriendlyName("X Offset", "An optional X (horizontal) offset in pixels you wish to use for the new Rect.")]
      [SocketState(false, false), DefaultValue(0)]
      int xOffset,

      [FriendlyName("Y Offset", "An optional Y (vertical) offset in pixels you wish to use for the new Rect.")]
      [SocketState(false, false), DefaultValue(0)]
      int yOffset,

      [FriendlyName("Output Rect", "The new Rect.")]
      out Rect OutputRect
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
