// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the distance between two Vector3 locations as a float.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Vector3_Distance")]

[FriendlyName("Get Vector3 Distance", "Returns the distance between two Vector3 locations as a float.")]
public class uScriptAct_GetVector3Distance : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first Vector3.")]
      Vector3 A,
      
      [FriendlyName("B", "The second Vector3.")]
      Vector3 B,
      
      [FriendlyName("Distance", "The distance between the A and B vectors.")]
      out float Distance
      )
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