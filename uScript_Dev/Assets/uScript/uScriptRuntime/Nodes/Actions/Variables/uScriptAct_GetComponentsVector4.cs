// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector4")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Vector4 as floats.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Components (Vector4)", "Gets the components of a Vector4 as floats.")]
public class uScriptAct_GetComponentsVector4 : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
                  [FriendlyName("Input Vector4", "The input vector to get components of.")]
                  Vector4 InputVector4,

                  [FriendlyName("X", "The X value of the Input Vector4.")]
                  out float X,

                  [FriendlyName("Y", "The Y value of the Input Vector4.")]
                  out float Y,

                  [FriendlyName("Z", "The Z value of the Input Vector4.")]
                  out float Z,

                  [FriendlyName("W", "The W value of the Input Vector4.")]
                  out float W
                  )
   {
      X = InputVector4.x;
      Y = InputVector4.y;
      Z = InputVector4.z;
      W = InputVector4.w;
   }
}
