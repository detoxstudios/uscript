// uScript Action Node
// (C) 2013 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Quaternion")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Sets a Quaternion to the defined X, Y, Z and W float component values.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Components (Quaternion)", "Sets a Quaternion to the defined X, Y, Z and W float component values.")]
public class uScriptAct_SetComponentsQuaternion : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("X", "X value to use for the Output Quaternion.")]
      float X,

      [FriendlyName("Y", "Y value to use for the Output Quaternion.")]
      float Y,

      [FriendlyName("Z", "Z value to use for the Output Quaternion.")]
      float Z,
      
      [FriendlyName("W", "W value to use for the Output Quaternion.")]
      float W,
      
      [FriendlyName("Output Quaternion", "Quaternion variable built from the specified X, Y, Z, and W.")]
      out Quaternion OutputQuaternion
      )
   {
      OutputQuaternion = new Quaternion(X, Y, Z, W);
   }
}
