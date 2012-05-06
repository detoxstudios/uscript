// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the distance between two Vector2 locations as a float.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Vector2_Distance")]

[FriendlyName("Get Vector2 Distance", "Returns the distance between two Vector2 locations as a float.")]
public class uScriptAct_GetVector2Distance : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first Vector2.")]
      Vector2 A,
      
      [FriendlyName("B", "The second Vector2.")]
      Vector2 B,
      
      [FriendlyName("Distance", "The distance between the A and B vectors.")]
      out float Distance
      )
   {
      if (A != Vector2.zero && B != Vector2.zero)
      {
         Distance = Vector2.Distance(A, B);
      }
      else
      {
         Distance = 0F;
      }
   }
}