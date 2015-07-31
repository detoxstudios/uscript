// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Reflects the vector along the normal.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Reflect Vector3", "Reflects the vector along the normal. The returned value is the reflected direction from a surface with a normal.")]
public class uScriptAct_ReflectVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Vector3 to be reflected.")]
      Vector3 Target,

      [FriendlyName("Normal", "The Vector3 normal used for the reflection.")]
      Vector3 ReflectedNormal,
            
      [FriendlyName("Result", "The resulting reflected Vector3 normal.")]
      out Vector3 Result
      )
   {
      Result = Vector3.Reflect(Target, ReflectedNormal);
   }
}