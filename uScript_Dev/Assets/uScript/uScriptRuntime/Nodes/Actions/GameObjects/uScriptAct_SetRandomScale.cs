// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets the scale of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random Scale", "Randomly sets the scale of a GameObject.")]
public class uScriptAct_SetRandomScale : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The GameObject(s) that the random scale is applied to."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,
      
      [FriendlyName("Min X", "Minimum allowable float value.")]
      [DefaultValue(0.5f), SocketState(false, false)]
      float MinX,
      
      [FriendlyName("Max X", "Maximum allowable float value.")]
      [DefaultValue(2f), SocketState(false, false)]
      float MaxX,
      
      [FriendlyName("Min Y", "Minimum allowable float value.")]
      [DefaultValue(0.5f), SocketState(false, false)]
      float MinY,
      
      [FriendlyName("Max Y", "Maximum allowable float value.")]
      [DefaultValue(2f), SocketState(false, false)]
      float MaxY,
      
      [FriendlyName("Min Z", "Minimum allowable float value.")]
      [DefaultValue(0.5f), SocketState(false, false)]
      float MinZ,
      
      [FriendlyName("Max Z", "Maximum allowable float value.")]
      [DefaultValue(2f), SocketState(false, false)]
      float MaxZ,
      
      [FriendlyName("Preserve X", "If checked, the existing value will be passed into the new scale, overriding the random value for that axis.")]
      [SocketState(false, false)]
      bool PreserveX_Axis,
      
      [FriendlyName("Preserve Y", "If checked, the existing value will be passed into the new scale, overriding the random value for that axis.")]
      [SocketState(false, false)]
      bool PreserveY_Axis,

      [FriendlyName("Preserve Z", "If checked, the existing value will be passed into the new scale, overriding the random value for that axis.")]
      [SocketState(false, false)]
      bool PreserveZ_Axis,
      
      [FriendlyName("Uniform", "Should the node scale the GameObject uniformly on all three axis. When set to true, only the Min and Max for X is used to determine the random scale range. Also, the Preserve(X/Y/Z) flags are ignored.")]
      [DefaultValue(true)]
      bool Uniform
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