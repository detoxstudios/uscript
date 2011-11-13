// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Sets the scale of a GameObject.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the scale of a GameObject.")]
[NodeDescription("Randomly sets the scale of a GameObject.\n \nTarget: The GameObject(s) that the random scale is applied to.\nMin(X/Y/Z): Minimum allowable float value.\nMax(X/Y/Z): Maximum allowable float value.\n\nPreserve(X/Y/Z): If checked, the existing value will be passed into the new scale, overriding the random value for that axis.\nUniform: Should the node scale the GameObject uniformly on all three axis. When set to true, only the Min and Max for X is used to determine the random scale range. Also, the Preserve(X/Y/Z) flags are ignored.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Random Scale")]
public class uScriptAct_SetRandomScale : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
	  [FriendlyName("Target")] GameObject[] Target,
      [FriendlyName("Min X"), DefaultValue(0.5f), SocketState(false, false)] float MinX,
      [FriendlyName("Max X"), DefaultValue(2f), SocketState(false, false)] float MaxX,
      [FriendlyName("Min Y"), DefaultValue(0.5f), SocketState(false, false)] float MinY,
      [FriendlyName("Max Y"), DefaultValue(2f), SocketState(false, false)] float MaxY,
      [FriendlyName("Min Z"), DefaultValue(0.5f), SocketState(false, false)] float MinZ,
      [FriendlyName("Max Z"), DefaultValue(2f), SocketState(false, false)] float MaxZ,
	  [FriendlyName("Preserve X"), SocketState(false, false)] bool PreserveX_Axis, 
      [FriendlyName("Preserve Y"), SocketState(false, false)] bool PreserveY_Axis,
      [FriendlyName("Preserve Z"), SocketState(false, false)] bool PreserveZ_Axis,
	  [FriendlyName("Uniform"), DefaultValue(true)] bool Uniform         
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
			
		 if (Uniform)
		 {
				PreserveX_Axis = false;
				PreserveY_Axis = false;
				PreserveZ_Axis = false;
		 }
			
         if ( currentTarget != null )
         {
			if (PreserveX_Axis)
			{
			   finalX = currentTarget.transform.localScale.x;
			}
			else
			{
			   finalX = Random.Range(MinX, MaxX);
			}
				
			if (PreserveY_Axis)
			{
			   finalY = currentTarget.transform.localScale.y;
			}
			else
			{
			   finalY = Random.Range(MinY, MaxY);
			}
		    
			if (PreserveZ_Axis)
			{
			   finalZ = currentTarget.transform.localScale.z;
			}
			else
			{
			   finalZ = Random.Range(MinZ, MaxZ);
			}
		
	        Vector3 finalScale;
	        if (Uniform)
	        {
			   finalScale = new Vector3(finalX, finalX, finalX);
	        }
	        else
            {
			finalScale = new Vector3(finalX, finalY, finalZ);
	        }
				
            currentTarget.transform.localScale = finalScale;
         }
      }
		
   }
}