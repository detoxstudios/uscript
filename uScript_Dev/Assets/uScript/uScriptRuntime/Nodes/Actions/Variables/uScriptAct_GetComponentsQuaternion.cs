// uScript Action Node
// (C) 2013 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Quaternion")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Quaternion as floats.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Components (Quaternion)", "Gets the components of a Quaternion as floats.")]
public class uScriptAct_GetComponentsQuaternion : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
                  [FriendlyName("Input Vector4", "The input vector to get components of.")]
                  Quaternion InputQuaternion,

                  [FriendlyName("X", "The X value of the Input Quaternion.")]
                  out float X,

                  [FriendlyName("Y", "The Y value of the Input Quaternion.")]
                  out float Y,

                  [FriendlyName("Z", "The Z value of the Input Quaternion.")]
                  out float Z,

                  [FriendlyName("W", "The W value of the Input Quaternion.")]
                  out float W
                  )
   {
      X = InputQuaternion.x;
      Y = InputQuaternion.y;
      Z = InputQuaternion.z;
      W = InputQuaternion.w;
   }
}
