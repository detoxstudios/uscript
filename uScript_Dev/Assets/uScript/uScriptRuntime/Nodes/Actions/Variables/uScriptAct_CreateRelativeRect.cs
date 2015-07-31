// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Rect")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Creates a new Rect within an existing target Rect.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Create Relative Rect", "Creates a new Rect within an existing target Rect. Useful for quickly laying out GUI elements based on another Rect.")]
public class uScriptAct_CreateRelativeRect : uScriptLogic
{
   public enum Position { TopLeft, TopCenter, TopRight, MiddleLeft, MiddleCenter, MiddleRight, BottomLeft, BottomCenter, BottomRight }

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The target Rect variable to base the new Rect off of.")]
      Rect Target,

      [FriendlyName("Width", "The width of the Rect in pixels you wish to make. Can not be less than 2 (will be automatically set to 2 if you specify a value less than 2).")]
      [DefaultValue(32)]
      int RectWidth,
      
      [FriendlyName("Height", "The height of the Rect in pixels you wish to make. Can not be less than 2 (will be automatically set to 2 if you specify a value less than 2).")]
      [DefaultValue(32)]
      int RectHeight,
      
      [FriendlyName("Position", "The position within the Target Rect you wish to locate the new Rect.")]
      [SocketState(false, false), DefaultValue(0)]
      Position RectPosition,
      
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
      // Get the target Rect size
      int TargetWidth = System.Convert.ToInt32(Target.width);
      int TargetHeight = System.Convert.ToInt32(Target.height);

      // Set min/max values
      if (RectWidth < 2) { RectWidth = 2; }
      if (RectHeight < 2) { RectHeight = 2; }

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
			RectLeft = ((TargetWidth / 2) - (RectWidth / 2)) + xOffset;
			RectTop = (0 + yOffset);
		}
		else if(RectPosition == Position.TopRight)
		{
			RectLeft = TargetWidth - (RectWidth - xOffset);
			RectTop = (0 + yOffset);
		}
		else if(RectPosition == Position.MiddleLeft)
		{
			RectLeft = (0 + xOffset);
			RectTop = ((TargetHeight / 2) - (RectHeight / 2)) + yOffset;
		}
		else if(RectPosition == Position.MiddleCenter)
		{
         RectLeft = ((TargetWidth / 2) - (RectWidth / 2)) + xOffset;
         RectTop = ((TargetHeight / 2) - (RectHeight / 2)) + yOffset;
		}
		else if(RectPosition == Position.MiddleRight)
		{
			RectLeft = TargetWidth - (RectWidth - xOffset);
			RectTop = ((TargetHeight / 2) - (RectHeight / 2)) + yOffset;
		}
		else if(RectPosition == Position.BottomLeft)
		{
			RectLeft = (0 + xOffset);
			RectTop = TargetHeight - (RectHeight - yOffset);
		}
		else if(RectPosition == Position.BottomCenter)
		{
			RectLeft = ((TargetWidth / 2) - (RectWidth / 2)) + xOffset;
			RectTop = TargetHeight - (RectHeight - yOffset);
		}
		else if(RectPosition == Position.BottomRight)
		{
			RectLeft = TargetWidth - (RectWidth - xOffset);
			RectTop = TargetHeight - (RectHeight - yOffset);
		}
		else
		{
         // Do center
         RectLeft = ((TargetWidth / 2) - (RectWidth / 2)) + xOffset;
         RectTop = ((TargetHeight / 2) - (RectHeight / 2)) + yOffset;
		}
		
		RectLeft = RectLeft + System.Convert.ToInt32(Target.x);
		RectTop = RectTop + System.Convert.ToInt32(Target.y);
		
      // Output final Rect
      Rect finalRect = new Rect(RectLeft, RectTop, RectWidth, RectHeight);
      OutputRect = finalRect;
   }
}
