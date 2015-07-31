// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Vector3 to the defined X, Y, and Z float component values.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Components (Vector3)", "Sets a Vector3 to the defined X, Y, and Z float component values.")]
public class uScriptAct_SetComponentsVector3 : uScriptLogic
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
      
      [FriendlyName("Output Vector3", "Vector3 variable built from the specified X, Y, and Z.")]
      out Vector3 OutputVector3
      )
   {
      OutputVector3 = new Vector3(X, Y, Z);
   }
}
