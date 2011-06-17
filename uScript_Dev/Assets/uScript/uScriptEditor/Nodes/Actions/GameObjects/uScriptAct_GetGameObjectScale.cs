// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Gets the scale of a GameObject as both a Vector3 and X, Y and Z float variables.

using UnityEngine;
using System.Collections;

[NodePath("Actions/GameObjects")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the scale of a GameObject as both a Vector3 and X, Y and Z float variables.")]
[NodeDescription("Gets the scale of a GameObject as both a Vector3 and X, Y and Z float variables.\n \nTarget: The Target GameObject you wish to get the scale of.\nScale: Returns the scale as a Vector3(X, Y, Z).\nX: Returns the X axis scale as a float.\nY: Returns the Y axis scale as a float.\nZ: Returns the Z axis scale as a float.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://uscript.net/manual/node_nodoc.html")]

[FriendlyName("Get Scale")]
public class uScriptAct_GetGameObjectScale : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(GameObject Target, out Vector3 Scale, out float X, out float Y, out float Z)
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
