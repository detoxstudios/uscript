// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Cross product of two Vector3 variables.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Cross (Vector3)", "Cross Product of two Vector3 variables." +
 "\n\n[ Cross(A,B) ]")]
public class uScriptAct_CrossVector3 : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("A", "The first variable.")]
      Vector3 A,

      [FriendlyName("B", "The second variable.")]
      Vector3 B,

      [FriendlyName("Result", "The resulting cross product.")]
      out Vector3 Result
      )
   {
      Result = Vector3.Cross(A, B);
   }
}