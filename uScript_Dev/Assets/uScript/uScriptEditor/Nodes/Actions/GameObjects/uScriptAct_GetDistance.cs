// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the distance between two GameObjects as a float.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the distance between two GameObjects as a float.")]
[NodeDescription("Returns the distance between two GameObjects as a float.\n \nA: The first GameObject.\nB: The second GameObject.\nDistance (out): The distance between GameObjects A and B.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Distance")]

[FriendlyName("Get Distance")]
public class uScriptAct_GetDistance : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject A, GameObject B, out float Distance)
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