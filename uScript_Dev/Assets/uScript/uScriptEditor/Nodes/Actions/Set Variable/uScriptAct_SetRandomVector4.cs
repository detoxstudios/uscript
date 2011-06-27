// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Randomly sets the value of a Vector4 variable. Min/Max ovverrides allow you to set the range of the random number.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Vector4 variable.")]
[NodeDescription("Randomly sets the value of a Vector4 variable.\n \nMin(X/Y/Z/W): Minimum allowable float value.\nMax(X/Y/Z/W): Maximum allowable float value.\nSeed: Seed value for the random number generator.\nTarget Vector4 (out): The Vector4 variable that gets set.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Set Random Vector4")]
public class uScriptAct_SetRandomVector4 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Min X"), DefaultValue(0f)] float MinX,
      [FriendlyName("Max X"), DefaultValue(1f)] float MaxX,
      [FriendlyName("Min Y"), DefaultValue(0f)] float MinY,
      [FriendlyName("Max Y"), DefaultValue(1f)] float MaxY,
      [FriendlyName("Min Z"), DefaultValue(0f)] float MinZ,
      [FriendlyName("Max Z"), DefaultValue(1f)] float MaxZ,
      [FriendlyName("Min Z"), DefaultValue(0f)] float MinW,
      [FriendlyName("Max Z"), DefaultValue(1f)] float MaxW,
      [FriendlyName("Seed"), DefaultValue(0), SocketState(false, false)] int Seed,
      [FriendlyName("Target Vector4")] out Vector4 TargetVector4)
   {
      // Make sure we don't have min > max (or other way around)
      if (MinX > MaxX) { MinX = MaxX; }
      if (MaxX < MinX) { MaxX = MinX; }
      if (MinY > MaxY) { MinY = MaxY; }
      if (MaxY < MinY) { MaxY = MinY; }
      if (MinZ > MaxZ) { MinZ = MaxZ; }
      if (MaxZ < MinZ) { MaxZ = MinZ; }
      if (MinW > MaxW) { MinW = MaxW; }
      if (MaxW < MinW) { MaxW = MinW; }

      if (Seed > 0) { Random.seed = Seed; }

      float finalX = Random.Range(MinX, MaxX);
      float finalY = Random.Range(MinY, MaxY);
      float finalZ = Random.Range(MinZ, MaxZ);
      float finalW = Random.Range(MinW, MaxW);

      TargetVector4 = new Vector4(finalX, finalY, finalZ, finalW);
   }
}