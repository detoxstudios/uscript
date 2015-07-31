// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Returns the distance between two Vector4 locations as a float.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Vector4 Distance", "Returns the distance between two Vector4 locations as a float.")]
public class uScriptAct_GetVector4Distance : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first Vector4.")]
      Vector4 A,

      [FriendlyName("B", "The second Vector4.")]
      Vector4 B,

      [FriendlyName("Distance", "The distance between the A and B vectors.")]
      out float Distance
      )
   {
      if (A != Vector4.zero || B != Vector4.zero)
      {
         Distance = Vector4.Distance(A, B);
      }
      else
      {
         Distance = 0F;
      }
   }
}