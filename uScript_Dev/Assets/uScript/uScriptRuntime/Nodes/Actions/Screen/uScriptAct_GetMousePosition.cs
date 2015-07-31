// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the position of the mouse.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Mouse Position", "Gets the position of the mouse.")]
public class uScriptAct_GetMousePosition : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Invert Y", "Flips the Y value, effectivly making the top left corner of the screen be (0,0) instead of the bottom left corner.")]
      [DefaultValue(true), SocketState(false, false)]
      bool InvertY,
      
      [FriendlyName("Position", "Returns the position of the mouse as a Vector2.")]
      out Vector2 positionV2,
      
      [FriendlyName("X Position", "Returns just the X position of the mouse as a float.")]
      out float XPosition,
      
      [FriendlyName("Y Position", "Returns just the Y position of the mouse as a float.")]
      out float YPosition,
      
      [FriendlyName("Position (Vector 3)", "Returns the position of the mouse as a Vector3.")]
      [SocketState(false, false)]
      out Vector3 position
      )
   {
		Vector3 tmpPosition = Input.mousePosition;
		float XPos = tmpPosition.x;
		float YPos;
		
		if (InvertY)
		{
			
		    YPos = Screen.height - tmpPosition.y;
			positionV2 = new Vector2(XPos, YPos);
		    position = new Vector3(XPos, YPos, tmpPosition.z);
			YPosition = YPos;
			XPosition = XPos;
		}
		else
		{
		    YPos = tmpPosition.y;
			positionV2 = new Vector2(XPos, YPos);
		    position = tmpPosition;
			YPosition = YPos;
			XPosition = XPos;
		}
		
		
   }
}