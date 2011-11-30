// uScript Action Node
// (C) 2010 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Vector4")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the components of a Vector4 as floats.")]
[NodeDescription("Gets the components of a Vector4 as floats.\n \n\n \nInput Vector4: The input vector to get components of.\nX: The x value of the Input Vector4.\nY: The y value of the Input Vector4.\nZ: The z value of the Input Vector4.\nW: The w value of the Input Vector4.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Vector4_Components")]

[FriendlyName("Get Components (Vector4)")]
public class uScriptAct_GetComponentsVector4 : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In([FriendlyName("Input Vector4")] Vector4 InputVector4, out float X, out float Y, out float Z, out float W)
   {
      X = InputVector4.x;
      Y = InputVector4.y;
      Z = InputVector4.z;
      W = InputVector4.w;
   }
}