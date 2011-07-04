// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the rotation in degrees (float) of a GameObject in local or world coordinates. Optionally can set rotation as offest from the target's current rotation.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the rotation in degrees (float) of a GameObject in local or world coordinates.")]
[NodeDescription("Sets the rotation in degrees (float) of a GameObject in local or world coordinates. Optionally can set rotation as offest from the target's current rotation.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Position")]

[FriendlyName("Set Rotation")]
public class uScriptAct_SetGameObjectRotation : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
	               GameObject[] Target,
	               [FriendlyName("X Degrees")] float XDegrees,
	               [FriendlyName("Y Degrees")] float YDegrees,
	               [FriendlyName("Z Degrees")] float ZDegrees,
	               [FriendlyName("Ignore X"), SocketState(false, false)]bool IgnoreX,
	               [FriendlyName("Ignore Y"), SocketState(false, false)]bool IgnoreY,
	               [FriendlyName("Ignore Z"), SocketState(false, false)] bool IgnoreZ,
	               [FriendlyName("Space"), SocketState(false, false)] UnityEngine.Space CoordinateSystem,
	               [FriendlyName("As Offset"), SocketState(false, false)] bool AsOffset
	               )
   {
		

		
		foreach (GameObject currentTarget in Target)
		{
			
			
			if (AsOffset)
			{
				// Added the anlges to the existing rotation of the GameObject.
				if (CoordinateSystem == Space.World)
				{
					if (!IgnoreX)
					{
					}
					if (!IgnoreY)
					{
					}
					if (!IgnoreZ)
					{
					}

				}
				else
				{
					if (!IgnoreX)
					{
					}
					if (!IgnoreY)
					{
					}
					if (!IgnoreZ)
					{
					}

				}
				
			}
			else
			{
				// Overrite the GameObjects rotation angles with the new ones
				if (CoordinateSystem == Space.World)
				{
					if (!IgnoreX)
					{
					}
					if (!IgnoreY)
					{
					}
					if (!IgnoreZ)
					{
					}

				}
				else
				{
					if (!IgnoreX)
					{
					}
					if (!IgnoreY)
					{
					}
					if (!IgnoreZ)
					{
					}

				}
				
			}
			
		}
		
		
		// Take the final information and update the currentTarget's rotation.
		

   }
}
