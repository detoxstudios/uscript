// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the current size informaiton for the screen.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Screen")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the position of the mouse.")]
[NodeDescription("Gets the position of the mouse.\n\nInvert Y: Flips the Y value, effectivly making the top left corner of the screen be (0,0) instead of the bottom left corner.\nPosition (out): Returns the position of the mouse as a Vector2.\nX Position (out): Returns just the X position of the mouse as a float.\nY Position (out): Returns just the Y position of the mouse as a float.\nPosition (Vector 3) (out): Returns the position of the mouse as a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Mouse_Position")]

[FriendlyName("Get Mouse Position")]
public class uScriptAct_GetMousePosition : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Invert Y"), DefaultValue(true), SocketState(false, false)] bool InvertY,
	  [FriendlyName("Position")] out Vector2 positionV2,
	  [FriendlyName("X Position")] out float XPosition,
	  [FriendlyName("Y Position")] out float YPosition,
	  [FriendlyName("Position (Vector 3)"), SocketState(false, false)] out Vector3 position
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