// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the distance between two Vector2 locations as a float.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the distance between two Vector2 locations as a float.")]
[NodeDescription("Returns the distance between two Vector2 locations as a float.\n \nA: The first Vector2.\nB: The second Vector2.\nDistance (out): The distance between the A and B vectors.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Vector2_Distance")]

[FriendlyName("Get Vector2 Distance")]
public class uScriptAct_GetVector2Distance : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Vector2 A, Vector2 B, out float Distance)
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