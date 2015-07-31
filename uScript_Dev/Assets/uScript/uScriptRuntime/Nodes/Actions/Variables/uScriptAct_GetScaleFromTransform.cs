// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Transform")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Gets the scale of a Transform variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Scale From Transform", "Gets the scale of a Transform variable.")]
public class uScriptAct_GetScaleFromTransform : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
                  [FriendlyName("Target", "The Transform you wish to get the scale of.")]
                  Transform target,

                  [FriendlyName("Get Lossy", "Returns the lossy scale of the target Transform when checked (true). Useful to help get an accurate scale when the GameObject is the child of a parent and might have been rotated. See the Unity documentation for lossyScale for more information.")]
                  [SocketStateAttribute(false, false)]
                  bool getLossy,

                  [FriendlyName("Scale", "The Vector3 scale of the target Transform.")]
                  out Vector3 scale,

                  [FriendlyName("X", "The X axis scale of the target Transform.")]
                  [SocketStateAttribute(false, false)]
                  out float xScale,

                  [FriendlyName("Y", "The X axis scale of the target Transform.")]
                  [SocketStateAttribute(false, false)]
                  out float yScale,

                  [FriendlyName("Z", "The X axis scale of the target Transform.")]
                  [SocketStateAttribute(false, false)]
                  out float zScale
                  )
   {

      if (getLossy)
      {
         scale = target.lossyScale;
         xScale = target.lossyScale.x;
         yScale = target.lossyScale.y;
         zScale = target.lossyScale.z;
      }
      else
      {
         scale = target.localScale;
         xScale = target.localScale.x;
         yScale = target.localScale.y;
         zScale = target.localScale.z;
      }

   }
}
