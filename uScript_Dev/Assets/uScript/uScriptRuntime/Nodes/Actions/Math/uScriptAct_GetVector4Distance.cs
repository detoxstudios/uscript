// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Returns the distance between two Vector4 locations as a float.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the distance between two Vector4 locations as a float.")]
[NodeDescription("Returns the distance between two Vector4 locations as a float.\n \nA: The first Vector4.\nB: The second Vector4.\nDistance (out): The distance between the A and B vectors.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Vector4_Distance")]

[FriendlyName("Get Vector4 Distance")]
public class uScriptAct_GetVector4Distance : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(Vector4 A, Vector4 B, out float Distance)
   {
      if (A != Vector4.zero && B != Vector4.zero)
      {
         Distance = Vector4.Distance(A, B);
      }
      else
      {
         Distance = 0F;
      }
   }
}