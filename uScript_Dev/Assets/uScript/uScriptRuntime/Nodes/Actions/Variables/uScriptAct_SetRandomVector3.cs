// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Randomly sets the value of a Vector3 variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Random Vector3", "Randomly sets the value of a Vector3 variable.")]
public class uScriptAct_SetRandomVector3 : uScriptLogic
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
      
      [FriendlyName("Min Z", "Minimum allowable float value for Z.")]
      [DefaultValue(0f), SocketState(false, false)]
      float MinZ,
      
      [FriendlyName("Max Z", "Maximum allowable float value for Z.")]
      [DefaultValue(1f), SocketState(false, false)]
      float MaxZ,
      
      [FriendlyName("Target Vector3", "The Vector3 variable that gets set.")]
      out Vector3 TargetVector3
      )
   {	
      float finalX = Random.Range(MinX, MaxX);
      float finalY = Random.Range(MinY, MaxY);
      float finalZ = Random.Range(MinZ, MaxZ);

      TargetVector3 = new Vector3(finalX, finalY, finalZ);
   }
}
