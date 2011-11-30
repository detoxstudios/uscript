// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the distance between two GameObjects as a float.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Distance")]

[FriendlyName("Get Distance", "Returns the distance between two GameObjects.")]
public class uScriptAct_GetDistance : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first GameObject.")]
      GameObject A,
      
      [FriendlyName("B", "The second GameObject.")]
      GameObject B,
      
      [FriendlyName("Distance", "The distance between GameObjects A and B.")]
      out float Distance
      )
   {
      if (A != null && B != null)
      {
         Distance = Vector3.Distance(A.transform.position, B.transform.position);
      }
      else
      {
         Distance = 0F;
      }
   }
}
