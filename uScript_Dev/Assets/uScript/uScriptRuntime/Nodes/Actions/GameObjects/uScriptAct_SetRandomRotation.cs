// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects/Movement")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the rotation of a GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random Rotation", "Randomly sets the rotation of a GameObject.")]
public class uScriptAct_SetRandomRotation : uScriptLogic
{
   public bool Out { get { return true; } }
	
   public void In(
      [FriendlyName("Target", "The GameObject(s) that the random rotation is applied to."), AutoLinkType(typeof(GameObject))]
      GameObject[] Target,

      [FriendlyName("Min Angle X", "Minimum allowable angle. (0-360 degrees)")]
      [DefaultValue(0f), SocketState(false, false)]
      float MinX,
      
      [FriendlyName("Max Angle X", "Maximum allowable angle. (0-360 degrees)")]
      [DefaultValue(360f), SocketState(false, false)]
      float MaxX,
      
      [FriendlyName("Min Angle Y", "Minimum allowable angle. (0-360 degrees)")]
      [DefaultValue(0f), SocketState(false, false)]
      float MinY,
      
      [FriendlyName("Max Angle Y", "Maximum allowable angle. (0-360 degrees)")]
      [DefaultValue(360f), SocketState(false, false)]
      float MaxY,
      
      [FriendlyName("Min Angle Z", "Minimum allowable angle. (0-360 degrees)")]
      [DefaultValue(0f), SocketState(false, false)]
      float MinZ,
      
      [FriendlyName("Max Angle Z", "Maximum allowable angle. (0-360 degrees)")]
      [DefaultValue(360f), SocketState(false, false)]
      float MaxZ,

      [FriendlyName("Preserve X", "If checked, the existing value will be passed into the new rotation, overriding the random value for this axis.")]
      [SocketState(false, false)]
      bool PreserveX_Axis,

      [FriendlyName("Preserve Y", "If checked, the existing value will be passed into the new rotation, overriding the random value for this axis.")]
      [SocketState(false, false)]
      bool PreserveY_Axis,
      
      [FriendlyName("Preserve Z", "If checked, the existing value will be passed into the new rotation, overriding the random value for this axis.")]
      [SocketState(false, false)]
      bool PreserveZ_Axis
      )
   {
		
	  // Make sure we don't have min > max (or other way around)
      if (MinX > MaxX) { MinX = MaxX; }
      if (MaxX < MinX) { MaxX = MinX; }
      if (MinY > MaxY) { MinY = MaxY; }
      if (MaxY < MinY) { MaxY = MinY; }
      if (MinZ > MaxZ) { MinZ = MaxZ; }
      if (MaxZ < MinZ) { MaxZ = MinZ; }
		
	  if (MinX < 0) { MinX = 0; }
	  if (MaxX > 360) { MaxX = 360; }
	  if (MinY < 0) { MinY = 0; }
	  if (MaxY > 360) { MaxY = 360; }
      if (MinZ < 0) { MinZ = 0; }
	  if (MaxZ > 360) { MaxZ = 360; }

      

      foreach (GameObject currentTarget in Target)
      {
			
		 float finalX;
	     float finalY;
	     float finalZ;
			
	     if (PreserveX_Axis)
		 {
				finalX = currentTarget.transform.eulerAngles.x;
		 }
		 else
		 {
				finalX = Random.Range(MinX, MaxX);
		 }
		 
		 if (PreserveY_Axis)
		 {
				finalY = currentTarget.transform.eulerAngles.y;
		 }
		 else
		 {
				finalY = Random.Range(MinY, MaxY);
		 }
			
		 if (PreserveZ_Axis)
		 {
				finalZ = currentTarget.transform.eulerAngles.z;
		 }
		 else
		 {
				finalZ = Random.Range(MinZ, MaxZ);
		 }
			
		 Vector3 rotationVector = new Vector3(finalX, finalY, finalZ);

         currentTarget.transform.eulerAngles = rotationVector;

      }
   }
	
}