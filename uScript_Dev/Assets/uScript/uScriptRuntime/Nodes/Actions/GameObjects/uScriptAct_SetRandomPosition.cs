// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the world position of a GameObject based around an origin point in the world.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the world position of a GameObject based around an origin point in the world.")]
[NodeDescription("Randomly sets the world position of a GameObject based around an origin point in the world.\n \nTarget: The GameObject(s) that the random position is applied to.\nOrigin: The starting location for the random position offset.\nMin(X/Y/Z): Minimum allowable float value.\nMax(X/Y/Z): Maximum allowable float value.\n\nPreserve(Z/Y/Z): If checked, the existing value will be passed into the new position, overriding the random value for that axis. Also not that preserving an axis will also override that axis for the specified Origin.\nAs Offset: This will use the target GameObject's current position as the origin point (Origin is not used when this property is checked).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Random Position")]
public class uScriptAct_SetRandomPosition : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
	  [FriendlyName("Target")] GameObject[] Target,
	  [FriendlyName("Origin")] Vector3 Origin,             
      [FriendlyName("Min X"), DefaultValue(-10f), SocketState(false, false)] float MinX,
      [FriendlyName("Max X"), DefaultValue(10f), SocketState(false, false)] float MaxX,
      [FriendlyName("Min Y"), DefaultValue(-10f), SocketState(false, false)] float MinY,
      [FriendlyName("Max Y"), DefaultValue(10f), SocketState(false, false)] float MaxY,
      [FriendlyName("Min Z"), DefaultValue(-10f), SocketState(false, false)] float MinZ,
      [FriendlyName("Max Z"), DefaultValue(10f), SocketState(false, false)] float MaxZ,
	  [FriendlyName("Preserve X"), SocketState(false, false)] bool PreserveX_Axis, 
      [FriendlyName("Preserve Y"), SocketState(false, false)] bool PreserveY_Axis,
      [FriendlyName("Preserve Z"), SocketState(false, false)] bool PreserveZ_Axis,
	  [FriendlyName("As Offset"), DefaultValue(false), SocketState(false, false)] bool AsOffset
	  )
   {
      // Make sure we don't have min > max (or other way around)
      if (MinX > MaxX) { MinX = MaxX; }
      if (MaxX < MinX) { MaxX = MinX; }
      if (MinY > MaxY) { MinY = MaxY; }
      if (MaxY < MinY) { MaxY = MinY; }
      if (MinZ > MaxZ) { MinZ = MaxZ; }
      if (MaxZ < MinZ) { MaxZ = MinZ; }
		
	  foreach ( GameObject currentTarget in Target )
      {
			float finalX;
			float finalY;
			float finalZ;
					
         if ( currentTarget != null )
         {
			if (PreserveX_Axis)
			{
				finalX = currentTarget.transform.position.x;
			}
			else
			{
			   finalX = Random.Range(MinX, MaxX);
			}
				
			if (PreserveY_Axis)
			{
				finalY = currentTarget.transform.position.y;
			}
			else
			{
			   finalY = Random.Range(MinY, MaxY);
			}
				
			if (PreserveZ_Axis)
			{
				finalZ = currentTarget.transform.position.z;
			}
			else
			{
			   finalZ = Random.Range(MinZ, MaxZ);
			}

	        Vector3 randomPosition = new Vector3(finalX, finalY, finalZ);
           Vector3 origin = Vector3.zero;

				if (AsOffset)
				{
					origin = currentTarget.transform.position;
				}
				
            currentTarget.transform.position = origin + randomPosition;
         }
      }
		
   }
}