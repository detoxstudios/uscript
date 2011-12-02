// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector2")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Vector2 variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Random_Vector2")]

[FriendlyName("Set Random Vector2", "Randomly sets the value of a Vector2 variable.")]
public class uScriptAct_SetRandomVector2 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Min X", "Minimum allowable float value for X.")]
      [DefaultValue(0f), SocketState(false, false)]
      float MinX,
      
      [FriendlyName("Max X", "Maximum allowable float value for X.")]
      [DefaultValue(1f), SocketState(false, false)]
      float MaxX,
      
      [FriendlyName("Min Y", "Minimum allowable float value for Y.")]
      [DefaultValue(0f), SocketState(false, false)]
      float MinY,
      
      [FriendlyName("Max Y", "Maximum allowable float value for Y.")]
      [DefaultValue(1f), SocketState(false, false)]
      float MaxY,
      
      [FriendlyName("Target Vector2", "The Vector2 variable that gets set.")]
      out Vector3 TargetVector2
      )
   {
      // Make sure we don't have min > max (or other way around)
      if (MinX > MaxX) { MinX = MaxX; }
      if (MaxX < MinX) { MaxX = MinX; }
      if (MinY > MaxY) { MinY = MaxY; }
      if (MaxY < MinY) { MaxY = MinY; }

      float finalX = Random.Range(MinX, MaxX);
      float finalY = Random.Range(MinY, MaxY);

      TargetVector2 = new Vector2(finalX, finalY);
   }
}
