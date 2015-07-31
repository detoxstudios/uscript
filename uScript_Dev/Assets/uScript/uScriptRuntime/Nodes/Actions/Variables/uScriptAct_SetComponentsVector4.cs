// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector4")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Vector4 to the defined X, Y, Z and W float component values.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Components (Vector4)", "Sets a Vector4 to the defined X, Y, Z and W float component values.")]
public class uScriptAct_SetComponentsVector4 : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("X", "X value to use for the Output Vector.")]
      float X,

      [FriendlyName("Y", "Y value to use for the Output Vector.")]
      float Y,

      [FriendlyName("Z", "Z value to use for the Output Vector.")]
      float Z,
      
      [FriendlyName("W", "W value to use for the Output Vector.")]
      float W,
      
      [FriendlyName("Output Vector4", "Vector4 variable built from the specified X, Y, Z, and W.")]
      out Vector4 OutputVector4
      )
   {
      OutputVector4 = new Vector4(X, Y, Z, W);
   }
}
