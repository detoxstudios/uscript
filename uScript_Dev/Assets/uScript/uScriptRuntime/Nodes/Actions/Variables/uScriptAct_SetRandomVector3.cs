// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Vector3 variable.")]
[NodeDescription("Randomly sets the value of a Vector3 variable.\n \nMin(X/Y/Z): Minimum allowable float value.\nMax(X/Y/Z): Maximum allowable float value.\nTarget Vector3 (out): The Vector3 variable that gets set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Random_Vector3")]

[FriendlyName("Set Random Vector3")]
public class uScriptAct_SetRandomVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Min X"), DefaultValue(0f), SocketState(false, false)] float MinX,
      [FriendlyName("Max X"), DefaultValue(1f), SocketState(false, false)] float MaxX,
      [FriendlyName("Min Y"), DefaultValue(0f), SocketState(false, false)] float MinY,
      [FriendlyName("Max Y"), DefaultValue(1f), SocketState(false, false)] float MaxY,
      [FriendlyName("Min Z"), DefaultValue(0f), SocketState(false, false)] float MinZ,
      [FriendlyName("Max Z"), DefaultValue(1f), SocketState(false, false)] float MaxZ,
      [FriendlyName("Target Vector3")] out Vector3 TargetVector3)
   {
      // Make sure we don't have min > max (or other way around)
      if (MinX > MaxX) { MinX = MaxX; }
      if (MaxX < MinX) { MaxX = MinX; }
      if (MinY > MaxY) { MinY = MaxY; }
      if (MaxY < MinY) { MaxY = MinY; }
      if (MinZ > MaxZ) { MinZ = MaxZ; }
      if (MaxZ < MinZ) { MaxZ = MinZ; }
		
      float finalX = Random.Range(MinX, MaxX);
      float finalY = Random.Range(MinY, MaxY);
      float finalZ = Random.Range(MinZ, MaxZ);

      TargetVector3 = new Vector3(finalX, finalY, finalZ);
   }
}