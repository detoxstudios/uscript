// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Transform")]

[NodeCopyright("Copyright 2012 by Detox Studios LLC")]
[NodeToolTip("Gets the rotation information of a Transform variable.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Rotation From Transform", "Gets the rotation information of a Transform variable.")]
public class uScriptAct_GetRotationFromTransform : uScriptLogic
{

   public bool Out { get { return true; } }

   public void In(
                  [FriendlyName("Target", "The Transform you wish to get the rotation information of.")]
                  Transform target,

                  [FriendlyName("Get Local", "Returns the local rotation of the target Transform when checked (true).")]
                  [SocketStateAttribute(false, false)]
                  bool getLocal,

                  [FriendlyName("Rotation", "The Quaternion rotation value of the target Transform.")]
                  out Quaternion rotation,

                  [FriendlyName("Euler Angles", "The Vector3 rotation in Euler Angles of the target Transform.")]
                  [SocketStateAttribute(false, false)]
                  out Vector3 eulerAngle
                  )
   {

      if (getLocal)
      {
         rotation = target.localRotation;
         eulerAngle = target.localEulerAngles;
      }
      else
      {
         rotation = target.rotation;
         eulerAngle = target.eulerAngles;
      }

      
   }
}
