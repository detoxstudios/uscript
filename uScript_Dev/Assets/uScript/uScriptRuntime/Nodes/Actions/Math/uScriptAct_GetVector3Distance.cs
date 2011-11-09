// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the distance between two Vector3 locations as a float.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the distance between two Vector3 locations as a float.")]
[NodeDescription("Returns the distance between two Vector3 locations as a float.\n \nA: The first Vector3.\nB: The second Vector3.\nDistance (out): The distance between the A and B vectors.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Vector3_Distance")]

[FriendlyName("Get Vector3 Distance")]
public class uScriptAct_GetVector3Distance : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Vector3 A, Vector3 B, out float Distance)
   {
      if (A != Vector3.zero && B != Vector3.zero)
      {
         Distance = Vector3.Distance(A, B);
      }
      else
      {
         Distance = 0F;
      }
   }
}