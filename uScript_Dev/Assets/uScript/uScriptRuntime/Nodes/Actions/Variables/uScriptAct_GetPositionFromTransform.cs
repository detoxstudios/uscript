// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Transform")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Gets the Vector3 position of a Transform variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Position From Transform", "Gets the Vector3 position of a Transform variable.")]
public class uScriptAct_GetPositionFromTransform : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
                  [FriendlyName("Target", "The Transform you wish to get the position information of.")]
                  Transform target,

                  [FriendlyName("Get Local", "Returns the local position of the target Transform when checked (true).")]
                  [SocketStateAttribute(false, false)]
                  bool getLocal,

                  [FriendlyName("Position", "The Vector3 position of the target Transform.")]
                  out Vector3 position,

                  [FriendlyName("Forward", "The Vector3 forward of the target Transform.")]
                  [SocketStateAttribute(false, false)]
                  out Vector3 forward,

                  [FriendlyName("Right", "The Vector3 right of the target Transform.")]
                  [SocketStateAttribute(false, false)]
                  out Vector3 right,

                  [FriendlyName("Up", "The Vector3 up of the target Transform.")]
                  [SocketStateAttribute(false, false)]
                  out Vector3 up,

                  [FriendlyName("World Matrix", "Returns the target Transform's world position as a local 4x4 matrix (transforms a point from world space into local space).")]
                  [SocketStateAttribute(false, false)]
                  out Matrix4x4 worldMatrix
                  )
   {

      if (getLocal)
      {
         position = target.localPosition;
      }
      else
      {
         position = target.position;
      }

      forward = target.forward;
      right = target.right;
      up = target.up;
      worldMatrix = target.worldToLocalMatrix;

   }
}
