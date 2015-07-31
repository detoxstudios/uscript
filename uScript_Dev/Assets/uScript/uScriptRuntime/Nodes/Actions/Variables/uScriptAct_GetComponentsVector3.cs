// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector3")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Vector3 as floats.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Get Components (Vector3)", "Gets the components of a Vector3 as floats.")]
public class uScriptAct_GetComponentsVector3 : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(
      [FriendlyName("Input Vector3", "The input vector to get components of.")]
      Vector3 InputVector3,
      
      [FriendlyName("X", "The X value of the Input Vector3.")]
      out float X,
      
      [FriendlyName("Y", "The Y value of the Input Vector3.")]
      out float Y,
      
      [FriendlyName("Z", "The Z value of the Input Vector3.")]
      out float Z
      )
   {
      X = InputVector3.x;
      Y = InputVector3.y;
      Z = InputVector3.z;
   }
}
