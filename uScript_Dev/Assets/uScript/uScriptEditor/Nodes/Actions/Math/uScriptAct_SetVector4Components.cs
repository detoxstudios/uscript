// uScript Action Node
// (C) 2010 Detox Studios LLC
// Desc: Sets a Vector4 to the defined X, Y, Z and W float component values.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Set Variable")]
[NodeLicense("http://www.detoxstudios.com/legal/eula.html")]
[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Sets a Vector4 to the defined X, Y, Z and W float component values.")]
[NodeDescription("Sets a Vector4 to the defined X, Y, Z and W float component values.\n \nX: X value to use for the Output Vector.\nY: Y value to use for the Output Vector.\nZ: Z value to use for the Output Vector.\nW: W value to use for the Output Vector.\nOutput Vector4 (out): Vector4 variable built from the specified X, Y, Z, and W.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Set_Vector4_Components")]

[FriendlyName("Set Vector4 Components")]
public class uScriptAct_SetVector4Components : uScriptLogic
{
   // How many outputs defined here
   public bool Out { get { return true; } }

   // Do logic here
   public void In(float X, float Y, float Z, float W, [FriendlyName("Output Vector4")] out Vector4 OutputVector4)
   {
      OutputVector4 = new Vector4(X, Y, Z, W);
   }
}