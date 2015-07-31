// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the scale of a GameObject as both a Vector3 and X, Y and Z float variables.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Scale", "Gets the scale of a GameObject as both a Vector3 and X, Y and Z float variables.")]
public class uScriptAct_GetGameObjectScale : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "The Target GameObject you wish to get the scale of.")]
      GameObject Target,
      
      [FriendlyName("Scale", "Returns the scale as a Vector3(X, Y, Z).")]
      out Vector3 Scale,
      
      [FriendlyName("X", "Returns the X axis scale as a float.")]
      out float X,
      
      [FriendlyName("Y", "Returns the Y axis scale as a float.")]
      out float Y,

      [FriendlyName("Z", "Returns the Z axis scale as a float.")]
      out float Z
      )
   {

      if ( Target != null )
      {
         Scale = Target.transform.localScale;
         X = Target.transform.localScale.x;
         Y = Target.transform.localScale.y;
         Z = Target.transform.localScale.z;
      }
      else
      {
         Scale = Vector3.zero;
         X = 0f;
         Y = 0f;
         Z = 0f;
      }

   }
}
